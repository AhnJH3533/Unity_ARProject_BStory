using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MM_LoadGameScene : MonoBehaviour
{
    public AudioSource audio;
    public void LoadGameScene() {
        audio.Play();
        Screen.orientation = ScreenOrientation.Portrait;
        StartCoroutine(GameManager.Instance.BGM.DeCrescendo());
        SceneManager.LoadScene("02 GameScene");
    }
}
