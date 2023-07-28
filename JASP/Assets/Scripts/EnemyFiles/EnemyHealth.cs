using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float addScore;
    [SerializeField] private AudioSource ShipDestroy;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        
        ShipDestroy = GetComponent<AudioSource>();
        ShipDestroy.enabled = false;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {

            ShipDestroy.enabled = true;


            Destroy(gameObject,1f);       
        }
    }
}
