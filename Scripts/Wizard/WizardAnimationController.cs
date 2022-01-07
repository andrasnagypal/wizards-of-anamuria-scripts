using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAnimationController : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void PlayIdleAnimation()
    {
        animator.Play("staff_01_idle");
        animator.speed = 1;
    }
    public void PlayStaffAttackAnimation(float speed)
    {
        animator.Play("staff_07_cast_A");
        animator.speed = speed;
    }
    public void PlayDyingAnimation()
    {
        animator.Play("staff_06_death_A");
        animator.speed = 1;
    }
    public void PlayWalkingAnimation()
    {
        animator.Play("staff_02_walk");
        animator.speed = 1;
    }
}
