using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HomeCamera : MonoBehaviour
{
    [SerializeField] private float moveSpeed;//카메라의 움직이는 속도
    [SerializeField] private float zoomSpeed;//카메라의 줌인 줌아웃 속도
    [SerializeField] private float padding;//카메라의 움직임의 최대 경계
    Vector3 moveDir;//카메라가 움직이는 방향 벡터
    private float zoomScroll;//줌인 줌아웃의 float

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Confined;//마우스가 화면 밖으로 나가지 못하게하기
    }
    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;//esc를 눌러서 화면 밖으로도 나갈 수 있게 하기
    }
    private void LateUpdate()//모든 업데이트가 끝나고서 업데이트 하는게 좋음
    {
        Move();
        Zoom();
    }
    private void Move()
    {//월드기준으로 하는 이유는 self로 할 시 카메라가 가라 앉을 수 도 있음 
        transform.Translate(Vector3.forward * moveDir.y * moveSpeed * Time.deltaTime, Space.World);
        //카메라의 위치를 현재 위치에 앞방향으로 세계기준으로 y방향으로 움직이게 하기
        transform.Translate(Vector3.right * moveDir.x * moveSpeed * Time.deltaTime, Space.World);
    }   //카메라의 위치를 현재 위치에 앞방향으로 세계기준으로 x방향으로 움직이게 하기
    private void OnHomePoint(InputValue value)//카메라의 움직임의 방향과 그 조건을 마우스의 위치에 따라 지정해주기
    {
        Vector2 mousePos = value.Get<Vector2>();//Vector2의 값을 담는다.
        if (mousePos.x <= padding)//마우스의.x 위치가 지정한 padding값보다 같거나 작을경우 x축으로 -1방향으로 가게한다.
            moveDir.x = -1;//왼쪽 끝부분에 갔을때 왼쪽으로 가는거라고 생각하면 편하다.
        else if (mousePos.x >= Screen.width - padding)//Screen.width - padding는 오른쪽 끝에서 padding 값만큼 뺀 크기를 말한다.
            moveDir.x = 1;//위와 반대인 오른쪽에 가까워졌으니 오른쪽으로 카메라가 이동한다.
        else moveDir.x = 0;//위 두 조건이 아닌경우는 카메라가 움직일 필요가 없다.

        if (mousePos.y <= padding)//y방향은 위쪽과 아래쪽으로 이동하는 방향이다
            moveDir.y = -1;         //방식은 위와 같다
        else if (mousePos.y >= Screen.height - padding)//위 끝에서 padding값을 뺀값
            moveDir.y = 1;
        else
            moveDir.y = 0;//위 두 조건이 아닌경우는 카메라가 움직일 필요가 없다.

    }
    private void Zoom()//카메라를 줌인 아웃 하는 함수
    {
        transform.Translate(Vector3.forward * zoomSpeed * zoomScroll * Time.deltaTime, Space.Self);
        //카메라의 위치를 앞으로 자기자신을 기준으로 움직이면서 줌인 줌 아웃 해준다.
    }
    private void OnHomeZoom(InputValue value)
    {
        zoomScroll = value.Get<Vector2>().y;//줌의위치는 한쪽이기 때문에 y방향만 받아온다.
    }
}
