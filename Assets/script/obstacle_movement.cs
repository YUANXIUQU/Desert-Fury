using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_movement : MonoBehaviour
{
    public float rollspeed = 5f;
    public float rotationspeed = 100f;
    public AudioSource die;
    public AudioSource pointsound;
    public fail_trigger failtrigger;

    public player_movement player_movement;

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.left * rollspeed * Time.deltaTime, Space.World);
        transform.Rotate(0, 0, rotationspeed * Time.deltaTime, Space.Self);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // player collides with obstacles then lose
        {
            fail_trigger.ending = true;
            die.Play();
            failtrigger.show_resultpage();
            player_movement.player_die();
            delete();
        }

        if (other.CompareTag("ob_gain_point")) // player avoid obs then gain points
        {
            score.points += 10;
            pointsound.Play();
            delete();
        }
    }

    public void delete()
    {
        Destroy(this.gameObject);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }


}
