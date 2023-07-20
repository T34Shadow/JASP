using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pojectiles : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
   // [SerializeField] private float rotaionSpeed;
   // [SerializeField] private bool spinControl;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vel = forwardSpeed * Time.deltaTime;
       // float spinRate = rotaionSpeed * Time.deltaTime;

        transform.Translate(0, 0, vel);
    }
}
