using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CControllerMove : CMove
{
    public override float Move()
    { 
        // ���� ��Ʈ�ѷ� ��ġ ����
        m_PrevControllerPos = m_CurControllerPos;

        // ���� ��Ʈ�ѷ� ��ġ ����
        m_CurControllerPos = getCurControllerPos();

        Vector3 frontDir = new Vector3(0.0f, 0.0f, 1.0f);

        // ��Ʈ�ѷ� �̵� ���� ���
        m_DistOfPos = m_CurControllerPos - m_PrevControllerPos;

        // ��Ʈ�ѷ� �̵� ���� ���
        m_SwingDir = m_DistOfPos.normalized;

        if (isPressedMoveButton() == false)
            return 0;

        float force = m_DistOfPos.magnitude * m_MagnitudeOfForce * 10.0f;
        // ��Ʈ�ѷ� �̵� ����� ���� ���� ��
        if (Vector3.Dot(frontDir, m_SwingDir) > 0)
            force = -force;

        return force;
    }

    protected abstract Vector3 getCurControllerPos();
    protected abstract bool isPressedMoveButton();

    public Vector3 m_DistOfPos = Vector3.zero;
    public Vector3 m_CurControllerPos = Vector3.zero;
    public Vector3 m_PrevControllerPos = Vector3.zero;
    public Vector3 m_SwingDir = Vector3.zero;
}
