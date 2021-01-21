using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PZ_turnPuzzle : MonoBehaviour {
    public GameObject pic;
    public GameObject tracking;
    void Start() {
        StartCoroutine(cr());
    }
    IEnumerator cr() {
        yield return new WaitForSeconds(1f);
        GameObject.Instantiate(pic, this.transform.position, Quaternion.identity);
    }
}
