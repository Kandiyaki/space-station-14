using Robust.Shared.GameStates;

namespace Content.Shared._MACRO.Species.Lobot.Components;

/// <summary>
/// 
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class LobotBrainBoardComponent : Component
{
    /// <summary>
    /// The action entity itself.
    /// </summary>
    [DataField]
    public EntityUid? BoardAction;

    /// <summary>
    /// The action's ID.
    /// </summary>
    [DataField]
    public string? BoardActionId = "ActionLobotBrainBoard";
}
