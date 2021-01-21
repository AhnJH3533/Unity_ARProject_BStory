using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MM_BtnManager : MonoBehaviour {

    public void LoadGB() {
        GameManager.Instance.BGM.BtnClickSound();
        SceneManager.LoadScene("GB_Guide Bot");
    }
    public void LoadSG() {
        GameManager.Instance.BGM.BtnClickSound(); ;
        SceneManager.LoadScene("GB_Voice Guide");
    }
    public void LoadPT() {
        GameManager.Instance.BGM.BtnClickSound();
        SceneManager.LoadScene("Portal");
    }
    public void LoadTH() {
        GameManager.Instance.BGM.BtnClickSound();
        SceneManager.LoadScene("Treasure Hunt");
    }
    public void LoadQZ() {
        GameManager.Instance.BGM.BtnClickSound();
        SceneManager.LoadScene("Quiz");
    }
    public void LoadPZ() {
        GameManager.Instance.BGM.BtnClickSound();
        SceneManager.LoadScene("Puzzle");
    }
}
