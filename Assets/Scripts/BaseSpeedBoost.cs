using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpeedBoost : MonoBehaviour
{
    public float speedMultiplier = 1.5f; // �̵� �ӵ� ���� ����
    public float boostRadius = 5f; // Base �ֺ� �ݰ�

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �÷��̾ ���� �ȿ� ������
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.ModifySpeed(speedMultiplier); // �̵� �ӵ� ����
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // �÷��̾ ������ �����
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.ModifySpeed(1f / speedMultiplier); // ���� �ӵ��� ����
            }
        }
    }
}
