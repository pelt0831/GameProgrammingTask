using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WavesGameMode : MonoBehaviour
{
    public string winSceneName = "WinScreen"; // 승리 시 이동할 씬 이름
    public GameObject baseObject; // Base 오브젝트를 참조
    public static bool hasWon = false; // 승리 여부를 관리하는 변수

    void Update()
    {
        // Base가 파괴되지 않았고 승리 상태가 아닐 때만 승리 조건을 확인
        if (!hasWon && baseObject != null)
        {
            // 현재 남아있는 적과 웨이브의 수를 출력
            //Debug.Log("현재 남아있는 적 수: " + EnemiesManager.instance.enemies.Count);
            //Debug.Log("현재 활성화된 웨이브 수: " + WavesManager.instance.GetActiveWaveCount());

            // 적과 웨이브가 모두 0일 때 승리 처리
            if (EnemiesManager.instance.enemies.Count <= 0 && WavesManager.instance.GetActiveWaveCount() <= 0)
            {
                Debug.Log("모든 적과 웨이브가 사라졌습니다. Win() 호출 준비.");
                Win();
            }
            else
            {
                //Debug.Log("적이 남아있거나 웨이브가 아직 끝나지 않았습니다.");
            }
        }
    }

    void Win()
    {
        // 승리 상태로 변경
        hasWon = true;

        // 콘솔에 승리 메시지 출력
        Debug.Log("You have won the game!");

        // 씬 이름이 올바른지 확인 후 씬 전환 시도
        if (Application.CanStreamedLevelBeLoaded(winSceneName))
        {
            Debug.Log("WinScreen 씬이 로드됩니다.");
            SceneManager.LoadScene(winSceneName);
        }
        else
        {
            Debug.LogError("WinScreen 씬을 찾을 수 없습니다. 씬 이름 또는 빌드 설정을 확인하세요.");
        }
    }
}
