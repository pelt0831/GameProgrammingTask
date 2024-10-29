using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    private enum State
    {
        Idle,        // ��� ���� (���ߴ� �ð�)
        MoveToBase   // ������ �̵� (�̵� �ð�)
    }

    private State currentState;

    public float moveSpeed = 2f;  // �̵� �ӵ�
    public GameObject baseTarget;  // ���� Ÿ�� (GameObject�� ����)
    public float stopTime = 2f;   // ���ߴ� �ð�
    public float moveTime = 3f;   // �̵��ϴ� �ð�
    public float detectionRange = 1f; // �������� �Ÿ� ���� ����

    private float stateTimer; // ���� ��ȯ�� ���� Ÿ�̸�

    void Start()
    {
        //Debug.Log("EnemyFSM Start() ȣ���");

        // baseTarget�� �������� �Ҵ���� ���� ���, �±׸� �̿��� ��Ÿ�ӿ� ã��
        if (baseTarget == null)
        {
            baseTarget = GameObject.FindWithTag("BaseBoxCollider");  // "BaseBoxCollider" �±׸� ���� ������Ʈ�� ã��
            if (baseTarget != null)
            {
                Debug.Log("Base Target�� �±׷� �����Ǿ����ϴ�: " + baseTarget.name);
            }
            else
            {
                Debug.LogError("������ Base Target�� �±׷� ã�� �� �����ϴ�.");
            }
        }

        // �ʱ� ���� ����
        currentState = State.Idle;
        stateTimer = stopTime;
    }

    void Update()
    {
        // ���� ���¿� ���� �ൿ ����
        switch (currentState)
        {
            case State.Idle:
                HandleIdleState();
                break;
            case State.MoveToBase:
                HandleMoveToBaseState();
                break;
        }
    }

    // ��� ���� ó��
    void HandleIdleState()
    {
        stateTimer -= Time.deltaTime;

        // ��� �ð��� ������ MoveToBase ���·� ��ȯ
        if (stateTimer <= 0)
        {
            currentState = State.MoveToBase;
            stateTimer = moveTime; // �̵� �ð� Ÿ�̸� ����
        }
    }

    // ������ �̵� ���� ó��
    void HandleMoveToBaseState()
    {
        if (baseTarget == null)
        {
            Debug.LogError("Base Target�� �Ҵ���� �ʾҽ��ϴ�.");
            return;
        }

        // ���� �������� �̵� (GameObject���� Transform�� ����Ͽ� ��ġ�� ����)
        transform.position = Vector3.MoveTowards(transform.position, baseTarget.transform.position, moveSpeed * Time.deltaTime);

        // �̵� �ð��� �������� Ȯ���ϰ� Idle ���·� ��ȯ
        stateTimer -= Time.deltaTime;

        if (stateTimer <= 0)
        {
            currentState = State.Idle;
            stateTimer = stopTime; // ���ߴ� �ð� Ÿ�̸� ����
        }

        // ������ ��������� �� ��� ���·� ��ȯ
        if (Vector3.Distance(transform.position, baseTarget.transform.position) <= detectionRange)
        {
            //Debug.Log("������ ������");
            currentState = State.Idle;
        }
    }

    // �ڽ� �ݶ��̴��� �浹 �� ó��
    void OnTriggerEnter(Collider other)
    {
        // Collider�� Ÿ���� üũ�ؼ� BoxCollider���� ����
        BoxCollider boxCollider = other as BoxCollider;
        if (boxCollider != null)
        {
            //Debug.Log("�ڽ� �ݶ��̴��� ����");
        }
    }
}
