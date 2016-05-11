using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class beeTalking : MonoBehaviour {

	public GameObject textBox;
	public Text theText;

	public TextAsset textFiles;
	public string[] textLines;

	int currentLine;
	int endAtLine;

	public GameObject DialogueButton;
	int clicked;

	public Text leftButtonAnswer;
	public Text rightButtonAnswer;
	int leftClicked;
	int rightClicked;

	public bool isTalking;
	public bool talked;
	public bool showDance;
	public bool findPartner;

	private playerControl move;

	void Start(){

		move = GameObject.Find ("FPSController").GetComponent<playerControl>();

		currentLine = 0;
		endAtLine = 1;

		clicked = 0;
		leftClicked = 0;
		rightClicked = 0;

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

		//begin dialog
		if (isTalking) {

			//stop character moving
			move.canMove = false;

			EnableTextBox ();

			if (!talked) {

				theText.text = textLines [currentLine];

				if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Return)) {
					if (currentLine <= endAtLine) {

						currentLine++;

					} else {

						EnableButton ();

					}
				}

			} else { 

				if (showDance) {
					theText.text = "Hold your camera!";

					if (Input.GetKeyDown (KeyCode.Return)) {
						DisableTextBox ();
					}
				}

				if (findPartner) {
					theText.text = "Did you find some great leaves?";

					if (Input.GetKeyDown (KeyCode.Return)) {
						DisableTextBox ();
					}
				}
			}

			//can move after finish talking
		}else if (!GameObject.FindObjectOfType<antTalking>().isTalking && !GameObject.FindObjectOfType<antTalking>().isTalking){

			move.canMove = true;
		}

	}

	public void EnableTextBox(){

		textBox.SetActive(true);

	}

	public void DisableTextBox(){

		textBox.SetActive(false);
		isTalking = false;
	}

	public void EnableButton(){

		//SingleButton.SetActive (true);
	}

	public void DisableButton(){

		//SingleButton.SetActive (false);

	}

	//Button functions
	public void LoadNextDialogue(){
		clicked++;

		if (clicked == 1) {
			currentLine = 4;


		}
	}

}

