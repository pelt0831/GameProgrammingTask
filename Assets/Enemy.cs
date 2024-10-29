using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject deathEffect; // ��ƼŬ �ý��� �������� ������ ����

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
        Debug.Log("Enemy is being destroyed.");

        // �� �ı� �� ��ƼŬ ����Ʈ ����
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
