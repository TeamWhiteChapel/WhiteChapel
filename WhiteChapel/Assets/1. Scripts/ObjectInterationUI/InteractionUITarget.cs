using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionUITarget : MonoBehaviour
{
    void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
