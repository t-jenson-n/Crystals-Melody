using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class Character : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 5.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;
    public float rotationSpeed;
    public Animator moveAnimator;
    private float pickAnimTimer = 0f;
    public float pickAnimDelay;
    private Camera camAccess;
    private float direction;
    public GameObject MenuStatus;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    
    // Update is called once per frame
    void Update()
    {
        /*
        //old code
        //Code source: https://www.youtube.com/watch?v=hiXYyn9NkOo
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(move * Time.deltaTime * playerSpeed);



        // Source: https://discussions.unity.com/t/gravity-with-character-controller/53805/3 The problem is that its tank controls, left and right rotate rather than make character go left and right.
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
        Vector3 vel = new Vector3(Input.GetAxis("Vertical"), 0, 0);
        vel = transform.forward * Input.GetAxis("Vertical") * charSpeed;
        //var controller = GetComponent(CharacterController);
        characterController.SimpleMove(vel);



        //Source: https://docs.unity3d.com/2022.3/Documentation/ScriptReference/CharacterController.SimpleMove.html Even though this is from official unity documentation, its still tank controls. I guess that means move is better than simple move
        // Rotate around y - axis
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed, 0);

        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = charSpeed * Input.GetAxis("Vertical");
        characterController.SimpleMove(forward * curSpeed);
        */
        //Found Timer code from: https://docs.unity3d.com/ScriptReference/Time-deltaTime.html
        //decrease delay timer
        if (pickAnimTimer > 0f)
        {
            pickAnimTimer -= Time.deltaTime;
        }
        //if it goes below 0, set it to 0
        if (pickAnimTimer < 0f)
        {
            pickAnimTimer = 0f;
        }

        //Source: https://docs.unity3d.com/2022.3/Documentation/ScriptReference/CharacterController.Move.html This is from unity official documentation, LETS GOOOOO
        //snippet to retrieve angle of camera
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) && MenuStatus == false)
        {
            //store camera based on cam with tag and store direction
            camAccess = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); //what a ridiculous coding language, https://discussions.unity.com/t/get-a-camera-by-tag/384618/3
            //Got anim Coding from here: https://www.youtube.com/watch?v=Fqvxbir7HlE
            direction = camAccess.transform.eulerAngles.y;
            moveAnimator.SetBool("ifMoving", true);

            //_________________________________________________
            Debug.Log("Moving!");
            
        } else if (Input.anyKey != true)
        {
            moveAnimator.SetBool("ifMoving", false);
            
            //________________________________________
        }

        //when user presses E, play swing anim
        if (Input.GetKeyDown(KeyCode.E) && pickAnimTimer == 0)
        {
            moveAnimator.SetTrigger("ePick");
            pickAnimTimer = pickAnimDelay;
        }

        //no idea what this is
        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        //this is the movement. makes a new vector by taking horizontal and vertical inputs (wasd)
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //make new vector, multiply y angle to change direction
        Vector3 turnedMove = Quaternion.Euler(0, direction, 0) * move; //Thank you https://discussions.unity.com/t/move-character-relative-to-camera-angle/666879/6
        //move character based on time and speed, using turned move for direction
        characterController.Move(turnedMove * Time.deltaTime * playerSpeed);

        //turning from here https://www.youtube.com/watch?v=BJzYGsMcy8Q
        if (turnedMove != Vector3.zero)
        {
            //simple solution
            //transform.forward = turnedMove;

            //better solution!
            Quaternion toRotation = Quaternion.LookRotation(turnedMove, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        //idk
        /*if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }*/


        // Makes the player jump. Removed
        /*
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }
        */

        //gravity
        playerVelocity.y += gravityValue * Time.deltaTime;
        //moves the character based on y axis, tied to time rather than framerate
        characterController.Move(playerVelocity * Time.deltaTime);
    
    
    
        //TRYING TO ADD SOMETHING FOR MENU++++++++++++++++
        //if (gameObject.Find("MenuManager").GetComponent<MenuManager>().MenuStatus)
        //{
            //Horizontal = Input.GetAxis("Horizontal");
        //}
       // else
        //{
            //horizontal = 0;
        //}
    
    }
}
