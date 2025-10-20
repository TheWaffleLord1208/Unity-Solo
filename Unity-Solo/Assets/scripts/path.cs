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

public class path : MonoBehaviour
{
    public Rigidbody rb;
    NavMeshAgent agent;
    public Vector3 startPosition;
    public Vector3 targetPosition;
    public float speed = .1f;

    Animator myAnim;

    public int health = 5;
    public int maxHealth = 5;

    void Start()
    {
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

        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(startPosition, targetPosition, time);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "projectile")
        {
            health -= 2;
        }
    }
}