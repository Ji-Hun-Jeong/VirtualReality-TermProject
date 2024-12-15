using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRightWheelMove : CMove
{
    // Start is called before the first frame update

    public override float Move() 
    {
        float force = 0.0f;
        if (Input.GetKey(KeyCode.RightArrow))
            force = m_MagnitudeOfForce;
        if (Input.GetKey(KeyCode.D))
            force = -m_MagnitudeOfForce;
        return force;
    }
}
