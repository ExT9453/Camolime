﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pie : MonoBehaviour
{

    public GameObject shotPrefab;
    Vector3 chrPos;

    public Transform target;
    public Transform target2;
    public Transform target3;
    private SpriteRenderer chrRenderer;
    public Vector3 direction;
    public Vector3 direction2;
    public float velocity;
    public bool Test =false;
    float timer;
    int waitingTime;
    // int count = 1;


    public float movePower = 5f;
    int movementFlag = 1; // 0:Idle, 1:left, 2:right

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        waitingTime = 2;
        // StartCoroutine("ChangeMovement");
        chrRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        target = GameObject.Find("Camolime").transform;
        // Player의 위치와 이 객체의 위치를 빼고 단위 벡터화 한다.
        direction = (target.position - transform.position).normalized;
        velocity = 0.2f; /*(velocity + accelaration * Time.deltaTime);*/
        // Player와 객체 간의 거리 계산
        float distance = Vector3.Distance(target.position, transform.position);



        if (Test && !PlayerMove.instance.IsHiding)
        {
            this.transform.position = new Vector3(transform.position.x + (direction.x * velocity),
                                                  transform.position.y,
                                                  transform.position.z + (direction.z * velocity)
                                                  );
            Debug.Log("if 들어옴");
            Debug.Log(distance);
        }
        else
        {
            Move();


         }


        if (distance > 10.0f)
        {
            Test = false;
            velocity = 0.0f;
        }

        if (distance < 5.0f)
        {
            if (!PlayerMove.instance.IsHiding)
            {
                if (timer > waitingTime)
                {
                    timer = 0;
                    shot();

                }
            }
        }


    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        Debug.Log("그냥 move 들어옴");

        if (movementFlag == 1)
        {
            //moveVelocity = Vector3.left;
            //transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);


            target = GameObject.Find("Flag").transform;
            direction = (target.position - transform.position).normalized;
            velocity = 0.2f;

            this.transform.position = new Vector3(transform.position.x + (direction.x * velocity),
                                      transform.position.y,
                                      transform.position.z + (direction.z * velocity)
                                      );

            Debug.Log("FLAG1 들어옴");

            // chrRenderer.flipX = false;

            //this.transform.rotation = Quaternion.Euler(30, -180, 0);
        }
        else if (movementFlag == 2)
        {
            //moveVelocity = Vector3.right;
            //transform.localScale = new Vector3(-3.5f, 3.5f, 3.5f);

            target = GameObject.Find("Flag2").transform;
            direction = (target.position - transform.position).normalized;
            velocity = 0.2f;

            this.transform.position = new Vector3(transform.position.x + (direction.x * velocity),
                                      transform.position.y,
                                      transform.position.z + (direction.z * velocity)
                                      );

            //chrRenderer.flipX = true;

            //this.transform.rotation = Quaternion.Euler(-30, 0, 0);
        }
        transform.position += moveVelocity * movePower * Time.deltaTime;


    }
    void FixedUpdate()
    {
        chrPos = this.gameObject.transform.position;
    }

    void shot()
    {
        GameObject shotInstance = (GameObject)Instantiate(shotPrefab, chrPos, Quaternion.identity);

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Flag2")
        {
            movementFlag = 1;
            Debug.Log("충돌 들어옴");

        }


        if (col.transform.tag == "Flag")
        {
            movementFlag = 2;
            Debug.Log("플래그 충돌");
        }

    }

    void OnTriggerStay(Collider col)
    {

        if (col.transform.tag == "Player")
            Test = true;

        if (col.transform.tag == "Flag2")
        {
            movementFlag = 1;
            Debug.Log("충돌 들어옴");

        }

        if (col.transform.tag == "Flag")
        {
            movementFlag = 2;
            Debug.Log("플래그 충돌");
        }

    }

    //void OnTriggerExit(Collider col)
    //{


    //}

    //IEnumerator ChangeMovement()
    //{
    //    if (movementFlag == 1)
    //    {
    //        movementFlag = 2;
    //    }
    //    else if (movementFlag == 2)
    //    {
    //        movementFlag = 1;
    //    }
    //    /*movementFlag =1;*/ /*Random.Range(0, 3);*/

    //    yield return new WaitForSeconds(5f);

    //    StartCoroutine("ChangeMovement");

    //    count += 1;
    //}


}
