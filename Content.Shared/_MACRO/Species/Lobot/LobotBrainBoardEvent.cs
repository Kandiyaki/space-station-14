using Robust.Shared.Serialization;

namespace Content.Shared._MACRO.Species.Lobot;

/// <summary>
///    
/// </summary>
public sealed class LobotBrainBoardEvent : EntityEventArgs
{
    public EntityUid Target;
    public EntityUid Brain;

    public LobotBrainBoardEvent(EntityUid target, EntityUid brain)
    {
        Target = target;
        Brain = brain;
    }
}
