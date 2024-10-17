using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject prefab;    // 스폰할 enemy 프리팹
    public float startTime;      // 스폰 시작 시간
    public float endTime;        // 스폰 종료 시간
    public float spawnRate;      // 스폰 간격
    public float spawnRange = 10f; // 스폰 범위(랜덤 위치 범위)

    private void Start()
    {
        // WavesManager에 현재 스포너를 등록
        WavesManager.instance.waves.Add(this);

        // 스폰 시작
        InvokeRepeating("Spawn", startTime, spawnRate);

        // 스폰 종료 시간 설정
        Invoke("EndSpawner", endTime);
    }

    void Spawn()
    {
        // 랜덤한 위치 계산
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnRange, spawnRange),
            0, // y축 고정 (적의 높이는 그대로)
            Random.Range(-spawnRange, spawnRange)
        );

        // 스폰 위치 설정 (현재 오브젝트의 위치를 기준으로 랜덤 오프셋)
        Vector3 spawnPosition = transform.position + randomPosition;

        // 적 생성
        Instantiate(prefab, spawnPosition, transform.rotation);
    }

    // 스폰 종료 함수
    void EndSpawner()
    {
        // WavesManager에서 현재 스포너를 제거
        WavesManager.instance.waves.Remove(this);
        CancelInvoke();  // 스폰 중단
    }

    void Update()
    {
        // 필요 시 업데이트 로직 추가 가능
    }
}
