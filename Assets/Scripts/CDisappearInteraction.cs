using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDisappearInteraction : CInteraction
{
    public override void Interaction()
    {
        if (m_DisappearObject)
            Destroy(m_DisappearObject);
    }

    public GameObject m_DisappearObject = null;
}
