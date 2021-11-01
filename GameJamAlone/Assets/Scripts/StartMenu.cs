using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject MenuMusic;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        SceneManager.LoadScene("Level1_present"); // 1 should be the number of the castle scene
        Time.timeScale = 1f;
        MenuMusic.SetActive(false);
    }

    public void credits()
    {
        SceneManager.LoadScene("credits");
        MenuMusic.SetActive(false);
    }

    public void startMenu()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        SceneManager.LoadScene(0); // 1 should be the number of the castle scene
        MenuMusic.SetActive(false);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void Sandbox()
    {
        SceneManager.LoadScene("Sandbox");
        MenuMusic.SetActive(false);
    }
}
