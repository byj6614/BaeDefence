using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowUI : BaseUI, IDragHandler,IPointerDownHandler
{
    protected override void Awake()
    {
        base.Awake();

        buttons["Close"].onClick.AddListener(() => { GameManager.Ui.CloseWindowUI(this); });
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position += (Vector3)eventData.delta;
    }

    
    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.Ui.SelectWindowUI(this);
    }
}
