using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpeedBoost : MonoBehaviour
{
    public float speedMultiplier = 1.5f; // 이동 속도 증가 배율
    public float boostRadius = 5f; // Base 주변 반경

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어가 범위 안에 들어오면
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.ModifySpeed(speedMultiplier); // 이동 속도 증가
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어가 범위를 벗어나면
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.ModifySpeed(1f / speedMultiplier); // 원래 속도로 복원
            }
        }
    }
}
