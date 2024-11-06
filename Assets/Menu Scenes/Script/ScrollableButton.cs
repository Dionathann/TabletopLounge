using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollableButton : Button, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private ScrollRect scrollRect;

    protected override void Start()
    {
        base.Start();
        scrollRect = GetComponentInParent<ScrollRect>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Pass drag to ScrollRect
        scrollRect.OnBeginDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Pass drag to ScrollRect
        scrollRect.OnDrag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Pass drag end to ScrollRect
        scrollRect.OnEndDrag(eventData);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        // Detect click only if no significant drag
        if (eventData.dragging == false)
            base.OnPointerClick(eventData);
    }
}
