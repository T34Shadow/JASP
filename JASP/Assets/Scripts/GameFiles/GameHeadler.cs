using System.Collections;
using System.Collections.Generic;

using UnityEngine;



public class GameHeadler : MonoBehaviour


{
    [Header("otherScripts")]
    [SerializeField] public ShipContorllorV2 playerShip;
   // [SerializeField] public AsteroidControl asteroidControl;

    [Header("player properties")]
    [SerializeField] public float playerHealth;
    [SerializeField] private float playerScore;
    [SerializeField] private Transform playerTramsform;
    [SerializeField] private bool playerAlive;

    [Header("Game properties")]
    [SerializeField] private float gameDifficulty;
    [SerializeField] private float gameWave;
    [SerializeField] private bool startNewWave;
    [SerializeField] private bool gameStart;
    [SerializeField] private bool gameRestart;
    [SerializeField] private float betweenSpawnTime;
    [SerializeField] private float timer;

    [Header("MotherShip propeties")]
    [SerializeField] private float motherShipCount;
    [SerializeField] private float enemyScaler;
    [SerializeField] private float spawnRange;
    [SerializeField] private float spawnRotaion;
    [SerializeField] private float minDis;
    [SerializeField] private float maxDis;
    [SerializeField] private Vector3 spawnlocation;
    [SerializeField] private Quaternion spawnQuaternion;
    [SerializeField] private GameObject motherShip; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private Vector3 spawnRangeVector3()
    {
        Vector3 randomePos;
        do
        {

            float randomX = Random.Range(-spawnRange, spawnRange);
            float randomY = Random.Range(-spawnRange, spawnRange);
            float randomZ = Random.Range(-spawnRange, spawnRange);

            randomePos = new Vector3(randomX, randomY, randomZ);
        } while (tooClose(randomePos));

        return randomePos;

    }
    private Quaternion spawnRotation()
    {
        Quaternion randomeRot;
        

        float randomX = Random.Range(-spawnRotaion, spawnRotaion);
        float randomY = Random.Range(-spawnRotaion, spawnRotaion);
        float randomZ = Random.Range(-spawnRotaion, spawnRotaion);
        float randomW = Random.Range(-spawnRotaion, spawnRotaion);
        randomeRot = new Quaternion(randomX, randomY, randomZ, randomW);
        
        return randomeRot;
    }
    private bool tooClose(Vector3 randomPos)
    {
        GameObject[] otherMotherShip = GameObject.FindGameObjectsWithTag("MotherShip");

        foreach (GameObject obj in otherMotherShip)
        {
            if (Vector3.Distance(randomPos, obj.transform.position) < minDis)
            {
                return true;
            }
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
       
      
        if(playerHealth <= 0)
        {
            playerAlive = false;
        }    
        if(!playerAlive)
        {
            //death screen
            //End of game
        }

        if (motherShipCount == 0)
        {
            motherShipCount = gameWave * gameDifficulty;
            enemyScaler += (gameDifficulty/10) ;
            gameWave++;
          

            for (int i = 0; i < motherShipCount; i++)
            {
                spawnlocation = spawnRangeVector3();
                spawnQuaternion = spawnRotation();
                Instantiate(motherShip, spawnlocation, spawnQuaternion);
            }

        }
      
    }
}
