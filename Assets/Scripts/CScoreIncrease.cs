using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CScoreIncrease : CInteraction
{
    public override void Interaction()
    {
        m_Player.IncreaseScore();
    }

    public CPlayer m_Player = null;
}
