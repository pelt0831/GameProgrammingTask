using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 10f; // �ڵ����� �̵� �ӵ�
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // Rigidbody�� Ű�׸�ƽ���� ����
    }

    void Update()
    {
        // Ű���� 'O' Ű�� ����
        if (Input.GetKey(KeyCode.O))
        {
            Vector3 forwardMovement = transform.forward * speed * Time.deltaTime;
            rb.MovePosition(transform.position + forwardMovement);
        }

        // Ű���� 'P' Ű�� ����
        if (Input.GetKey(KeyCode.P))
        {
            Vector3 backwardMovement = -transform.forward * speed * Time.deltaTime;
            rb.MovePosition(transform.position + backwardMovement);
        }
    }
}
