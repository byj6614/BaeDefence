using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBill : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        //ī�޶� ���鿡�� �ٶ󺼶� �׸�� �״�� ��� ȸ�� �����ش�.
    }
}
