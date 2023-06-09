using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackRange : MonoBehaviour
{
    public Tower tower;
    public LayerMask enemyMask;
    /*
    public UnityEvent<EnemyController> OnInRangeEnemy;
    public UnityEvent<EnemyController> OnOutRangeEnemy;*/
    private void OnTriggerEnter(Collider other)
    {
        if(enemyMask.IsContaion(other.gameObject.layer))
        {
            EnemyController enemy=other.GetComponent<EnemyController>();
            enemy.OnDied.AddListener(() => { tower.RemoveEnemy(enemy); });
            tower.AddEnemy(enemy);
           // OnInRangeEnemy?.Invoke(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (enemyMask.IsContaion(other.gameObject.layer))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            tower.RemoveEnemy(enemy);
            //OnOutRangeEnemy?.Invoke(enemy);
        }
    }
}
