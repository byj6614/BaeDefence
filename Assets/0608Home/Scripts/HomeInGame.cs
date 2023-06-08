using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeInGame : BaseUI
{
    public Transform followTarget;  //인게임에서 따라갈 위치
    public Vector3 followOffset;    //따라갈 위치에서 어디에 위치할 지

    public void LateUpdate()
    {
        if(followTarget !=null)//타겟이 비어있지 않을 때
        {
            transform.position = Camera.main.WorldToScreenPoint(followTarget.position) + (Vector3)followOffset;
            //이 오브젝트의 위치는 메인카메라가 월드 기준으로 보았을 때 타겟의 위치에서 followOffset으로 움직인 위치를 보여준다.
        }
    }

    public void HomeTarget(Transform target)//클릭할 때 현재 타겟을 고르도록 하는 함수
    {                                       //타워의 위치에 맞게 해야하므로 TowerPlace컴포넌트에서 작업해준다.
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