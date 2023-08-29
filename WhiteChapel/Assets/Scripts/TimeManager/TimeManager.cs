using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private static TimeManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private readonly DateTime startDate = Convert.ToDateTime("1885-11-11 06:00:00");

    private readonly float timeTick = 1.0f;

    private static DateTime _gameDate;

    private static float _rawTime;

    private static bool _paused;

    public static DateTime GameDate
    {
        get
        {
            return _gameDate;
        }
    }

    public static float RawTime
    {
        get
        {
            return _rawTime;
        }
    }

    public static bool Paused
    {
        get
        {
            return _paused;
        }
        set
        {
            _paused = value;
        }
    }

    void Start()
    {
        Paused = false;        
    }

    void Update()
    {

    }
    public static void ResetTime(float savedTime)
    {
        Paused = false;

        TimeSpan pointTime = TimeSpan.FromSeconds(savedTime);
        _gameDate = Instance.startDate.Add(pointTime);
        _rawTime = (float)pointTime.TotalSeconds;

        Instance.gameTime = Instance.GameTime();

        Instance.StartCoroutine(Instance.gameTime);
    }

    private IEnumerator gameTime;

    IEnumerator GameTime()
    {       
        while (true)
        {
           
            if (!_paused)
            {
                yield return new WaitForSeconds(timeTick);

                _gameDate = startDate.AddSeconds((Time.time + _rawTime) * 24.0f);
            }
            else
            {
                yield return null;
            }
        }
    }

    public void Pause()
    {
        if (_paused)
        {
            _paused = false;
            Instance.StartCoroutine(gameTime);
        }
        else
        {
            _paused = true;
            Instance.StopCoroutine(gameTime);
        }
    }
}
