using UnityEngine;
using UnityEngine.SceneManagement; // 씬 전환을 위해 필요

public class BaseHealth : MonoBehaviour
{
    public string loseSceneName = "LoseScreen"; // 패배 시 전환할 씬 이름
    public BoxCollider baseBoxCollider; // 베이스의 박스 콜라이더 참조

    void OnTriggerEnter(Collider other)
    {
        // 적 태그와 충돌했는지 확인
        if (other.CompareTag("Enemy"))
        {
            // 베이스의 박스 콜라이더와 충돌했는지 확인
            if (baseBoxCollider.bounds.Intersects(other.bounds))
            {
                Debug.Log("박스 콜라이더에 적이 닿음!");

                // 베이스 파괴
                Destroy(gameObject);

                // 패배 씬으로 전환, 승리한 경우 전환하지 않음
                if (!WavesGameMode.hasWon)
                {
                    Debug.Log("Base destroyed! Loading Lose Screen.");
                    SceneManager.LoadScene(loseSceneName);
                }
            }
            else
            {
                Debug.Log("박스 콜라이더와 충돌하지 않음");
            }
        }
    }
}
