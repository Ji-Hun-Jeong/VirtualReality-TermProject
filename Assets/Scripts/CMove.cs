using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CMove : MonoBehaviour
{
    public abstract Vector3 Move(Vector3 frontDirection);
    public virtual void Rotate(Transform transform)
    {
        
    }

    public float m_MagnitudeOfForce = 0.0f;
}
