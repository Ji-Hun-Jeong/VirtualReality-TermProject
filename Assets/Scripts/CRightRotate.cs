using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRightRotate : CRotate
{
    public override void Rotate(Transform transform)
    {
        if (Input.GetKey(KeyCode.E))
            transform.Rotate(Vector3.up, m_RotationForce * Time.deltaTime, Space.World);
    }
}
