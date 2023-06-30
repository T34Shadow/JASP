using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStarShipController : MonoBehaviour
{
    [Header("ShipMovementProperties")]
    [SerializeField] private float forwardFactor;
    [SerializeField] private float topForwardSpeed;
    [SerializeField] private float brakeFactor;
    [SerializeField] private float boostFactor;
    [SerializeField] private float topBoostSpeed;

    [SerializeField] private float leftStrafeFactor;
    [SerializeField] private float rightStrafeFactor;

    [SerializeField] private float pitchUpFactor;
    [SerializeField] private float pitchDownFactor;

    [SerializeField] private float rollLeftFactor;
    [SerializeField] private float rollRightFactor;

    [SerializeField] private float yawLeftFactor;
    [SerializeField] private float yawRightFactor;

   // [Header("CamearProperties")]
   //
   // [Header("AutoBlasterProperties")]
   //
   // [Header("SemiBlasterProperties")]



    // Start is called before the first frame update
    void Start()
    {
        //This locks and hides the cursor to the centur of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        bool forwardInput = Input.GetKey(KeyCode.W);
        bool brakeInput = Input.GetKey(KeyCode.S);

        if (forwardInput)
        {

        }
        
        
        
        
        
        //cam movemnt when in free look mode
       // (if)
       // {
       //     //Turret Rotaion with mouse on camear
       //
       //     // get mouse input 
       //     float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
       //     float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
       //
       //     yRotation += mouseX;
       //     xRotation -= mouseY;
       //
       //     // rotate cam and orientaion
       //     turretRing.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
       //     orientation.rotation = Quaternion.Euler(0, yRotation, 0);
       // }


    }
}
