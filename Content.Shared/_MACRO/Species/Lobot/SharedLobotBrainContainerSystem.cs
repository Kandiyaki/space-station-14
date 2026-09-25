using Content.Shared._MACRO.Species.Lobot.Components;
using Content.Shared.Actions;
using Content.Shared.Body;

namespace Content.Shared._MACRO.Species.Lobot;
/// <summary>
/// Handles inserting and removing lobot brains from chassis
/// </summary>
public abstract partial class SharedLobotBrainContainerSystem : EntitySystem
{
    [Dependency] private BodySystem _body = default!;

    [SubscribeLocalEvent]
    private void OnStartup(Entity<LobotBrainContainerComponent> ent, ref ComponentStartup args)
    {
        var bodyEnt = WithCompOrNull<BodyComponent>(ent.Owner);
        if (bodyEnt is not null)//the container has a body, so we can check its organs
        {
            _body.RelayEvent<LobotBrainContainerStartupEvent>(bodyEnt.Value, new LobotBrainContainerStartupEvent()); //this is caught by LobotBrainSystem and assigns the brain to the comp's container if exists
        }
        else //for a theoretical chassis without a body component (like, slotting a brain into a control console)
        {

        }


    }

    [SubscribeLocalEvent]
    private void OnShutdown(Entity<LobotBrainContainerComponent> ent, ref ComponentShutdown args)
    {

    }
}

public sealed partial class LobotBrainContainerStartupEvent : EntityEventArgs {Entity<LobotBrainContainerComponent> _entity};
