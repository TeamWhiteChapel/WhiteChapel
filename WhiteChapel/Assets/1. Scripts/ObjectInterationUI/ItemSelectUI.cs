using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelectUI : MonoBehaviour
{
    [Tooltip("�̹����� ��� UI Image")]
    [SerializeField] Image image;
    [Tooltip("�� ���� �̹���")]
    [SerializeField] Sprite idleSprite;
    [Tooltip("�� �� �̹���")]
    [SerializeField] Sprite selectedSprite;

    LayerMask InteractionObj;
    [Tooltip("��ȣ�ۿ��� ������ �ִ� �Ÿ�")]
    [SerializeField] float rayMaxDistance = 0.5f;

    [Tooltip("�� �̹��� UI")]
    [SerializeField] GameObject InterationUI;
    [Tooltip("������Ʈ �� ���� UI")]
    [SerializeField] GameObject selectedUI;
    [Tooltip("������Ʈ ������(detailed)")]
    [SerializeField] GameObject copyObj;
    [Tooltip("player(GetPositionValue ��ũ��Ʈ�� ������ ������Ʈ)")]
    [SerializeField] GameObject player;
    // ��ȣ�ۿ� ���� ��(����â Ȯ�� ������) ����
    bool isSelectedUIActive = false;
    [Tooltip("������Ʈ�� ī�޶��� �Ÿ�")]
    [SerializeField] float distance = 0.4f;
    [Tooltip("������Ʈ�� �������� xdistance��ŭ �̵�")]
    [SerializeField] float xdistance = -0.1f;

    private void Start()
    {
        if(image == null)
            image = transform.Find("InterationCanvas").GetComponentInChildren<Image>();
        if (idleSprite == null)
            idleSprite = Resources.Load<Sprite>("InterationUI/Eye_Closed");
        if (selectedSprite == null)
            selectedSprite = Resources.Load<Sprite>("InterationUI/Eye_Open");

        InteractionObj = LayerMask.GetMask("Interaction");

        isSelectedUIActive = false;
    }

    void Update()
    {
        Ray inGameRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit inGameHit;

        if (Physics.Raycast(inGameRay, out inGameHit, rayMaxDistance, InteractionObj))
        {
            // ���� ������Ʈ�� ���� �ִ� ���
            if(inGameHit.collider.gameObject == gameObject)
            {
                OnMouseOver();

                // ��ȣ�ۿ��� ������ ������Ʈ�� Ŭ��/eŰ �ϸ� ������Ʈ ȸ����ɰ� ����â�� ���δ�.
                if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
                {
                    OnObjectDetailedMode();
                }
            }
            else
            {
                OnMouseExit();
            }
        }
        else
        {
            OnMouseExit();
        }

        // ������Ʈ ����â�� ����� �ִ� ���, 
        if (isSelectedUIActive)
        {
            // ESC�� ���� �������� ���ư� �� �ְ� �Ѵ�.
            if (Input.GetKeyDown(KeyCode.Escape)) 
            {
                OffObjectDetailedMode();
            }
        }
    }

    private void OnObjectDetailedMode()
    {
        // ESC Ű�� ���� UIâ �����ϱ� ���� �뵵.
        isSelectedUIActive = true;

        // ������Ʈ �������� ī�޶� ������ �������� ������ �ٶ󺸰��� �� Ȱ��ȭ
        Transform camera = Camera.main.transform;
        copyObj.transform.position = camera.position + camera.forward * distance + camera.right * xdistance;
        copyObj.transform.LookAt(copyObj.transform.position - Camera.main.transform.position);

        // ���콺 �Է°��� ī�޶� ȸ���� ���� �ʰ� ��Ȱ��ȭ
        player.GetComponent<GetPositionValue>().enabled = false;
        Camera.main.GetComponent<CameraPC>().enabled = false;

        // ��ȣ�ۿ� ���� ǥ�� UI�� �Ⱥ��̰� �ϱ� ���� OverUI ī�޶� ��Ȱ��ȭ
        Camera.main.transform.GetChild(0).gameObject.SetActive(false);

        // ������Ʈ ������ Ȱ��ȭ
        copyObj.SetActive(true);

        // ������ UI Ȱ��ȭ
        selectedUI.SetActive(true);
    }

    private void OffObjectDetailedMode()
    {
        // ������Ʈ ������ ��Ȱ��ȭ
        copyObj.SetActive(false);

        // ������ UI ��Ȱ��ȭ
        selectedUI.SetActive(false);

        // ��ȣ�ۿ� ���� ǥ�� UI�� ���̰� �ϱ� ���� OverUI ī�޶� Ȱ��ȭ
        Camera.main.transform.GetChild(0).gameObject.SetActive(true);

        // ���콺 �Է°��� ī�޶� ȸ���� �ǰ� Ȱ��ȭ
        player.GetComponent<GetPositionValue>().enabled = true;
        Camera.main.GetComponent<CameraPC>().enabled = true;

        // ESC Ű�� ���� UIâ �����ϱ� ���� �뵵.
        isSelectedUIActive = false;
    }

    public void OnMouseOver()
    {
        image.sprite = selectedSprite;
    }

    public void OnMouseExit()
    {
        image.sprite = idleSprite;
    }
}
