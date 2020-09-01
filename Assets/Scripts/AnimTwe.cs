using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class AnimTwe : MonoBehaviour
{
    [SerializeField] private GameObject _ReadyTwe;

    Rigidbody Twerigidbody;
    Animator Tweanimator;
    MeshRenderer meshRenderer;

    private GameObject _Twe;

    private bool tweCheck;
    private float _BasePosition;
    private float horizontalDirection;
    private float verticalDirection;

    private void Awake()
    {
        Twerigidbody = GetComponent<Rigidbody>();
        Tweanimator = GetComponent<Animator>();
        meshRenderer = GetComponent<MeshRenderer>();

        tweCheck = false;
    }

    private void Update()
    {
        UpdateReadyTwePosition();
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            TweAnimationUpdate();
            Invoke("TweAnimationUpdate", 0.5f);
        }
    }

    private void TweAnimationUpdate()
    {
        if (tweCheck == false)
        {
            Tweanimator.SetBool("_Twe", true);
            Tweanimator.SetTrigger("_TweStartTrigger");
            Tweanimator.SetTrigger("_TweGoingTrigger");
            meshRenderer.enabled = true;
            tweCheck = true;
        }
        
        else
        {
            Tweanimator.SetBool("_Twe", false);
            meshRenderer.enabled = false;
            tweCheck = false;
        }

    }
    private void UpdateReadyTwePosition()
    {
        Vector3 twePosition = new Vector3(7f, -1f, -1.5f) ;
    
        _ReadyTwe.transform.localPosition = twePosition;
    }
}



