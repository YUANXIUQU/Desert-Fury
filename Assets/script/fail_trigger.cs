using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fail_trigger : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject final_page;
    public AudioSource die;
    public player_movement player_movement;
    public static bool ending;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ending = false;
    }
    void OnTriggerEnter2D(Collider2D other) // collide with animals, player fails
    {
        if (other.CompareTag("enemy"))
        {
            ending = true;
            die.Play();
            player_movement.player_die();
            other.enabled = false;
            Destroy(other.gameObject);
            show_resultpage();

        }
    }


    public void show_resultpage()
    {
        final_page.SetActive(true);
    }

}
