using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HomeWindow : BaseUI,IDragHandler,IPointerDownHandler
{                               //IDragHandler:���콺�� ������ �����̴� interface
                                //IPointerDownHandler:���콺�� ������ ���� �۵��ϴ� interface

    protected override void Awake()
    {
        base.Awake();

        //buttons["Close"].onClick.AddListener(() => { GameManager.Ui.CloseWindowUI(this); });//Close��� �̸��� ��ư�� ������ ���� �� â�� �ݴ´�.
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position += (Vector3)eventData.delta;//������Ʈ �ǰ� ������ ��ġ�� ����ġ�� �����ָ鼭 �̵�
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //GameManager.Ui.SelectWindowUI(this);//���콺�� ������ ���� �� ��ġ�� ���� �Ʒ��� �������� �Լ�
    }
}
