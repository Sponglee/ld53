using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator animator;
    public void PlayFlyingAnim(bool aToggle)
    {

    }
    public void PlayFallingAnim(bool aToggle)
    {
        animator.SetBool("IsFalling", aToggle);
    }
    public void PlayGroundedAnim(bool aToggle)
    {
        animator.SetBool("IsGrounded", aToggle);
    }
}
