using Content.Shared._MACRO.Species.Lobot.Components;
using Content.Shared.Actions;

namespace Content.Shared._MACRO.Species.Lobot;
/// <summary>
/// Handles adding the boarding action to lobot brains 
/// </summary>
public sealed partial class SharedLobotBrainBoardSystem : EntitySystem
{
    [Dependency] private SharedActionsSystem _actionsSystem = default!;

    [SubscribeLocalEvent]
    private void OnStartup(Entity<LobotBrainBoardComponent> ent, ref ComponentStartup args)
    {
        _actionsSystem.AddAction(ent, ref ent.Comp.BoardAction, ent.Comp.BoardActionId);
    }

    [SubscribeLocalEvent]
    private void OnShutdown(Entity<LobotBrainBoardComponent> ent, ref ComponentShutdown args)
    {
        _actionsSystem.RemoveAction(ent.Owner, ent.Comp.BoardAction);
    }

}

/// <summary>
///    
/// </summary>
public sealed partial class LobotBrainBoardEvent : EntityTargetActionEvent;
