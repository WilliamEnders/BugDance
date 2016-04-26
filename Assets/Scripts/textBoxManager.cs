using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class textBoxManager : MonoBehaviour {

	public GameObject textBox;
	public Text theText;

	public TextAsset textFiles;
	public string[] textLines;

	public GameObject buttons;
	int leftClicked;
	int rightClicked;
	public Text leftButtonText;
	public Text rightButtonText;

	public int currentLine;
	public int endAtLine;

	bool isActive;
	bool showButton;

	public bool dialogFinished;
	public bool showDance;
	public bool findLeave;

	private playerControl move;

	void Start(){

		move = GameObject.Find ("FPSController").GetComponent<playerControl>();

		leftClicked = 0;
		rightClicked = 0;

		isActive = false;
		showButton = false;
		showDance = false;
		findLeave = false;

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

		if(dialogFinished){
			move.canMove = true;
		}

		if (!isActive) {
			return;

		} else {
			
			EnableTextBox ();
		
			theText.text = textLines [currentLine];

			if (Input.GetMouseButtonDown (0) || Input.GetKeyDown(KeyCode.Return) ) {
				
				currentLine++;

//				print (currentLine);
//				print (endAtLine);

			}

			if (currentLine == endAtLine) {
				
				EnableButton ();

			}else if (currentLine > endAtLine) {

				isActive = false;
			}
		}
			
//		print (dialogFinished);
//		if (dialogFinished && Input.GetKeyDown (KeyCode.Return)) {
//				
//			DisableTextBox ();
//			dialogFinished = false;
//		}

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
		isActive = false;
	}

	public void LoadScript(TextAsset theText){

		if (theText != null) {
			textLines = new string[1];
			textLines = (theText.text.Split('\n'));
		}

	}

	public void LoadNextDialogue1(){

		leftClicked++;
//		print ("leftClicked:" + leftClicked + ", rightClicked:" + rightClicked);

		if (!dialogFinished) {
			
			if (leftClicked == 1) {
				theText.text = textLines [5];
				leftButtonText.text = "Can I take a picture of your happy dance?";
				rightButtonText.text = "I'd love to see you dancing!";
			}

			if (leftClicked == 2 && rightClicked == 0) {
				theText.text = textLines [10];
//			DisableButton ();
//			dialogFinished = true;
//			print (dialogFinished);
				leftButtonText.text = "Cool!";
				GameObject.Find ("RightButton").SetActive (false);
			}
			
			if (leftClicked == 1 && rightClicked == 1) {
				theText.text = textLines [14];
				leftButtonText.text = "Ok.";
				GameObject.Find ("RightButton").SetActive (false);

				findLeave = true;
				dialogFinished = true;
			}

		}

		if (leftClicked == 3 || (leftClicked == 2 && rightClicked == 1)) {
			DisableButton ();
			DisableTextBox ();

			showDance = true;
			dialogFinished = true;

		}
	}

	public void LoadNextDialogue2(){

		rightClicked++;
//		print ("leftClicked:" + leftClicked + ", rightClicked:" + rightClicked);

		if (!dialogFinished) {
			
			if (rightClicked == 1) {
				theText.text = textLines [7];
				leftButtonText.text = "I'm a reporter, can you dance now?";
				rightButtonText.text = "Can I take a picture of your happy dance?";
			}

			if (rightClicked == 2) {
				theText.text = textLines [12];
//				DisableButton ();
//				dialogFinished = true;
//				print (dialogFinished);
				rightButtonText.text = "Cool!";
				GameObject.Find ("LeftButton").SetActive (false);

				showDance = true;
				dialogFinished = true;

			}

			if (leftClicked == 1 && rightClicked == 1) {
				theText.text = textLines [14];
				rightButtonText.text = "Ok.";
				GameObject.Find ("LeftButton").SetActive (false);

				findLeave = true;
				dialogFinished = true;

			}

		}

		if (rightClicked == 3 || (leftClicked == 1 && rightClicked == 2)) {
			
			DisableButton ();
			DisableTextBox ();

			findLeave = true;
			dialogFinished = true;


		}
	}

}
