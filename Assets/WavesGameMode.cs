using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬 전환을 위해 추가

public class WavesGameMode : MonoBehaviour
{
    public string winSceneName = "WinScreen"; // 승리 시 이동할 씬 이름
    public GameObject baseObject; // Base 오브젝트를 참조
    public static bool hasWon = false; // 승리 여부를 관리하는 변수

    void Update()
    {
        // Base가 파괴되지 않았고 승리 상태가 아닐 때만 승리 조건을 확인
        if (!hasWon && baseObject != null && EnemiesManager.instance.enemies.Count <= 0 && WavesManager.instance.GetActiveWaveCount() <= 0)
        {
            Win();
        }
    }

    void Win()
    {
        // 콘솔에 승리 메시지 출력
        Debug.Log("You have won the game!");

        // 승리 상태로 변경
        hasWon = true;

        // 승리 씬으로 전환 (WinScreen)
        SceneManager.LoadScene(winSceneName);
    }
}
