using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public Transform feet;
    public LayerMask groundLayer; // Should allways be "Ground". Select from inspector
    public Signal timeSapce;
    public float jumpTime; // So that player can jump higher the longer he presses SPACE
    private float jumpTimeCounter; // variable to count the jump time above

    [SerializeField] private float speed = 25f;
    [SerializeField] private float jump = 1.5f;

    [HideInInspector] public static PlayerController instance;
    private Transform position;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private SpriteRenderer sprite;

    private bool isJumping;
    private int isMoving; // -1 Left, 0 for not moving, 1 Right
    private bool onGround;
    private float groundCheckRadius = 0.3f;
    public bool ghostEffect = false;

    private bool isEnd = false;

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


    // Start is called before the first frame update
    void Start()
    {
        position  = gameObject.GetComponent<Transform>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        //DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnd){
            PlayerMovement();

            if (Input.GetKeyDown(KeyCode.F))
            {
                timeSapce.Raise();
                SwapColor();
            }
        }
    }

    private void PlayerMovement(){

        onGround = Physics2D.OverlapCircle(feet.position, groundCheckRadius, groundLayer);

        //Starts the jump
        if ((Input.GetKeyDown(KeyCode.Space)) && onGround)
        {
            isJumping = true;
            animator.SetInteger("isJumping",1);
            jumpTimeCounter = jumpTime;
            rigidBody.velocity = Vector2.up * jump;
        }

        //The longer you stay pressed the higher you go
        if ((Input.GetKey(KeyCode.Space)) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {

                rigidBody.velocity = Vector2.up * jump;
                jumpTimeCounter -= Time.deltaTime;

            }
            else
            {
                animator.SetInteger("isJumping",-1);
                isJumping = false;
            }
        }
        else if (onGround) {
            animator.SetInteger("isJumping",0);
        }

        if (Input.GetKeyUp(KeyCode.Space)){
            isJumping = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            isMoving = -1;
            if (position.localScale.x > 0) position.localScale = new Vector3(position.localScale.x*-1,position.localScale.y,position.localScale.z); //Flips sprite to face left when moving left
            //isJumping = false;
            animator.SetBool("isPlayerMoving",true);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            isMoving = 1;
            if (position.localScale.x < 0) position.localScale = new Vector3(position.localScale.x*-1,position.localScale.y,position.localScale.z); //Flips sprite to face right when moving right
            animator.SetBool("isPlayerMoving",true);
        }
        else
        {
            animator.SetBool("isPlayerMoving",false);
            isMoving = 0;
        }

    }

    private void FixedUpdate() {
        float mH = Input.GetAxis("Horizontal");
        
        rigidBody.velocity = new Vector2(mH*speed, rigidBody.velocity.y);
    }

    //Prevision of furture movement
    void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log(collision);
        if (collision.collider.tag == "FallThrough" && ((Input.GetKey(KeyCode.S))||(Input.GetKey(KeyCode.Space))))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>(), true);
            StartCoroutine(ReenableCollision(collision.collider,0.6f));
        }
        else if(collision.collider.tag == "Pushable" && (collision.GetContact(0).normal.x*isMoving) < 0)
        {
            collision.collider.attachedRigidbody.position += new Vector2(Mathf.Sign(position.localScale.x) * speed * Time.deltaTime, 0);
        }
    }

    private IEnumerator ReenableCollision(Collider2D collidesWith, float delay)
    {
        yield return new WaitForSeconds(delay);
        Physics2D.IgnoreCollision(collidesWith, GetComponent<Collider2D>(), false);
    }

    void OnTriggerEnter2D(Collider2D collider){

        if(collider.tag == "End"){
            collider.GetComponent<Animator>().SetBool("IsEnd",true);
            sprite.enabled = false;
            isEnd = true;
        }

    }

    private void SwapColor()
    {
        Debug.Log("Swap color?");
        sprite.color = ghostEffect ? new Color(1,1,1,1) : new Color(0.35f,0.39f,0.41f,0.46f);
        ghostEffect = !ghostEffect;
        Debug.Log(ghostEffect);
    }

    private void EndScene(){
        SceneManager.LoadScene("End Scene");
    }
}
