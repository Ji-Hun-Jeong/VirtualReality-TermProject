using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CRotate : MonoBehaviour
{
    public abstract void Rotate(Transform transform);
    public float m_RotationForce = 50.0f;
}
