using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableItem : MonoBehaviour
{
    //player uses a key press on item
    //item moves to on player and is attached to player
    //player is able to drop item

    private PlayerController playerController;

    [SerializeField]
    private Transform grabPoint;

    [SerializeField]
    private Transform rayPoint;
    [SerializeField]
    private float rayDistance;

    private GameObject grabbedItem;
    private int layerIndex;


    private void Start()
    {
        layerIndex = LayerMask.NameToLayer("Items");
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        SpriteRenderer spriteRenderer = playerController.GetSpriteRenderer();
        Vector2 castDirection = spriteRenderer.flipX ? Vector2.left : Vector2.right;

        if (spriteRenderer.flipX)
        {
            grabPoint.localPosition = new Vector3(-Mathf.Abs(grabPoint.localPosition.x), grabPoint.localPosition.y, grabPoint.localPosition.z);
        }
        else
        {
            grabPoint.localPosition = new Vector3(Mathf.Abs(grabPoint.localPosition.x), grabPoint.localPosition.y, grabPoint.localPosition.z);
        }

        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, castDirection, rayDistance);


        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            //grab object
            if(Keyboard.current.eKey.wasPressedThisFrame && grabbedItem == null)
            {
                grabbedItem = hitInfo.collider.gameObject;
                grabbedItem.transform.position = grabPoint.position;
                grabbedItem.transform.SetParent(grabPoint);
            }

            //drop object
            else if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                grabbedItem.transform.SetParent(null);
                grabbedItem = null;
            }
        }
    }

}
