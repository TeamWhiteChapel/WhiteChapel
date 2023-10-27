using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RaycastManager : MonoBehaviour
{
    LayerMask InteractionObj;
    LayerMask NPCTalk;
    [Tooltip("상호작용이 가능한 최대 거리")]
    [SerializeField] float rayMaxDistance = 0.5f;

    Ray inGameRay;
    RaycastHit inGameHit;
    InterationManager target;
    Talk talktarget;

    void Start()
    {
        InteractionObj = LayerMask.GetMask("Interaction");
        NPCTalk = LayerMask.GetMask("NPC");
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

        if (Physics.Raycast(inGameRay, out inGameHit, rayMaxDistance, NPCTalk))
        {
            if (talktarget != null && talktarget.npcRaycast == true &&
                talktarget.gameObject != inGameHit.collider.gameObject)
                talktarget.npcRaycast = false;
            talktarget = inGameHit.collider.GetComponent<Talk>();
            talktarget.npcRaycast = true;
        }
        else
        {
            if (talktarget != null && talktarget.npcRaycast == true)
                talktarget.npcRaycast = false;
        }
    }
}
