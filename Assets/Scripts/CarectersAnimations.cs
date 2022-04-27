using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarectersAnimations : MonoBehaviour
{

    private Animator animator;

    private int isJumpingHash;

    private int isWalkingHash;
    private int isWalkingRightHash;
    private int isWalkingLeftHash;
    private int isWalkingBackwardHash;
    private int isWalkingForwardRightHash;
    private int isWalkingForwardLeftHash;
    private int isWalkingBackwardRightHash;
    private int isWalkingBackwardLeftHash;

    private int isRuningHash;
    private int isRuningRightHash;
    private int isRuningLeftHash;
    private int isRuningBackwardHash;
    private int isRuningForwardRightHash;
    private int isRuningForwardLeftHash;
    private int isRuningBackwardRightHash;
    private int isRuningBackwardLeftHash;

    private int isCrouchingIdleHash;
    private int isCrouchingHash;
    private int isCrouchingRightHash;
    private int isCrouchingLeftHash;
    private int isCrouchingBackwardHash;
    private int isCrouchingForwardRightHash;
    private int isCrouchingForwardLeftHash;
    private int isCrouchingBackwardRightHash;
    private int isCrouchingBackwardLeftHash;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        isJumpingHash = Animator.StringToHash("isJumping");

        isWalkingHash = Animator.StringToHash("isWalking");
        isWalkingRightHash = Animator.StringToHash("isWalkingRight");
        isWalkingLeftHash = Animator.StringToHash("isWalkingLeft");
        isWalkingBackwardHash = Animator.StringToHash("isWalkingBackward");
        isWalkingForwardRightHash = Animator.StringToHash("isWalkingForwardRight");
        isWalkingForwardLeftHash = Animator.StringToHash("isWalkingForwardLeft");
        isWalkingBackwardRightHash = Animator.StringToHash("isWalkingBackwardRight");
        isWalkingBackwardLeftHash = Animator.StringToHash("isWalkingBackwardLeft");

        isRuningHash = Animator.StringToHash("isRuning");
        isRuningRightHash = Animator.StringToHash("isRuningRight");
        isRuningLeftHash = Animator.StringToHash("isRuningLeft");
        isRuningBackwardHash = Animator.StringToHash("isRuningBackward");
        isRuningForwardRightHash = Animator.StringToHash("isRuningForwardRight");
        isRuningForwardLeftHash = Animator.StringToHash("isRuningForwardLeft");
        isRuningBackwardRightHash = Animator.StringToHash("isRuningBackwardRight");
        isRuningBackwardLeftHash = Animator.StringToHash("isRuningBackwardLeft");

        isCrouchingIdleHash = Animator.StringToHash("isCrouchingIdle");
        isCrouchingHash = Animator.StringToHash("isCrouching");
        isCrouchingRightHash = Animator.StringToHash("isCrouchingRight");
        isCrouchingLeftHash = Animator.StringToHash("isCrouchingLeft");
        isCrouchingBackwardHash = Animator.StringToHash("isCrouchingBackward");
        isCrouchingForwardRightHash = Animator.StringToHash("isCrouchingForwardRight");
        isCrouchingForwardLeftHash = Animator.StringToHash("isCrouchingForwardLeft");
        isCrouchingBackwardRightHash = Animator.StringToHash("isCrouchingBackwardRight");
        isCrouchingBackwardLeftHash = Animator.StringToHash("isCrouchingBackwardLeft");

    }//Start

    // Update is called once per frame
    void Update()
    {
        bool isJumping = animator.GetBool(isJumpingHash);

        bool isWalking = animator.GetBool(isWalkingHash);
        bool isWalkingRight = animator.GetBool(isWalkingRightHash);
        bool isWalkingLeft = animator.GetBool(isWalkingLeftHash);
        bool isWalkingBackward = animator.GetBool(isWalkingBackwardHash);
        bool isWalkingForwardRight = animator.GetBool(isWalkingForwardRightHash);
        bool isWalkingForwardLeft = animator.GetBool(isWalkingForwardLeftHash);
        bool isWalkingBackwardRight = animator.GetBool(isWalkingBackwardRightHash);
        bool isWalkingBackwardLeft = animator.GetBool(isWalkingBackwardLeftHash);

        bool isRuning = animator.GetBool(isRuningHash);
        bool isRuningRight = animator.GetBool(isRuningRightHash);
        bool isRuningLeft = animator.GetBool(isRuningLeftHash);
        bool isRuningBackward = animator.GetBool(isRuningBackwardHash);
        bool isRuningForwardRight = animator.GetBool(isRuningForwardRightHash);
        bool isRuningForwardLeft = animator.GetBool(isRuningForwardLeftHash);
        bool isRuningBackwardRight = animator.GetBool(isRuningBackwardRightHash);
        bool isRuningBackwardLeft = animator.GetBool(isRuningBackwardLeftHash);

        bool isCrouchingIdle = animator.GetBool(isCrouchingIdleHash);
        bool isCrouching = animator.GetBool(isCrouchingHash);
        bool isCrouchingRight = animator.GetBool(isCrouchingRightHash);
        bool isCrouchingLeft = animator.GetBool(isCrouchingLeftHash);
        bool isCrouchingBackward = animator.GetBool(isCrouchingBackwardHash);
        bool isCrouchingForwardRight = animator.GetBool(isCrouchingForwardRightHash);
        bool isCrouchingForwardLeft = animator.GetBool(isCrouchingForwardLeftHash);
        bool isCrouchingBackwardRight = animator.GetBool(isCrouchingBackwardRightHash);
        bool isCrouchingBackwardLeft = animator.GetBool(isCrouchingBackwardLeftHash);

        bool isWPressed = Input.GetKey(KeyCode.W);
        bool isSPressed = Input.GetKey(KeyCode.S);
        bool isAPressed = Input.GetKey(KeyCode.A);
        bool isDPressed = Input.GetKey(KeyCode.D);
        bool isLeftShiftPressed = Input.GetKey(KeyCode.LeftShift);
        bool isLeftControlPressed = Input.GetKey(KeyCode.LeftControl);
        bool isSpacePressed = Input.GetKey(KeyCode.Space);

        if (!isJumping && isSpacePressed)
        {
            animator.SetBool(isJumpingHash, true);
        }
        else if (isJumping && !isSpacePressed)
        {
            animator.SetBool(isJumpingHash, false);
        }

        if (!isWalking && isWPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }
        else if (isWalking && !isWPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isWalkingRight && isDPressed)
        {
            animator.SetBool(isWalkingRightHash, true);
        }
        else if (isWalkingRight && !isDPressed)
        {
            animator.SetBool(isWalkingRightHash, false);
        }

        if (!isWalkingLeft && isAPressed)
        {
            animator.SetBool(isWalkingLeftHash, true);
        }
        else if (isWalkingLeft && !isAPressed)
        {
            animator.SetBool(isWalkingLeftHash, false);
        }

        if (!isWalkingBackward && isSPressed)
        {
            animator.SetBool(isWalkingBackwardHash, true);
        }
        else if (isWalkingBackward && !isSPressed)
        {
            animator.SetBool(isWalkingBackwardHash, false);
        }

        if (!isWalkingForwardRight && (isWPressed && isDPressed))
        {
            animator.SetBool(isWalkingForwardRightHash, true);
        }
        else if (isWalkingForwardRight && !(isWPressed && isDPressed))
        {
            animator.SetBool(isWalkingForwardRightHash, false);
        }

        if (!isWalkingForwardLeft && (isWPressed && isAPressed))
        {
            animator.SetBool(isWalkingForwardLeftHash, true);
        }
        else if (isWalkingForwardLeft && !(isWPressed && isAPressed))
        {
            animator.SetBool(isWalkingForwardLeftHash, false);
        }

        if (!isWalkingBackwardRight && (isSPressed && isDPressed))
        {
            animator.SetBool(isWalkingBackwardRightHash, true);
        }
        else if (isWalkingBackwardRight && !(isSPressed && isDPressed))
        {
            animator.SetBool(isWalkingBackwardRightHash, false);
        }

        if (!isWalkingBackwardLeft && (isSPressed && isAPressed))
        {
            animator.SetBool(isWalkingBackwardLeftHash, true);
        }
        else if (isWalkingBackwardLeft && !(isSPressed && isAPressed))
        {
            animator.SetBool(isWalkingBackwardLeftHash, false);
        }

        if (!isRuning && (isWPressed && isLeftShiftPressed))
        {
            animator.SetBool(isRuningHash, true);
        }
        else if (isRuning && !(isWPressed && isLeftShiftPressed))
        {
            animator.SetBool(isRuningHash, false);
        }

        if (!isRuningRight && (isWPressed && isDPressed  && isLeftShiftPressed))
        {
            animator.SetBool(isRuningRightHash, true);
        }
        else if (isRuningRight && !(isWPressed && isDPressed && isLeftShiftPressed))
        {
            animator.SetBool(isRuningRightHash, false);
        }

        if (!isRuningLeft && (isWPressed && isAPressed && isLeftShiftPressed))
        {
            animator.SetBool(isRuningLeftHash, true);
        }
        else if (isRuningLeft && !(isWPressed && isAPressed && isLeftShiftPressed))
        {
            animator.SetBool(isRuningLeftHash, false);
        }

        if (!isRuningBackward && (isSPressed && isLeftShiftPressed))
        {
            animator.SetBool(isRuningBackwardHash, true);
        }
        else if (isRuningBackward && !(isSPressed && isLeftShiftPressed))
        {
            animator.SetBool(isRuningBackwardHash, false);
        }

        if (!isRuningForwardRight && (isWPressed && isDPressed && isLeftShiftPressed))
        {
            animator.SetBool(isRuningForwardRightHash, true);
        }
        else if (isRuningForwardRight && !(isWPressed && isDPressed && isLeftShiftPressed))
        {
            animator.SetBool(isRuningForwardRightHash, false);
        }

        if (!isRuningForwardLeft && (isWPressed && isAPressed && isLeftShiftPressed))
        {
            animator.SetBool(isRuningForwardLeftHash, true);
        }
        else if (isRuningForwardLeft && !(isWPressed && isAPressed && isLeftShiftPressed))
        {
            animator.SetBool(isRuningForwardLeftHash, false);
        }

        if (!isRuningBackwardRight && (isSPressed && isDPressed && isLeftShiftPressed))
        {
            animator.SetBool(isRuningBackwardRightHash, true);
        }
        else if (isRuningBackwardRight && !(isSPressed && isDPressed && isLeftShiftPressed))
        {
            animator.SetBool(isRuningBackwardRightHash, false);
        }

        if (!isRuningBackwardLeft && (isSPressed && isAPressed && isLeftShiftPressed))
        {
            animator.SetBool(isRuningBackwardLeftHash, true);
        }
        else if (isRuningBackwardLeft && !(isSPressed && isAPressed && isLeftShiftPressed))
        {
            animator.SetBool(isRuningBackwardLeftHash, false);
        }

        if (!isCrouchingIdle && isLeftControlPressed)
        {
            animator.SetBool(isCrouchingIdleHash, true);
        }
        else if (isCrouchingIdle && !isLeftControlPressed)
        {
            animator.SetBool(isCrouchingIdleHash, false);
        }

        if (!isCrouching && (isLeftControlPressed && isWPressed))
        {
            animator.SetBool(isCrouchingHash, true);
        }
        else if (isCrouching && !(isLeftControlPressed && isWPressed))
        {
            animator.SetBool(isCrouchingHash, false);
        }

        if (!isCrouchingRight && (isLeftControlPressed && isDPressed))
        {
            animator.SetBool(isCrouchingRightHash, true);
        }
        else if (isCrouchingRight && !(isLeftControlPressed && isDPressed))
        {
            animator.SetBool(isCrouchingRightHash, false);
        }

        if (!isCrouchingLeft && (isLeftControlPressed && isAPressed))
        {
            animator.SetBool(isCrouchingLeftHash, true);
        }
        else if (isCrouchingLeft && !(isLeftControlPressed && isAPressed))
        {
            animator.SetBool(isCrouchingLeftHash, false);
        }

        if (!isCrouchingBackward && (isLeftControlPressed && isSPressed))
        {
            animator.SetBool(isCrouchingBackwardHash, true);
        }
        else if (isCrouchingBackward && !(isLeftControlPressed && isSPressed))
        {
            animator.SetBool(isCrouchingBackwardHash, false);
        }

        if (!isCrouchingForwardRight && (isLeftControlPressed && isWPressed && isDPressed))
        {
            animator.SetBool(isCrouchingForwardRightHash, true);
        }
        else if (isCrouchingForwardRight && !(isLeftControlPressed && isWPressed && isDPressed))
        {
            animator.SetBool(isCrouchingForwardRightHash, false);
        }

        if (!isCrouchingForwardLeft && (isLeftControlPressed && isWPressed && isAPressed))
        {
            animator.SetBool(isCrouchingForwardLeftHash, true);
        }
        else if (isCrouchingForwardLeft && !(isLeftControlPressed && isWPressed && isAPressed))
        {
            animator.SetBool(isCrouchingForwardLeftHash, false);
        }

        if (!isCrouchingBackwardRight && (isLeftControlPressed && isSPressed && isDPressed))
        {
            animator.SetBool(isCrouchingBackwardRightHash, true);
        }
        else if (isCrouchingBackwardRight && !(isLeftControlPressed && isSPressed && isDPressed))
        {
            animator.SetBool(isCrouchingBackwardRightHash, false);
        }

        if (!isCrouchingBackwardLeft && (isLeftControlPressed && isSPressed && isAPressed))
        {
            animator.SetBool(isCrouchingBackwardLeftHash, true);
        }
        else if (isCrouchingBackwardLeft && !(isLeftControlPressed && isSPressed && isAPressed))
        {
            animator.SetBool(isCrouchingBackwardLeftHash, false);
        }

    }//Update

}//Class
