using UnityEngine;

public class CAutoDoor : MonoBehaviour
{
    public Transform door1, door2, target;
    public float openDistance = 5f;
    public float closeDistance = 5f;
    public float speed = 2f;  
    public float moveDistance = 1.25f; 

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

        if (distance < openDistance)
        {
            door1.position = Vector3.Lerp(door1.position, openPosition1, Time.deltaTime * speed);
            door2.position = Vector3.Lerp(door2.position, openPosition2, Time.deltaTime * speed);
        }
        else if (distance > closeDistance)
        {
            door1.position = Vector3.Lerp(door1.position, initialPosition1, Time.deltaTime * speed);
            door2.position = Vector3.Lerp(door2.position, initialPosition2, Time.deltaTime * speed);
        }
    }
}
