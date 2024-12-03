using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    Rigidbody2D rb;

    Animator animator;
    Animator enemy;
    public GameObject spawn_enemies;
    public GameObject spawn_obstacles;
    public GameObject fail_trigger;
    public GameObject gainScore;

    public AudioSource attacksound;
    public AudioSource jump;
    public AudioSource pointsound;

    public float nextattacktime = 0f;
    public float attackrate = 0.5f;
    public float jumppower = 2f;
    public float attackrange = 0.5f;

    public bool isgrounded = false;

    public Transform attackpoint;
    public LayerMask enemyLayers;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Time.time >= nextattacktime)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                animator.SetTrigger("attack1");
                Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackpoint.position
                    , attackrange, enemyLayers);
                foreach (Collider2D enemy in hitenemies)// hit enemy, gain points 15.
                {
                    attacksound.Play();
                    enemy.GetComponent<enemy_movement>().damage();
                    enemy.GetComponent<Collider2D>().enabled = false;
                    enemy.enabled = false;
                    StartCoroutine(DestroyAfterDelay(enemy.gameObject, 0.25f));
                    gainScore.SetActive(true);
                    StartCoroutine(delay()); //dalay for add_scores anim playing

                }
                nextattacktime = Time.time + attackrate;
            }

            else if (Input.GetKeyDown(KeyCode.S) && isgrounded)
            {
                jump.Play();
                rb.AddForce(new Vector2(0, jumppower), ForceMode2D.Impulse);
                animator.SetTrigger("jump");
                nextattacktime = Time.time + attackrate;
                isgrounded = false;
            }
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            isgrounded = true;
        }
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(1.0f);
        score.points += 15;
        pointsound.Play();
        gainScore.SetActive(false);
    }
    IEnumerator DestroyAfterDelay(GameObject enemy, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(enemy);
        
    }

    public void player_die() //player die animation ; disenable spawns of obs,enemy
    {
        animator.SetTrigger("dead");
        spawn_enemies.SetActive(false);
        spawn_obstacles.SetActive(false);
        fail_trigger.GetComponent<Collider2D>().enabled = false;
        this.GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackpoint.position, attackrange);
    }
}
