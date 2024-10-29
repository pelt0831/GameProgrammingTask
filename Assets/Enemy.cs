using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject deathEffect; // 파티클 시스템 프리팹을 참조할 변수

    void Start()
    {
        // EnemyManager가 아니라 EnemiesManager를 사용합니다.
        if (EnemiesManager.instance != null)
        {
            EnemiesManager.instance.enemies.Add(this); // 자신을 리스트에 추가
        }
    }

    void OnDestroy() // 적이 파괴될 때 리스트에서 제거
    {
        Debug.Log("Enemy is being destroyed.");

        // 적 파괴 시 파티클 이펙트 생성
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        if (EnemiesManager.instance != null)
        {
            EnemiesManager.instance.enemies.Remove(this);
            Debug.Log("Enemy removed from list. Remaining enemies: " + EnemiesManager.instance.enemies.Count);
        }
    }
}
