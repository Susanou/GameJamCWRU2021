using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Transform feet;
    public LayerMask groundLayer; // Should allways be "Ground". Select from inspector
    public float jumpTime; // So that player can jump higher the longer he presses SPACE
    private float jumpTimeCounter; // variable to count the jump time above

    [SerializeField] private float speed = 25f;
    [SerializeField] private float jump = 1.5f;


    private Transform transform;
    private Rigidbody2D rigidBody;
    
    private bool isJumping;
    private bool onGround;
    private float groundCheckRadius = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        transform  = gameObject.GetComponent<Transform>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement(){

        onGround = Physics2D.OverlapCircle(feet.position, groundCheckRadius, groundLayer);

        //Starts the jump
        if ((Input.GetKeyDown(KeyCode.Space)) && onGround)
        {
            isJumping = true;

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
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space)){
            isJumping = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            //isJumping = false;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

    }

    //Prevision of furture movement
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "FallThrough" && (Input.GetKey(KeyCode.S)))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>(), true);
        }
    }

}
