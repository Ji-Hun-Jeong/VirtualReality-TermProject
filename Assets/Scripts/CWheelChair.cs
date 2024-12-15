using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CWheelChair : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_FrontPointer.transform.position = transform.position;

        Vector3 frontDirection = m_FrontPointer.transform.forward;

        m_LeftWheelMove.Rotate(transform);
        m_RightWheelMove.Rotate(transform);

        frontDirection = m_FrontPointer.transform.forward;
        m_LeftForce = m_LeftWheelMove.Move(frontDirection);
        m_RightForce = m_RightWheelMove.Move(frontDirection);

        m_SumOfForce = m_LeftForce + m_RightForce;

        // 속도 비율에 따라 힘 조정
        float speedRatio = m_RigidBody.velocity.magnitude / m_MaxSpeed;
        Vector3 adjustedForce = m_SumOfForce * Mathf.Clamp(1f - speedRatio, 0f, 1f);

        m_RigidBody.AddForce(adjustedForce.magnitude * frontDirection);

        // 속도 제한
        /*if (m_RigidBody.velocity.magnitude > m_MaxSpeed)
            m_RigidBody.velocity = m_RigidBody.velocity.normalized * m_MaxSpeed;*/
    }


    public CMove m_LeftWheelMove = null;
    public CMove m_RightWheelMove = null;
    public GameObject m_FrontPointer = null;

    public Vector3 m_LeftForce = Vector3.zero;
    public Vector3 m_RightForce = Vector3.zero;
    public Vector3 m_SumOfForce = Vector3.zero;

    private Rigidbody m_RigidBody = null;
    private float m_MaxSpeed = 15.0f;
}
