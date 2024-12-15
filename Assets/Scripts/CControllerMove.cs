using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CControllerMove : CMove
{
    public override Vector3 Move(Vector3 frontDirection)
    {
        // 이전 컨트롤러 위치 저장
        m_PrevControllerPos = m_CurControllerPos;

        // 현재 컨트롤러 위치 갱신
        m_CurControllerPos = getCurControllerPos();

        Vector3 frontDir = new Vector3(0.0f, 0.0f, 1.0f);

        // 컨트롤러 이동 벡터 계산
        m_DistOfPos = m_CurControllerPos - m_PrevControllerPos;

        // 컨트롤러 이동 방향 계산
        m_SwingDir = m_DistOfPos.normalized;

        if (isPressedMoveButton() == false)
            return Vector3.zero;

        // 컨트롤러 이동 방향과 전방 방향 비교
        if (Vector3.Dot(frontDir, m_SwingDir) > 0)
            frontDir = -frontDirection;
        else
            frontDir = frontDirection;

        // 최종 힘 반환
        return frontDir * m_DistOfPos.magnitude * m_MagnitudeOfForce;
    }

    protected abstract Vector3 getCurControllerPos();
    protected abstract bool isPressedMoveButton();

    public float m_RotationForce = 0.0f;
    public Vector3 m_DistOfPos = Vector3.zero;
    public Vector3 m_CurControllerPos = Vector3.zero;
    public Vector3 m_PrevControllerPos = Vector3.zero;
    public Vector3 m_SwingDir = Vector3.zero;
}
