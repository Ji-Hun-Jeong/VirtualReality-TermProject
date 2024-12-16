using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameSystem : MonoBehaviour
{
    public void CheckComplete()
    {
        if(m_Player.GetScore() == m_ObjectCountOfComplete)
        {
            Debug.Log("¼º°ø!!");
        }
    }

    public CPlayer m_Player = null;

    private int m_ObjectCountOfComplete = 4;
}
