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
        endPoint = GameObject.FindGameObjectWithTag("EndPoint").transform;//태그를 통한 endPoint위치 지정
        agent.destination = endPoint.position;//지정된 위치까지 이동하라는 코드
    }

    private void Update()
    {

        if (Vector3.Distance(transform.position, endPoint.position) < 0.1f)//도착지에 도달했을시 오브젝트 삭제
        {
            Destroy(gameObject);
        }
    }
}
