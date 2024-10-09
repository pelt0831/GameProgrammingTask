using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpForce = 5f;
    public float shiftMultiplier = 2f;
    private bool isGrounded = true; // �÷��̾ ���� �ִ��� ���θ� Ȯ���ϱ� ���� ����
    private Rigidbody rb;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>(); // Rigidbody ������Ʈ�� �����ɴϴ�.
    }

    // Update is called once per frame
    void Update()
    {
        // �̵� �ӵ�: ����Ʈ Ű�� ������ 2�谡 ��
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? speed * shiftMultiplier : speed;

        // �÷��̾� �̵�
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

        // ���콺 ȸ��
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0);

        // ���� ���: �����̽��ٸ� ������, ���� ���� ���� ���� ����
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // ���� �� ���߿� �����Ƿ� false�� ����
        }
    }

    // �÷��̾ ���� ����� �� ���� (OnCollisionEnter ���)
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // ���� ����� �� ���� ���� ���·� ����
        }
    }

    // �÷��̾ ������ ��� �� ���� (OnCollisionExit ���)
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // ������ ����� ���� �Ұ��� ���·� ����
        }
    }
}
