using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SceneChange : MonoBehaviour
{
    public void ClickChangeScene(string sceneName)
    {
        SceneManager.LoadScene("Chap1_1");
    }
}
