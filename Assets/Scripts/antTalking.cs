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

	public GameObject DialogueButton;
	public GameObject QuestButton;
	public Text buttonText;
	int clicked;

	public bool isTalking;
	public bool talked;
	public bool showDance;
	public bool findPartner;
	public bool foundPartner;
	bool questComplete;

	private playerControl move;

	void Start(){

		move = GameObject.Find ("FPSController").GetComponent<playerControl>();

		currentLine = 0;
		endAtLine = 1;

		clicked = 0;

		isTalking = false;
		showDance = false;
		findPartner = false;

		if (textFiles != null) {
			textLines = (textFiles.text.Split('\n'));
		}

//		if (endAtLine == 0) {
//			endAtLine = textLines.Length - 1;
//		}

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
					
					if (currentLine >= endAtLine) {
						
						EnableButton ();

					} else {
						currentLine++;
						DisableButton ();
					}

				}

			} else { 

				if (showDance) {
					theText.text = "We'll dance together for you!";

					if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Return)) {
						DisableTextBox ();
					}
				}

				if (findPartner) {
					theText.text = "Did you find me a cute little guy?";

					if (foundPartner) {
						EnableQuestButton ();
					}else{
						if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Return)) {
							DisableTextBox ();
						}
					}
				}

			}
		
		//can move after finish talking
		}else if (!GameObject.FindObjectOfType<textBoxManager>().isTalking && !GameObject.FindObjectOfType<beeTalking>().isTalking){
			move.canMove = true;
		}

		if (questComplete) {
			theText.text = "You are such a nice bug!! We'll dance together for you!";

			showDance = true;

			DisableQuestButton ();

			if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Return)) {
				DisableTextBox ();
			}		
		}


		//cheat
		if (Input.GetKey (KeyCode.X)) {
			foundPartner = true;
		}
	}

	void EnableTextBox(){
		textBox.SetActive(true);
	}

	void DisableTextBox(){

		textBox.SetActive(false);
		isTalking = false;
	}

	void EnableButton(){
		DialogueButton.SetActive (true);
	}

	void DisableButton(){
		DialogueButton.SetActive (false);
	}

	void EnableQuestButton(){
		QuestButton.SetActive (true);
	}

	void DisableQuestButton(){
		QuestButton.SetActive (false);
	}

	//Button functions
	public void LoadNextDialogue(){
		clicked++;

		print (clicked);
		if (clicked == 1) {
			
			currentLine = 4;
			buttonText.text = "Well... Can I take a picture of your happy dance?";
		
		}

		if (clicked == 2) {

			currentLine = 7;
			buttonText.text = "Let's hear it.";

		}

		if (clicked == 3) {

			buttonText.text = "Sure! I'll try my best.";
			DisableButton ();
			currentLine = 8;
			endAtLine = 11;
		}

		if(clicked == 4){
			DisableTextBox ();
			DisableButton ();

			isTalking = false;
			talked = true;
			findPartner = true;
		}
	
	}

	public void CompleteQuest(){

		questComplete = true;
		findPartner = false;
	}
}

