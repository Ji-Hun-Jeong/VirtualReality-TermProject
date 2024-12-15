using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRightControllerMove : CControllerMove
{
    protected override Vector3 getCurControllerPos()
    {
        return OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
    }
    protected override bool isPressedMoveButton()
    {
        return OVRInput.Get(OVRInput.Button.One);
    }

}
