using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPositionValue : MonoBehaviour
{
    void Update()
    {
        transform.rotation = PlayerCameraInput.rotation;
    }
}
