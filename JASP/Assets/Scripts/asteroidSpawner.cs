using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidSpawner : MonoBehaviour
{

    [SerializeField] private float timeBetweemSpawn;
    [SerializeField] private float timer;
    [SerializeField] private bool canSpawn;
    [SerializeField] private GameObject AsteoridGameObject;
    [SerializeField] private Transform player;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);

        if (!canSpawn)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweemSpawn)
            {
                canSpawn = true;
                timer = 0;
            }
        }
        if (canSpawn)
        {
            Instantiate(AsteoridGameObject, transform.position, transform.rotation);
            canSpawn = false;
        }
    }
}
