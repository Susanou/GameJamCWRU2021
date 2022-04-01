using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eroded : MonoBehaviour
{

    public BooleanValue eroded;

    void Awake(){

        Debug.Log(eroded.RuntimeValue);

        if (eroded.RuntimeValue)
            Destroy(this.gameObject);
    }

}
