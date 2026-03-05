using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class Character : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 5.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private Camera camAccess;
    private float direction;

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
        */

        /*
        // Source: https://discussions.unity.com/t/gravity-with-character-controller/53805/3 The problem is that its tank controls, left and right rotate rather than make character go left and right.
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
        Vector3 vel = new Vector3(Input.GetAxis("Vertical"), 0, 0);
        vel = transform.forward * Input.GetAxis("Vertical") * charSpeed;
        //var controller = GetComponent(CharacterController);
        characterController.SimpleMove(vel);
        */

        /*
        //Source: https://docs.unity3d.com/2022.3/Documentation/ScriptReference/CharacterController.SimpleMove.html Even though this is from official unity documentation, its still tank controls. I guess that means move is better than simple move
        // Rotate around y - axis
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed, 0);

        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = charSpeed * Input.GetAxis("Vertical");
        characterController.SimpleMove(forward * curSpeed);
        */

        //Source: https://docs.unity3d.com/2022.3/Documentation/ScriptReference/CharacterController.Move.html This is from unity official documentation, LETS GOOOOO
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            camAccess = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); //what a ridiculous coding language, https://discussions.unity.com/t/get-a-camera-by-tag/384618/3
            direction = camAccess.transform.eulerAngles.y;
            /* Debug.Log("Camera angle is " + direction);
            Debug.Log("Horizontal is" + Input.GetAxis("Horizontal"));
            Debug.Log("Vertical is" + Input.GetAxis("Vertical")); */
        }

        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        //this is the movement. I don't exactly know what it means
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 turnedMove = Quaternion.Euler(0, direction, 0) * move; //Thank you https://discussions.unity.com/t/move-character-relative-to-camera-angle/666879/6
        characterController.Move(turnedMove * Time.deltaTime * playerSpeed);

        /*if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }*/

        // Makes the player jump
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }
}
