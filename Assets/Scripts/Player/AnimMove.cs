﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimMove : MonoBehaviour
{
    Rigidbody rigidbody;
    Animator animator;
    MeshRenderer meshRenderer;

    public float horizontalMove;
    public float verticalMove;
    bool hideCheck;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        meshRenderer = GetComponent<MeshRenderer>();

        hideCheck = false;
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        MoveAnimationUpdate();
        ActionAnimationUpdate();
    }

    void MoveAnimationUpdate()
    {
        if (horizontalMove == 0)
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
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (horizontalMove == -1)
        {
            animator.SetBool("_SideMove", true);
            transform.localScale = new Vector3(-1f, 1f, 1f);
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

    void ActionAnimationUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (hideCheck == false)
            {
                animator.SetBool("_Hide", true);
                animator.SetFloat("_ReversePlay", 1.0f);
                hideCheck = true;
            }
            else
            {
                animator.SetBool("_Hide", false);
                animator.SetFloat("_ReversePlay", -1.0f);
                hideCheck = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            animator.SetTrigger("_Twe");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetTrigger("_Nyam");
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("_Jump");
        }

    }
}
