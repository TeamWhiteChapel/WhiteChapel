using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPC : PlayerCameraInput
{
    [SerializeField, Range(0, 80)]
    protected float angleClamp = 89f;

    public float sensitivity = 200f;

    float mX;
    float mY;
    
    float inputMouseX;
    float inputMouseY;
    void Update()
    {
        inputMouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        inputMouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        mX += inputMouseX;
        mY += inputMouseY;

        mY = Mathf.Clamp(mY, -angleClamp, angleClamp);

        rotation = Quaternion.Euler(-mY, mX, 0f);
    }
}


