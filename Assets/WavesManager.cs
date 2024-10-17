using System.Collections.Generic;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
    public static WavesManager instance;    // 싱글톤 인스턴스
    public List<WaveSpawner> waves = new List<WaveSpawner>();   // 현재 활성화된 모든 스포너 리스트

    private void Awake()
    {
        // 싱글톤 패턴 적용
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);  // 중복된 인스턴스가 생성되지 않도록 파괴
        }
    }

    public int GetActiveWaveCount()
    {
        // 현재 활성화된 웨이브 수를 반환
        return waves.Count; // 실제로는 활성화된 웨이브의 상태를 체크하여 이 값을 조정해야 할 수 있습니다.
    }
}
