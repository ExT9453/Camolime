using Spine.Unity;
using Spine.Unity.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpineMove : MonoBehaviour
{
	float horizontalMove;
	float verticalMove;

	Rigidbody rigidbody;
	Animator animator;

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

		#region SpineWork
		/*
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			// true는 looping 할것인가
			_SkeletonAnimation.AnimationState.SetAnimation(0, "Move/Move_Side", true);
			_SkeletonAnimation.skeleton.FlipX = false;
		}
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			_SkeletonAnimation.AnimationState.SetAnimation(0, "Move/Move_Side", true);
			_SkeletonAnimation.skeleton.FlipX = true;
		}
		if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
		{
			_SkeletonAnimation.AnimationState.SetAnimation(0, "Move/Move_Front", true);
		}
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			_SkeletonAnimation.AnimationState.SetAnimation(0, "Move/Move_Back", true);
		}
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			_SkeletonAnimation.AnimationState.SetAnimation(0, "Yum/Yum_Side", true);
		}
		//if (Input.GetKeyDown(KeyCode.K))
		//{
		//
		//}
		if (Input.GetKeyDown(KeyCode.L))
		{
			_SkeletonAnimation.AnimationState.SetAnimation(0, "Spat", true);
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			_SkeletonAnimation.AnimationState.SetAnimation(0, "Hide/Hide_Side", true);
		}
		*/
#endregion
    }


	void AnimationUpdate()
    {
		if (horizontalMove == 0 && verticalMove == 0)
		{
			animator.SetBool("_MoveHorizontal", false);
			animator.SetBool("_MoveBack", false);
			animator.SetBool("_MoveFront", false);
		}
		if (horizontalMove > 0)
        {
			animator.SetBool("_MoveHorizontal", true);
			transform.localScale = new Vector3(1, 1, 1);
        }
		if (horizontalMove < 0)
        {
			animator.SetBool("_MoveHorizontal", true);
			transform.localScale = new Vector3(-1, 1, 1);
		}
		if (verticalMove > 0)
        {
			animator.SetBool("_MoveBack", true);
        }
		if (verticalMove < 0)
        {
			animator.SetBool("_MoveFront", true);
        }
	}
}
