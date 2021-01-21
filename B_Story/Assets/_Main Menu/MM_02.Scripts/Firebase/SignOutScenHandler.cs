using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignOutScenHandler : MonoBehaviour
{
    public void SignOutGoogle()
    {
        GameManager.Instance.AuthAPI.SignOutGoogle();
        SceneManager.LoadScene(1);
    }
}
