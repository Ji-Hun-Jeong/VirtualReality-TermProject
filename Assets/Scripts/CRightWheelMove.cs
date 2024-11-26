using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRightWheelMove : CMove
{
    // Start is called before the first frame update

    public override float Move() 
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            return 2.0f * Time.deltaTime;
        }
        return 0.0f;
    }
}
