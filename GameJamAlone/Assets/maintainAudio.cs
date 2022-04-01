using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maintainAudio : MonoBehaviour
{
    [HideInInspector] public static maintainAudio instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
