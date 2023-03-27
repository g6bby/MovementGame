using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 

    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public float maxSpeed;

    public float jumpForce;
    public float airMultiplier;
    private bool doubleJump;

    public float gravityScale;
    //bool readyToJump;

    public float shiftWalk;

    //animation
    Animator m_Animator;
    bool isJumping;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask isGround;
    bool grounded;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        m_Animator = gameObject.GetComponent<Animator>();
        isJumping = false;
    }


    void Update()
    {
        MyInput();
        SpeedControl();

        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, isGround);

        //drag
        if (grounded)
        {
            rb.drag = groundDrag;
     
        }

        else
        {
            rb.drag = 0;
    

           
        }


        //jump + double jump
        if (grounded && !Input.GetKey(KeyCode.Space))
        {
            doubleJump = false;
            isJumping = false;

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded || doubleJump)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

                doubleJump = !doubleJump;

                isJumping = true;
            }

            if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * 0.2f);
                isJumping = true;
           
                
            }

            if (isJumping == false) 
                m_Animator.SetBool("Jump", false);
            

            if (isJumping == true) 
                m_Animator.SetBool("Jump", true);
            

        }

        //shift to walk
        //if (grounded && Input.GetKey(KeyCode.LeftShift))
        //{
        //    rb.velocity = new Vector3(rb.velocity.x, shiftWalk);
        //}

        
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        //calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //on ground
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        //in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

        //jump fall
        if (!grounded)
        {
            rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);

        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        //velocity limit if needed
        if (flatVel.magnitude > maxSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * maxSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

}