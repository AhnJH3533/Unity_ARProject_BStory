using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGuide : MonoBehaviour
{
    public void LoadGuideScene() {
        GameManager.Instance.BGM.BtnClickSound();
        SceneManager.LoadScene(2);
    }
}
