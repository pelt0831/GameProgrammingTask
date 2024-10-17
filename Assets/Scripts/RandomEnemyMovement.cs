using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float changeDirectionInterval = 2f; // ������ ������ �ð� ����
    private Vector3 movementDirection;

    void Start()
    {
        InvokeRepeating("ChangeDirection", 0, changeDirectionInterval); // ���� �ð����� ���� ����
    }

    void Update()
    {
        // ������ �������� �̵�
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);
    }

    void ChangeDirection()
    {
        // ���ο� ���� ���� ����
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        movementDirection = new Vector3(randomX, 0, randomZ).normalized; // ���� ���� ����
    }
}
