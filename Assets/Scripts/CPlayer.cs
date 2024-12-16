using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : MonoBehaviour
{
    public CMissionManager MissionManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore() { 
        m_Score += 1;
        MissionManager.missionNext();
    }
    public int GetScore() { return MissionManager.itemCount; }

    public int m_Score = 0;
}
