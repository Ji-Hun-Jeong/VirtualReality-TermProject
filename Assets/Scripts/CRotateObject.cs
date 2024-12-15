using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRotateObject : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        m_LeftRotate.Rotate(transform);
        m_RightRotate.Rotate(transform);

        m_RotateObject.transform.rotation = transform.rotation;
    }

    public CRotate m_LeftRotate = null;
    public CRotate m_RightRotate = null;

    public GameObject m_RotateObject = null;
}
