using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damgeScript : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
        
    }
}
