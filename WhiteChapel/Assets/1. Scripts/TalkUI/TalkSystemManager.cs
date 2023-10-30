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

    public Text sentence_text; //텍스트 UI연결
    //public Image[] character_icons;
    public Image textIcon;
    public GameObject TalkCanvas;

    private void Start()
    {
        //대화 저장 공간에 대한 초기화를 진행
        sentences = new string[count];
        //다이얼로그 내용 초기화
        DialogInitialize();
    }

    private void DialogInitialize()
    {
        sentences[0] = "즐겁다!(진심)";
        sentences[1] = "성공";
    }

    void Update()
    {
        if (isTalk)
        {
            Debug.Log("isTalk");

            if (isShowDialog == true)   // TalkCanvas가 켜지면 아래 이프문실행
            {
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
        //textIcon.gameObject.SetActive(true); //텍스트 활성화
        sentence_text.text = sentences[check_count];

    }
}
