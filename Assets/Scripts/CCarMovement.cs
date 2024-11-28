using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCarMovement : MonoBehaviour
{
    public float speed = 5f;           // �ڵ��� �ӵ�
    public float turnSpeed = 100f;     // ȸ�� �ӵ�
    public Transform[] waypoints;      // �׸� ����� �� �ڳʿ� ���� ����

    private int currentWaypointIndex = 0; // ���� ����� �ڳ� �ε���

    void Update()
    {
        // ��ǥ �������� �ڵ����� �̵�
        MoveAlongPath();
    }

    void MoveAlongPath()
    {
        if (waypoints.Length == 0) return;

        // ���� ��ǥ �������� �̵�
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = targetWaypoint.position - transform.position;

        // ������ ���� ȸ��
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

        // ��ǥ �������� �̵�
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // ��ǥ ������ ���������� ���� �������� �̵�
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}
