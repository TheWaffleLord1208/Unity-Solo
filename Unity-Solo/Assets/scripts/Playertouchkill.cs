using UnityEngine;

public class Playertouchkill : MonoBehaviour
{

    public int health = 1;
    public int maxHealth = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            health -= 2;
        }
    }
}