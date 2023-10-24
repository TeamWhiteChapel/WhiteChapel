using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    float h, v, xRotate, yRotate, xRotateMove, yRotateMove;
    public float moveSpeed = 3f;
    public float rotateSpeed = 200f;

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        transform.position += new Vector3(h, 0, v) * moveSpeed * Time.deltaTime;

        //xRotateMove = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;
        //yRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;

        //yRotate = transform.eulerAngles.y + yRotateMove;
        //xRotate += xRotateMove;
        //xRotate = Mathf.Clamp(xRotate, -90, 90);
        //transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
    }
}
