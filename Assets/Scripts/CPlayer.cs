using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore() { m_Score += 1; Debug.Log(m_Score); }
    public int GetScore() { return m_Score; }

    private int m_Score = 0;
}
