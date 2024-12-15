using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMoveObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_MoveObject.transform.position = transform.position;

        Vector3 frontDirection = m_MoveObject.transform.forward;

        m_LeftForce = m_LeftWheelMove.Move();
        m_RightForce = m_RightWheelMove.Move();

        m_SumOfForce = m_LeftForce + m_RightForce;

        m_RigidBody.AddForce(frontDirection * m_SumOfForce);
    }


    public CMove m_LeftWheelMove = null;
    public CMove m_RightWheelMove = null;

    public float m_LeftForce = 0.0f;
    public float m_RightForce = 0.0f;
    public float m_SumOfForce = 0.0f;

    private Rigidbody m_RigidBody = null;

    public GameObject m_MoveObject = null;
}
