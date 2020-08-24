using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpineMove : MonoBehaviour
{
    public SkeletonAnimation _SkeletonAnimation;

	public float m_MoveSpeed = 10.0f;

	// 이동할 방향을 나타냅니다.
	private Vector3 _DirectionVector;

	private void Update()
	{
		// 키 입력
		InputKey();

		// 캐릭터 이동
		MovePlayerCharacter();

        #region SpineWork
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
#endregion
    }

    // 키 입력을 받습니다.
    private void InputKey()
	{
		// 방향 설정
		_DirectionVector.x = Input.GetAxisRaw("Horizontal");
		_DirectionVector.z = Input.GetAxisRaw("Vertical");
	}

	// 설정된 방향으로 캐릭터를 이동시킵니다.
	private void MovePlayerCharacter()
	{
		transform.Translate(_DirectionVector * m_MoveSpeed * Time.deltaTime, Space.World);
	}

}
