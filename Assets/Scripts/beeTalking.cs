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
	public Text dialogText;
	int clicked;

	public GameObject LeftAnswerButton;
	public GameObject RightAnswerButton;
	public Text leftText;
	public Text rightText;
	int leftClicked;
	int rightClicked;

	public bool isTalking;
	public bool talked;
	public bool showDance;
	bool questionsComplete;
	bool answered;

	int correctAnswers;

	private playerControl move;

	void Start(){

		move = GameObject.Find ("FPSController").GetComponent<playerControl>();

		currentLine = 0;
		endAtLine = 2;

		clicked = 0;

		correctAnswers = 0;

		isTalking = false;
		showDance = false;
		talked = false;
		questionsComplete = true;
		answered = false;

		if (textFiles != null) {
			textLines = (textFiles.text.Split('\n'));
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

//				theText.text = textLines [currentLine];
//
//				if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Return)) {
//					currentLine++;
//				}
//
//				if (currentLine == endAtLine) {
//
//					EnableButton ();
//
//				} else if (currentLine > endAtLine) {
//				}

				theText.text = textLines [currentLine];

				if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Return)) {

					if (currentLine >= endAtLine) {

						EnableButton ();

					} else {
						currentLine++;
					}

				}


			} else {
				
				if (showDance) {
					theText.text = "Come on, guys, dance time!";

					if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Return)) {
						DisableTextBox ();
					}

				} else {
					theText.text = textLines [currentLine];

					if (!questionsComplete) {
					
						EnableQuestButton ();

//					if (correctAnswers == 0 && answered == false) {
						if (correctAnswers == 0) {
							
							currentLine = 14;
						}

						theText.text = textLines [currentLine];

					} else {
					
						if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Return)) {
							DisableTextBox ();
						}
					}
				}
					
			}

		//can move after finish talking
		} else if (!GameObject.FindObjectOfType<textBoxManager>().isTalking && !GameObject.FindObjectOfType<antTalking>().isTalking){
			move.canMove = true;
		}
			
		if (correctAnswers == 3) {
			
			currentLine = 29;
			DisableQuestButton ();

			if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Return)) {
				DisableTextBox ();
				DisableButton ();
				showDance = true;
			}
		}
			

		if (questionsComplete) {
			
			theText.text = textLines [28];

			leftText.text = "Of course, you guys often sleep in your cells.";
			rightText.text = "Nope, but you would rest in empty cells.";

			Invoke ("StartQuestionsAgain", 2);
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
		LeftAnswerButton.SetActive (true);
		RightAnswerButton.SetActive (true);

	}

	void DisableQuestButton(){
		LeftAnswerButton.SetActive (false);
		RightAnswerButton.SetActive (false);	
	}
		
	//Button functions

	public void LoadNextDialogue(){
		clicked++;

		if (clicked == 1) {
			currentLine = 5;
			dialogText.text = "I'm collecting dancing bugs' photos for the next magazine!";
		}

		if (clicked == 2) {
			currentLine = 8;
			dialogText.text = "So... Can I get to see your dance? I've heard bees' group dancing is fantastic!";
		}

		if (clicked == 3) {
			currentLine = 11;
			dialogText.text = "Cool!";
		}

		if (clicked == 4) {
			talked = true;
			currentLine = 14;
			DisableButton ();
			EnableQuestButton ();
		}
	}

	public void Answer1(){

		//wrong
		if (currentLine == 14 || currentLine == 24) {
			correctAnswers = 0;
			currentLine = 28;
			DisableQuestButton ();
			questionsComplete = true;

		}
		//correct
		if (currentLine == 19) {
			correctAnswers ++;
			currentLine = 24;

			leftText.text = "Ultraviolet!";
			rightText.text = "Red!";
		}
			
	}

	public void Answer2(){
		
		//wrong
		if (currentLine == 19) {
			correctAnswers = 0;
			currentLine = 28;
			DisableQuestButton ();

			questionsComplete = true;

		}
		//correct
		if (currentLine == 14) {
			correctAnswers ++;
			currentLine = 19;

			leftText.text = "About 40 days.";
			rightText.text = "Approximately 4 - 9 months.";
		}

		if (currentLine == 24) {
			correctAnswers ++;
		}

//		answered = true;

	}

	void StartQuestionsAgain(){
		questionsComplete = false;
	}
}
