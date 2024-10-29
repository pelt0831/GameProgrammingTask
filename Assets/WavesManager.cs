using System.Collections.Generic;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
    public static WavesManager instance;  // 싱글톤 인스턴스
    public List<WaveSpawner> waves = new List<WaveSpawner>();   // 활성화된 모든 스포너 리스트

    private void Awake()
    {
        // 싱글톤 패턴 적용
        if (instance == null)
        {
            instance = this;
            Debug.Log("WavesManager instance created.");
        }
        else
        {
            Destroy(gameObject);  // 중복된 인스턴스가 생성되지 않도록 파괴
            Debug.LogError("Duplicated WavesManager, destroying this one.", gameObject);
        }
    }

    public int GetActiveWaveCount()
    {
        // 현재 활성화된 웨이브 수 반환
        return waves.Count;
    }

    // 웨이브 스포너가 종료될 때 호출되어 스포너를 리스트에서 제거
    public void RemoveWave(WaveSpawner waveSpawner)
    {
        if (waves.Contains(waveSpawner))
        {
            waves.Remove(waveSpawner);
            Debug.Log("Wave removed. Remaining waves: " + waves.Count);
        }
    }
}
