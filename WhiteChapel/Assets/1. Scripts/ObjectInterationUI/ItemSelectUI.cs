using System;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelectUI : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Sprite idleSprite;
    [SerializeField] Sprite selectedSprite;

    LayerMask InteractionObj;
    [SerializeField] float rayMaxDistance = 0.5f;

    [SerializeField] GameObject selectedUI;
    bool isSelectedUIActive;

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
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo = new RaycastHit();

        if (Physics.Raycast(ray, out hitInfo, rayMaxDistance, InteractionObj))
        {
            if(hitInfo.collider.gameObject == gameObject)
            {
                OnMouseOver();

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

        if (isSelectedUIActive)
        {
            if(Input.GetKeyDown(KeyCode.Escape)) 
            {
                OffObjectDetailedMode();
            }
        }
    }

    private void OnObjectDetailedMode()
    {
        // ESC 키를 눌러 UI창 끄게하기 위한 용도.
        isSelectedUIActive = true;

        // 카메라 오브젝트 회전으로 바꾸기

        // 오브젝트 데이터 불러와서 적용하기

        // 데이터 UI 활성화
        selectedUI.SetActive(true);
    }

    private void OffObjectDetailedMode()
    {
        // ESC 키를 눌러 UI창 끄게하기 위한 용도.
        isSelectedUIActive = false;
        
        // 카메라 플레이어 회전으로 바꾸기

        // 데이터 UI 비활성화
        selectedUI.SetActive(false);
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
