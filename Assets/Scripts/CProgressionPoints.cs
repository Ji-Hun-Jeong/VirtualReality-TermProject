using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CProgressionPoints : MonoBehaviour
{
    public Transform targetPosition;
    public GameObject guidePrefab;
    public float stopDistance = 3.0f;
    public float guideOffset = 2.0f;

    private GameObject guideInstance;
    public CTestMoving movementController;

    void Start()
    {
    }

    void Update()
    {
        if (movementController != null && guidePrefab != null)
        {
            if (Vector3.Distance(transform.position, targetPosition.position) < stopDistance)
            {
                if (guideInstance == null)
                {
                    guideInstance = Instantiate(guidePrefab, transform.position + new Vector3(0, 2, 0), Quaternion.Euler(90f, 0f, 0f));
                }

                movementController.transform.position = transform.position + transform.forward * guideOffset;

                movementController.transform.LookAt(transform);

                Rigidbody rb = movementController.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = Vector3.zero;
                }

                movementController.SetCanMove(false);

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
