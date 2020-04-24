using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSet : MonoBehaviour
{
    public float PlayerCameraDistance { get; set; }
    public Transform cameraTarget;
    Camera playerCamera;
    void Awake()
    {
      //  Camera.main.orthographicSize = Screen.height / (100.0f * 2.0f);

        Camera.main.aspect = 16f / 9f;
        PlayerCameraDistance = 12f;
        playerCamera = GetComponent<Camera>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cameraTarget.position.x, cameraTarget.position.y + PlayerCameraDistance, cameraTarget.position.z - PlayerCameraDistance+5);
    }
}
