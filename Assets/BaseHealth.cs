using UnityEngine;
using UnityEngine.SceneManagement; // �� ��ȯ�� ���� �ʿ�

public class BaseHealth : MonoBehaviour
{
    public string loseSceneName = "LoseScreen"; // �й� �� ��ȯ�� �� �̸�

    void OnDestroy()
    {
        // �¸� ���°� �ƴ� ���� LoseScreen���� ��ȯ
        if (!WavesGameMode.hasWon)
        {
            Debug.Log("Base destroyed!"); // �ֿܼ� �ı� �޽��� ���
            SceneManager.LoadScene(loseSceneName); // LoseScreen ������ ��ȯ
        }
    }
}
