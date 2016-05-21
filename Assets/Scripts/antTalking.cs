using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class antTalking : MonoBehaviour {

	public GameObject textBox;
	public GameObject dialog;
	public Text theText;

	public TextAsset textFiles;
	public string[] textLines;

	public int currentLine;
	public int endAtLine;

	public GameObject DialogueButton;
	public GameObject QuestButton;
	public Text dialogueText;
	public Text questButtonText;
	bool questClicked;
	int clicked;

	public bool isTalking;
	public bool talked;
	public bool showDance;
	public bool findPartner;
	public bool foundPartner;
	bool questComplete;

	public Transform girlPosition;

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

		DisableTextBox();
		DisableButton();

		girlPosition = transform;
	}

	void Update(){

		//begin dialog
		if (isTalking) {
			
			//stop character moving
			move.canMove = false;

			EnableTextBox ();

			if (!talked) {
				
				theText.text = textLines [currentLine];

				if (Input.GetMouseButtonDown (0)) {
					
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

					if (Input.GetMouseButtonDown (0)) {
						DisableTextBox ();
					}
				}

				if (findPartner) {
					theText.text = "Did you find me a cute little guy?";

					if (!foundPartner) {
						
						EnableQuestButton ();
						questButtonText.text = "Oh, I'm trying!";

						if(questClicked){
							DisableQuestButton ();
							DisableTextBox ();
							questClicked = false;
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

			if (Input.GetMouseButtonDown (0)) {
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
		dialog.SetActive(true);

	}

	void DisableTextBox(){

		textBox.SetActive(false);
		dialog.SetActive(false);

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

//		print (clicked);
		if (clicked == 1) {
			
			currentLine = 4;
			dialogueText.text = "Well... Can I take a picture of your happy dance?";
		
		}

		if (clicked == 2) {

			currentLine = 7;
			dialogueText.text = "Let's hear it.";

		}

		if (clicked == 3) {

			dialogueText.text = "Sure! I'll try my best.";
			DisableButton ();
//			currentLine = 8;
			currentLine = 9;
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
		if (foundPartner) {
			questComplete = true;
			findPartner = false;
		}
	}

	public void QuestButtonClick(){
		questClicked = true;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Ant") {
			showDance = true;
		}
	}
}

