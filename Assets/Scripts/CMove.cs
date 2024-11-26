using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CMove : MonoBehaviour
{
    public abstract Vector3 Move(Vector3 frontDirection);

    protected float m_MagnitudeOfForce = 5.0f;
}
