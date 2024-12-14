using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTestFlow : MonoBehaviour
{
    public Transform targetPosition;    // 목표 지점 (Transform)
    public GameObject guidePrefab;      // 안내 메시지 프리팹
    public float stopDistance = 2.0f;   // 목표 지점과의 거리 차이가 이 값 이하가 되면 멈추기
    public float guideOffset = 2.0f;    // movementController가 위치할 오프셋 (앞으로 얼마나 떨어뜨릴지)

    private GameObject guideInstance;
    public CTestMoving movementController;

    // Start is called before the first frame update
    void Start()
    {
        if (movementController == null)
        {
            Debug.LogError("CTestMoving 컴포넌넌트가 할당되지 않았습니다.");
        }

        if (guidePrefab == null)
        {
            Debug.LogError("Guide Prefab이 할당되지 않았습니다.");
        }
    }

    void Update()
    {
        if (movementController != null && guidePrefab != null)
        {
            // 목표 지점과의 거리 차이가 stopDistance 이하일 때
            if (Vector3.Distance(transform.position, targetPosition.position) < stopDistance)
            {
                // guideInstance가 없으면 새로운 guidePrefab 인스턴스를 생성
                if (guideInstance == null)
                {
                    guideInstance = Instantiate(guidePrefab, transform.position + new Vector3(0, 2, 0), Quaternion.Euler(90f, 0f, 0f));
                }

                // movementController의 위치를 이 스크립트가 부착된 오브젝트의 앞쪽으로 이동
                movementController.transform.position = transform.position + transform.forward * guideOffset;

                movementController.transform.LookAt(transform);

                // Rigidbody의 velocity를 0으로 설정하여 이동 멈추기
                Rigidbody rb = movementController.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = Vector3.zero;  // 속도를 0으로 설정
                }

                movementController.SetCanMove(false);  // 이동 불가 설정

                if (!movementController.canMove && Input.GetKeyDown(KeyCode.Q))
                {
                    movementController.SetCanMove(true);
                    Destroy(guideInstance);
                    Destroy(gameObject);
                }
            }
        }
    }
}
