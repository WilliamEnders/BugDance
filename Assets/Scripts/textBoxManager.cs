using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class textBoxManager : MonoBehaviour {

	public GameObject textBox;
	public Text theText;

	public TextAsset textFiles;
	public string[] textLines;

	public GameObject buttons;

	public int currentLine;
	public int endAtLine;

//	public PlayerController player;
	GameObject player;

	bool isActive = false;
	bool showButton = false;
//	bool stopPlayerMovement = false;

//	public string[] dialogues;
	int dialoguePart = 1;

	void Start(){

//		player = GameObject.FindObjectOfType<playerControl>();
//		player = GameObject.FindGameObjectWithTag("Player");

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

			if (Input.GetKeyDown (KeyCode.Return)) {
			
//				if (currentLine >= endAtLine) {
//					currentLine = endAtLine;
//				} else {
					currentLine++;
//				}
			}
		}

		if (currentLine == endAtLine) {
			
			EnableButton ();

		} else if (currentLine > endAtLine) {
			//DisableTextBox ();
			isActive = false;
		}
	}



	public void EnableTextBox(){
		
		textBox.SetActive(true);
		isActive = true;

//		if (stopPlayerMovement) {
//			player.GetComponent<playerControl> ().canMove = false;
//		}
	}

	public void DisableTextBox(){
		
		textBox.SetActive(false);

//		player.GetComponent<playerControl> ().canMove = true;
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
//		currentLine = 7;
//		endAtLine = 7;
		theText.text = textLines [7];

	}

	public void LoadNextDialogue2(){

//		currentLine = 9;
//		endAtLine = 9;

		theText.text = textLines [9];

	}

}
