using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPC : PlayerCameraInput
{
    [SerializeField, Range(0, 80)]
    protected float angleClamp = 10f;
    
    public float sensitivity = 5.0f;

    float mX;
    float mY;
    
    float mouseX;
    float mouseY;

    void Start(){}

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        mX += mouseX;
        mY += mouseY;

        mY = Mathf.Clamp(mY, -angleClamp, angleClamp);

        transform.rotation = Quaternion.Euler(-mY, mX, 0f);

        rotation = transform.rotation;
    }
}


