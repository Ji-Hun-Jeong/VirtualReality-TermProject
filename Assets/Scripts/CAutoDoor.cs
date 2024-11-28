using UnityEngine;

public class CAutoDoor : MonoBehaviour
{
    public Transform door1, door2, target; // 문 1, 문 2, 타겟(플레이어)
    public float openDistance = 5f;  // 문을 열 거리
    public float closeDistance = 5f; // 문을 닫을 거리
    public float speed = 2f;         // 문을 여는/닫는 속도
    public float moveDistance = 1.25f;  // 문이 이동할 거리

    private Vector3 initialPosition1, initialPosition2;
    private Vector3 openPosition1, openPosition2;

    private void Start()
    {
        initialPosition1 = door1.position;
        initialPosition2 = door2.position;
        openPosition1 = initialPosition1 + Vector3.left * moveDistance;
        openPosition2 = initialPosition2 + Vector3.right * moveDistance;
    }

    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        // 플레이어가 가까우면 문을 열고, 멀어지면 문을 닫음
        if (distance < openDistance)
        {
            // 문을 여는 함수
            door1.position = Vector3.Lerp(door1.position, openPosition1, Time.deltaTime * speed);
            door2.position = Vector3.Lerp(door2.position, openPosition2, Time.deltaTime * speed);
        }
        else if (distance > closeDistance)
        {
            // 문을 닫는 함수
            door1.position = Vector3.Lerp(door1.position, initialPosition1, Time.deltaTime * speed); // 문 1 원래 위치
            door2.position = Vector3.Lerp(door2.position, initialPosition2, Time.deltaTime * speed); // 문 2 원래 위치
        }
    }
}
