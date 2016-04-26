using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class textBoxManager : MonoBehaviour {

	public GameObject textBox;
	public Text theText;

	public TextAsset textFiles;
	public string[] textLines;

	public GameObject buttons;
	int leftClicked = 0;
	int rightClicked = 0;

	public int currentLine;
	public int endAtLine;

	public bool isActive = false;
	public bool showButton = false;
	public bool stopPlayerMovement;


	void Start(){

		if (textFiles != null) {
			textLines = (textFiles.text.Split('\n'));
		}

		if (endAtLine == 0) {
			endAtLine = textLines.Length - 1;
		}

		if (isActive) {
			EnableTextBox ();
		} else {
			DisableTextBox();
		}

		if (showButton) {
			EnableButton ();
		}else {
			DisableButton();
		}
	}

	void Update(){

		if (!isActive) {
			return;

		} else {
			EnableTextBox ();
		
			theText.text = textLines [currentLine];

			if (Input.GetMouseButtonDown (0) || Input.GetKeyDown(KeyCode.Return) ) {
				currentLine++;
			}

			if (currentLine == endAtLine) {
			
				EnableButton ();

			} else if (currentLine > endAtLine) {

				isActive = false;
			}
		}
	}

	public void EnableTextBox(){
		
		textBox.SetActive(true);
		isActive = true;

	}

	public void DisableTextBox(){
		
		textBox.SetActive(false);
	}

	public void EnableButton(){

		buttons.SetActive (true);

	}

	public void DisableButton(){
		
		buttons.SetActive (false);

	}

	public void ReloadScript(TextAsset theText){

		if (theText != null) {
			textLines = new string[1];
			textLines = (theText.text.Split('\n'));
		}

	}

	public void LoadNextDialogue1(){

		leftClicked ++;
		theText.text = textLines [7];

	}

	public void LoadNextDialogue2(){

		rightClicked++;
		theText.text = textLines [9];

	}

}
