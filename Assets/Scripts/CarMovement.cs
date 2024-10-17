using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 10f; // 자동차의 이동 속도
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // Rigidbody를 키네마틱으로 설정
    }

    void Update()
    {
        // 키보드 'O' 키로 전진
        if (Input.GetKey(KeyCode.O))
        {
            Vector3 forwardMovement = transform.forward * speed * Time.deltaTime;
            rb.MovePosition(transform.position + forwardMovement);
        }

        // 키보드 'P' 키로 후진
        if (Input.GetKey(KeyCode.P))
        {
            Vector3 backwardMovement = -transform.forward * speed * Time.deltaTime;
            rb.MovePosition(transform.position + backwardMovement);
        }
    }
}
