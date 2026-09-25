using Robust.Shared.GameStates;

namespace Content.Shared._MACRO.Species.Lobot.Components;

/// <summary>
/// Marks an entity as capable of entering a lobot chassis, as well as holding the character's visual and identity data
/// </summary>

[RegisterComponent, NetworkedComponent]
public sealed partial class LobotBrainComponent : Component
{
    public bool IsInChassis = false;
}
