using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player movment speed for forward or backward;
    public float speed;
    //Player rotation for rotate left or right;
    public float rotation;

    // Start is called before the first frame update
    void Start()
    {
        
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


        //forward or backward player
        transform.Translate(moveLeftOrRight, 0, moveForwardOrBackward);
        //transform.Rotate(0, rotation, 0);
        transform.Rotate(0, RotationLeftOrRight, 0);

    }//Update

}//Class
