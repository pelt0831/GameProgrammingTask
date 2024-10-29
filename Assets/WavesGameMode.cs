using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WavesGameMode : MonoBehaviour
{
    public string winSceneName = "WinScreen"; // �¸� �� �̵��� �� �̸�
    public GameObject baseObject; // Base ������Ʈ�� ����
    public static bool hasWon = false; // �¸� ���θ� �����ϴ� ����

    void Update()
    {
        // Base�� �ı����� �ʾҰ� �¸� ���°� �ƴ� ���� �¸� ������ Ȯ��
        if (!hasWon && baseObject != null)
        {
            // ���� �����ִ� ���� ���̺��� ���� ���
            //Debug.Log("���� �����ִ� �� ��: " + EnemiesManager.instance.enemies.Count);
            //Debug.Log("���� Ȱ��ȭ�� ���̺� ��: " + WavesManager.instance.GetActiveWaveCount());

            // ���� ���̺갡 ��� 0�� �� �¸� ó��
            if (EnemiesManager.instance.enemies.Count <= 0 && WavesManager.instance.GetActiveWaveCount() <= 0)
            {
                Debug.Log("��� ���� ���̺갡 ��������ϴ�. Win() ȣ�� �غ�.");
                Win();
            }
            else
            {
                //Debug.Log("���� �����ְų� ���̺갡 ���� ������ �ʾҽ��ϴ�.");
            }
        }
    }

    void Win()
    {
        // �¸� ���·� ����
        hasWon = true;

        // �ֿܼ� �¸� �޽��� ���
        Debug.Log("You have won the game!");

        // �� �̸��� �ùٸ��� Ȯ�� �� �� ��ȯ �õ�
        if (Application.CanStreamedLevelBeLoaded(winSceneName))
        {
            Debug.Log("WinScreen ���� �ε�˴ϴ�.");
            SceneManager.LoadScene(winSceneName);
        }
        else
        {
            Debug.LogError("WinScreen ���� ã�� �� �����ϴ�. �� �̸� �Ǵ� ���� ������ Ȯ���ϼ���.");
        }
    }
}
