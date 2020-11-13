using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airo : MonoBehaviour
{
    // Start is called before the first frame update

    int movementFlag = 2;
    void Start()
    {
        StartCoroutine("ChangeMovement");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject tempObj = null;
        tempObj = GameObject.Find("movementFlag");


        if (movementFlag == 1)
        {
            //moveVelocity = Vector3.left;
            //transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);


            // chrRenderer.flipX = false;

            this.transform.rotation = Quaternion.Euler(0, -180, 0);
        }                                          
        else if (movementFlag == 2)
        {
            //moveVelocity = Vector3.right;

            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    IEnumerator ChangeMovement()
    {
        if (movementFlag == 1)
        {
            movementFlag = 2;
        }
        else if (movementFlag == 2)
        {
            movementFlag = 1;
        }
        /*movementFlag =1;*/ /*Random.Range(0, 3);*/

        yield return new WaitForSeconds(10f);

        StartCoroutine("ChangeMovement");
    }
}

