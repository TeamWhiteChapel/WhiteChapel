using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLocked : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
