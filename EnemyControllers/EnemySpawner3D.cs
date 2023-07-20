using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner3D : MonoBehaviour
{

    public float orbitSpeed = 1f;
    public float orbitRadius = 5f;

    [SerializeField]
    private GameObject _enemyPrefab;


    [SerializeField]
    private Transform player;

    [SerializeField]
    private float _maximumSpawnTime;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField] 
    //SerializeField to be able to set from the inspector the min-max and time till enemy spawn
    private float _minimumSpawnTime;

    private float _timeUntilSpawn;

    private int rangeInt;
   
    private void Awake()
    {
        SetTimeUntilSpawn();
        //sets time till spawn when scene first loads
    }

    // Update is called once per frame
    void Update()
    {
        //reduces time til spawn by amount of time passed
        _timeUntilSpawn -= Time.deltaTime;



        // Calculate the desired position in a circular orbit
        Vector3 desiredPosition = player.position + Quaternion.Euler(0f, orbitSpeed * Time.time, 0f) * (Vector3.forward * orbitRadius);

        // Move the Spawner to the desired position
        transform.position = desiredPosition;

        Vector3 _spawnRange = (player.position*rangeInt - transform.position*rangeInt);



        if (_timeUntilSpawn <= 0)
        {
            //makes a clone of the enemy prefab where the spawn point is
            Instantiate(_enemyPrefab, _spawnRange, Quaternion.identity);
            SetTimeUntilSpawn();

           

        }
    }


private void SetTimeUntilSpawn()
    //setting random value for spawn time between min/max
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
        rangeInt = Random.Range(1, 5);
    }
}


  
