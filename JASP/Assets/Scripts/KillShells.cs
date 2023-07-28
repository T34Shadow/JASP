using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillShells : MonoBehaviour

{
    [SerializeField] private float timer;
    [SerializeField] private float timeBetween;
    private bool killShell = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!killShell)
        {
            timer += Time.deltaTime;
            if(timer > timeBetween)
            {
                killShell = true;
            }
        }
        if (killShell)
        {
            Object.Destroy(gameObject);
        }    
    }
    
}
