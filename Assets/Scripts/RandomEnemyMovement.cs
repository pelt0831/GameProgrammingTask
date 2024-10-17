using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float changeDirectionInterval = 2f; // 방향을 변경할 시간 간격
    private Vector3 movementDirection;

    void Start()
    {
        InvokeRepeating("ChangeDirection", 0, changeDirectionInterval); // 일정 시간마다 방향 변경
    }

    void Update()
    {
        // 랜덤한 방향으로 이동
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);
    }

    void ChangeDirection()
    {
        // 새로운 랜덤 방향 설정
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        movementDirection = new Vector3(randomX, 0, randomZ).normalized; // 랜덤 방향 벡터
    }
}
