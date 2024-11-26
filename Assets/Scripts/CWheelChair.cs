using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CWheelChair : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        m_LeftMove = new CLeftWheelMove();
        m_RightMove = new CRightWheelMove();

        m_RigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 일정속도 이하로 떨어지면 멈추기
        if (m_RigidBody.velocity.magnitude < 0.05f)
            m_RigidBody.velocity = Vector3.zero;

        // 앞을 위한 GameObject의 위치를 맞춰주기
        m_FrontPointer.transform.position = transform.position;

        Vector3 frontDirection = m_FrontPointer.transform.forward;

        // 한 프레임당 가해지는 힘 구하기
        m_LeftForce = m_LeftMove.Move(frontDirection);
        m_RightForce = m_RightMove.Move(frontDirection);

        // 두 힘을 더해 이번 프레임에 가해지는 힘의 방향이 어디인지 알아내기
        m_SumOfForce = m_LeftForce + m_RightForce;

        Vector3 moveDirection = m_SumOfForce.normalized;

        float magnitudeOfLeftForce = m_LeftForce.magnitude;
        float magnitudeOfRightForce = m_RightForce.magnitude;

        // 두 힘의 크기중 더 작은 힘의 크기만큼을 이동에 사용
        float moveForce = magnitudeOfLeftForce > magnitudeOfRightForce ? magnitudeOfRightForce
                                                                       : magnitudeOfLeftForce;

        // 두 힘의 크기의 차 만큼을 회전에 사용
        float rotationDegree = magnitudeOfLeftForce - magnitudeOfRightForce;

        // 밑에는 전부 휠체어를 바퀴중심으로 회전하기 위한 코드
        {
            float axisAndOriginDist = Vector3.Distance(transform.position, m_LeftAxisLocation.transform.position);

            transform.position = rotationDegree > 0 ? m_RightAxisLocation.transform.position
                                                : m_LeftAxisLocation.transform.position;

            if (Vector3.Dot(moveDirection, frontDirection) >= 0)
                transform.Rotate(Vector3.up, rotationDegree * 0.2f, Space.World);
            else
                transform.Rotate(Vector3.up, -rotationDegree * 0.2f, Space.World);


            Vector3 returnDir = rotationDegree > 0 ? -transform.right : transform.right;

            transform.position += returnDir * axisAndOriginDist;
        }

        // 이동방향에 이동에 사용할 힘을 곱해 더해줌
        m_RigidBody.AddForce(moveDirection * moveForce);
    }

    public GameObject m_FrontPointer = null;
    public GameObject m_LeftAxisLocation = null;
    public GameObject m_RightAxisLocation = null;

    private Rigidbody m_RigidBody = null;
    private CMove m_LeftMove = null;
    private CMove m_RightMove = null;

    public Vector3 m_LeftForce = Vector3.zero;
    public Vector3 m_RightForce = Vector3.zero;
    public Vector3 m_SumOfForce = Vector3.zero;
}
