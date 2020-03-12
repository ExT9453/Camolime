using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public static int twecolor = 0;
    /* Material blueMT;
     Material redMT;
     Material greenMT;*/
    private Rigidbody rigid;
    //캐릭터 기본
    public Sprite[] chrColorSprite;
    private SpriteRenderer chrRenderer;
    public int JumpPower;
    public int speed;
    public static bool IsNormal;
    public bool IsJumping;
    public int chrSize;
    Vector3 chrPos;
    public static int chrColor;
    //퉤 관련
    
    public int tweSpeed;
    public static bool IsTweing;
    public GameObject twePrefab;
    //냠 관련
    public bool IsNyaming;




    // Start is called before the first frame update
    void Awake()
    {
        chrColor = 0;
       /* blueMT = Resources.Load("blueMaterial", typeof(Material)) as Material;
        redMT = Resources.Load("redMaterial", typeof(Material)) as Material;
        greenMT = Resources.Load("greenMaterial", typeof(Material)) as Material;*/
        rigid = GetComponent<Rigidbody>();
        chrRenderer = GetComponent<SpriteRenderer>();
        chrRenderer.sprite = chrColorSprite[0];


    }
    void Start()
    {
        IsNormal = true;
        IsJumping = false;
        IsTweing = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveObject();
        Jump();
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
        

    }


    void moveObject()

    {

        float h = Input.GetAxis("Horizontal");

        float v = Input.GetAxis("Vertical");

        if (h < 0)
        {
            chrRenderer.flipX = true;

        }
        else if (h > 0)
        {

            chrRenderer.flipX = false;

        }

        transform.Translate(Vector3.right.normalized * speed * Time.smoothDeltaTime * h, Space.World);

        transform.Translate(Vector3.forward.normalized * speed * Time.smoothDeltaTime * v, Space.World);

    }


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
    }

    void twe()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (IsNormal&&!IsTweing)
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
                    GameObject tweInstance = (GameObject)Instantiate(twePrefab, chrPos, Quaternion.identity);
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
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (IsJumping)
            {
                IsNormal = true;
            }
          
            IsJumping = false;
            Debug.Log("ㅇ");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //IsJumping = false;

    }

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
    }

    private void OnTriggerStay(Collider collision)
    {

        //if (collision.gameObject.CompareTag("tweground"))
        //{
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (IsNormal && !IsTweing && chrSize<5)
                {
                    IsNormal = false;
                    IsTweing = true;
                    chrSize += 1;
                    if (collision.gameObject.CompareTag("blueG"))
                    {
                        chrColor = 0;
                    }
                    else if (collision.gameObject.CompareTag("redG"))
                    {
                        chrColor = 1;
                    }

                   else if (collision.gameObject.CompareTag("greenG"))
                    {
                        chrColor = 2;
                    }
                    
                        Destroy(collision.gameObject);
                    //애니메이션 끝나면
                    IsNormal = true;
                    IsTweing = false;
                }
            }
        //}
    }

}
