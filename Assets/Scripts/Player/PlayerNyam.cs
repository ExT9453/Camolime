using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNyam : MonoBehaviour
{
        private GameObject nowtrigger;
        private bool timerOn=false;
        private float timer=0f;

    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(nowtrigger!=null)
        {
            Debug.Log("null 아님");
        }
        if(timerOn==true)
        {
            timer+=Time.deltaTime;
        }
        if(timer>0.3f)
        {
            timer=0;
            timerOn=false;
             PlayerMove.instance.IsNormal = true;
            PlayerMove.instance.IsTweing = false;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (timerOn == false)
        {
            if (collision.gameObject.CompareTag("blueOb") || 
                collision.gameObject.CompareTag("redOb") || 
                collision.gameObject.CompareTag("greenOb"))
            {
                if (nowtrigger == null)
                {
                    nowtrigger = collision.gameObject;
                    Debug.Log("nowtrigger에 collision 대입");

                    if (collision.gameObject.CompareTag("blueG"))
                    {
                        nowtrigger.gameObject.tag = "blueG";
                        Debug.Log("충돌만 됨");

                    }
                    if (collision.gameObject.CompareTag("redG"))
                    {
                        nowtrigger.gameObject.tag = "redG";
                        Debug.Log("빨강 충돌 중");
                    }
                    if (collision.gameObject.CompareTag("greenG"))
                    {
                        nowtrigger.gameObject.tag = "greenG";
                    }
                }
                else
                {
                }

                //if (collision.gameObject.CompareTag("tweground"))
                //{
                if (Input.GetKeyDown(KeyCode.J))
                {
                    Debug.Log("냠냠냠 키 누름");
                    

                    if (PlayerMove.instance.IsNormal && !PlayerMove.instance.IsTweing && PlayerMove.instance.chrSize < 5 && !PlayerMove.instance.IsJumping)
                    {
                        if (nowtrigger.gameObject.CompareTag("blueG"))
                        {
                            PlayerMove.instance.IsNormal = false;
                            PlayerMove.instance.IsTweing = true;
                            PlayerMove.instance.chrColor = 1;
                            PlayerMove.instance.chrSize += 1;
                            Debug.Log("냠 완료");
                            Destroy(nowtrigger.gameObject);
                            nowtrigger = null;
                            timerOn = true;

                        }
                        else if (nowtrigger.gameObject.CompareTag("redG"))
                        {
                            PlayerMove.instance.IsNormal = false;
                            PlayerMove.instance.IsTweing = true;
                            PlayerMove.instance.chrColor = 2;
                            PlayerMove.instance.chrSize += 1;
                            Debug.Log("냠 완료");
                            Destroy(nowtrigger.gameObject);
                            nowtrigger = null;
                            timerOn = true;

                        }

                        else if (nowtrigger.gameObject.CompareTag("greenG"))
                        {
                            PlayerMove.instance.IsNormal = false;
                            PlayerMove.instance.IsTweing = true;
                            PlayerMove.instance.chrColor = 3;
                            PlayerMove.instance.chrSize += 1;
                            Debug.Log("냠 완료");
                            Destroy(nowtrigger.gameObject);
                            nowtrigger = null;
                            timerOn = true;

                        }

                        //애니메이션 끝나면

                    }
                    //PlayerMove.instance.IsNormal = true;
                    // PlayerMove.instance.IsTweing = false;
                }

                //}


                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (PlayerMove.instance.IsNormal && !PlayerMove.instance.IsJumping && !PlayerMove.instance.IsHiding)
                    {
                        Debug.Log("숨기 키 누름");
                        if (nowtrigger.gameObject.CompareTag("blueOb"))
                        {
                            bool blueColorOn = nowtrigger.gameObject.GetComponent<colorManager>().colorOn;
                            if (blueColorOn)
                            {
                                if (PlayerMove.instance.chrColor == 1)
                                {
                                    PlayerMove.instance.IsHiding = true;
                                    PlayerMove.instance.IsNormal = false;
                                    PlayerMove.instance.hidingOff = false;
                                    PlayerMove.instance.hidingDelay = 2;

                                    Debug.Log("숨기");
                                }
                                else
                                {
                                    //색이 다릅니다
                                }
                            }
                        }
                        if (nowtrigger.gameObject.CompareTag("redOb"))
                        {
                            bool redColorOn = nowtrigger.gameObject.GetComponent<colorManager>().colorOn;
                            if (redColorOn)
                            {
                                if (PlayerMove.instance.chrColor == 2)
                                {
                                    PlayerMove.instance.IsHiding = true;
                                    PlayerMove.instance.IsNormal = false;
                                    PlayerMove.instance.hidingOff = false;
                                    PlayerMove.instance.hidingDelay = 2;

                                    animator.SetBool("_Hide", true);
                                    animator.SetFloat("_ReversePlay", 1.0f);

                                    Debug.Log("숨기");
                                }
                                else
                                {
                                    //색이 다릅니다
                                }
                            }
                        }
                        if (nowtrigger.gameObject.CompareTag("greenOb"))
                        {
                            if (PlayerMove.instance.chrColor == 3)
                            {
                                PlayerMove.instance.IsHiding = true;
                                PlayerMove.instance.IsNormal = false;
                                PlayerMove.instance.hidingOff = false;
                                PlayerMove.instance.hidingDelay = 2;

                                Debug.Log("숨기");
                            }
                            else
                            {
                                //색이 다릅니다
                            }
                        }

                    }

                }
                /*
                else if (IsHiding && hidingOff)
                {
                    IsHiding = false;
                    IsNormal = true;
                    hidingOff = false;
                    Debug.Log("a");
                }*/
            }

            else
            {

            }
        }
    }
    private void OnTriggerExit(Collider Collision)
    {
                    nowtrigger=null;

    }
}
