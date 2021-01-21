using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public AuthAPI AuthAPI;
    public MM_BGMManager BGM;

    public bool isFirstGB = true;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;

        AuthAPI = GetComponent<AuthAPI>();

        SceneManager.LoadScene("01 UI MainMenu");
    }
}
