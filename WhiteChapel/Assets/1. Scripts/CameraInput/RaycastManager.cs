using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RaycastManager : MonoBehaviour
{
    LayerMask InteractionObj;
    LayerMask TalkNPC;
    [Tooltip("상호작용이 가능한 최대 거리")]
    [SerializeField] float rayMaxDistance = 0.5f;

    Ray inGameRay;
    RaycastHit inGameHit;
    InterationManager target;
    TalkSystemManager talkTarget;



    void Start()
    {
        InteractionObj = LayerMask.GetMask("Interaction");
        TalkNPC = LayerMask.GetMask("NPC");
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
        if (Physics.Raycast(inGameRay, out inGameHit, rayMaxDistance, TalkNPC))
        {
            if (talkTarget != null && talkTarget.isTalk == true &&
                talkTarget.gameObject != inGameHit.collider.gameObject)
                talkTarget.isTalk = false;
            talkTarget = inGameHit.collider.GetComponent<TalkSystemManager>();
            talkTarget.isTalk = true;
            Debug.Log("true");
        }
        else
        {
            if (talkTarget != null && talkTarget.isTalk == true)
            {
                talkTarget.isTalk = false;
                Debug.Log("false");

            }
        }
       

    }
}
