using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectNyamed_nonSpine : MonoBehaviour
{
    [SerializeField] float m_angle = 0f;
    [SerializeField] float m_distance = 0f;

    private bool nyamedCheck;

    public Sprite Original;
    public Sprite CamolimeTouch;
    public Sprite CamolimeNyamed;
    public Transform target;
    public Vector3 direction;

    void Start()
    {
        nyamedCheck = false;
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
        if (!nyamedCheck)
        {
            if (distance >= 2.0f)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Original;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = CamolimeTouch;
                if (Input.GetKeyDown(KeyCode.J))
                {
                    nyamedCheck = true;
                }
            }
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = CamolimeNyamed;
        }
    }
}
