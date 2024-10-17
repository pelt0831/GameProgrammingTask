using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // �⺻ �ӵ�
    private float currentSpeed; // ���� �ӵ�
    public float rotationSpeed = 700f; // ȸ�� �ӵ�
    public float jumpForce = 5f;
    public float shiftMultiplier = 2f;
    public bool isGrounded = true; // �÷��̾ ���� �ִ��� ����
    private Rigidbody rb;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>(); // Rigidbody ������Ʈ�� ������
        currentSpeed = speed; // ���� �ӵ� �ʱ�ȭ
    }

    void Update()
    {
        // �÷��̾� �̵�
        MovePlayer(currentSpeed);
        RotatePlayer();

        // ���� ���
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // ���� �ÿ��� ���� ���� ����
        }
    }

    // �̵� �ӵ��� �����ϴ� �޼���
    public void ModifySpeed(float multiplier)
    {
        currentSpeed = speed * multiplier; // �ӵ� ����
    }

    // �÷��̾� �̵� ó��
    void MovePlayer(float currentSpeed)
    {
        Vector3 moveDirection = Vector3.zero; // �ʱ� �̵� ����

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection += transform.forward; // ����
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection -= transform.forward; // �Ĺ�
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection -= transform.right; // ����
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection += transform.right; // ������
        }

        // �̵� �ӵ��� �����Ͽ� Rigidbody�� ���� ��
        rb.MovePosition(rb.position + moveDirection * currentSpeed * Time.deltaTime);
    }

    // �÷��̾� ȸ�� ó��
    void RotatePlayer()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0);
    }

    // �÷��̾ ���� ��Ҵ��� �����ϴ� �Լ�
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // ���� ����� ���� ���� ����
        }
    }
}
