using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class ButtonController : MonoBehaviour
{
    [System.Serializable]
    public class ButtonScenePair
    {
        public string ButtonName;  // 버튼의 이름을 저장하는 변수
        public string sceneToLoad; // 해당 버튼이 클릭되었을 때 로드할 씬의 이름을 저장하는 변수
    }

    public ButtonScenePair[] buttonScenePairs; // 버튼과 씬 정보를 담고 있는 배열

    private void Start()
    {
        // 게임 시작 시 실행되는 메서드
        foreach (ButtonScenePair pair in buttonScenePairs)
        {
            // 버튼과 씬 정보를 반복하여 처리
            GameObject button = GameObject.Find(pair.ButtonName);

            if (button != null)
            {
                // 버튼이 존재하면 해당 버튼에 클릭 이벤트 리스너를 추가
                button.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
                {
                    // 버튼이 클릭되면 LoadScene 메서드를 호출하여 지정된 씬을 로드
                    LoadScene(pair.sceneToLoad);
                });
            }
            else
            {
                Debug.LogError("Button not found: " + pair.ButtonName);
                // 버튼을 찾지 못하면 에러 메시지를 출력
            }
        }
    }

    public void LoadScene(string sceneName)
    {
        // 지정된 씬을 로드하는 메서드
        SceneManager.LoadScene(sceneName);
    }
}
