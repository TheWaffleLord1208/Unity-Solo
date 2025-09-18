using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class BasicEnemyMovement : MonoBehaviour

{
    public Rigidbody rb;
    public Transform target;
    NavMeshAgent agent;
    public float speed = 5f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        agent.destination = GameObject.Find("Player").transform.position;

        Vector3 direction = target.position;
        transform.position = Vector3.MoveTowards(transform.position, direction, speed * Time.deltaTime);
    }

}
