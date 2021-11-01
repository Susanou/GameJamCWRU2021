using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Canvas pause;
    bool pauseOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            pauseOpen = togglePause();
    }

    bool togglePause()
    {
        pauseOpen = !pauseOpen; //swap state
        pause.gameObject.SetActive(pauseOpen); //activate/deactivate
        Time.timeScale = pauseOpen ? 0f : 1f;
        return pauseOpen; //new value
    }
}
