using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float baseSpeed = 5f; // 기본 속도
    private float currentSpeed; // 현재 속도
    public float rotationSpeed = 700f; // 회전 속도
    public float jumpForce = 5f;
    public float shiftMultiplier = 2f; // Shift 키 속도 배율
    public bool isGrounded = true; // 플레이어가 땅에 있는지 여부
    private Rigidbody rb;

    private bool isInBase = false; // Base 안에 있는지 여부

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>(); // Rigidbody 컴포넌트를 가져옴
        currentSpeed = baseSpeed; // 현재 속도 초기화
    }

    void Update()
    {
        // Shift 키로 이동 속도 조정
        float speedMultiplier = Input.GetKey(KeyCode.LeftShift) ? shiftMultiplier : 1f;

        // 베이스 안에 있을 경우 추가 속도 배율 적용
        if (isInBase)
        {
            speedMultiplier *= shiftMultiplier; // Base 안에서 Shift를 누르면 4배 속도
        }

        // 플레이어 이동
        MovePlayer(currentSpeed * speedMultiplier);
        RotatePlayer();

        // 점프 기능
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // 점프 시에는 땅에 있지 않음
        }
    }

    // 이동 속도를 수정하는 메서드
    public void ModifySpeed(float multiplier)
    {
        currentSpeed = baseSpeed * multiplier; // 속도 조정
        Debug.Log("현재 속도: " + currentSpeed);
    }

    // 플레이어 이동 처리
    void MovePlayer(float currentSpeed)
    {
        Vector3 moveDirection = Vector3.zero; // 초기 이동 방향

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection += transform.forward; // 전방
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection -= transform.forward; // 후방
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection -= transform.right; // 왼쪽
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection += transform.right; // 오른쪽
        }

        // 이동 속도를 적용하여 Rigidbody에 힘을 줌
        rb.MovePosition(rb.position + moveDirection * currentSpeed * Time.deltaTime);
    }

    // 플레이어 회전 처리
    void RotatePlayer()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0);
    }

    // 플레이어가 땅에 닿았는지 감지하는 함수
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // 땅에 닿았을 때만 점프 가능
        }
    }

    // 베이스 영역에 들어가면 호출되는 함수
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Base")) // Base 태그를 가진 오브젝트의 콜라이더에 닿으면
        {
            isInBase = true; // Base 안에 있음
            Debug.Log("Player가 Base 범위 안에 들어옴");
        }
    }

    // 베이스 영역에서 나가면 호출되는 함수
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Base")) // Base 태그를 가진 오브젝트의 콜라이더에서 나가면
        {
            isInBase = false; // Base 밖에 있음
            Debug.Log("Player가 Base 범위 밖으로 나감");
        }
    }
}
