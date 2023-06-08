using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeInGame : BaseUI
{
    public Transform followTarget;  //�ΰ��ӿ��� ���� ��ġ
    public Vector3 followOffset;    //���� ��ġ���� ��� ��ġ�� ��

    public void LateUpdate()
    {
        if(followTarget !=null)//Ÿ���� ������� ���� ��
        {
            transform.position = Camera.main.WorldToScreenPoint(followTarget.position) + (Vector3)followOffset;
            //�� ������Ʈ�� ��ġ�� ����ī�޶� ���� �������� ������ �� Ÿ���� ��ġ���� followOffset���� ������ ��ġ�� �����ش�.
        }
    }

    public void HomeTarget(Transform target)//Ŭ���� �� ���� Ÿ���� ������ �ϴ� �Լ�
    {                                       //Ÿ���� ��ġ�� �°� �ؾ��ϹǷ� TowerPlace������Ʈ���� �۾����ش�.
        this.followTarget = target;
        if(followTarget != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(followTarget.position) + (Vector3)followOffset;
        }
    }

    public void SetOffset(Vector3 offset)
    {
        this.followOffset = offset;
        if(followOffset != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(followTarget.position) + (Vector3)followOffset;
        }
    }
}