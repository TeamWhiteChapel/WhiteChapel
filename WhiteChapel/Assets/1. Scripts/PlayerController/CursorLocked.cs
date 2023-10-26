using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLocked : MonoBehaviour
{
    public bool isLocked = true;

    void Update()
    {
        if (isLocked)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
