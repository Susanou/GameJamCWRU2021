using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Erode : MonoBehaviour
{

    public BooleanValue eroded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other) {
        Debug.Log("Particle collision");
        eroded.RuntimeValue = true;
        Debug.Log(eroded.RuntimeValue);
    }
}
