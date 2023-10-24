using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using JetBrains.Annotations;
using Unity.VisualScripting;

public class SceneLoad : MonoBehaviour
{
    public string GameExit;
    public void OnButtonClickExit()
    {
        /*UnityEditor.EditorApplication.isPlaying = false;*/

        Application.Quit();
        Debug.Log("Exit");
    }
}
