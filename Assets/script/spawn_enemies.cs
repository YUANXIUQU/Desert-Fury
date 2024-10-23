using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_objects : MonoBehaviour
{
    public GameObject[] enemyprefab;
    public Transform spawnpoint;
    public float initialspawnrate = 5f;
    public float difficultyuprate = 0.1f;
    public float minispawnrate = 1f;

    float currentspawnrate;
    float nextspawntime;
    void Start()
    {
        currentspawnrate = initialspawnrate;
        nextspawntime = Time.time + currentspawnrate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextspawntime)
        {
            spawnCreature();
            adjustspawnrate();
            nextspawntime = Time.time + currentspawnrate;
        }
    }

    void spawnCreature()
    {
        int randomindex = Random.Range(0, enemyprefab.Length);
        Instantiate(enemyprefab[randomindex], spawnpoint.position, spawnpoint.rotation);
    }

    void adjustspawnrate()
    {
        currentspawnrate = Mathf.Max(minispawnrate,
            currentspawnrate - difficultyuprate);
    }
}
