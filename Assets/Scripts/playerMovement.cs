using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [Header("References")]
    public Rigidbody playerRigidBody;
    [Header("Movement stuff")]
    public int multiplier = 10;
    public float counterMovementRatio;
    public float forwardSpeed;
    public float backwardSpeed;
    public float sideSpeed;
    public float maxSpeed, minSpeed;
    public float slideSpeed;
    public Vector3 slideScale;
    [Header("jumping")]
    public ParticleSystem jumpParticle;
    public bool hasJumped = false;
    public float jumpForce;
    public float groundCheckDistance, wallCheckDistance;
    public LayerMask groundLayer;
    [Header("crouching and sliding")]
    private Vector3 playerScale;
    private bool isCrouched = false, counteringMovement = false;

    float xMove;
    float zMove;
    float forwardMovement;
    float sideways;
    // Start is called before the first frame update
    void Start()
    {
        jumpParticle.Stop();
        isCrouched = false;
        playerScale = transform.localScale;
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
    }
    public void wallJump()
    {
        if(hasJumped && groundCheck() == false)
        {
            Collider[] walls = Physics.OverlapSphere(transform.position, wallCheckDistance, groundLayer);
            if (walls != null)
            {
                Vector3 dir = transform.localPosition - walls[0].transform.localPosition;
                dir = new Vector3(dir.x, 0, 0);
                playerRigidBody.AddForce(dir.normalized * jumpForce * multiplier);
                playerRigidBody.AddForce(Vector3.up * jumpForce * multiplier);
            }
        }
    }
    public void jump()
    {
       
            if (hasJumped)
            {
                if (groundCheck())
                {
                jumpParticle.Play();

                hasJumped = false;
                }
            }
            else
            {
                playerRigidBody?.AddForce(Vector3.up * jumpForce * multiplier);
                hasJumped = true;
            }
        
    }
    public bool groundCheck()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        return Physics.Raycast(ray, groundCheckDistance, groundLayer);
    }
    public void move()
    {
        playerRigidBody.AddForce(Vector3.down* Time.deltaTime * 10);
        if(playerRigidBody.velocity.magnitude == 0)
        {
            counteringMovement = false;
        }
        if (playerRigidBody.velocity.magnitude < maxSpeed)
        {
/*            xMove = Input.GetAxis("Horizontal");
            zMove = Input.GetAxis("Vertical");
*/
            forwardMovement = zMove > 0 ? zMove * forwardSpeed  * multiplier* Time.deltaTime : zMove * multiplier* backwardSpeed * Time.deltaTime;
            sideways = xMove * sideSpeed *multiplier* Time.deltaTime;


            //Forward / backward movement
            playerRigidBody.AddForce(transform.forward * forwardMovement);
            //Sideways movements
            playerRigidBody.AddForce(transform.right * sideways);
        }
        if (playerRigidBody.velocity.magnitude > minSpeed || counteringMovement == true)
        {
            counteringMovement = true;
            counterMove();
        }
/*        if (Input.GetKeyDown(KeyCode.C))
        {

                startCrouch();        
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            endCrouch();
        }*/
    }
    public void startSlide()
    {
        playerRigidBody.AddForce(transform.forward * slideSpeed * multiplier);

        }
    public void endSlide()
    { 
    
    }

    public void endCrouch()
    {
 /*       transform.localScale = playerScale;
        isCrouched = false;*/
    }
    public void startCrouch()
    {
/*        transform.localScale = slideScale;
        isCrouched = true;*/
        if (playerRigidBody.velocity.magnitude > minSpeed)
        {
            startSlide();
        }
    }

    private void counterMove()
    {
        if (isCrouched == false)
        {
            playerRigidBody.AddForce(transform.forward * forwardMovement * -1 * counterMovementRatio);
            playerRigidBody.AddForce(transform.right * sideways * -1 * counterMovementRatio);
        }
    }

    #region inputEvent
    public void XMovment_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        xMove = obj.ReadValue<float>();
    }
    public void ZMovment_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        zMove = obj.ReadValue<float>();
    }
    public void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        jump();
    }
    #endregion
}
