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
    string NPCName;


    public Text sentence_text; //�ؽ�Ʈ UI����
    public Text npc_name;
    public Image textIcon;
    public GameObject TalkCanvas;
    PlayerController PlayerControllerComponent;
    CameraPC CameraPCComponent;
    public GameObject targetImage;


    private void Start()
    {
        //��ȭ ���� ������ ���� �ʱ�ȭ�� ����
        sentences = new string[count];
        //���̾�α� ���� �ʱ�ȭ
        DialogInitialize(gameObject.name);
    }

    private void DialogInitialize(string NPCName)
    {
        if (NPCName.Equals("NPC_1"))
        {
            sentences[0] = "�ɳ�";
            sentences[1] = "�Ҹ�";
        }
        else if (NPCName.Equals("NPC_2"))
        {
            sentences[0] = "�ɳ�";
            sentences[1] = "�Ҹ�";
        }


    }

    void Update()
    {
        if (isTalk)
        {
            Debug.Log("isTalk");

            if (isShowDialog == true)   // TalkCanvas�� ������ �Ʒ� ����������
            {
                PlayerControllerComponent = Camera.main.GetComponentInParent<PlayerController>();
                PlayerControllerComponent.enabled = false;  //��ȭ �� �÷��̾� �̵� ���ϰ�
                //��ȭ �� ȭ����ȯ �ȵǰ�
                CameraPCComponent = Camera.main.GetComponentInParent<CameraPC>();
                CameraPCComponent.enabled = false;
                //��ȭ �� ������ ���ֱ�
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
        sentence_text.text = sentences[check_count];
    }

}
