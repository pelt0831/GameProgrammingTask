using System.Collections.Generic;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
    public static WavesManager instance;    // �̱��� �ν��Ͻ�
    public List<WaveSpawner> waves = new List<WaveSpawner>();   // ���� Ȱ��ȭ�� ��� ������ ����Ʈ

    private void Awake()
    {
        // �̱��� ���� ����
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);  // �ߺ��� �ν��Ͻ��� �������� �ʵ��� �ı�
        }
    }

    public int GetActiveWaveCount()
    {
        // ���� Ȱ��ȭ�� ���̺� ���� ��ȯ
        return waves.Count; // �����δ� Ȱ��ȭ�� ���̺��� ���¸� üũ�Ͽ� �� ���� �����ؾ� �� �� �ֽ��ϴ�.
    }
}
