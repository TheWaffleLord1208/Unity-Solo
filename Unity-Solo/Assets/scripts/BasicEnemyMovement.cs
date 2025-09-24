using System.Security.Cryptography;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using Random = Unity.Mathematics.Random;

public class BasicEnemyMovement : MonoBehaviour

{
    public Rigidbody rb;
    public Transform target;
    NavMeshAgent agent;
    public float speed = 5f;
    public float detection = 10f;
    private float distance;

    public int health = 5;
    public int maxHealth = 5;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        distance = Vector3.Distance(target.transform.position, rb.transform.position);
        {
            if (distance < detection)
            {
                agent.destination = GameObject.Find("Player").transform.position;

                Vector3 direction = target.position;
                transform.position = Vector3.MoveTowards(transform.position, direction, speed * Time.deltaTime);
            }
            else
            {
                agent.destination = GameObject.Find("tower").transform.position;

                Vector3 direction = target.position;
                transform.position = Vector3.MoveTowards(transform.position, direction, speed * Time.deltaTime);
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "projectile")
        {
            health -= 2;
        }
    }
}