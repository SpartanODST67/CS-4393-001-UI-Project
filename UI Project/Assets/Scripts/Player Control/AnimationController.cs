using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void Walk()
    {
        animator.SetFloat("Speed_f", 1f);
    }

    public void Stand()
    {
        animator.SetFloat("Speed_f", 0f);
    }
}
