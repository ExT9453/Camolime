using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartman : MonoBehaviour
{
    public GameObject heart1;
        public GameObject heart2;

    public GameObject heart3;

    public GameObject heart4;

    public GameObject heart5;
    public GameObject emptyheart1;
        public GameObject emptyheart2;

    public GameObject emptyheart3;

    public GameObject emptyheart4;

    public GameObject emptyheart5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMove.instance.hp==0)
        {
            this.gameObject.SetActive(false);
        }
          if(PlayerMove.instance.hp==5)
        {
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
            heart4.gameObject.SetActive(true);
            heart5.gameObject.SetActive(true);

        }
           if(PlayerMove.instance.hp==4)
        {
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
            heart4.gameObject.SetActive(true);
            heart5.gameObject.SetActive(false);

        }
           if(PlayerMove.instance.hp==3)
        {
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
            heart4.gameObject.SetActive(false);
            heart5.gameObject.SetActive(false);

        }
           if(PlayerMove.instance.hp==2)
        {
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(false);
            heart4.gameObject.SetActive(false);
            heart5.gameObject.SetActive(false);

        }
           if(PlayerMove.instance.hp==1)
        {
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(false);
            heart4.gameObject.SetActive(false);
            heart5.gameObject.SetActive(false);

        }
           if(PlayerMove.instance.hp==0)
        {
            heart1.gameObject.SetActive(false);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(false);
            heart4.gameObject.SetActive(false);
            heart5.gameObject.SetActive(false);

        }

        if(PlayerMove.instance.chrSize==5)
        {
            emptyheart1.gameObject.SetActive(true);
            emptyheart2.gameObject.SetActive(true);
            emptyheart3.gameObject.SetActive(true);
            emptyheart4.gameObject.SetActive(true);
            emptyheart5.gameObject.SetActive(true);

        }
           if(PlayerMove.instance.chrSize==4)
        {
            emptyheart1.gameObject.SetActive(true);
            emptyheart2.gameObject.SetActive(true);
            emptyheart3.gameObject.SetActive(true);
            emptyheart4.gameObject.SetActive(true);
            emptyheart5.gameObject.SetActive(false);

        }
           if(PlayerMove.instance.chrSize==3)
        {
            emptyheart1.gameObject.SetActive(true);
            emptyheart2.gameObject.SetActive(true);
            emptyheart3.gameObject.SetActive(true);
            emptyheart4.gameObject.SetActive(false);
            emptyheart5.gameObject.SetActive(false);

        }
           if(PlayerMove.instance.chrSize==2)
        {
            emptyheart1.gameObject.SetActive(true);
            emptyheart2.gameObject.SetActive(true);
            emptyheart3.gameObject.SetActive(false);
            emptyheart4.gameObject.SetActive(false);
            emptyheart5.gameObject.SetActive(false);

        }
           if(PlayerMove.instance.chrSize==1)
        {
            emptyheart1.gameObject.SetActive(true);
            emptyheart2.gameObject.SetActive(false);
            emptyheart3.gameObject.SetActive(false);
            emptyheart4.gameObject.SetActive(false);
            emptyheart5.gameObject.SetActive(false);

        }
        

    }
}
