using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class antTalking : MonoBehaviour {

	public GameObject textBox;
	public Text theText;

	public TextAsset textFiles;
	public string[] textLines;

	int currentLine;
	int endAtLine;

	public GameObject SingleButton;
	public Text buttonText;
	int clicked;

	public bool isTalking;
	public bool talked;
	public bool showDance;
	public bool findPartner;

	private playerControl move;

	void Start(){

		move = GameObject.Find ("FPSController").GetComponent<playerControl>();

		currentLine = 0;
		endAtLine = 1;

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

			} else { 

				if (showDance) {
					theText.text = "Hold your camera!";

					if (Input.GetKeyDown (KeyCode.Return)) {
						DisableTextBox ();
					}
				}

				if (findPartner) {
					theText.text = "Did you find me a cute little guy?";
					if (Input.GetKeyDown (KeyCode.Return)) {
						DisableTextBox ();
					}
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
			}
		
		
		} else {
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

	}

	public void DisableButton(){

	}

	//Button functions
	public void LoadNextDialogue(){
		
	}

}

