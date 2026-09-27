using Content.Shared._MACRO.Species.Lobot.Components;
using Content.Shared.Body;
using Content.Shared.Body.Components;
using Robust.Shared.Containers;

namespace Content.Shared._MACRO.Species.Lobot;
/// <summary>
/// Handles inserting and removing lobot brains from chassis
/// </summary>
public abstract partial class SharedLobotBrainContainerSystem : EntitySystem
{
    [Dependency] private BodySystem _body = default!;
    [Dependency] private SharedContainerSystem _container = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<LobotBrainContainerComponent, LobotBrainBoardEvent>(OnBoarded);
        SubscribeLocalEvent<LobotBrainContainerComponent, LobotBrainRemoveActionEvent>(OnExited);
        SubscribeLocalEvent<BodyComponent, LobotBrainContainerStartupEvent>(_body.RelayEvent);

    }

    [SubscribeLocalEvent]
    public void OnStartup(Entity<LobotBrainContainerComponent> ent, ref ComponentStartup args)
    {

        var bodyEnt = WithCompOrNull<BodyComponent>(ent);
        if (bodyEnt is not null)//the container has a body, so we can check its organs
        {
            //this is caught by LobotBrainSystem and assigns the brain to the comp's container if empty
            Log.Debug(message: $"LobotBrainContainer {ToPrettyString(ent)} with a {nameof(InitialBodyComponent)} is starting up, relaying {nameof(LobotBrainContainerStartupEvent)} to body.");
            var ev = new LobotBrainContainerStartupEvent();
            RaiseLocalEvent(bodyEnt.Value, ev);
        }
        else //for a theoretical chassis without a body component (like, slotting a brain into a control console)
        {
            Log.Error($"Entity {ToPrettyString(ent)} with a {nameof(InitialBodyComponent)} is missing a container ({BodyComponent.ContainerID}).");
        }
    }

    public void OnBoarded(Entity<LobotBrainContainerComponent> ent, ref LobotBrainBoardEvent args)
    {
        Log.Debug(message: $"OnBoarded recieved BoardEvent with brain: {args.Brain}");
        if (ent.Comp.CurrentBrain != null)
        {
            //there's already a brain in this container, so we can't insert another
            return;
        }

        //CURRENT ISSUE: SOMETHING SOMETHING NETID VS UID AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
        var brain = args.Brain;
        Log.Debug(message: $"set OnBoarded brain to: {ToPrettyString(brain)}");


        SetCurrentBrain(ent, brain);

        var bodyEnt = WithCompOrNull<BodyComponent>(ent);
        if (bodyEnt is not null)//the container has a body, so we can change its organs
        {
            if (!_container.TryGetContainer(ent, BodyComponent.ContainerID, out var container))
            {
                Log.Error($"Entity {ToPrettyString(ent)} with a {nameof(InitialBodyComponent)} is missing a container ({BodyComponent.ContainerID}).");
                return;
            }

            var xform = Transform(ent);

            _container.Insert(brain, container, containerXform: xform);

        }
        else //for a theoretical chassis without a body component (like, slotting a brain into a control console)
        {

        }

    }

    public void OnExited(Entity<LobotBrainContainerComponent> ent, ref LobotBrainRemoveActionEvent args)
    {
        var brain = ent.Comp.CurrentBrain;
        var body = args.Performer;

        if (!brain.HasValue) //how'd you do that
        {
            return;
        }

        var bodyEnt = WithCompOrNull<BodyComponent>(ent);
        if (bodyEnt is not null)//the container has a body, so we can change its organs
        {
            if (!_container.TryGetContainer(ent, BodyComponent.ContainerID, out var container))
            {
                Log.Error($"Entity {ToPrettyString(ent)} with a {nameof(InitialBodyComponent)} is missing a container ({BodyComponent.ContainerID}).");
                return;
            }

            var xform = Transform(ent);
            _container.Remove(brain.Value, container);
        }
        else //for a theoretical chassis without a body component (like, slotting a brain into a control console)
        {

        }

    }

    public void SetCurrentBrain(Entity<LobotBrainContainerComponent> ent, EntityUid? brain)
    {
        ent.Comp.CurrentBrain = brain;
    }
}

//public sealed partial class LobotBrainContainerStartupEvent : EntityEventArgs
//{
//    public Entity<LobotBrainContainerComponent> ContainerEnt { get; }

//    public LobotBrainContainerStartupEvent(Entity<LobotBrainContainerComponent> entity)
//    {
//        ContainerEnt = entity;
//    }

//}

public record struct LobotBrainContainerStartupEvent(Entity<LobotBrainContainerComponent>? Container = null);
