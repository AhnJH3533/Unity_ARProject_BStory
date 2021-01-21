using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QZ_TypeWriterEffect : MonoBehaviour {

	public float delay = 0.1f;
	private string fullText;
	private string currentText = "";

    void Start () {
		fullText = GetComponent<Text>().text;
		GetComponent<Text>().text = "";
		StartCoroutine(ShowText());
	}

    private void OnEnable()
    {
		TypingText();
	}

    public void TypingText()
    {
		StartCoroutine(ShowText());
	}
	
	IEnumerator ShowText(){
		for(int i = 0; i <= fullText.Length; i++){
			currentText = fullText.Substring(0,i);
			this.GetComponent<Text>().text = currentText;
			yield return new WaitForSeconds(delay);
		}
	}
}

