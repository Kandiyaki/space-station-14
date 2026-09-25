

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
        _body.TryGetOrgansWithComponent<LobotBrainComponent>(ent.Owner, out var brains);

    }

    [SubscribeLocalEvent]
    private void OnShutdown(Entity<LobotBrainContainerComponent> ent, ref ComponentShutdown args)
    {

    }
}
