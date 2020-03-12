using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class PlayerColor : MonoBehaviour
{
    MeshRenderer colorRenderer;
    Material blueMT;
    Material redMT;
    Material greenMT;
    
    // Start is called before the first frame update
    void Awake()
    {
        
        colorRenderer=GetComponent<MeshRenderer>();
        blueMT = Resources.Load("blueMaterial", typeof(Material)) as Material;
        redMT = Resources.Load("redMaterial", typeof(Material)) as Material;
        greenMT = Resources.Load("greenMaterial", typeof(Material)) as Material;

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("redItem"))
        {
            //colorRenderer.material = redMT;
            PlayerMove.chrRenderer.sprite = PlayerMove.chrColorSprite[1];
        }
        else if (collision.gameObject.CompareTag("blueItem"))
        {
            //colorRenderer.material = blueMT;
            PlayerMove.chrRenderer.sprite = PlayerMove.chrColorSprite[0];

        }
        else if (collision.gameObject.CompareTag("greenItem"))
        {
            //colorRenderer.material = greenMT;
            PlayerMove.chrRenderer.sprite = PlayerMove.chrColorSprite[2];

        }
    }

        
    



}
*/