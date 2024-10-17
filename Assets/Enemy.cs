using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Start()
    {
        // EnemyManager�� �ƴ϶� EnemiesManager�� ����մϴ�.
        if (EnemiesManager.instance != null)
        {
            EnemiesManager.instance.enemies.Add(this); // �ڽ��� ����Ʈ�� �߰�
        }
    }

    void OnDestroy() // ���� �ı��� �� ����Ʈ���� ����
    {
        if (EnemiesManager.instance != null)
        {
            EnemiesManager.instance.enemies.Remove(this);
        }
    }
}
