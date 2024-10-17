using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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
        if (EnemiesManager.instance != null)
        {
            EnemiesManager.instance.enemies.Remove(this);
        }
    }
}
