
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(DroneMovement))]


public class DroneMovement : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;

    [SerializeField] private float cohesionRadius;
    [SerializeField] private float cohesionForce;

    [SerializeField] private float alignmentRadius;
    [SerializeField] private float alignmentForce;

    [SerializeField] private float separationRadius;
    [SerializeField] private float separationForce;


    [SerializeField] private float maxVelocity;
    [SerializeField] private DroneMovement drone;
    

    

    // Start is called before the first frame update
    void Start()
    {
        drone = GetComponent<DroneMovement>();
        velocity = new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
    }

    // Update is called once per frame
    void Update()
    {
        if (velocity.magnitude > maxVelocity)
        {
            velocity = velocity.normalized * maxVelocity;
        }
        
        drone.transform.position += velocity * Time.deltaTime;
        drone.transform.rotation = Quaternion.LookRotation(velocity);

        Separation();

        Alignment();

        Cohesion();

    }
    private void Separation() // sepration, is where when a drome gets to close to another, it will change its direction to avoid colition with another drone
    {
        var drones = FindObjectOfType<DroneMovement>(); //need to find drones with this scrip that are around current drone

        var average = Vector3.zero;
        var found = 0;
        //there needs to be a foreach loop to check and compare between drones around current drone 
        var diff = drone.transform.position - transform.position;
        if (diff.magnitude < separationRadius)
        {
            average += diff;
            found += 1;
        }

        if (found > 0)
        {
            average /= found;
            drone.velocity -= Vector3.Lerp(Vector3.zero, average, average.magnitude / separationRadius) * separationForce;
        }
    }
    private void Alignment() // alignment, is where the drones should target a avrage velocity of the list, to travel at a average speed together
    {
        var drones = FindObjectOfType<DroneMovement>(); //need to find drones with this scrip that are around current drone

        var average = Vector3.zero;
        var found = 0;
        //there needs to be a foreach loop to check and compare between drones around current drone 
        var diff = drone.transform.position - transform.position;
        if (diff.magnitude < alignmentRadius)
        {
            average += diff;
            found += 1;
        }

        if (found > 0)
        {
            average /= found;
            drone.velocity += Vector3.Lerp(drone.velocity, average, Time.deltaTime);
        }

    }
    private void Cohesion() // cohesion, is where the drones should target an average postion between the list of near by drones 
    {
        var drones = FindObjectOfType<DroneMovement>(); //need to find drones with this scrip that are around current drone

        var average = Vector3.zero;
        var found = 0;
        //there needs to be a foreach loop to check and compare between drones around current drone 
        var diff = drone.transform.position - transform.position;
        if(diff.magnitude < cohesionRadius)
        {
            average += diff;
            found += 1;
        }

        if (found > 0)
        {
            average /= found;
            drone.velocity += Vector3.Lerp(Vector3.zero, average, average.magnitude / cohesionRadius);
        }
            
    }
}
