using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBill : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        //카메라가 정면에서 바라볼때 그모습 그대로 계속 회전 시켜준다.
    }
}
