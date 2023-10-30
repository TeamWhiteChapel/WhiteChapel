using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RaycastManager : MonoBehaviour
{
    LayerMask InteractionObj;
<<<<<<< HEAD
    LayerMask NPCTalk;
=======
    LayerMask TalkNPC;
>>>>>>> c2007002b11313ffa98112f194c7221f91ceebf3
    [Tooltip("상호작용이 가능한 최대 거리")]
    [SerializeField] float rayMaxDistance = 0.5f;

    Ray inGameRay;
    RaycastHit inGameHit;
    InterationManager target;
<<<<<<< HEAD
    Talk talktarget;
=======
    TalkSystemManager talkTarget;
>>>>>>> c2007002b11313ffa98112f194c7221f91ceebf3

    void Start()
    {
        InteractionObj = LayerMask.GetMask("Interaction");
<<<<<<< HEAD
        NPCTalk = LayerMask.GetMask("NPC");
=======
        TalkNPC = LayerMask.GetMask("NPC");
>>>>>>> c2007002b11313ffa98112f194c7221f91ceebf3
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

<<<<<<< HEAD
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
=======
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
>>>>>>> c2007002b11313ffa98112f194c7221f91ceebf3
        }
    }
}
