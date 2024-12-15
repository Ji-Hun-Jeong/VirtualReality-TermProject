using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRightRotate : CRotate
{
    public override void Rotate(Transform transform)
    {
        if (Input.GetKeyDown(KeyCode.E))
            transform.Rotate(Vector3.up, 90, Space.World);
    }
}
