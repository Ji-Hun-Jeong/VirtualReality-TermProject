using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CMove : MonoBehaviour
{
    public abstract float Move();

    public float m_MagnitudeOfForce = 10.0f;
}
