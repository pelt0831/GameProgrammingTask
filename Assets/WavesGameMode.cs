using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �� ��ȯ�� ���� �߰�

public class WavesGameMode : MonoBehaviour
{
    public string winSceneName = "WinScreen"; // �¸� �� �̵��� �� �̸�
    public GameObject baseObject; // Base ������Ʈ�� ����
    public static bool hasWon = false; // �¸� ���θ� �����ϴ� ����

    void Update()
    {
        // Base�� �ı����� �ʾҰ� �¸� ���°� �ƴ� ���� �¸� ������ Ȯ��
        if (!hasWon && baseObject != null && EnemiesManager.instance.enemies.Count <= 0 && WavesManager.instance.GetActiveWaveCount() <= 0)
        {
            Win();
        }
    }

    void Win()
    {
        // �ֿܼ� �¸� �޽��� ���
        Debug.Log("You have won the game!");

        // �¸� ���·� ����
        hasWon = true;

        // �¸� ������ ��ȯ (WinScreen)
        SceneManager.LoadScene(winSceneName);
    }
}
