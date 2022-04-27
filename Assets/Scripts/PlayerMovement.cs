using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Get RigidBody
    private Rigidbody rb;

    //Player walk speed for forward or backward;
    public float playerWalk;
    //Player run speed for forward or backward;
    public float playerRun;
    //Player rotation for rotate left or right;
    public float rotation;

    //Player movment speed for forward or backward;
    private float speed;
    //time is 0
    private float time = 0.0f;

    //player jump is default false
    private bool isJumpPressed = false;
    

    [SerializeField] PlayerAnimation animations;

    // Start is called before the first frame update
    void Start()
    {
        //get RigidBody component
        rb = GetComponent<Rigidbody>();
    }//Start

    // Update is called once per frame
    void Update()
    {
        //If player press Leftshitf, player can run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        if (isRunning)
        {
            //set speed to "playerRun" speed
            speed = playerRun;
        }
        //If player not press Leftshitf, player walk
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            //set speed to "playerWalk" speed
            speed = playerWalk;
        }

        //Add speed for player forward or backward
        float moveForwardOrBackward = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //Add speed for player left or right
        float moveLeftOrRight = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //Add rotation for player rotation to left or right
        float RotationLeftOrRight = Input.GetAxis("Mouse X") * rotation * Time.deltaTime;

        
        //Give the animation controller our input for playing the animations
        animations.Animate(moveLeftOrRight, moveForwardOrBackward, isJumpPressed, isRunning, Input.GetKey(KeyCode.R)); //delegate reload later

        //player forward or backward
        transform.Translate(moveLeftOrRight, 0, moveForwardOrBackward);
        //player rotation
        transform.Rotate(0, RotationLeftOrRight, 0);
        //if player press "Space" bool is true
        isJumpPressed = Input.GetKey(KeyCode.Space);

    }//Update

    // Fixed Update is called once per frame for most frames but not all
    void FixedUpdate()
    {
        //add game time to "time" variable
        time += Time.fixedDeltaTime;

        //if player press "Space" and if 1.5 seconds have elapsed since it jumped, the player can jump again.
        if (isJumpPressed && time > 1.5f)
        {
            //jump
            print(isJumpPressed);
            rb.velocity = new Vector3(0, 6, 0);
            //set time to 0
            time = 0.0f;
        }

    }//Fixed Update

}//Class
