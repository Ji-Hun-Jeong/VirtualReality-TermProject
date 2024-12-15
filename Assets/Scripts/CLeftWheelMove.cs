using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLeftWheelMove : CMove
{
    public override float Move()
    {
        float force = 0.0f;
        if (Input.GetKey(KeyCode.LeftArrow))
            force = m_MagnitudeOfForce;
        if (Input.GetKey(KeyCode.A))
            force = -m_MagnitudeOfForce;
        return force;
    }
}
