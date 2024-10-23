using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Animator enemy;
    public AudioSource attacksound;
    public AudioSource jump;
    public AudioSource pointsound;
    public float nextattacktime = 0f;
    public float attackrate = 0.5f;
    public float jumppower = 2f;

    public Transform attackpoint;
    public float attackrange = 0.5f;
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
                foreach (Collider2D enemy in hitenemies)
                {
                    attacksound.Play();
                    enemy.GetComponent<enemy_movement>().damage();
                    enemy.GetComponent<Collider2D>().enabled = false;
                    enemy.enabled = false;
                    StartCoroutine(DestroyAfterDelay(enemy.gameObject, 0.25f));
                    score.points += 15;
                    pointsound.Play();
                    
                }
                nextattacktime = Time.time + attackrate;
            }

            else if (Input.GetKeyDown(KeyCode.S))
            {
                jump.Play();
                rb.AddForce(new Vector2(0, jumppower), ForceMode2D.Impulse);
                animator.SetTrigger("jump");
                nextattacktime = Time.time + attackrate;
            }
        }


    }

    IEnumerator DestroyAfterDelay(GameObject enemy, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(enemy);

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackpoint.position, attackrange);
    }
}
