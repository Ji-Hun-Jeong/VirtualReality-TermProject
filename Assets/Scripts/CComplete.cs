using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CComplete : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PLAYER")
        {
            m_GameSystem.CheckComplete();
        }
    }

    public CGameSystem m_GameSystem = null;
}
