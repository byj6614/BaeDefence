using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HomeCamera : MonoBehaviour
{
    [SerializeField] private float moveSpeed;//ī�޶��� �����̴� �ӵ�
    [SerializeField] private float zoomSpeed;//ī�޶��� ���� �ܾƿ� �ӵ�
    [SerializeField] private float padding;//ī�޶��� �������� �ִ� ���
    Vector3 moveDir;//ī�޶� �����̴� ���� ����
    private float zoomScroll;//���� �ܾƿ��� float

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Confined;//���콺�� ȭ�� ������ ������ ���ϰ��ϱ�
    }
    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;//esc�� ������ ȭ�� �����ε� ���� �� �ְ� �ϱ�
    }
    private void LateUpdate()//��� ������Ʈ�� ������ ������Ʈ �ϴ°� ����
    {
        Move();
        Zoom();
    }
    private void Move()
    {//����������� �ϴ� ������ self�� �� �� ī�޶� ���� ���� �� �� ���� 
        transform.Translate(Vector3.forward * moveDir.y * moveSpeed * Time.deltaTime, Space.World);
        //ī�޶��� ��ġ�� ���� ��ġ�� �չ������� ����������� y�������� �����̰� �ϱ�
        transform.Translate(Vector3.right * moveDir.x * moveSpeed * Time.deltaTime, Space.World);
    }   //ī�޶��� ��ġ�� ���� ��ġ�� �չ������� ����������� x�������� �����̰� �ϱ�
    private void OnHomePointer(InputValue value)//ī�޶��� �������� ����� �� ������ ���콺�� ��ġ�� ���� �������ֱ�
    {
        Vector2 mousePos = value.Get<Vector2>();//Vector2�� ���� ��´�.
        if (mousePos.x <= padding)//���콺��.x ��ġ�� ������ padding������ ���ų� ������� x������ -1�������� �����Ѵ�.
            moveDir.x = -1;//���� ���κп� ������ �������� ���°Ŷ�� �����ϸ� ���ϴ�.
        else if (mousePos.x >= Screen.width - padding)//Screen.width - padding�� ������ ������ padding ����ŭ �� ũ�⸦ ���Ѵ�.
            moveDir.x = 1;//���� �ݴ��� �����ʿ� ����������� ���������� ī�޶� �̵��Ѵ�.
        else moveDir.x = 0;//�� �� ������ �ƴѰ��� ī�޶� ������ �ʿ䰡 ����.

        if (mousePos.y <= padding)//y������ ���ʰ� �Ʒ������� �̵��ϴ� �����̴�
            moveDir.y = -1;         //����� ���� ����
        else if (mousePos.y >= Screen.height - padding)//�� ������ padding���� ����
            moveDir.y = 1;
        else
            moveDir.y = 0;//�� �� ������ �ƴѰ��� ī�޶� ������ �ʿ䰡 ����.

    }
    private void Zoom()//ī�޶� ���� �ƿ� �ϴ� �Լ�
    {
        transform.Translate(Vector3.forward * zoomSpeed * zoomScroll * Time.deltaTime, Space.Self);
        //ī�޶��� ��ġ�� ������ �ڱ��ڽ��� �������� �����̸鼭 ���� �� �ƿ� ���ش�.
    }
    private void OnHomeZoom(InputValue value)
    {
        zoomScroll = value.Get<Vector2>().y;//������ġ�� �����̱� ������ y���⸸ �޾ƿ´�.
    }
}
