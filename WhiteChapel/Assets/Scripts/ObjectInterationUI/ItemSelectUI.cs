using UnityEngine;
using UnityEngine.UI;

public class ItemSelectUI : MonoBehaviour
{
    Image image;
    Sprite idleSprite;
    Sprite selectedSprite;

    LayerMask InteractionObj;
    [SerializeField] float rayMaxDistance = 0.5f;

    private void Start()
    {
        image = transform.Find("InterationCanvas").GetComponentInChildren<Image>();
        idleSprite = Resources.Load<Sprite>("InterationUI/Eye_Closed");
        selectedSprite = Resources.Load<Sprite>("InterationUI/Eye_Open");

        InteractionObj = LayerMask.GetMask("Interaction");
    }

    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, rayMaxDistance, InteractionObj))
        {
            OnMouseOver();
        }
        else
        {
            OnMouseExit();
        }
    }

    public void OnMouseOver()
    {
        image.sprite = selectedSprite;
    }

    public void OnMouseExit()
    {
        image.sprite = idleSprite;
    }
}
