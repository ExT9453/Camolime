using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int JumpPower;
    public int speed;
    private Rigidbody rigid;
    private bool IsJumping;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    void Start()
    {
       IsJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveObject();
        Jump();
       
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
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (!IsJumping)
            {
                
                IsJumping = true;
                rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            }
            
            else
            {
                return;
            }
        }
    }


   


    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
          
            IsJumping = false;
        }
    }


 
   
}
