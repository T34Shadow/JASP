using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pojectiles : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    
    
       
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vel = forwardSpeed * Time.deltaTime;
        transform.Translate(0, 0, vel);
    }
}
