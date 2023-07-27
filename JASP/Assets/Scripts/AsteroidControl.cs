using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidControl : MonoBehaviour
{
    [Header("Astroid Properties")]
    [SerializeField] private float forceFactor;
    [SerializeField] private Rigidbody AsteroidRB;
    [SerializeField] private Transform AsteoridTransform;
    [SerializeField] private GameObject AsteoridGameObject;

    [Header("player Properties")]
    [SerializeField] private Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {


        AsteroidRB = GetComponent<Rigidbody>();
        transform.LookAt(playerTransform.transform.position);
    }

    private void FixedUpdate()
    {
        AsteroidRB.AddForce(Vector3.forward * forceFactor, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //deal damge to the player 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

