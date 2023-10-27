using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    
    public float speed = 200.0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");

        Vector3 dir = new Vector3(0, mouseX, 0);

        transform.eulerAngles = transform.eulerAngles + dir * speed * Time.deltaTime;

           
    }
}
