using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class textcutscene2 : MonoBehaviour
{
    public GameObject image1;
    public GameObject image2;
    public GameObject text1;
    public GameObject text2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image1.SetActive(false);
        image2.SetActive(false);
        text1.SetActive(false);
        text2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider Player)
    {
        if (gameObject.tag == "enemy")
        {
            StartCoroutine("WaitForSec");
        }
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(4);
        image1.SetActive(false);
        image2.SetActive(true);
        text1.SetActive(false);
        text2.SetActive(true);
    }
}
