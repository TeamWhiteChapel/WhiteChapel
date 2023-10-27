using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RaycastManager : MonoBehaviour
{
    LayerMask InteractionObj;
    [Tooltip("상호작용이 가능한 최대 거리")]
    [SerializeField] float rayMaxDistance = 0.5f;

    Ray inGameRay;
    RaycastHit inGameHit;
    InterationManager target;

    void Start()
    {
        InteractionObj = LayerMask.GetMask("Interaction");
    }

    void FixedUpdate()
    {
        inGameRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        Debug.DrawRay(transform.position, transform.forward * rayMaxDistance);
        if (Physics.Raycast(inGameRay, out inGameHit, rayMaxDistance, InteractionObj))
        {
            if (target != null && target.isRaycast == true &&
                target.gameObject != inGameHit.collider.gameObject)
                target.isRaycast = false;
            target = inGameHit.collider.GetComponent<InterationManager>();
            target.isRaycast = true;
        }
        else
        {
            if (target != null && target.isRaycast == true)
                target.isRaycast = false;
        }
    }
}
