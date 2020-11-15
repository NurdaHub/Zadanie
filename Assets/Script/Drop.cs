using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
        if (eventData.pointerDrag == null)
            return;

        Drag d = eventData.pointerDrag.GetComponent<Drag>();
        if (d != null)
        {
            d.placeholderParent = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
        if (eventData.pointerDrag == null)
            return;

        Drag d = eventData.pointerDrag.GetComponent<Drag>();
        if (d != null && d.placeholderParent == this.transform)
        {
            d.placeholderParent = d.parentToReturnTo;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        Drag d = eventData.pointerDrag.GetComponent<Drag>();
        if (d != null)
        {
            d.parentToReturnTo = this.transform;
        }

    }
}
