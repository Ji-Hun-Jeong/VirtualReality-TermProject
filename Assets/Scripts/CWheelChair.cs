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
        m_LeftSumOfForce += m_LeftMove.Move() - 1.0f * Time.deltaTime;
        m_RightSumOfForce += m_RightMove.Move() - 1.0f * Time.deltaTime;

        if (m_LeftSumOfForce < 0.0f)
            m_LeftSumOfForce = 0.0f;
        if (m_LeftSumOfForce > m_MaxSumOfForce)
            m_LeftSumOfForce = m_MaxSumOfForce;

        if (m_RightSumOfForce < 0.0f)
            m_RightSumOfForce = 0.0f;
        if (m_RightSumOfForce > m_MaxSumOfForce)
            m_RightSumOfForce = m_MaxSumOfForce;

        float axisAndOriginDist = Vector3.Distance(transform.position, m_LeftAxisLocation.transform.position);

        float moveForce = m_LeftSumOfForce > m_RightSumOfForce ? m_RightSumOfForce : m_LeftSumOfForce;
        float rotationDegree = m_LeftSumOfForce - m_RightSumOfForce;
        
        if (m_RequiredRotationForce < Mathf.Abs(rotationDegree))
        {
            if(moveForce < 3.0f)
            {
                transform.position = rotationDegree > 0 ? m_RightAxisLocation.transform.position
                                                    : m_LeftAxisLocation.transform.position;

                transform.Rotate(Vector3.up, rotationDegree * Time.deltaTime, Space.World);

                Vector3 returnDir = rotationDegree > 0 ? -transform.right : transform.right;

                transform.position += returnDir * axisAndOriginDist;
            }
        }

        transform.Translate(transform.forward * moveForce * Time.deltaTime);
    }

    public GameObject m_LeftAxisLocation = null;
    public GameObject m_RightAxisLocation = null;

    private Rigidbody m_RigidBody = null;
    private CMove m_LeftMove = null;
    private CMove m_RightMove = null;

    public float m_LeftSumOfForce = 0.0f;
    public float m_RightSumOfForce = 0.0f;
    private float m_MaxSumOfForce = 5.0f;
    private float m_RequiredRotationForce = 1.0f;

}
