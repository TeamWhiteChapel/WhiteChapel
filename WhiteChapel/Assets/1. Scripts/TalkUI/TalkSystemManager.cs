using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TalkSystemManager : MonoBehaviour
{
    public bool isTalk = false;

    void Update()
    {
        if (isTalk)
        {
            Debug.Log("isTalk");
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Å¬¸¯");
            }
        }
    }
}
