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
    public int count = 2; //��ȭ�� �� ����
    public int check_count = 0; //�� ������ ��ġ ���� = ��ȭ ����
    string[] sentences; //��ȭ ����

    public Text sentence_text; //�ؽ�Ʈ UI����
    //public Image[] character_icons;
    public Image textIcon;
    public GameObject TalkCanvas;

    private void Start()
    {
        //��ȭ ���� ������ ���� �ʱ�ȭ�� ����
        sentences = new string[count];
        //���̾�α� ���� �ʱ�ȭ
        DialogInitialize();
    }

    private void DialogInitialize()
    {
        sentences[0] = "��̴�!(����)";
        sentences[1] = "����";
    }

    void Update()
    {
        if (isTalk)
        {
            Debug.Log("isTalk");

            if (isShowDialog == true)   // TalkCanvas�� ������ �Ʒ� ����������
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
            else  //TalkCanvas�� �������� ������ ����
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
        //textIcon.gameObject.SetActive(true); //�ؽ�Ʈ Ȱ��ȭ
        sentence_text.text = sentences[check_count];

    }
}
