using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncSceneLoader : MonoBehaviour
{
    [SerializeField]
    Canvas loadingUI;
    [SerializeField]
    Image imageBackground, imageForeground;
    [SerializeField]
    float fadeTime = 1.0f;
    [SerializeField]
    float sceneLoadCheckInterval = 1.0f;

    IEnumerator runningScene;
    Action<string> errorHandleEvent;

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
        runningScene = _SceneLoad<int>(index);
        StartCoroutine(runningScene);
        errorHandleEvent = _errorHandleEvent;
    }
    public void SceneLoad(string name, Action<string> _errorHandleEvent)
    {
        runningScene = _SceneLoad<string>(name);
        StartCoroutine(runningScene);
        errorHandleEvent = _errorHandleEvent;
    }

    IEnumerator _SceneLoad<T>(T index)
    {
        WaitForSeconds yieldTime = new WaitForSeconds(fadeTime);

        // Fade in
        Color fadeColor = imageBackground.color;
        fadeColor.a = 0;
        imageForeground.CrossFadeColor(fadeColor, fadeTime, false, true);
        yield return yieldTime;

        // Load Scene
        AsyncOperation loadingScene = null;

        if (typeof(T).Equals(typeof(Int32)))
        {
            SceneManager.LoadSceneAsync((int)(object)index.ToString());
        }
        else if(typeof(T).Equals(typeof(string)))
        {
            SceneManager.LoadSceneAsync(index.ToString());
        }
        else
        {
            // Load fail
            Error("Can't find scene");
            imageBackground.color = fadeColor;
            yield return null;
        }

        loadingScene.allowSceneActivation = false;

        yieldTime = new WaitForSeconds(sceneLoadCheckInterval);
        while (loadingScene.isDone)
        {
            yield return yieldTime;
        }

        // Loading complete
        loadingScene.allowSceneActivation = true;

        // Fade out
        fadeColor = imageBackground.color;
        fadeColor.a = 1;
        imageForeground.CrossFadeColor(fadeColor, fadeTime, false, true);
        yieldTime = new WaitForSeconds(fadeTime);
        yield return yieldTime;
    }

    public void Error(string err)
    {
        StopCoroutine(runningScene);
        runningScene = null;
        errorHandleEvent.Invoke(err);
    }
}
