using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipSpawner : MonoBehaviour
{

    

    [SerializeField]
    private GameObject _mothershipPrefab;

    [SerializeField]
    private float _maximumSpawnTime;

    [SerializeField]
    //SerializeField to be able to set from the inspector the min-max and time till enemy spawn
    private float _minimumSpawnTime;

    private float _timeUntilSpawn;



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


        if (_timeUntilSpawn <= 0)
        {
            //makes a clone of the enemy prefab where the spawn point is
            Instantiate(_mothershipPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();

        }
    }


    private void SetTimeUntilSpawn()
    //setting random value for spawn time between min/max
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
   
    }
}

