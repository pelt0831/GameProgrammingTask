using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float baseSpeed = 5f; // �⺻ �ӵ�
    private float currentSpeed; // ���� �ӵ�
    public float rotationSpeed = 700f; // ȸ�� �ӵ�
    public float jumpForce = 5f;
    public float shiftMultiplier = 2f; // Shift Ű �ӵ� ����
    public bool isGrounded = true; // �÷��̾ ���� �ִ��� ����
    private Rigidbody rb;

    private bool isInBase = false; // Base �ȿ� �ִ��� ����

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>(); // Rigidbody ������Ʈ�� ������
        currentSpeed = baseSpeed; // ���� �ӵ� �ʱ�ȭ
    }

    void Update()
    {
        // Shift Ű�� �̵� �ӵ� ����
        float speedMultiplier = Input.GetKey(KeyCode.LeftShift) ? shiftMultiplier : 1f;

        // ���̽� �ȿ� ���� ��� �߰� �ӵ� ���� ����
        if (isInBase)
        {
            speedMultiplier *= shiftMultiplier; // Base �ȿ��� Shift�� ������ 4�� �ӵ�
        }

        // �÷��̾� �̵�
        MovePlayer(currentSpeed * speedMultiplier);
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
        currentSpeed = baseSpeed * multiplier; // �ӵ� ����
        Debug.Log("���� �ӵ�: " + currentSpeed);
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

    // ���̽� ������ ���� ȣ��Ǵ� �Լ�
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Base")) // Base �±׸� ���� ������Ʈ�� �ݶ��̴��� ������
        {
            isInBase = true; // Base �ȿ� ����
            Debug.Log("Player�� Base ���� �ȿ� ����");
        }
    }

    // ���̽� �������� ������ ȣ��Ǵ� �Լ�
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Base")) // Base �±׸� ���� ������Ʈ�� �ݶ��̴����� ������
        {
            isInBase = false; // Base �ۿ� ����
            Debug.Log("Player�� Base ���� ������ ����");
        }
    }
}
