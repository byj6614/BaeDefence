using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeSpawn : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;//������Ʈ�� ��ȯ�� ��ġ
    [SerializeField] float spawnTime;//��ȯ ����
    [SerializeField] GameObject enemyPrefab;//��ȯ�� ������Ʈ

    private void OnEnable()
    {
        StartCoroutine(SpawnRoutine());//�ڷ�ƾ�� �̿��Ͽ� ��ȯ
    }

    private void OnDisable()
    {
        StopAllCoroutines();//��� �ڸ�ƾ�� �����ش�.
    }

    IEnumerator SpawnRoutine()//������Ʈ�� ��ȯ�ϴ� �ڸ�ƾ
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);//spawnTime���� ��ٸ���.
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);//���� ������Ʈ�� spawnPoint�� ��ġ�� �� �������� ��ȯ
        }
    }
}
