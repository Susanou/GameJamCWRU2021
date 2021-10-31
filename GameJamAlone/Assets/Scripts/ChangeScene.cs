using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int sceneIndex;    
    Animator animator;   

    private GameObject player; 
    void Start()
    {
        animator = transform.GetComponent<Animator>();
    }    
    
    void Update()
    {

    }    
    
    public void changeScene(){
        StartCoroutine(LoadSceneAfterTransition());
    }

    private IEnumerator LoadSceneAfterTransition()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //DontDestroyOnLoad(player);
        //show animate out animation
        animator.SetBool("animateOut", true);
        yield return new WaitForSeconds(1f);        //load the scene we want
        SceneManager.LoadScene(sceneIndex);
    }
}