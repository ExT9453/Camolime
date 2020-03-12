using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class PlayerJump : MonoBehaviour
{



    RaycastHit Hit;

  
    Vector3 startPos;
    Vector3 destPos;
    private bool isJumping;
    float timer;
    float vx;
    float vy;
    float vz;
    float sx;
    float sy;
    float sz;
    void Start()
    {
        isJumping = false;
    

    }



    // Update is called once per frame

    void Update()
    {



        if (Input.GetMouseButton(0))
        {
            if (isJumping == false)
            {
                // 마우스 왼쪽 클릭시

                Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out Hit);
        
                //마우스 포지션으로 빛을 쏴서 그 값을 hit 에 저장

                destPos = Hit.point;

                //hit 값을 Click 저장
                startPos = transform.position;
                vx = (destPos.x - startPos.x) / 2f;
                vz = (destPos.z - startPos.z) / 2f;
                vy = (destPos.y - startPos.y + 2 * 9.8f) / 2f;
                isJumping = true;
                //transform.Translate((Click - transform.position).normalized * MoveSpeed * Time.deltaTime);



                // 클릭좌표로 이동
            }
        }
        if (isJumping == true)
        {
           
            timer += Time.deltaTime;
             sx = startPos.x + vx * timer;
             sy = startPos.y + vy * timer - 0.5f * 9.8f * timer * timer;
             sz = startPos.z + vz * timer;
            transform.position = new Vector3(sx, sy, sz);
         
        }

    }

    void OnCollisionEnter(Collision ground)
    {
        if (ground.gameObject.CompareTag("Ground"))
        {
            isJumping = false;

        }
    }
    /*
    void OnCollisionStay(Collision ground)
    {
        if (ground.gameObject.CompareTag("Ground"))
        {
            isJumping = false;

        }
    }
    void OnCollisionExit(Collision ground)
    {
        if (ground.gameObject.CompareTag("Ground"))
        {
            isJumping = true;

        }
    }
    */
}

