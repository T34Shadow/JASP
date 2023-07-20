using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipMover : MonoBehaviour
{
    public float orbitSpeed = 1f;
    public float orbitRadius = 5f;

    [SerializeField]
    private Rigidbody rb;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        // Calculate the desired position in a circular orbit
        Vector3 desiredPosition = new Vector3(0, 0,0) + Quaternion.Euler(0f, orbitSpeed * Time.time, 0f) * (Vector3.forward * orbitRadius);

        // Move the Spawner to the desired position
        transform.position = desiredPosition;
    }
}
