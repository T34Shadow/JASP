using Unity.VisualScripting;
using UnityEngine;

public class ShipContorllorV2 : MonoBehaviour
{
    [SerializeField] private Rigidbody shipRigidbody;
    private Vector3 shipVelcoity;
    [Header("MovmentValues")]

    [SerializeField] private float forwardFactor;
    [SerializeField] private float brakeFactor;
    [SerializeField] private float rollFactor;
    [SerializeField] private float pitchFactor;
    [SerializeField] private float yawFactor;

    [Header("Transform Origin points")]
    [SerializeField] private Transform centerOrigin;
    
    [SerializeField] private Transform frontPitchOrigin;
    [SerializeField] private Transform backPitchOrigin;

    [SerializeField] private Transform frontYawOrigin;
    [SerializeField] private Transform backYawOrigin;

    [SerializeField] private Transform rightRollOrigin;
    [SerializeField] private Transform leftRollOrigin;

    [Header("weapons")]
    [SerializeField] private GameObject lazerBolt;
    [SerializeField] private GameObject cannonBolt;
    [SerializeField] private GameObject mine;

    [Header("weaponsPrperties")]
    [SerializeField] private Transform spawnPointLazerBoltRight;
    [SerializeField] private Transform spawnPointLazerBoltLeft;
    [SerializeField] private Transform spawnPointcannonBolt;
    [SerializeField] private Transform spawnPointMine;

    [Header("CameraPrperties")]
    [SerializeField] private Camera playerCam;
    [SerializeField] private float StartFOV;
    [SerializeField] private float EndFOV;


    int selectedWeapon = 1;

    // Start is called before the first frame update
    public void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        shipRigidbody = GetComponent<Rigidbody>();


        
    }

    public void FixedUpdate()
    {
        
        //player movement

        bool forwardInput = Input.GetKey(KeyCode.W);
        bool brakeInput = Input.GetKey(KeyCode.S);
        bool rollRightInput = Input.GetKey(KeyCode.K);
        bool rollLeftInput = Input.GetKey(KeyCode.H);
        bool pitchUpInput = Input.GetKey(KeyCode.J);
        bool pitchDownInput = Input.GetKey(KeyCode.U);
        bool yawRightInput = Input.GetKey(KeyCode.D);
        bool yawLeftInput = Input.GetKey(KeyCode.A);
        bool bootsInput = Input.GetKey(KeyCode.LeftShift);

        shipVelcoity = shipRigidbody.velocity;
        //forward and break movement
        if(forwardInput)
        {
            shipRigidbody.AddForce(centerOrigin.transform.forward * forwardFactor, ForceMode.Impulse);
        }
        if (shipRigidbody.velocity.z > 0 & brakeInput)
        {
            shipRigidbody.AddForce(-centerOrigin.transform.forward * brakeFactor, ForceMode.Impulse);
        }
        if (shipRigidbody.velocity.z <= 0)
        {
            shipVelcoity.z = 0;
        }
        if (bootsInput)
        {
            shipRigidbody.AddForce(centerOrigin.transform.forward * forwardFactor, ForceMode.Impulse);
        }
        //pitch controll
        if (pitchUpInput)
        {
            shipRigidbody.AddTorque(-frontPitchOrigin.transform.right * pitchFactor, ForceMode.Impulse);
        }
        if (pitchDownInput)
        {
            shipRigidbody.AddTorque(backPitchOrigin.transform.right * pitchFactor, ForceMode.Impulse);
        }

        //roll controll
        if (rollRightInput)
        {
            shipRigidbody.AddTorque(-rightRollOrigin.transform.forward * rollFactor,ForceMode.Impulse);
        }
        if (rollLeftInput)
        {
            shipRigidbody.AddTorque(leftRollOrigin.transform.forward * rollFactor, ForceMode.Impulse);
        }
        //Yaw controll
        if (yawRightInput)
        {
            shipRigidbody.AddTorque(frontYawOrigin.transform.up * yawFactor, ForceMode.Impulse);
        }
        if (yawLeftInput)
        {
            shipRigidbody.AddTorque(-frontYawOrigin.transform.up * yawFactor, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
   public void Update()
    {

        //player attacking


        bool shootInput = Input.GetKey(KeyCode.Space);
        
        bool miniGunActive = false;
        bool blasterCannonActive = false;
        bool minesActive = false;

        if (Input.GetKey(KeyCode.Alpha1))
        {
            selectedWeapon = 1;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            selectedWeapon = 2;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            selectedWeapon = 3;
        }

        if (selectedWeapon == 1)
        {
            miniGunActive = true;
            blasterCannonActive = false;
            minesActive = false;
        }
        else if (selectedWeapon == 2)
        {
            blasterCannonActive = true;
            miniGunActive = false;
            minesActive = false;
        }
        else if (selectedWeapon == 3)
        {
            minesActive = true;
            blasterCannonActive = false;
            miniGunActive = false;
        }

        //Shooting weapons
        if (shootInput & miniGunActive)
        {
            GameObject cloneLazerBoltLeft = Instantiate(lazerBolt, spawnPointLazerBoltLeft.position, spawnPointLazerBoltLeft.rotation);
            GameObject cloneLazerBoltRight = Instantiate(lazerBolt, spawnPointLazerBoltRight.position, spawnPointLazerBoltRight.rotation);
               
        }
        if (shootInput & blasterCannonActive)
        {
            GameObject cloneCannonBolt = Instantiate(cannonBolt, spawnPointcannonBolt.position, spawnPointcannonBolt.rotation);
        }
        if (shootInput & minesActive)
        {
            GameObject cloneMine = Instantiate(mine, spawnPointMine.position, spawnPointMine.rotation);
        }




    }
}
