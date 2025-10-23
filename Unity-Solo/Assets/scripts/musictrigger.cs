using UnityEngine;

public class musictrigger : MonoBehaviour
{
    public GameObject currentMusic;
    public GameObject otherMusic
        ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentMusic.SetActive(true);
        otherMusic.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            currentMusic.SetActive(false);
            otherMusic.SetActive(true);
        }
    }
}
