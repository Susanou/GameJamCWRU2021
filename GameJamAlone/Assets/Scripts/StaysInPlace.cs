using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaysInPlace : MonoBehaviour
{
    [HideInInspector] public static StaysInPlace[] instances = new StaysInPlace[10];
    [SerializeField] public int index;

    public PositionValue position;

    void Awake()
    {
/*         if(instances[index] == null)
        {
            instances[index] = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instances[index] != this)
        {
            Destroy(gameObject);
        } */

        gameObject.transform.position = position.RuntimeValue;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        position.RuntimeValue = this.transform.position;
    }
}
