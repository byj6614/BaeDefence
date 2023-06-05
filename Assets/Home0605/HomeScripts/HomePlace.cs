using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HomePlace : MonoBehaviour,IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{                   //=> 인터페이스   //마우스가 클릭할 때//마우스가 오브젝트에서 나갈때//마우스가 오브젝트에 진입할때
    [SerializeField] Color normal;  //마우스가 지정 안할 때 색상
    [SerializeField] Color onMouse; //마우스가 오브젝트 위를 선택할 때 색상
    private Renderer render;  //Render를 통해 오브젝트 색상 변화
    private void Awake()
    {
        render = GetComponent<Renderer>();
    }
    public void OnPointerClick(PointerEventData eventData)//오브젝트를 선택할 때
    {
        if (eventData.button == PointerEventData.InputButton.Left)//좌클릭 할 때 상호작용
        {
            Debug.Log("좌클릭됨");
        }
        else if (eventData.button == PointerEventData.InputButton.Right)//우클릭 할 때 상호작용
        {
            Debug.Log("우클릭됨");
        }

    }

    public void OnPointerEnter(PointerEventData eventData)//마우스의 위치가 오브젝트에 닿았을경우 상호작용
    {
        render.material.color = onMouse;
    }

    public void OnPointerExit(PointerEventData eventData)//마우스의 위치가 오브젝트에서 벗어날때 상호작용
    {
        render.material.color = normal;
    }
}
