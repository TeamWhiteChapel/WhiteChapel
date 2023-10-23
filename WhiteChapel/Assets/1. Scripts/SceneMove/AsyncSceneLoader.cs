using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncSceneLoader : MonoBehaviour
{
    [Header("Core")]
    [SerializeField]
    Canvas loadingUI;
    [SerializeField]
    Image imageBackground;
    [SerializeField]
    float sceneLoadCheckInterval = 1.0f;
    [SerializeField]
    FadeUI fadeUI;

    [Header("Skin")]
    [SerializeField]
    FadeData fadeIn;
    [SerializeField]
    FadeData fadeOut;


    IEnumerator runningScene;
    Action<string> errorHandleEvent;
    WaitForSeconds sceneCheckTime;

    private void Awake()
    {
        sceneCheckTime = new WaitForSeconds(sceneLoadCheckInterval);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneLoad(int index, Action<string> _errorHandleEvent)
    {
        fadeUI.FadeStart(new Action(OnSceneLoadingStart), fadeIn);
        runningScene = _SceneLoadOnce<int>(index);
        errorHandleEvent = _errorHandleEvent;
    }
    public void SceneLoad(string name, Action<string> _errorHandleEvent)
    {
        fadeUI.FadeStart(new Action(OnSceneLoadingStart), fadeIn);
        runningScene = _SceneLoadOnce<string>(name);
        errorHandleEvent = _errorHandleEvent;
    }

    private void OnSceneLoadingStart()
    {
        StartCoroutine(runningScene);
    }

    // Fade in > Open loading ui > Fade out > Load > Fade in > Fade out
    private IEnumerator _SceneLoadOnce<T>(T index)
    {
        // Load Scene
        AsyncOperation loadingScene = null;

        string errors = "";
        try
        {
            if (typeof(T).Equals(typeof(Int32)))
            {
                SceneManager.LoadSceneAsync((int)(object)index.ToString());
            }
            else if (typeof(T).Equals(typeof(string)))
            {
                SceneManager.LoadSceneAsync(index.ToString());
            }
            else
            {
                throw new Exception("Can't find scene!");
            }
        }
        catch(Exception e)
        {
            errors = e.Message;
        }

        // Load fail
        if(errors != "")
        {
            Error(errors);
            yield return null;
        }

        loadingScene.allowSceneActivation = false;

        while (loadingScene.isDone)
        {
            yield return sceneCheckTime;
        }

        // Loading complete
        loadingScene.allowSceneActivation = true;
    }

    private void _SceneLoad()
    {

    }

    private void OnSceneLoadComplete() 
    { 

    }

    public void Error(string err)
    {
        StopCoroutine(runningScene);
        runningScene = null;
        errorHandleEvent.Invoke(err);
    }
}
