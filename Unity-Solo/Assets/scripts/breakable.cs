using UnityEngine;

public class target : MonoBehaviour
{
    private int health = 1;
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
        if (other.tag == "projectile")
        {
            health -= 1;
        }
    }
}
