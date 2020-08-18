using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public sealed class EnemyMove : MonoBehaviour
{
    #region Inspector
    [SpineAnimation]
    public string moveAnimation;

    #endregion
    private SkeletonAnimation _SkeletonAnimation;
    private SkeletonRenderer _SkeletonRenderer;

    [Header("드론 이동 속도")]
    // 이동 속도
    private float _EnemySpeed = 8.0f;
    
    // 좌, 우 끝 좌표
    public const float _EnemyRightPosition = 8.0f;
    public const float _EnemyLeftPosition = -8.0f;

    public float _EnemyPosition;

    // 초기 위치
    private float _EnemyFirstPosition;

    

    private void Awake()
    {
        // 초기 위치 설정
        _EnemyFirstPosition = _EnemyPosition;

        //_SkeletonAnimation.state.SetAnimation(0, "moving", true);
    }

    private void Update()
    {
        // 왼쪽 이동
        LeftMove();

        //_SkeletonAnimation.timeScale = 1.5f;
        //
        //_SkeletonAnimation.loop = true;
        //
        //_SkeletonAnimation.AnimationName = "moving";
    }

    // 한시적으로 왼쪽으로만 움직임
    private void LeftMove()
    {
        // 왼쪽으로 이동
        transform.Translate(Vector3.left * _EnemySpeed * Time.deltaTime, Space.World);

        // 좌, 우 끝 좌표를 넘어가지 않게끔
        Vector2 currentPosition = transform.position;

        currentPosition.x = Mathf.Clamp(currentPosition.x, _EnemyLeftPosition, _EnemyRightPosition);

        transform.position = currentPosition;
    }

    private void ChangeState()
    {
    }
}
