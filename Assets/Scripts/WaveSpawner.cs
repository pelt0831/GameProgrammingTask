using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject prefab;    // ������ enemy ������
    public float startTime;      // ���� ���� �ð�
    public float endTime;        // ���� ���� �ð�
    public float spawnRate;      // ���� ����
    public float spawnRange = 10f; // ���� ����(���� ��ġ ����)

    private void Start()
    {
        // WavesManager�� ���� �����ʸ� ���
        WavesManager.instance.waves.Add(this);

        // ���� ����
        InvokeRepeating("Spawn", startTime, spawnRate);

        // ���� ���� �ð� ����
        Invoke("EndSpawner", endTime);
    }

    void Spawn()
    {
        // ������ ��ġ ���
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnRange, spawnRange),
            0, // y�� ���� (���� ���̴� �״��)
            Random.Range(-spawnRange, spawnRange)
        );

        // ���� ��ġ ���� (���� ������Ʈ�� ��ġ�� �������� ���� ������)
        Vector3 spawnPosition = transform.position + randomPosition;

        // �� ����
        Instantiate(prefab, spawnPosition, transform.rotation);
    }

    // ���� ���� �Լ�
    void EndSpawner()
    {
        // WavesManager���� ���� �����ʸ� ����
        WavesManager.instance.waves.Remove(this);
        CancelInvoke();  // ���� �ߴ�
    }

    void Update()
    {
        // �ʿ� �� ������Ʈ ���� �߰� ����
    }
}
