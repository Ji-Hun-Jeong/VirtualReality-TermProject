using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCompletePoint : MonoBehaviour
{
    public GameObject targetPrefab1;
    public GameObject targetPrefab2;
    public GameObject guidePrefab;
    public float stopDistance = 3.0f;
    public float guideOffset = 2.0f;

    private GameObject guideInstance;
    public CMoveObject movementController;
    public CMissionManager cMissionManager;

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (movementController != null && guidePrefab != null)
        {
            if (Vector3.Distance(transform.position, movementController.transform.position) < stopDistance)
            {
                cMissionManager.InitText();

                if (guideInstance == null)
                {
                    guideInstance = Instantiate(guidePrefab, transform.position + new Vector3(0, 2, 0), transform.rotation * Quaternion.Euler(90f, 0f, 0f));
                }

                targetPrefab1.transform.position = transform.position + transform.forward * guideOffset;
                targetPrefab1.transform.LookAt(transform);

                targetPrefab2.transform.position = transform.position + transform.forward * guideOffset;
                targetPrefab2.transform.LookAt(transform);

                Rigidbody rb = movementController.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = Vector3.zero;
                }

                movementController.SetCanMove(false);

                if (!movementController.canMove && (OVRInput.Get(OVRInput.Button.Three) || Input.GetKeyDown(KeyCode.Q)))
                {
                    movementController.SetCanMove(true);
                    Destroy(guideInstance);
                    Destroy(gameObject);
                }
            }
        }
    }

    public void starting()
    {
        gameObject.SetActive(true);
    }
}
