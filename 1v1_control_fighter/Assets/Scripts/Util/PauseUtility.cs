using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PauseUtility
{
    public static bool IsPaused()
    {
        return Time.timeScale == 0;
    }

    public static void Pause()
    {
        Time.timeScale = 0;
    }

    public static void Unpause()
    {
        Time.timeScale = 1;
    }

    public static void TogglePause()
    {
        Time.timeScale = IsPaused() ? 1 : 0;
    }
}
