using Robust.Shared.GameStates;

namespace Content.Shared._MACRO.Species.Lobot.Components;

/// <summary>
/// Keeps track of the Lobot brain and its information while the brain is in the chassis
/// Also marks an object as capable of brain takeover
/// </summary>

[RegisterComponent, NetworkedComponent]
public sealed partial class LobotBrainContainerComponent : Component
{
    /// <summary>
    /// The brain currently inside and controlling the chassis. Null if no brain is present.
    /// </summary>
    [DataField]
    public EntityUid? CurrentBrain;
}
