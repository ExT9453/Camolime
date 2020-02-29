using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Rigidbody rigid;
    //캐릭터 기본
    public int JumpPower;
    public int speed;
    public static bool IsNormal;
    public bool IsJumping;
    public int chrSize;
    Vector3 chrPos;
    public int chrColor;
    //퉤 관련
    public int tweSpeed;
    public static bool IsTweing;

    //냠 관련
    public bool IsNyaming;
   // public GameObject obj_twe;
    public GameObject twePrefab;




    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        
        
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
    }
    void moveObject()

    {

        float h = Input.GetAxis("Horizontal");

        float v = Input.GetAxis("Vertical");

        
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
                    IsNormal = false;
                    IsTweing = true;
                    chrSize -= 1;
                    GameObject Instance = (GameObject)Instantiate(twePrefab, chrPos, Quaternion.identity);
                    //Instance.name = "twespit";
                 
                    Instance.GetComponent<Rigidbody>().AddForce(Vector3.right*tweSpeed, ForceMode.Impulse);
                   
                    //프리팹으로 퉤 생성하고 끝나면 노말이랑 점핑 원래대로

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


    private void OnTriggerStay(Collider collision)
    {

        if (collision.gameObject.CompareTag("tweground"))
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (IsNormal && !IsTweing && chrSize<5)
                {
                    IsNormal = false;
                    IsTweing = true;
                    chrSize += 1;
                    Destroy(collision.gameObject);

                }
            }
        }
    }

}
