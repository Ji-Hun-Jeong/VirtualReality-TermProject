using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTestMoving : MonoBehaviour
{
    public float moveSpeed = 5.0f;      // 이동 속도
    private Rigidbody rb;               // Rigidbody 컴포넌트 저장 변수
    public bool canMove = true;        // 이동 가능 여부

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Rigidbody 컴포넌트 참조
    }

    // Update is called once per frame
    void Update()
    {
        // `canMove`가 true일 때만 이동
        if (canMove)
        {
            // 입력을 받은 방향을 기준으로 이동
            float moveX = 0f;
            float moveZ = 0f;

            // W, A, S, D 키 입력을 받아서 이동 방향 결정
            if (Input.GetKey(KeyCode.W))  // W 키를 누르면 전진
            {
                moveZ = -1f;
            }
            if (Input.GetKey(KeyCode.S))  // S 키를 누르면 후진
            {
                moveZ = +1f;
            }
            if (Input.GetKey(KeyCode.A))  // A 키를 누르면 왼쪽으로
            {
                moveX = +1f;
            }
            if (Input.GetKey(KeyCode.D))  // D 키를 누르면 오른쪽으로
            {
                moveX = -1f;
            }

            // 이동 방향 벡터 생성
            Vector3 moveDirection = new Vector3(moveX, 0f, moveZ); // y축은 0으로 설정

            // Rigidbody에 힘을 추가하여 이동 (물리적 이동)
            rb.AddForce(moveDirection * moveSpeed, ForceMode.Force);
        }
    }

    public void SetCanMove(bool move)
    {
        canMove = move;
    }
}
