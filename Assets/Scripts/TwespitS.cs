using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwespitS : MonoBehaviour
{
    public GameObject nyamPrefabBlue;
    public GameObject nyamPrefabRed;
    public GameObject nyamPrefabGreen;
    Vector3 twePos;
    public Sprite[] tweColorSprite;
    private SpriteRenderer colorRenderer;
    Material blueMT;
    Material redMT;
    Material greenMT;
    // Start is called before the first frame update

    void Awake()
    {
        colorRenderer = GetComponent<SpriteRenderer>();
        colorRenderer.sprite = tweColorSprite[0];
      

        
    }

    void Start()
    {
        if (PlayerMove.twecolor == 0)
        {
            colorRenderer.sprite = tweColorSprite[0];
           // colorRenderer.material = blueMT;
        }
        else if (PlayerMove.twecolor == 1)
        {
            colorRenderer.sprite = tweColorSprite[1];



          //  colorRenderer.material = redMT;
        }
        else if (PlayerMove.twecolor == 2)
        {
            colorRenderer.sprite = tweColorSprite[2];
           // colorRenderer.material = greenMT;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        twePos = this.gameObject.transform.position;
        

    }

    private void  OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {

            PlayerMove.instance.IsTweing = false;
            PlayerMove.instance.IsNormal = true;
            Quaternion rotation = Quaternion.identity;
            rotation.eulerAngles = new Vector3(60, 0, 0);
            if (PlayerMove.twecolor == 0)
            {
                GameObject nyamInstanceBlue = (GameObject)Instantiate(nyamPrefabBlue, twePos, rotation/*Quaternion.identity*/);
                Destroy(this.gameObject);
            }
            else if (PlayerMove.twecolor == 1)
            {
                GameObject nyamInstanceRed = (GameObject)Instantiate(nyamPrefabRed, twePos, rotation/*Quaternion.identity*/);
                Destroy(this.gameObject);
            }
            else if (PlayerMove.twecolor == 2)
            {
                GameObject nyamInstanceGreed = (GameObject)Instantiate(nyamPrefabGreen, twePos, rotation/*Quaternion.identity*/);
                Destroy(this.gameObject);
            }
           


        }
    }
}
