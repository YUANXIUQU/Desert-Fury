using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fail_trigger : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject final_page;
    public AudioSource die;

    public cameraShake cameraShake;
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
            cameraShake.GetComponent<cameraShake>().ShakeCamera(2, 0.5f);
            die.Play();
            player_movement.player_die();
            other.enabled = false;
            Destroy(other.gameObject);
            final_page.SetActive(true); 

        }
    }

}
