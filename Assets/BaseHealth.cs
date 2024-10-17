using UnityEngine;
using UnityEngine.SceneManagement; // 씬 전환을 위해 필요

public class BaseHealth : MonoBehaviour
{
    public string loseSceneName = "LoseScreen"; // 패배 시 전환할 씬 이름

    void OnDestroy()
    {
        // 승리 상태가 아닐 때만 LoseScreen으로 전환
        if (!WavesGameMode.hasWon)
        {
            Debug.Log("Base destroyed!"); // 콘솔에 파괴 메시지 출력
            SceneManager.LoadScene(loseSceneName); // LoseScreen 씬으로 전환
        }
    }
}
