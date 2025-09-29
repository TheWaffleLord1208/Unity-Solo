using UnityEngine;

public class path : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed = 5f;
    void Start()
    {
        
    }
    void Update()
    {
       transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed); 
    }
}
