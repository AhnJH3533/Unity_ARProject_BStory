using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignInSceneHandler : MonoBehaviour
{

    public void SignInHandler()
    {
        GameManager.Instance.BGM.BtnClickSound();
        GameManager.Instance.AuthAPI.SignInGoogle(
            () =>{ 
                //SceneManager.LoadScene(1); 
            }, 
            Debug.LogError
        );
    }
    public void SignOutHandler()
    {
        GameManager.Instance.AuthAPI.SignOutGoogle();
    }
}
