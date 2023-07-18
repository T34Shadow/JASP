using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStarShipController : MonoBehaviour
{
    [Header("ShipMovementProperties")]

    [SerializeField] private float forwardFactor;
    [SerializeField] private float topForwardSpeed;
    [SerializeField] private float brakeFactor;

    [SerializeField] private float boostFactor;
    [SerializeField] private float topBoostSpeed;

    [SerializeField] private float StrafeFactor;
    [SerializeField] private float pitchFactor;
    [SerializeField] private float rollFactor;
    [SerializeField] private float yawFactor;
    

    [Header("CamearProperties")]

    [SerializeField] private float xRotation;
    [SerializeField] private float yRotation;
    [SerializeField] private float zRotation;

    // [Header("AutoBlasterProperties")]
    //
    // [Header("SemiBlasterProperties")]

    //Other vaules
    private float axisZ;

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

        //Keybord Input controls
        bool forwardInput = Input.GetKey(KeyCode.W);
        bool brakeInput = Input.GetKey(KeyCode.S);

        bool rightStrafeInput = Input.GetKey(KeyCode.D);
        bool leftStrafeInput = Input.GetKey(KeyCode.A);

        bool rightRoleInput = Input.GetKey(KeyCode.E);
        bool leftRoleInput = Input.GetKey(KeyCode.Q);

        if (forwardInput)
        {
            float Vel = forwardFactor * Time.deltaTime;
            Vector3 movement = new(0, 0, Vel);
            transform.Translate(movement);
        }
        if (rightStrafeInput)
        {
            float vel = StrafeFactor * Time.deltaTime;
            Vector3 movement = new(vel, 0, 0);
            transform.Translate(movement);
        }
        if (leftStrafeInput)
        {
            float vel = StrafeFactor * Time.deltaTime;
            Vector3 movement = new(-vel, 0, 0);
            transform.Translate(movement);
        }

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * yawFactor;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * pitchFactor;

        if(rightRoleInput)
        {
            float rollRight =- 1 * Time.deltaTime * rollFactor;
            axisZ = rollRight;
        }
        else
        {
            axisZ = 0;
        }
        if(leftRoleInput)
        {
            float rollLeft =+ 1 * Time.deltaTime * rollFactor;
            axisZ = rollLeft;
        }
        yRotation += mouseX;
        xRotation -= mouseY;
        zRotation += axisZ;
        transform.rotation = Quaternion.Euler(xRotation, yRotation, zRotation);

    }
}
