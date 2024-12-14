using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTestFlow : MonoBehaviour
{
    public Transform targetPosition;    // ��ǥ ���� (Transform)
    public GameObject guidePrefab;      // �ȳ� �޽��� ������
    public float stopDistance = 2.0f;   // ��ǥ �������� �Ÿ� ���̰� �� �� ���ϰ� �Ǹ� ���߱�
    public float guideOffset = 2.0f;    // movementController�� ��ġ�� ������ (������ �󸶳� ����߸���)

    private GameObject guideInstance;
    public CTestMoving movementController;

    // Start is called before the first frame update
    void Start()
    {
        if (movementController == null)
        {
            Debug.LogError("CTestMoving �����ͳ�Ʈ�� �Ҵ���� �ʾҽ��ϴ�.");
        }

        if (guidePrefab == null)
        {
            Debug.LogError("Guide Prefab�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }

    void Update()
    {
        if (movementController != null && guidePrefab != null)
        {
            // ��ǥ �������� �Ÿ� ���̰� stopDistance ������ ��
            if (Vector3.Distance(transform.position, targetPosition.position) < stopDistance)
            {
                // guideInstance�� ������ ���ο� guidePrefab �ν��Ͻ��� ����
                if (guideInstance == null)
                {
                    guideInstance = Instantiate(guidePrefab, transform.position + new Vector3(0, 2, 0), Quaternion.Euler(90f, 0f, 0f));
                }

                // movementController�� ��ġ�� �� ��ũ��Ʈ�� ������ ������Ʈ�� �������� �̵�
                movementController.transform.position = transform.position + transform.forward * guideOffset;

                movementController.transform.LookAt(transform);

                // Rigidbody�� velocity�� 0���� �����Ͽ� �̵� ���߱�
                Rigidbody rb = movementController.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = Vector3.zero;  // �ӵ��� 0���� ����
                }

                movementController.SetCanMove(false);  // �̵� �Ұ� ����

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
