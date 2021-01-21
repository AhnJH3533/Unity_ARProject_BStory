using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GB_BGMManager : MonoBehaviour {
    void Start() {
        StartCoroutine(GameManager.Instance.BGM.DeCrescendo());
    }
}
