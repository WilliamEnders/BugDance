using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class antTalking : MonoBehaviour {

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

	public bool isTalking;
	public bool talked;
	public bool showDance;
	public bool findPartner;

	private playerControl move;

	void Start(){

		move = GameObject.Find ("FPSController").GetComponent<playerControl>();

		leftClicked = 0;
		rightClicked = 0;

		isActive = false;
		isTalking = false;

		showDance = false;
		findPartner = false;

		if (textFiles != null) {
			textLines = (textFiles.text.Split('\n'));
		}

		if (endAtLine == 0) {
			endAtLine = textLines.Length - 1;
		}

		DisableTextBox();
		DisableButton();
	}

	void Update(){
		//allow player move while NOT talking
		if (!isTalking) {
			move.canMove = true;
		}

		//begin dialog
		if (isActive) {

			EnableTextBox ();

			if (!talked) {
				theText.text = textLines [currentLine];
			} else { 

				if (showDance) {
					theText.text = "Hold your camera!";

					if (Input.GetKeyDown (KeyCode.Return)) {
						DisableTextBox ();
					}
				}

				if (findPartner) {
					
					theText.text = "Did you find me a cute little guy?";

				}
			}


			if ((Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Return)) && !talked) {
				currentLine++;
			}

			if (currentLine == endAtLine) {

				if (!talked) {
					EnableButton ();
				}

			} else if (currentLine > endAtLine) {
				isActive = false;
			}
		}

	}

	public void EnableTextBox(){

		textBox.SetActive(true);
		isActive = true;

		isTalking = true;

	}

	public void DisableTextBox(){

		textBox.SetActive(false);
		isTalking = false;
	}

	public void EnableButton(){

		buttons.SetActive (true);
		GameObject.Find ("LeftButton").SetActive (true);
		GameObject.Find ("RightButton").SetActive (true);

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

	//Button functions
	public void LoadNextDialogue1(){

		leftClicked++;
		//print ("leftClicked:" + leftClicked + ", rightClicked:" + rightClicked);

		if (isTalking) {

			if (leftClicked == 1) {
				theText.text = textLines [5];
				leftButtonText.text = "Can I take a picture of your happy dance?";
				rightButtonText.text = "I'd love to see you dancing!";
			}

			if (leftClicked == 2 && rightClicked == 0) {
				theText.text = textLines [10];
				leftButtonText.text = "Cool!";
				GameObject.Find ("RightButton").SetActive (false);
			}

			if (leftClicked == 1 && rightClicked == 1) {
				theText.text = textLines [14];
				leftButtonText.text = "Ok.";
				GameObject.Find ("RightButton").SetActive (false);

				findPartner = true;
			}

		}

		if (leftClicked == 3 || (leftClicked == 2 && rightClicked == 1)) {
			DisableButton ();
			DisableTextBox ();

			showDance = true;
			//print ("can dance now");
			isTalking = false;

			talked = true;
		}
	}

	public void LoadNextDialogue2(){

		rightClicked++;
		print ("leftClicked:" + leftClicked + ", rightClicked:" + rightClicked);

		if (isTalking) {

			if (rightClicked == 1) {
				theText.text = textLines [7];
				leftButtonText.text = "I'm a reporter, can you dance now?";
				rightButtonText.text = "Can I take a picture of your happy dance?";
			}

			if (leftClicked == 1 && rightClicked == 1 || leftClicked == 0 && rightClicked == 2) {
				theText.text = textLines [14];
				rightButtonText.text = "Ok.";

				GameObject.Find ("LeftButton").SetActive (false);

				findPartner = true;
			}

		}

		if (rightClicked == 3 || (leftClicked == 1 && rightClicked == 2)) {

			DisableButton ();
			DisableTextBox ();

			isTalking = false;

			talked = true;

		}
	}

}
