using System.Collections;
using UnityEngine;
using UnityEngine.UI;  // Unity UI ���ӽ����̽� �߰�

public class CEndingPoint : MonoBehaviour
{
    public Text messageText;
    public CMoveObject movementController;
    public float stopDistance = 3.0f;

    private bool hasTriggered = false;

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, movementController.transform.position) < stopDistance)
        {
            hasTriggered = true;
            ShowMessage("����ϼ̽��ϴ�!!");
        }
    }
    void ShowMessage(string message)
    {
        if (messageText != null)
        {
            messageText.text = message;
            StartCoroutine(ClearMessageAfterDelay(10f));
        }
    }

    IEnumerator ClearMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (messageText != null)
        {
            messageText.text = "";

        }
    }

    public void starting()
    {
        gameObject.SetActive(true);
    }
}
