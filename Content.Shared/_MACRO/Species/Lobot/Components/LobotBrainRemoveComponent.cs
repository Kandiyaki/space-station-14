using Robust.Shared.GameStates;

namespace Content.Shared._MACRO.Species.Lobot.Components;

/// <summary>
/// 
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class LobotBrainRemoveComponent : Component
{
    /// <summary>
    /// The action entity itself.
    /// </summary>
    [DataField]
    public EntityUid? RemoveAction;

    /// <summary>
    /// The action's ID.
    /// </summary>
    [DataField]
    public string? RemoveActionId = "ActionLobotBrainRemove";
}
