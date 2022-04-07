using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player movment speed for forward or backward;
    public float speed;
    //Player rotation for rotate left or right;
    public float rotation;
    Animator animator;
    static readonly int Horizontal = Animator.StringToHash("Horizontal");
    static readonly int Vertical = Animator.StringToHash("Vertical");
    static readonly int Moving = Animator.StringToHash("Moving");

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }//Start

    // Update is called once per frame
    void Update()
    {
        //Add speed for player forward or backward
        float moveForwardOrBackward = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //Add speed for player left or right
        float moveLeftOrRight = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //Add rotation for player rotation to left or right
        float RotationLeftOrRight = Input.GetAxis("Mouse X") * rotation * Time.deltaTime;
        
        animator.SetFloat(Horizontal, moveLeftOrRight);
        animator.SetFloat(Vertical, moveForwardOrBackward);
        float absoluteMovement = Mathf.Abs(moveForwardOrBackward + moveLeftOrRight);
        animator.SetBool(Moving, absoluteMovement > 0);

        //forward or backward player
        transform.Translate(moveLeftOrRight, 0, moveForwardOrBackward);
        //transform.Rotate(0, rotation, 0);
        transform.Rotate(0, RotationLeftOrRight, 0);

    }//Update

}//Class
