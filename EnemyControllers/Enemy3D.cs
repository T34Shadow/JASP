using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy3D : MonoBehaviour
{
    public float speed = 5f;
    public Transform player;
    public GameObject bulletPrefab;
    public int TotalScore;
    private Rigidbody rb;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Calculate direction towards the player
        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        // Move the enemy towards the player
        rb.velocity = direction * speed;

      
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Bullet")) //checks for bullet hitting an enemy and removes itself after adding to the score
        {
            TotalScore = PlayerPrefs.GetInt("Score", 0);

            TotalScore++;

            PlayerPrefs.SetInt("Score", TotalScore);
            

            

            Destroy(gameObject); // Destroy the enemy
            Destroy(collision.gameObject); // Destroy the bullet
        }
    }
}
