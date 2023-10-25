using System.Collections;
using System.Collections.Generic;
using Assets.Sprites.Characters;
using UnityEngine;

public class Enemy : HealthPoint
{
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    public float moveSpeed;

    private Transform player;
}