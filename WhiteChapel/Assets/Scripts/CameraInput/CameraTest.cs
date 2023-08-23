using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    float sensitivity = 5.0f;

    Vector3 dir = new Vector3(0, 0, 0);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float mouseX = Input.mousePosition.x; -190 ~ 4k 값 반환
        //float mouseX = Input.GetAxis("Mouse X"); 부드럽다
        //float mouseX = Input.GetAxisRaw("Mouse X"); 즉시 가져온다 라는데 구분 못하겠다
        //Debug.Log(mouseX);

        Vector3 dir = Vector3.up * sensitivity; //Vector3 성질 파악
    }
}
