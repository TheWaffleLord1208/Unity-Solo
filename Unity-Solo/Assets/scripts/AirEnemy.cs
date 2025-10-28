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

public class AirEnemy : MonoBehaviour

{
    public Rigidbody rb;
    public Transform target;
    NavMeshAgent agent;
    public float speed = 5f;
    public float detection = 10f;
    private float distance;

    Animator myAnim;

    public int health = 1;
    public int maxHealth = 1;

    void Start()
    {
        myAnim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
    }
    void Update()
    {
        myAnim.SetBool("isAttacking", true);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        distance = Vector3.Distance(target.transform.position, rb.transform.position);

        if (distance < detection)
        {
            agent.isStopped = false;
            agent.destination = GameObject.Find("Player").transform.position;

            Vector3 direction = target.position;
            transform.position = Vector3.MoveTowards(transform.position, direction, speed * Time.deltaTime);
            myAnim.SetBool("isAttacking", true);
        }
        myAnim.SetBool("spin", true);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "projectile")
        {
            health -= 2;
        }
        if (other.tag == "Player")
        {
            health -= 3;
        }
        if (other.tag == "projectile2")
        {
            health -= 5;
        }
    }
}