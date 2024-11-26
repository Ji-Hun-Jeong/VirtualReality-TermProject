using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLeftWheelMove : CMove
{
    public override Vector3 Move(Vector3 frontDirection)
    {
        float force = 0.0f;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            force = m_MagnitudeOfForce;
        if (Input.GetKeyDown(KeyCode.A))
            force = -m_MagnitudeOfForce;
        return frontDirection * force;
    }
}
