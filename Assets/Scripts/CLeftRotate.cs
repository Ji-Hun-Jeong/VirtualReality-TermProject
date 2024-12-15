using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CLeftRotate : CRotate
{
    public override void Rotate(Transform transform)
    {
        if (Input.GetKeyDown(KeyCode.Q))
            transform.Rotate(Vector3.up, -90, Space.World);
    }
}
