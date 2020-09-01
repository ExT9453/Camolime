using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEditor;
//using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instance;
    public AudioClip[] sounds;

    AudioSource AS;
    public static int twecolor = 0;
    /* Material blueMT;
     Material redMT;
     Material greenMT;*/
    private Rigidbody rigid;
    //캐릭터 기본
    public float h, v;
    Vector3 moveDirection;
    public Sprite[] chrColorSprite;
    private SpriteRenderer chrRenderer;
    public float JumpPower;
    public float speed = 7f;
    public bool IsMoving;
    public bool IsNormal;
    public bool IsJumping;
    public int chrSize;
    Vector3 chrPos;
    public int chrColor=0;
    //퉤 관련
    
    public int tweSpeed;
    public bool IsTweing;
    public GameObject twePrefab;
    //냠 관련
    public bool IsNyaming;
    //숨기 관련
    public bool IsHiding;
    public bool hidingOff;
    public float hidingDelay;




    // Start is called before the first frame update
    void Awake()
    {
        if(instance==null)
        {
            instance=this;
        }
        else
        {
            Destroy(this);
        }
        chrColor = 0;
        AS = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody>();
        chrRenderer = GetComponent<SpriteRenderer>();
        chrRenderer.sprite = chrColorSprite[0];


    }
    void Start()
    {
        IsNormal = true;
        IsJumping = false;
        IsTweing = false;
        IsHiding = false;
        hidingOff = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveObject();
        //Jump();
        twe();
        chrPos = this.gameObject.transform.position;
        if (chrColor==0)
        {
            chrRenderer.sprite = chrColorSprite[0];
        }
        else if (chrColor==1)
        {
            chrRenderer.sprite = chrColorSprite[1];

        }
        else if (chrColor==2)
        {
            chrRenderer.sprite = chrColorSprite[2];

        }

       
    }
    void Update()
    {
        rigid.WakeUp();
        if (!hidingOff&&IsHiding)
        {
            
            if (hidingDelay > 0)
            {
                hidingDelay -= Time.deltaTime;
            }
            if (hidingDelay <= 0)
            {
                hidingOff = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsHiding && hidingOff)
            {
                IsHiding = false;
                IsNormal = true;
                hidingOff = false;
                Debug.Log("a");
            }
        }

        
    }


    void moveObject()
    {
        if (IsNormal&& !IsJumping)
        {
            
            h = Input.GetAxis("Horizontal");

            v = Input.GetAxis("Vertical");
            //IsNormal = false;
            if (h < 0)
            {
                chrRenderer.flipX = true;
                

            }
            else if (h > 0)
            {

                chrRenderer.flipX = false;
            }

            if(h==0 && v==0)
            {
                 
                    AS.Stop();
            }
            else
            {
                 if (!AS.isPlaying)
                {
                    AS.clip=sounds[0];
                    AS.Play();
                }
            }


            transform.Translate(Vector3.right.normalized * speed * Time.smoothDeltaTime * h, Space.World);
            transform.Translate(Vector3.forward.normalized * speed * Time.smoothDeltaTime * v, Space.World);
            moveDirection = new Vector3(h, 0, v);
            moveDirection.Normalize();
           
            //playerRb.AddForce(moveDirection * speed);
            //rigid.velocity = (moveDirection * speed);

        }
    }

    /*
    void Jump()
    {
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            
            if (IsNormal && !IsJumping)
            {
                IsNormal = false;
                IsJumping = true;
                rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
                Debug.Log("jump");
            }
            
            else
            {
                //return;
            }
        }
    }*/

    void twe()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (IsNormal&&!IsTweing&&!IsJumping)
            {
                if (chrSize > 1)
                {
                    if (chrColor==0)
                    {
                        twecolor = 0;
                    }
                    else if (chrColor==1)
                    {
                        twecolor = 1;

                    }
                    else if (chrColor==2)
                    {
                        twecolor = 2;

                    }
                    IsNormal = false;
                    IsTweing = true;
                    chrSize -= 1;
                    //Quaternion rotation = Quaternion.identity;
                    //rotation.eulerAngles = new Vector3(60, 0, 0);
                    GameObject tweInstance = (GameObject)Instantiate(twePrefab, chrPos,Quaternion.identity);
                    //Instance.name = "twespit";
                    if (chrRenderer.flipX == false)
                    {
                        tweInstance.GetComponent<Rigidbody>().AddForce(Vector3.right * tweSpeed, ForceMode.Impulse);
                    }
                    else if (chrRenderer.flipX == true)
                    {
                        tweInstance.GetComponent<Rigidbody>().AddForce(Vector3.left * tweSpeed, ForceMode.Impulse);

                    }


                }
            }
        }
    }
   
   


    private void OnCollisionEnter(Collision collision)
    {
        /*
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (IsJumping)
            {
                IsNormal = true;
            }
          
            IsJumping = false;
            Debug.Log("ㅇ");
        }*/
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
            speed = 7f;
            Debug.Log("on ground");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {

            if (IsNormal && !IsJumping)
            {
                float xSpeed = 0;
                float zSpeed = 0;
                IsJumping = true;
                moveDirection = new Vector3(h, 1, v);
                rigid.velocity = Vector3.zero;
                //moveDirection.Normalize();
                Vector3 vectornormal = moveDirection.normalized;
                speed = 0;
                if (h > 0)
                {
                    xSpeed = 9;
                }
                else if (h < 0)
                {
                    xSpeed = -9;
                }
                if (v > 0)
                {
                    zSpeed = 9;
                }
                else if (v < 0)
                {
                    zSpeed = -9;
                }
                rigid.velocity = vectornormal + new Vector3(xSpeed, JumpPower*0.75f, zSpeed);
               // rigid.AddForce(vectornormal* JumpPower, ForceMode.Impulse);
                Debug.Log("jump");
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
           
            
                if (collision.gameObject.CompareTag("blueOb"))
                
            {
                colorManager obBlue = collision.gameObject.GetComponent<colorManager>();
                
                
                if (obBlue.colorOn)
                {
                    //colorManager.colorOn = false;
                    obBlue.colorOn = false;
                    chrColor = 0;
                    Debug.Log("뺏음");
                }
            }

            if (collision.gameObject.CompareTag("redOb"))
            {
                //colorManager.colorOn = false;
                chrColor = 1;
            }

            if (collision.gameObject.CompareTag("greenOb"))
            {
                //colorManager.colorOn = false;
                chrColor = 2;
            }
        }


        }
    
    /*
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("redItem"))
        {
            chrColor = 1;
        }
        else if (collision.gameObject.CompareTag("blueItem"))
        {
            chrColor = 0;

        }
        else if (collision.gameObject.CompareTag("greenItem"))
        {
            chrColor = 2;

        }
    }*/

}


