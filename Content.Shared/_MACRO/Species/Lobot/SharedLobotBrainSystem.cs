using Content.Shared._MACRO.Species.Lobot.Components;
using Content.Shared.Body;
using Content.Shared.Actions;


namespace Content.Shared._MACRO.Species.Lobot;
/// <summary>
/// Handles special logic for lobot brains, such as pausing stuff when inside a chassis?
/// component mostly exists as a marker tbh
/// </summary>
public abstract partial class SharedLobotBrainSystem : EntitySystem
{
    [Dependency] private BodySystem _body = default!;
    [Dependency] private SharedLobotBrainContainerSystem _brainContainer = default!;

    public override void Initialize()
    {
        base.Initialize();
        Log.Debug(message: "Initializing LobotBrain");
        //SubscribeLocalEvent<BodyComponent, LobotBrainContainerStartupEvent>(_body.RelayEvent);
    }

    [SubscribeLocalEvent]
    public void OnLobotBrainContainerStartup(Entity<LobotBrainComponent> ent, ref BodyRelayedEvent<LobotBrainContainerStartupEvent> args)
    {
        //add this lobot brain to the container's... container
        //since this is run by the brain, it doesn't happen if we spawn a brainless chassis
        Log.Debug(message: "adding LobotBrain to container");
        var ev = new LobotBrainBoardEvent(args.Body.Owner, ent);
        RaiseLocalEvent(args.Body.Owner, ev);
        Log.Debug(message: $"BoardEvent performer: {ev.Brain}");
    }
}
