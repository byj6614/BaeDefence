using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeSpawn : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;//오브젝트가 소환될 위치
    [SerializeField] float spawnTime;//소환 간격
    [SerializeField] GameObject enemyPrefab;//소환될 오브젝트

    private void OnEnable()
    {
        StartCoroutine(SpawnRoutine());//코루틴을 이용하여 소환
    }

    private void OnDisable()
    {
        StopAllCoroutines();//모든 코르틴을 끝내준다.
    }

    IEnumerator SpawnRoutine()//오브젝트를 소환하는 코르틴
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);//spawnTime동안 기다린다.
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);//그후 오브젝트를 spawnPoint의 위치와 그 방향으로 소환
        }
    }
}
