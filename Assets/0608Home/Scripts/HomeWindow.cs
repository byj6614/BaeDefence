using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HomeWindow : BaseUI,IDragHandler,IPointerDownHandler
{                               //IDragHandler:마우스로 누르고 움직이는 interface
                                //IPointerDownHandler:마우스를 누르는 순간 작동하는 interface

    protected override void Awake()
    {
        base.Awake();

        buttons["Close"].onClick.AddListener(() => { GameManager.Ui.CloseWindowUI(this); });//Close라는 이름의 버튼이 눌리는 순간 이 창을 닫는다.
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position += (Vector3)eventData.delta;//업데이트 되고서 움직인 위치를 현위치에 더해주면서 이동
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.Ui.SelectWindowUI(this);//마우스가 눌리는 순간 현 위치에 가장 아래로 내려가는 함수
    }
}
