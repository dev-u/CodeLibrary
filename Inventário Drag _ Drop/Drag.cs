using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentReturn = null;
    private Vector3 tr;

    public void OnBeginDrag(PointerEventData pointerData)
    {
        parentReturn = transform.parent;
        tr = transform.position;
        //transform.SetParent(transform.parent.parent.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData pointerData)
    {
        transform.position = pointerData.position;
    }

    public void OnEndDrag(PointerEventData pointerData)
    {
        transform.SetParent(parentReturn);
        transform.SetPositionAndRotation(tr, transform.rotation);

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
