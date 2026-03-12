using UnityEngine;
using System.Collections;

public static class MessageSystem
{
    /// <summary>
    /// message event for win Scenario
    /// </summary>
    public delegate void WinScenarioHandler();
    public static event WinScenarioHandler onWinScenario;

    public static void BroadcastWinScenario()
    {
        if (onWinScenario == null)
            return;

        onWinScenario();
    }
}
