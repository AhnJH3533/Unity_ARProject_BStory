using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QZ_BGMManager : MonoBehaviour {
    void Start() {
        GameManager.Instance.BGM.QuizBGM();
    }
}
