using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    private enum State
    {
        Idle,        // 대기 상태 (멈추는 시간)
        MoveToBase   // 기지로 이동 (이동 시간)
    }

    private State currentState;

    public float moveSpeed = 2f;  // 이동 속도
    public GameObject baseTarget;  // 기지 타겟 (GameObject로 변경)
    public float stopTime = 2f;   // 멈추는 시간
    public float moveTime = 3f;   // 이동하는 시간
    public float detectionRange = 1f; // 기지와의 거리 감지 범위

    private float stateTimer; // 상태 전환을 위한 타이머

    void Start()
    {
        //Debug.Log("EnemyFSM Start() 호출됨");

        // baseTarget이 수동으로 할당되지 않은 경우, 태그를 이용해 런타임에 찾음
        if (baseTarget == null)
        {
            baseTarget = GameObject.FindWithTag("BaseBoxCollider");  // "BaseBoxCollider" 태그를 가진 오브젝트를 찾음
            if (baseTarget != null)
            {
                Debug.Log("Base Target이 태그로 설정되었습니다: " + baseTarget.name);
            }
            else
            {
                Debug.LogError("씬에서 Base Target을 태그로 찾을 수 없습니다.");
            }
        }

        // 초기 상태 설정
        currentState = State.Idle;
        stateTimer = stopTime;
    }

    void Update()
    {
        // 현재 상태에 따라 행동 수행
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

    // 대기 상태 처리
    void HandleIdleState()
    {
        stateTimer -= Time.deltaTime;

        // 대기 시간이 끝나면 MoveToBase 상태로 전환
        if (stateTimer <= 0)
        {
            currentState = State.MoveToBase;
            stateTimer = moveTime; // 이동 시간 타이머 설정
        }
    }

    // 기지로 이동 상태 처리
    void HandleMoveToBaseState()
    {
        if (baseTarget == null)
        {
            Debug.LogError("Base Target이 할당되지 않았습니다.");
            return;
        }

        // 기지 방향으로 이동 (GameObject에서 Transform을 사용하여 위치로 접근)
        transform.position = Vector3.MoveTowards(transform.position, baseTarget.transform.position, moveSpeed * Time.deltaTime);

        // 이동 시간이 끝났는지 확인하고 Idle 상태로 전환
        stateTimer -= Time.deltaTime;

        if (stateTimer <= 0)
        {
            currentState = State.Idle;
            stateTimer = stopTime; // 멈추는 시간 타이머 설정
        }

        // 기지에 가까워졌을 때 대기 상태로 전환
        if (Vector3.Distance(transform.position, baseTarget.transform.position) <= detectionRange)
        {
            //Debug.Log("기지에 접근함");
            currentState = State.Idle;
        }
    }

    // 박스 콜라이더와 충돌 시 처리
    void OnTriggerEnter(Collider other)
    {
        // Collider의 타입을 체크해서 BoxCollider에만 반응
        BoxCollider boxCollider = other as BoxCollider;
        if (boxCollider != null)
        {
            //Debug.Log("박스 콜라이더에 닿음");
        }
    }
}
