using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    public float runspeed = 7f;
    Animator animator;
    bool ishurt = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ishurt == false)
        {
            transform.Translate(Vector2.left * runspeed * Time.deltaTime);
        }
        
    }

    public void damage()
    {
        ishurt = true;
        animator.SetTrigger("hurt");
    }
}
