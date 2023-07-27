using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }
public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
            //send to death screen
        }
    }
}
