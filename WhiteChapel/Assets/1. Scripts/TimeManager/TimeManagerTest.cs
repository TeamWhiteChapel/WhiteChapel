using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManagerTest : MonoBehaviour
{
    public TMP_Text text1;
    public DateTime test;

    private void Start()
    {
        TimeManager.ResetTime(0);
    }
    private void Update()
    {    
        text1.text = TimeManager.GameDate.ToString("yyyy-MM-dd HH:mm:ss");
    }
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
