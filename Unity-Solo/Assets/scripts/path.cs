using UnityEngine;

public class path : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 targetPosition;
    public float speed = 5f;
    void Start()
    {

    }
    void Update()
    {
        if (currentPosition != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
        }
    }

}