using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HomePlace : MonoBehaviour,IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{                   //=> �������̽�   //���콺�� Ŭ���� ��//���콺�� ������Ʈ���� ������//���콺�� ������Ʈ�� �����Ҷ�
    [SerializeField] Color normal;  //���콺�� ���� ���� �� ����
    [SerializeField] Color onMouse; //���콺�� ������Ʈ ���� ������ �� ����
    private Renderer render;  //Render�� ���� ������Ʈ ���� ��ȭ
    private void Awake()
    {
        render = GetComponent<Renderer>();
    }
    public void OnPointerClick(PointerEventData eventData)//������Ʈ�� ������ ��
    {
        if (eventData.button == PointerEventData.InputButton.Left)//��Ŭ�� �� �� ��ȣ�ۿ�
        {
            Debug.Log("��Ŭ����");
        }
        else if (eventData.button == PointerEventData.InputButton.Right)//��Ŭ�� �� �� ��ȣ�ۿ�
        {
            Debug.Log("��Ŭ����");
        }

    }

    public void OnPointerEnter(PointerEventData eventData)//���콺�� ��ġ�� ������Ʈ�� �������� ��ȣ�ۿ�
    {
        render.material.color = onMouse;
    }

    public void OnPointerExit(PointerEventData eventData)//���콺�� ��ġ�� ������Ʈ���� ����� ��ȣ�ۿ�
    {
        render.material.color = normal;
    }
}
