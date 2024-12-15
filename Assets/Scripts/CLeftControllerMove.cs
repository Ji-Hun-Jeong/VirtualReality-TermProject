using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLeftControllerMove : CControllerMove
{
    protected override Vector3 getCurControllerPos()
    {
        return OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
    }
    protected override bool isPressedMoveButton()
    {
        return OVRInput.Get(OVRInput.Button.Three);
    }
    public override void Rotate(Transform transform)
    {
        if (OVRInput.Get(OVRInput.Button.Four) == false)
            return;
        Vector3 frontDir = new Vector3(0.0f, 0.0f, 1.0f);
        float rotateDegree = -(m_SwingDir * m_DistOfPos.magnitude * m_RotationForce).magnitude;

        if (Vector3.Dot(m_DistOfPos, frontDir) < 0)
            rotateDegree = -rotateDegree;

        transform.Rotate(Vector3.up, rotateDegree, Space.World);
    }
}
