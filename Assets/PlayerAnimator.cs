using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator animator;
    public void PlayReactAnim()
    {
        animator.SetTrigger("React");
    }
    public void PlayFallingAnim(bool aToggle)
    {
        animator.SetBool("IsFalling", aToggle);
    }
    public void PlayGroundedAnim(bool aToggle)
    {
        animator.SetBool("IsGrounded", aToggle);
    }
    public void JumpAnim()
    {
        animator.SetTrigger("Jump");
    }

    public void PlayLevitatingAnim(bool aToggle)
    {
        animator.SetBool("IsLevitating", aToggle);
    }

}
