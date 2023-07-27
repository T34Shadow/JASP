using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class GameController : MonoBehaviour
{
    [Header("Player Properties")]
    public float playerHeath = 100;
    public float playerScore = 0;
    public bool playerAlive = true;


    [Header("Game Properties")]
    //Game difficulty is ether easy, normal, or hard(1,2,3). This can be used to times the enemy scaler number
    public float gameDifficulty = 3;
    //for each round, is the base count of motherships in the level
    public float gameRound = 1;
    public bool gameStart;
    public bool gameRestart;
    private float betweenSpawn;
    private float timer;
    private float range;
    private Vector3 spawnRange()
    {
        Vector3 randomPosition;

        // Loop until a suitable position is found
        do
        {
            // Generate random X Z Y coordinates
            float randomX = Random.Range(-10000f, 10000f);
            float randomZ = Random.Range(-10000f, 10000f);
            float randomY = Random.Range(-10000f, 10000f);
            Debug.Log(randomX + " " + randomZ + " " + randomY);
            // Create a random position with the new coordinates
            randomPosition = new Vector3(randomX, randomY, randomZ);

        } while (tooClose(randomPosition));

        return randomPosition;
    }
    private float rotaionRange;
    [SerializeField] private float minDis;
    [SerializeField] private float maxDisTOPlayer;
    private bool tooClose(Vector3 randomPostion)
    {
        
       GameObject[] existingObjects = GameObject.FindGameObjectsWithTag("MotherShip");

        // Check the distance between the new position and each existing object
        foreach (GameObject obj in existingObjects)
        {
            if (Vector3.Distance(randomPostion, obj.transform.position) < minDis)
            {
                return true; // The new position is too close to an existing object
            }
        }

        return false; // The new position is not too close to any existing object
    }
    private Quaternion RandomRotionRange;

    [Header("Enemy Properties")]
    //The enemy scaler is used for how hard each enemy is.
    public float enemyScaler = 1;

    public float motherShipCount = 0;
    public GameObject motherShip;

   // public AsteroidControl asteroidContr;
    

    // Start is called before the first frame update
    void Start()
    {
        gameStart = true;
        gameRestart = false;

       // asteroidContr = GetComponent<AsteroidControl>();
       // motherShipCount = gameRound * gameDifficulty;
    }

    // Update is called once per frame
    void Update()
    {

        
        if(!playerAlive)
        {
            //Stop the game, go to death screen, give option for restart for a new game, or main menu, while restarting the game vaules.
        }

        if(gameRestart)
        {
            //set all vaules back to origanl
            playerHeath = 100;
            playerScore = 0;
            gameDifficulty = 1;
            gameRound = 1;
            enemyScaler = 1;

            gameRestart = false;
        }       //once there is no longer any motherships in the level then start a new round.

        



        if (motherShipCount == 0)
        {

            motherShipCount = gameRound * gameDifficulty;
            Debug.Log(motherShipCount);
            gameRound++;
            for (int i = 0; i < motherShipCount; i++)
            {
                Vector3 randomPos = spawnRange();
                //range = Random.Range(-100, 100);
                //Debug.Log(range);
                //spawnRange = new Vector3(range * range, range * range, range * range);
                //Debug.Log(spawnRange);

                //rotaionRange = Random.Range(-180, 180);
                //Debug.Log(rotaionRange);
                //RandomRotionRange = new Quaternion(rotaionRange * rotaionRange, rotaionRange * rotaionRange, rotaionRange * rotaionRange, 0);
                //Debug.Log(RandomRotionRange);
                Instantiate(motherShip, randomPos, RandomRotionRange);
            }
        }

    }

    

}
