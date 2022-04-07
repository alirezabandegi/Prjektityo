using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player walk speed for forward or backward;
    public float playerWalk;
    //Player run speed for forward or backward;
    public float playerRun;
    //Player rotation for rotate left or right;
    public float rotation;

    //Player movment speed for forward or backward;
    private float speed;

    //what this do?
    Animator animator;
    static readonly int Horizontal = Animator.StringToHash("Horizontal");
    static readonly int Vertical = Animator.StringToHash("Vertical");
    static readonly int Moving = Animator.StringToHash("Moving");

    // Start is called before the first frame update
    void Start()
    {
        //what this do?
        animator = GetComponent<Animator>();
    }//Start

    // Update is called once per frame
    void Update()
    {
        //If player press Leftshitf, player can run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = playerRun;
        }
        //If player not press Leftshitf, player walk
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            speed = playerWalk;
        }

        //Add speed for player forward or backward
        float moveForwardOrBackward = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //Add speed for player left or right
        float moveLeftOrRight = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //Add rotation for player rotation to left or right
        float RotationLeftOrRight = Input.GetAxis("Mouse X") * rotation * Time.deltaTime;

        //what this do?
        animator.SetFloat(Horizontal, moveLeftOrRight);
        animator.SetFloat(Vertical, moveForwardOrBackward);
        float absoluteMovement = Mathf.Abs(moveForwardOrBackward + moveLeftOrRight);
        animator.SetBool(Moving, absoluteMovement > 0);

        //player forward or backward
        transform.Translate(moveLeftOrRight, 0, moveForwardOrBackward);
        //player rotation
        transform.Rotate(0, RotationLeftOrRight, 0);

        

    }//Update

}//Class
