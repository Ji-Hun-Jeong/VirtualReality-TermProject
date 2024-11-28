using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCarMovement : MonoBehaviour
{
    public float speed = 5f;           // 자동차 속도
    public float turnSpeed = 100f;     // 회전 속도
    public Transform[] waypoints;      // 네모난 경로의 각 코너에 대한 참조

    private int currentWaypointIndex = 0; // 현재 경로의 코너 인덱스

    void Update()
    {
        // 목표 지점으로 자동차를 이동
        MoveAlongPath();
    }

    void MoveAlongPath()
    {
        if (waypoints.Length == 0) return;

        // 현재 목표 지점으로 이동
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = targetWaypoint.position - transform.position;

        // 방향을 향해 회전
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

        // 목표 지점으로 이동
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // 목표 지점에 도달했으면 다음 지점으로 이동
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}
