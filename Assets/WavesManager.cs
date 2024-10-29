using System.Collections.Generic;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
    public static WavesManager instance;  // �̱��� �ν��Ͻ�
    public List<WaveSpawner> waves = new List<WaveSpawner>();   // Ȱ��ȭ�� ��� ������ ����Ʈ

    private void Awake()
    {
        // �̱��� ���� ����
        if (instance == null)
        {
            instance = this;
            Debug.Log("WavesManager instance created.");
        }
        else
        {
            Destroy(gameObject);  // �ߺ��� �ν��Ͻ��� �������� �ʵ��� �ı�
            Debug.LogError("Duplicated WavesManager, destroying this one.", gameObject);
        }
    }

    public int GetActiveWaveCount()
    {
        // ���� Ȱ��ȭ�� ���̺� �� ��ȯ
        return waves.Count;
    }

    // ���̺� �����ʰ� ����� �� ȣ��Ǿ� �����ʸ� ����Ʈ���� ����
    public void RemoveWave(WaveSpawner waveSpawner)
    {
        if (waves.Contains(waveSpawner))
        {
            waves.Remove(waveSpawner);
            Debug.Log("Wave removed. Remaining waves: " + waves.Count);
        }
    }
}
