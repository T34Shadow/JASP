
using UnityEngine;
using System.Linq;


[RequireComponent(typeof(DroneMovement))]


public class DroneMovement : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float radius;
    [SerializeField] private float speed;


    [SerializeField] private float cohesionRadius;
    [SerializeField] private float cohesionForce;

    [SerializeField] private float alignmentRadius;
    [SerializeField] private float alignmentForce;

    [SerializeField] private float separationRadius;
    [SerializeField] private float separationForce;


    [SerializeField] private float maxVelocity;
    [SerializeField] private DroneMovement drone;
    private Collider[] dronesInRange;

    [SerializeField] private Transform player;
    [SerializeField] private float toThePlayerForce;


    // Start is called before the first frame update
    void Start()
    {
        float speedFactor = 100;
        drone = GetComponent<DroneMovement>();
       velocity = new Vector3(Random.Range(0, speedFactor), Random.Range(0, speedFactor), Random.Range(0, speedFactor));
    }
    private void FixedUpdate()
    {
        dronesInRange = Physics.OverlapSphere(transform.position, radius, 6);

        if (velocity.magnitude > maxVelocity)
        {
            velocity = velocity.normalized * maxVelocity;
        }

        transform.position += velocity * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(velocity);
        
        toThePlayer();

        Separation();

        Alignment();

        Cohesion();

    }
    // Update is called once per frame
   
    private void Separation() // sepration, is where when a drome gets to close to another, it will change its direction to avoid colition with another drone
    {
        //need to find drones with this scrip that are around current drone
        Vector3 average = Vector3.zero;
        Collider[] seperationDrones = getDronesInRange(separationRadius, out average);

        if (seperationDrones.Length > 0)
        {
            average /= seperationDrones.Length;
            velocity -= Vector3.Lerp(Vector3.zero, average, average.magnitude / separationRadius) * separationForce;
        }
    }
    private void Alignment() // alignment, is where the drones should target a avrage velocity of the list, to travel at a average speed together
    {
        
        Vector3 average = Vector3.zero;
        Collider[] alignmnetDrones = getDronesInRange(alignmentRadius, out average);

        if (alignmnetDrones.Length > 0)
        {
            average /= alignmnetDrones.Length;
            velocity += Vector3.Lerp(drone.velocity, average, Time.deltaTime) * alignmentForce;
        }

    }
    private void Cohesion() // cohesion, is where the drones should target an average postion between the list of near by drones 
    {

        Vector3 average = Vector3.zero;
        Collider[] cohesionDrones = getDronesInRange(cohesionRadius, out average);

        if (cohesionDrones.Length > 0)
        {
            average /= cohesionDrones.Length;
            velocity += Vector3.Lerp(Vector3.zero, average, average.magnitude / cohesionRadius) * cohesionForce;
        }

    }
    private void toThePlayer()
    {
        
    }

    private Collider[] getDronesInRange(float scopeRadius, out Vector3 average)
    {
        average = Vector3.zero;
        Collider[] found= { };

        foreach (var Drone in dronesInRange)
        {
            if (Drone == drone) continue;
            Vector3 diff = Drone.transform.position - transform.position;

            if (diff.magnitude < scopeRadius)
            {
                average += diff;
                found.Append(Drone);
            }
        }

        return found;
    }
}


