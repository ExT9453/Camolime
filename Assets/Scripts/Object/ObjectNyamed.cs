using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectNyamed : MonoBehaviour
{
    [SerializeField] float m_angle = 0f;
    [SerializeField] float m_distance = 0f;

    Animator animator;

    public Transform target;
    public Vector3 direction;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Nyamed();
    }

     public void Nyamed()
     {
        target = GameObject.Find("1").transform;
        // Player와 객체 간의 거리 계산
        float distance = Vector3.Distance(target.position, transform.position);
        // 일정거리 안에 있을 시
        if (distance >= 2.0f)
        {
            animator.SetBool("_Close", false);

            //if(this.direction.x<=0)
            //{
            //}
            //else
            //{
            //}
        }
        else
        {
            animator.SetBool("_Close", true);

            if (Input.GetKeyDown(KeyCode.J))
                animator.SetBool("_Nyamed", true);
        }
    }
}
