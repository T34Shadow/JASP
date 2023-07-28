using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToEnemy : MonoBehaviour
{
    public EnemyHealth enemyHealth;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            enemyHealth.TakeDamage(damage);
        }

    }
}
