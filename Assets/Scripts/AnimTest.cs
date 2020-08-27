using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimTest : MonoBehaviour
{
    Rigidbody rigidbody;
    Animator animator;

    float horizontalMove;
    float verticalMove;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        AnimationUpdate();
    }

    void AnimationUpdate()
    {
        if(horizontalMove == 0)
        {
            animator.SetBool("_SideMove", false);
        }
        if (verticalMove == 0)
        {
            animator.SetBool("_UpMove", false);
            animator.SetBool("_DownMove", false);
        }
        if (horizontalMove == 1)
        {
            animator.SetBool("_SideMove", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (horizontalMove == -1)
        {
            animator.SetBool("_SideMove", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (verticalMove == 1)
        {
            animator.SetBool("_UpMove", true);
        }
        if (verticalMove == -1)
        {
            animator.SetBool("_DownMove", true);
        }
    }
}
