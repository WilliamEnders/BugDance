using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class maleAntTalking : MonoBehaviour {

	public GameObject textBox;
	public GameObject dialog;
	public Text theText;

	public TextAsset textFiles;
	public string[] textLines;

	public int currentLine;
	public int endAtLine;

	public bool isTalking;
	public bool talked;


	void Start(){

		isTalking = false;

		if (textFiles != null) {
			textLines = (textFiles.text.Split('\n'));
		}

		if (endAtLine == 0) {
			endAtLine = textLines.Length - 1;
		}
	
	}

	void Update(){

		//begin dialog
		if (isTalking) {

			EnableTextBox ();
			theText.text = textLines [currentLine];

			if (Input.GetMouseButtonDown (0)) {
				currentLine++;
			}

			if (currentLine == endAtLine) {
				DisableTextBox ();
				isTalking = false;
				talked = true;
			}
				
		}

		if (talked) {
			transform.position = GameObject.FindObjectOfType<antTalking> ().girlPosition.position - new Vector3(2, 0, 0);
		}

	}

	public void EnableTextBox(){

		textBox.SetActive(true);
		dialog.SetActive(true);


	}

	public void DisableTextBox(){

		textBox.SetActive(false);
		dialog.SetActive(false);

		isTalking = false;
	}

}
