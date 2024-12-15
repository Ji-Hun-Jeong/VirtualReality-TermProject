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
}
