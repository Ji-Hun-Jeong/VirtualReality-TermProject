using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTestMoving : MonoBehaviour
{
    public float moveSpeed = 5.0f;      // �̵� �ӵ�
    private Rigidbody rb;               // Rigidbody ������Ʈ ���� ����
    public bool canMove = true;        // �̵� ���� ����

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Rigidbody ������Ʈ ����
    }

    // Update is called once per frame
    void Update()
    {
        // `canMove`�� true�� ���� �̵�
        if (canMove)
        {
            // �Է��� ���� ������ �������� �̵�
            float moveX = 0f;
            float moveZ = 0f;

            // W, A, S, D Ű �Է��� �޾Ƽ� �̵� ���� ����
            if (Input.GetKey(KeyCode.W))  // W Ű�� ������ ����
            {
                moveZ = -1f;
            }
            if (Input.GetKey(KeyCode.S))  // S Ű�� ������ ����
            {
                moveZ = +1f;
            }
            if (Input.GetKey(KeyCode.A))  // A Ű�� ������ ��������
            {
                moveX = +1f;
            }
            if (Input.GetKey(KeyCode.D))  // D Ű�� ������ ����������
            {
                moveX = -1f;
            }

            // �̵� ���� ���� ����
            Vector3 moveDirection = new Vector3(moveX, 0f, moveZ); // y���� 0���� ����

            // Rigidbody�� ���� �߰��Ͽ� �̵� (������ �̵�)
            rb.AddForce(moveDirection * moveSpeed, ForceMode.Force);
        }
    }

    public void SetCanMove(bool move)
    {
        canMove = move;
    }
}
