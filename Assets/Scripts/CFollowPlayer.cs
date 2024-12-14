using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFollowPlayer : MonoBehaviour
{
    public GameObject player;  // �÷��̾� ���� ������Ʈ
    public float heightOffset = 2.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = player.transform.position;
        newPosition.y += heightOffset;

        transform.position = newPosition;
    }
}
