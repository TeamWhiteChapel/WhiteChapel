using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TalkSystemManager : MonoBehaviour
{
    public bool isTalk = false;
    public bool isShowDialog = false;
    public int count = 2; //대화의 총 개수
    public int check_count = 0; //이 변수의 수치 조절 = 대화 진행
    string[] sentences; //대화 문장
    string NPCName;


    public Text sentence_text; //텍스트 UI연결
    public Text npc_name;
    public Image textIcon;
    public GameObject TalkCanvas;
    PlayerController PlayerControllerComponent;
    CameraPC CameraPCComponent;
    public GameObject targetImage;


    private void Start()
    {
        //대화 저장 공간에 대한 초기화를 진행
        sentences = new string[count];
        //다이얼로그 내용 초기화
        DialogInitialize(gameObject.name);
    }

    private void DialogInitialize(string NPCName)
    {
        if (NPCName.Equals("NPC_1"))
        {
            sentences[0] = "냥냥";
            sentences[1] = "먕먕";
        }
        else if (NPCName.Equals("NPC_2"))
        {
            sentences[0] = "냥냥";
            sentences[1] = "먕먕";
        }


    }

    void Update()
    {
        if (isTalk)
        {
            Debug.Log("isTalk");

            if (isShowDialog == true)   // TalkCanvas가 켜지면 아래 이프문실행
            {
                PlayerControllerComponent = Camera.main.GetComponentInParent<PlayerController>();
                PlayerControllerComponent.enabled = false;  //대화 시 플레이어 이동 못하게
                //대화 시 화면전환 안되게
                CameraPCComponent = Camera.main.GetComponentInParent<CameraPC>();
                CameraPCComponent.enabled = false;
                //대화 시 조준점 없애기
                targetImage.gameObject.SetActive(false);
                NPCName = gameObject.name;
                npc_name.text = NPCName;

                if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
                {
                    if (check_count + 1 < count)
                    {
                        check_count++;
                        ShowDialog();
                    }
                    else
                    {
                        TalkCanvas.SetActive(false);
                        isShowDialog = false;
                        check_count = 0;
                        PlayerControllerComponent.enabled = true;
                        CameraPCComponent.enabled = true;
                        targetImage.gameObject.SetActive(true);
                    }
                }
            }
            else  //TalkCanvas가 켜져있지 않으면 실행
            {
                if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
                {
                    ShowDialog();
                    TalkCanvas.SetActive(true);
                    isShowDialog = true;
                }
            }


        }
    }

    private void ShowDialog()
    {
        sentence_text.text = sentences[check_count];
    }

}
