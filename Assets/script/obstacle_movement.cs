using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_movement : MonoBehaviour
{
    public float rollspeed = 5f;
    public float rotationspeed = 100f;
    public AudioSource die;
    public AudioSource pointsound;
    public GameObject final_page;
    public cameraShake cameraShake;
    public player_movement player_movement;
    public GameObject gainScore;

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.left * rollspeed * Time.deltaTime, Space.World);
        transform.Rotate(0, 0, rotationspeed * Time.deltaTime, Space.Self);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // player collides with obstacles then fails
        {
            fail_trigger.ending = true;
            cameraShake.GetComponent<cameraShake>().ShakeCamera(2, 0.5f);
            die.Play();
            final_page.SetActive(true);
            player_movement.player_die();
            delete();
        }

        if (other.CompareTag("ob_gain_point")) // player avoid obs then gain points
        {
            gainScore.SetActive(true);
            StartCoroutine(delay());
        }
    }

    public void delete()
    {
        Destroy(this.gameObject);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(1.0f);
        score.points += 10;
        pointsound.Play();
        gainScore.SetActive(false);
        
    }

}
