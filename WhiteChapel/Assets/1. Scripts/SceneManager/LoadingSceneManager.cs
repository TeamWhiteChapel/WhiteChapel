using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneManager : MonoBehaviour
{
    public Slider progress_bar;
    public string SceneName;
    public Text progress_text;
    public Text loadingScene_ToolTip;

    private float time;

    private void Start()
    {
        StartCoroutine(AsyncLoadScene());
    }

    IEnumerator AsyncLoadScene()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneName);

        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            time += Time.time; // ���α׷� ���� �� ���� ���� ����.

            progress_bar.value = time / 10;

            progress_text.text = $"{progress_bar.value * 100: 0}%";

            if (time > 10)
            {
                progress_text.text = "�����Ϸ��� ���� Ű�� ��������";

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    asyncOperation.allowSceneActivation = true;
                }
            }

            yield return null;

        }

    }
}
