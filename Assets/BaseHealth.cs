using UnityEngine;
using UnityEngine.SceneManagement; // �� ��ȯ�� ���� �ʿ�

public class BaseHealth : MonoBehaviour
{
    public string loseSceneName = "LoseScreen"; // �й� �� ��ȯ�� �� �̸�
    public BoxCollider baseBoxCollider; // ���̽��� �ڽ� �ݶ��̴� ����

    void OnTriggerEnter(Collider other)
    {
        // �� �±׿� �浹�ߴ��� Ȯ��
        if (other.CompareTag("Enemy"))
        {
            // ���̽��� �ڽ� �ݶ��̴��� �浹�ߴ��� Ȯ��
            if (baseBoxCollider.bounds.Intersects(other.bounds))
            {
                Debug.Log("�ڽ� �ݶ��̴��� ���� ����!");

                // ���̽� �ı�
                Destroy(gameObject);

                // �й� ������ ��ȯ, �¸��� ��� ��ȯ���� ����
                if (!WavesGameMode.hasWon)
                {
                    Debug.Log("Base destroyed! Loading Lose Screen.");
                    SceneManager.LoadScene(loseSceneName);
                }
            }
            else
            {
                Debug.Log("�ڽ� �ݶ��̴��� �浹���� ����");
            }
        }
    }
}
