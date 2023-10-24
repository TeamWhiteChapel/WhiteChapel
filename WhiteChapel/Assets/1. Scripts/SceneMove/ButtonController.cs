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
        public string ButtonName;  // ��ư�� �̸��� �����ϴ� ����
        public string sceneToLoad; // �ش� ��ư�� Ŭ���Ǿ��� �� �ε��� ���� �̸��� �����ϴ� ����
    }

    public ButtonScenePair[] buttonScenePairs; // ��ư�� �� ������ ��� �ִ� �迭

    private void Start()
    {
        // ���� ���� �� ����Ǵ� �޼���
        foreach (ButtonScenePair pair in buttonScenePairs)
        {
            // ��ư�� �� ������ �ݺ��Ͽ� ó��
            GameObject button = GameObject.Find(pair.ButtonName);

            if (button != null)
            {
                // ��ư�� �����ϸ� �ش� ��ư�� Ŭ�� �̺�Ʈ �����ʸ� �߰�
                button.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
                {
                    // ��ư�� Ŭ���Ǹ� LoadScene �޼��带 ȣ���Ͽ� ������ ���� �ε�
                    LoadScene(pair.sceneToLoad);
                });
            }
            else
            {
                Debug.LogError("Button not found: " + pair.ButtonName);
                // ��ư�� ã�� ���ϸ� ���� �޽����� ���
            }
        }
    }

    public void LoadScene(string sceneName)
    {
        // ������ ���� �ε��ϴ� �޼���
        SceneManager.LoadScene(sceneName);
    }
}
