using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public float speed = 100.0f;

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");

        Vector3 dir = new Vector3(0, mouseX, 0);

        transform.rotation = PlayerCameraInput.rotation;
    }
}
