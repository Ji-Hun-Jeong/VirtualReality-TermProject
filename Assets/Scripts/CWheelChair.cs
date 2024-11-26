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
        // �����ӵ� ���Ϸ� �������� ���߱�
        if (m_RigidBody.velocity.magnitude < 0.05f)
            m_RigidBody.velocity = Vector3.zero;

        // ���� ���� GameObject�� ��ġ�� �����ֱ�
        m_FrontPointer.transform.position = transform.position;

        Vector3 frontDirection = m_FrontPointer.transform.forward;

        // �� �����Ӵ� �������� �� ���ϱ�
        m_LeftForce = m_LeftMove.Move(frontDirection);
        m_RightForce = m_RightMove.Move(frontDirection);

        // �� ���� ���� �̹� �����ӿ� �������� ���� ������ ������� �˾Ƴ���
        m_SumOfForce = m_LeftForce + m_RightForce;

        Vector3 moveDirection = m_SumOfForce.normalized;

        float magnitudeOfLeftForce = m_LeftForce.magnitude;
        float magnitudeOfRightForce = m_RightForce.magnitude;

        // �� ���� ũ���� �� ���� ���� ũ�⸸ŭ�� �̵��� ���
        float moveForce = magnitudeOfLeftForce > magnitudeOfRightForce ? magnitudeOfRightForce
                                                                       : magnitudeOfLeftForce;

        // �� ���� ũ���� �� ��ŭ�� ȸ���� ���
        float rotationDegree = magnitudeOfLeftForce - magnitudeOfRightForce;

        // �ؿ��� ���� ��ü� �����߽����� ȸ���ϱ� ���� �ڵ�
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

        // �̵����⿡ �̵��� ����� ���� ���� ������
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
