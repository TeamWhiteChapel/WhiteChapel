using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelectUI : MonoBehaviour
{
    [Tooltip("이미지를 띄울 UI Image")]
    [SerializeField] Image image;
    [Tooltip("눈 감은 이미지")]
    [SerializeField] Sprite idleSprite;
    [Tooltip("눈 뜬 이미지")]
    [SerializeField] Sprite selectedSprite;

    LayerMask InteractionObj;
    [Tooltip("상호작용이 가능한 최대 거리")]
    [SerializeField] float rayMaxDistance = 0.5f;

    [Tooltip("눈 이미지 UI")]
    [SerializeField] GameObject InterationUI;
    [Tooltip("오브젝트 상세 정보 UI")]
    [SerializeField] GameObject selectedUI;
    [Tooltip("오브젝트 복제본(detailed)")]
    [SerializeField] GameObject copyObj;
    [Tooltip("player(GetPositionValue 스크립트를 가지는 오브젝트)")]
    [SerializeField] GameObject player;
    // 상호작용 중인 지(정보창 확인 중인지) 여부
    bool isSelectedUIActive = false;
    [Tooltip("오브젝트와 카메라의 거리")]
    [SerializeField] float distance = 0.4f;
    [Tooltip("오브젝트가 왼쪽으로 xdistance만큼 이동")]
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
            // 원본 오브젝트를 보고 있는 경우
            if(inGameHit.collider.gameObject == gameObject)
            {
                OnMouseOver();

                // 상호작용이 가능한 오브젝트를 클릭/e키 하면 오브젝트 회전기능과 정보창이 보인다.
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

        // 오브젝트 정보창이 띄워져 있는 경우, 
        if (isSelectedUIActive)
        {
            // ESC를 눌러 게임으로 돌아갈 수 있게 한다.
            if (Input.GetKeyDown(KeyCode.Escape)) 
            {
                OffObjectDetailedMode();
            }
        }
    }

    private void OnObjectDetailedMode()
    {
        // ESC 키를 눌러 UI창 끄게하기 위한 용도.
        isSelectedUIActive = true;

        // 오브젝트 복제본을 카메라 앞으로 가져오고 방향을 바라보게한 후 활성화
        Transform camera = Camera.main.transform;
        copyObj.transform.position = camera.position + camera.forward * distance + camera.right * xdistance;
        copyObj.transform.LookAt(copyObj.transform.position - Camera.main.transform.position);

        // 마우스 입력값이 카메라 회전이 되지 않게 비활성화
        player.GetComponent<GetPositionValue>().enabled = false;
        Camera.main.GetComponent<CameraPC>().enabled = false;

        // 상호작용 가능 표시 UI가 안보이게 하기 위해 OverUI 카메라 비활성화
        Camera.main.transform.GetChild(0).gameObject.SetActive(false);

        // 오브젝트 복제본 활성화
        copyObj.SetActive(true);

        // 데이터 UI 활성화
        selectedUI.SetActive(true);
    }

    private void OffObjectDetailedMode()
    {
        // 오브젝트 복제본 비활성화
        copyObj.SetActive(false);

        // 데이터 UI 비활성화
        selectedUI.SetActive(false);

        // 상호작용 가능 표시 UI가 보이게 하기 위해 OverUI 카메라 활성화
        Camera.main.transform.GetChild(0).gameObject.SetActive(true);

        // 마우스 입력값이 카메라 회전이 되게 활성화
        player.GetComponent<GetPositionValue>().enabled = true;
        Camera.main.GetComponent<CameraPC>().enabled = true;

        // ESC 키를 눌러 UI창 끄게하기 위한 용도.
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
