using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLeftControllerRotate : CRotate
{
    public override void Rotate(Transform transform)
    {
        if (OVRInput.Get(OVRInput.Button.Four) == false)
            return;
        Vector3 frontDir = new Vector3(0.0f, 0.0f, 1.0f);
        float rotateDegree = -(m_ControllerMove.m_SwingDir * m_ControllerMove.m_DistOfPos.magnitude 
            * m_RotationForce).magnitude;

        if (Vector3.Dot(m_ControllerMove.m_DistOfPos, frontDir) < 0)
            rotateDegree = -rotateDegree;

        transform.Rotate(Vector3.up, rotateDegree, Space.World);
    }

    public CControllerMove m_ControllerMove = null;
    public float m_RotationForce = 50.0f;
}
