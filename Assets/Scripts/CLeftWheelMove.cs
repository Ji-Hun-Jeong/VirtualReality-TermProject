using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLeftWheelMove : CMove
{
    public override float Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            return 2.0f * Time.deltaTime;
        }
        return 0.0f;
    }
}
