using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// this class needs Phisics 2D raycaster on main camera and EventSystem object in the scene to work

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;



    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        // get gameobject under mouse cursor from eventData and save it to itemBeingDragged

        itemBeingDragged = Helpers.GetGameObjectUnderMouse2D();
        Debug.Log("itemBeingDragged: " + itemBeingDragged.name);

        // get position of itemBeingDragged and save it to startPosition
        startPosition = itemBeingDragged.transform.position;

        // GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (itemBeingDragged != null)
        {
            Debug.Log("OnDrag");
            // mouse position to world position
            Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            itemBeingDragged.transform.position = newPosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (itemBeingDragged != null)
        {

            Debug.Log("OnEndDrag");
            itemBeingDragged = null;
            // GetComponent<CanvasGroup>().blocksRaycasts = true;
            // if (transform.parent == startParent)
            // {
            //     transform.position = startPosition;
            // }
        }
    }

    // righ click to rotate object
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject objectUnderMouse = Helpers.GetGameObjectUnderMouse2D();
            if (objectUnderMouse != null)
            {
                objectUnderMouse.transform.Rotate(0, 0, 45);
            }
        }
    }
}