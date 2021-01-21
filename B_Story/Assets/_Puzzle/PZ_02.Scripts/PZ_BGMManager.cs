using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PZ_BGMManager : MonoBehaviour {
    void Start() {
        GameManager.Instance.BGM.PuzzleBGM();
    }
}
