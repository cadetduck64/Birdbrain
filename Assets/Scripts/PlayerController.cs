using NUnit.Framework.Internal.Execution;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    private GameObject peckHitbox;

    private GameManager gameManagerVariable;

    public float hoverForce;
    public float speed;
    public int jumpForce; // default 60 @ 10 mass

    private int lastRotation;

    public bool isHovering;

    //debug varible for checking ground contact
    // public float raycast;

    public LayerMask layerMask;


    [SerializeField] GameObject playerModel;

    public void PlayerPeckAttack()
    {
        Animator anim = playerModel.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        // Debug.Log("ATTACKED");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManagerVariable = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
        speed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerVariable.isPaused)
        {return;}

        // if (Input.GetKeyDown(KeyCode.Escape))
        // {gameManagerVariable.PauseGame();}
        
        //moves the player to a set Z axis if deviated from
        if (playerRb.transform.position.z != 0)
        {playerRb.transform.position = new Vector3(playerRb.transform.position.x, playerRb.transform.position.y, 0);}

        //allows player to move around (multiplies forward input, speed variable and applies direction via vector)
        float forwardInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(forwardInput * speed * Vector3.right, ForceMode.VelocityChange);
        
        //checks if player is sliding by determining if forward input is positive and and velocity is not (or vice versa) and activates slide)

        //checks if player is touching the ground by sending a small raycast downward and checking for a layermask
        bool IsOnGround() {
            return Physics.Raycast(new Ray(transform.position, new Vector3(0, -1 , 0).normalized), 0.2f, layerMask);
        }

        bool IsSliding () {
            return forwardInput < 0 && playerRb.linearVelocity.normalized.x > 0 || forwardInput > 0 && playerRb.linearVelocity.normalized.x < 0;
        }

        bool IsSlidingOnGround() {
            return IsOnGround() && IsSliding();
        }

        
        //check if player is touching the ground by checking true for on IsOnGround and IsSliding functions
        //check if player is touching the ground by checking true for on IsOnGround and IsSliding functions

        //changes last recorded rotation direction in the forward input variable and tracks key presses to turn the model
        if (forwardInput < 0)
        {lastRotation = -90;}
        else if (forwardInput > 0)
        {lastRotation = 90;}

        //plays peck attack animation on keypress (if player is sliding on the ground, attack will not activate)
        if (Input.GetKeyDown(KeyCode.Q) && !IsSlidingOnGround())
        {PlayerPeckAttack();}
        
        //allows player to dash by applying vector force based on last rotation
        if (Input.GetKeyDown(KeyCode.R))
        {if(lastRotation < 0)
        {playerRb.AddForce(new Vector3(-10, 0, 0), ForceMode.VelocityChange);}
        else if (lastRotation > 0) {playerRb.AddForce(new Vector3(10, 0, 0), ForceMode.VelocityChange);}
        }

        //locks player Y axis if isHovering bool is true
        if (Input.GetKeyDown(KeyCode.LeftShift) && !IsOnGround())
        {if (isHovering) {isHovering = false;}
        else if (!isHovering) {isHovering = true;}}

        //applies hover on keypress
        if (isHovering)
        {playerRb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;}
        else {playerRb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;}

        //applies player speed limit
        if (playerRb.linearVelocity.x > 10)
        {playerRb.AddForce(new Vector3(-0.2f, 0, 0), ForceMode.VelocityChange);}
        else if (playerRb.linearVelocity.x < -10)
        {playerRb.AddForce(new Vector3(0.2f, 0, 0), ForceMode.VelocityChange);}

        //rotates playermodel depending on last direction keypress
        if (IsSlidingOnGround())
        {playerRb.transform.eulerAngles = new Vector3(0, 0, 0);}
        else if (forwardInput / 1 != 1)
        {playerRb.transform.eulerAngles = new Vector3(0, -lastRotation, 0);}
        else {playerRb.transform.eulerAngles = new Vector3(0, forwardInput * -90, 0);}

        //applies jump force
        if (Input.GetKeyDown(KeyCode.Space))
        {isHovering = false;
        playerRb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);}
        else if (Input.GetKey(KeyCode.Space))
        {playerRb.AddForce(new Vector3(0, 0.075f, 0), ForceMode.VelocityChange);}

        // Debug.Log(forwardInput);
        // Debug.Log(playerRb.linearVelocity);
        // Debug.Log(playerRb.transform.position);
    }
}
