using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinesPojectiles : MonoBehaviour
{
    [SerializeField] private Rigidbody MinesRigidbody;
    [SerializeField] private Transform pivoitPoint01;
    [SerializeField] private Transform pivoitPoint02;
    [SerializeField] private float forceFactor;
    [SerializeField] private float TorqueFactor;


    // Start is called before the first frame update
    void Start()
    {
        MinesRigidbody = GetComponent<Rigidbody>();

        MinesRigidbody.AddForce(transform.forward * forceFactor, ForceMode.Impulse);

        MinesRigidbody.AddTorque(transform.forward * forceFactor, ForceMode.Impulse);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
