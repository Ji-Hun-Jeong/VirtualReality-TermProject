using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCameraFix : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_MainCamera.transform.position = transform.position;
    }

    public GameObject m_MainCamera = null;
}
