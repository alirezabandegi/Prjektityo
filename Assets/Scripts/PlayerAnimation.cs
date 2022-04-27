using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator _animator;
    //String based lookup is inefficient so we get the strings as a hash instead for later usage
    static readonly int Moving = Animator.StringToHash("Moving");
    static readonly int Jumping = Animator.StringToHash("Jumping");
    static readonly int Running = Animator.StringToHash("Running");
    static readonly int Reloading = Animator.StringToHash("Reloading");

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Animate(float moveLeftOrRight, float moveForwardOrBackward, bool isJumpPressed, bool isRunning, bool isReloading)
    {
        float absoluteMovement = Mathf.Abs(moveLeftOrRight + moveForwardOrBackward);
        bool isMoving = absoluteMovement > 0;
        
        _animator.SetBool(Moving, isMoving);
        _animator.SetBool(Running, isRunning);
        _animator.SetBool(Jumping, isJumpPressed);
        _animator.SetBool("Reloading", isReloading);
        print(isReloading);
    }
}
