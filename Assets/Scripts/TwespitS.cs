using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwespitS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void  OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {

            PlayerMove.IsTweing = false;
            PlayerMove.IsNormal = true;
            gameObject.SetActive(false);
           


        }
    }
}
