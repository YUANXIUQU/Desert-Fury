using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fail_trigger : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject final_page;
    public AudioSource die;
    public static bool ending;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ending = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            ending = true;
            die.Play();
            final_page.SetActive(true);
            Time.timeScale = 0;
            other.GetComponent<Collider2D>().enabled = false;
            other.enabled = false;
            Destroy(other.gameObject);
            
        }
    }

}
