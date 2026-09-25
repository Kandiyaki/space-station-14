using Content.Shared._MACRO.Species.Lobot;
using Content.Shared._MACRO.Species.Lobot.Components;

namespace Content.Server._MACRO.Species.Lobot;
/// <summary>
/// Handles special logic for lobot brains, such as pausing stuff when inside a chassis?
/// component mostly exists as a marker tbh
/// </summary>
public sealed partial class LobotBrainSystem : SharedLobotBrainSystem
{
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<LobotBrainComponent, LobotBrainContainerStartupEvent>(OnLobotBrainContainerStartup);
    }

    public void OnLobotBrainContainerStartup(Entity<LobotBrainComponent> ent, ref LobotBrainContainerStartupEvent args)
    {
        //add this lobot brain to the container's... container
        
    }
}
