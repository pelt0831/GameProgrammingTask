using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpForce = 5f;
    public float shiftMultiplier = 2f;
    private bool isGrounded = true; // 플레이어가 땅에 있는지 여부를 확인하기 위한 변수
    private Rigidbody rb;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>(); // Rigidbody 컴포넌트를 가져옵니다.
    }

    // Update is called once per frame
    void Update()
    {
        // 이동 속도: 쉬프트 키가 눌리면 2배가 됨
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? speed * shiftMultiplier : speed;

        // 플레이어 이동
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, currentSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -currentSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-currentSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(currentSpeed * Time.deltaTime, 0, 0);
        }

        // 마우스 회전
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0);

        // 점프 기능: 스페이스바를 눌렀고, 땅에 있을 때만 점프 가능
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // 점프 후 공중에 있으므로 false로 설정
        }
    }

    // 플레이어가 땅에 닿았을 때 감지 (OnCollisionEnter 사용)
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // 땅에 닿았을 때 점프 가능 상태로 변경
        }
    }

    // 플레이어가 땅에서 벗어날 때 감지 (OnCollisionExit 사용)
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // 땅에서 벗어나면 점프 불가능 상태로 변경
        }
    }
}
