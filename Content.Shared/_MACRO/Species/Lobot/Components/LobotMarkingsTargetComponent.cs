using Robust.Shared.GameStates;

namespace Content.Shared._MACRO.Species.Lobot.Components;


/// <summary>
/// Handles lobot markings being applied to a chassis upon entry. Separate from LobotBrainContainer just in case there's a lobot brain target that cant have markings
/// </summary>

[RegisterComponent, NetworkedComponent]
public sealed partial class LobotMarkingTargetComponent : Component
{
    [DataField]
    public LobotBrainContainerComponent? BrainContainer; // Reference to the LobotBrainContainerComponent for easy usage
}
