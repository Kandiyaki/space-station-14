using Content.Shared._MACRO.Species.Lobot.Components;
using Content.Shared.Actions;

namespace Content.Shared._MACRO.Species.Lobot;
/// <summary>
/// Handles adding the ejection action to lobot chassis (or other lobot-boardable stuff i guess)
/// </summary>
public sealed partial class SharedLobotBrainRemoveSystem : EntitySystem
{
    [Dependency] private SharedActionsSystem _actionsSystem = default!;

    [SubscribeLocalEvent]
    private void OnStartup(Entity<LobotBrainRemoveComponent> ent, ref ComponentStartup args)
    {
        _actionsSystem.AddAction(ent, ref ent.Comp.RemoveAction, ent.Comp.RemoveActionId);
    }

    [SubscribeLocalEvent]
    private void OnShutdown(Entity<LobotBrainRemoveComponent> ent, ref ComponentShutdown args)
    {
        _actionsSystem.RemoveAction(ent.Owner, ent.Comp.RemoveAction);
    }

}

/// <summary>
///   
/// </summary>
public sealed partial class LobotBrainRemoveEvent : InstantActionEvent;
