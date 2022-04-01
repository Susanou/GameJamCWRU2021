using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;    
    Animator animator;   

    private GameObject player; 

    void Awake()
    {
        animator = transform.GetComponent<Animator>();
    }

    void Start()
    {
        
    }    
    
    void Update()
    {

    }    
    
    public void changeScene(){
        //Debug.Log("this function was called");
        StartCoroutine(LoadSceneAfterTransition());
    }

    private IEnumerator LoadSceneAfterTransition()
    {

        //player = GameObject.FindGameObjectWithTag("Player");
        //DontDestroyOnLoad(player);
        //show animate out animation
        Debug.Log("Changing scene");
        animator.SetBool("animateOut", true);
        yield return new WaitForSeconds(1f);        //load the scene we want
        SceneManager.LoadScene(sceneName);
    }
}