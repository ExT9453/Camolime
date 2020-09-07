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
    Animator animator;
    MeshRenderer meshRenderer;
    SkeletonAnimation skeletonAnimation;
    public static int twecolor = 0;
    /* Material blueMT;
     Material redMT;
     Material greenMT;*/
    private Rigidbody rigid;
    public Material material;
    //캐릭터 기본
    public float h, v;
    Vector3 moveDirection;
    public Sprite[] chrColorSprite;
    //private SpriteRenderer chrRenderer;
    public float JumpPower;
    public float speed = 7f;
    public bool IsMoving;
    public bool IsNormal;
    public bool IsJumping;
    public bool hideCheck;
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
    public bool firstHiding;
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
        animator = GetComponent<Animator>();
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        material = GetComponent<Material>();
        meshRenderer = GetComponent<MeshRenderer>();
        //chrRenderer = GetComponent<SpriteRenderer>();
        //chrRenderer.sprite = chrColorSprite[0];


    }
    void Start()
    {
        IsNormal = true;
        IsJumping = false;
        IsTweing = false;
        IsHiding = false;
        hidingOff = false;
        hideCheck = false;
        firstHiding = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        chrPos = this.gameObject.transform.position+new Vector3(0.5f,1f,0f);

        moveObject();
        //Jump();
        twe();
        if (chrColor==0)
        {
            // chrRenderer.sprite = chrColorSprite[0];
            meshRenderer.material.SetColor("_Color", Color.white);
        }
        else if (chrColor==1)
        {
            // chrRenderer.sprite = chrColorSprite[1];
            meshRenderer.material.SetColor("_Color", Color.blue);
        }
        else if (chrColor==2)
        {
            //  chrRenderer.sprite = chrColorSprite[2];
            meshRenderer.material.SetColor("_Color", Color.red);
        }
        else if (chrColor == 3)
        {
            meshRenderer.material.SetColor("_Color", Color.green);
        }

    }
    void Update()
    {
        rigid.WakeUp();
        if (!hidingOff&&IsHiding)
        {
            
            if (hidingDelay > 0 && firstHiding == false)
            {
                hidingDelay -= Time.deltaTime;
            }
            if (hidingDelay <= 0 || firstHiding == true)
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
                firstHiding = false;
                Debug.Log("a");
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
        }

        
    }


    void moveObject()
    {
        if (IsNormal&& !IsJumping)
        {
            
            h = Input.GetAxis("Horizontal");

            v = Input.GetAxis("Vertical");
            //IsNormal = false;
            if (h == 0)
            {
                animator.SetBool("_SideMove", false);
                //transform.GetChild(0).localScale = new Vector3(1f, 1f, 1f);
            }
            if (v == 0)
            {
                animator.SetBool("_UpMove", false);
                animator.SetBool("_DownMove", false);
            }

            if (h < 0)
            {
                //chrRenderer.flipX = true;
                //transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
                animator.SetBool("_SideMove", true);
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            if (h > 0)
            {
                // chrRenderer.flipX = false;
                //transform.GetChild(0).localScale = new Vector3(1f, 1f, 1f);
                animator.SetBool("_SideMove", true);
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            if (v < 0)
                animator.SetBool("_DownMove", true);

            if (v > 0)
                animator.SetBool("_UpMove", true);

            if (h==0 && v==0)
                AS.Stop();

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
            //moveDirection = new Vector3(h, 0, v);
            //moveDirection.Normalize();
           
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
                    if (chrColor== 1)
                    {
                        twecolor = 1;
                    }
                    else if (chrColor==2)
                    {
                        twecolor = 2;
                    }
                    else if (chrColor==3)
                    {
                        twecolor = 3;
                    }
                    IsNormal = false;
                    IsTweing = true;
                    chrSize -= 1;
                    //Quaternion rotation = Quaternion.identity;
                    //rotation.eulerAngles = new Vector3(60, 0, 0);
                    GameObject tweInstance = (GameObject)Instantiate(twePrefab, chrPos,Quaternion.identity);
                    //Instance.name = "twespit";
                    //if (chrRenderer.flipX == false)
                    if(transform.GetChild(0).localScale.x>=0)
                    {
                        tweInstance.GetComponent<Rigidbody>().AddForce(Vector3.right * tweSpeed, ForceMode.Impulse);
                        tweInstance.GetComponent<SpriteRenderer>().flipX=false;

                        //여기서 애니메이션
                        animator.SetTrigger("_Twe");
                    }
                    else if (transform.GetChild(0).localScale.x<0)
                    {
                        tweInstance.GetComponent<Rigidbody>().AddForce(Vector3.left * tweSpeed, ForceMode.Impulse);
                        tweInstance.GetComponent<SpriteRenderer>().flipX=true;

                        //여기서 애니메이션
                        animator.SetTrigger("_Twe");
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

                animator.SetTrigger("_Jump");

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
                rigid.velocity = /*vectornormal +*/ new Vector3(xSpeed, JumpPower*0.75f, zSpeed);
               // rigid.AddForce(vectornormal* JumpPower, ForceMode.Impulse);
                Debug.Log("jump");
            }
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("_Nyam");

            if (collision.gameObject.CompareTag("blueOb"))
            {
                colorManager obBlue = collision.gameObject.GetComponent<colorManager>();
                if (obBlue.colorOn)
                {
                    //colorManager.colorOn = false;
                    obBlue.colorOn = false;
                    chrColor = 1;
                    Debug.Log("뺏음");
                }
            }

            if (collision.gameObject.CompareTag("redOb"))
            {
                colorManager obRed = collision.gameObject.GetComponent<colorManager>();

                if (obRed.colorOn)
                {
                    //colorManager.colorOn = false;
                    obRed.colorOn = false;
                    chrColor = 2;
                }
            }

            if (collision.gameObject.CompareTag("greenOb"))
            {
                colorManager obRed = collision.gameObject.GetComponent<colorManager>();

                if (obRed.colorOn)
                {
                    //colorManager.colorOn = false;
                    obRed.colorOn = false;
                    chrColor = 3;
                }
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


