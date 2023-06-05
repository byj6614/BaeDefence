using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HomeMove : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform endPoint;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

    }
    private void Start()
    {
        endPoint = GameObject.FindGameObjectWithTag("EndPoint").transform;//�±׸� ���� endPoint��ġ ����
        agent.destination = endPoint.position;//������ ��ġ���� �̵��϶�� �ڵ�
    }

    private void Update()
    {

        if (Vector3.Distance(transform.position, endPoint.position) < 0.1f)//�������� ���������� ������Ʈ ����
        {
            Destroy(gameObject);
        }
    }
}
