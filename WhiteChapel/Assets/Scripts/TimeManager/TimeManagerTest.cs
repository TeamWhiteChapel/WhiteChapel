using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManagerTest : MonoBehaviour
{
    public void Pause()
    {
        if (TimeManager.Paused)
        {
            TimeManager.Paused = false;
        }
        else
        {
            TimeManager.Paused = true;
        }
    }
}
