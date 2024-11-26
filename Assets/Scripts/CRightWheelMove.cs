using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRightWheelMove : CMove
{
    // Start is called before the first frame update

    public override Vector3 Move(Vector3 frontDirection) 
    {
        float force = 0.0f;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            force = m_MagnitudeOfForce;
        if (Input.GetKeyDown(KeyCode.D))
            force = -m_MagnitudeOfForce;
        return frontDirection * force;
    }
}
