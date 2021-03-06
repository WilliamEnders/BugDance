﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class textBoxManager : MonoBehaviour {

	public GameObject textBox;
	public GameObject dialog;

	public Text theText;

	public TextAsset textFiles;
	public string[] textLines;

//	public GameObject buttons;
	public GameObject LeftButton;
	public GameObject RightButton;
	public GameObject QuestButton;

	int leftClicked;
	int rightClicked;
	public Text leftButtonText;
	public Text rightButtonText;
	public Text questButtonText;
	bool clicked;

	public int currentLine;
	public int endAtLine;

	public bool isActive;
	public bool isTalking;
	public bool talked;
	public bool showDance;
	public bool findLeave;
	public bool foundLeave;
	bool questComplete;

	private playerControl move;

	void Start(){

		move = GameObject.Find ("FPSController").GetComponent<playerControl>();

		leftClicked = 0;
		rightClicked = 0;

		isActive = false;
		isTalking = false;

		showDance = false;
		findLeave = false;
		questComplete = false;

		if (textFiles != null) {
			textLines = (textFiles.text.Split('\n'));
		}

		currentLine = 0;

		if (endAtLine == 0) {
			endAtLine = textLines.Length - 1;
		}

		DisableTextBox();
		DisableButton();
	}

	void Update(){
		
		//allow player move while NOT talking
		if (isTalking) {
			
			move.canMove = false;

		} else if (!GameObject.FindObjectOfType<antTalking>().isTalking && !GameObject.FindObjectOfType<beeTalking>().isTalking){

			move.canMove = true;
		}


//		print (isTalking);

		//begin dialog
//		if (isActive) {
		if (isTalking) {

			EnableTextBox ();
		
			if (!talked) {
				theText.text = textLines [currentLine];

				if (currentLine < endAtLine) {
					if (Input.GetMouseButtonDown (0)) {
						currentLine++;
					}
				}

				if (currentLine == endAtLine) {
				
					EnableButton ();
//					isActive = false;

				} 
//				else if (currentLine > endAtLine) {
//					isActive = false;
//				}
					
			} else { 

				if (showDance) {
					theText.text = "Let me dance for you! Hold your camera!";

					if (Input.GetMouseButtonDown (0)) {
						DisableTextBox ();
					}
				}

				if (findLeave) {
					theText.text = "Did you find some great leaves?";

					if (foundLeave) {
						EnableQuestButton ();
						questButtonText.text = "Yep, I found you some great leaves! Give it a try!";

						if(clicked){
							DisableTextBox ();
							clicked = false;
						}
					}else{
						EnableQuestButton ();
						questButtonText.text = "Not yet. I'll keep looking.";
							
						if(clicked){
							DisableQuestButton ();
							DisableTextBox ();
							clicked = false;
						}
					}
				}
			}

		}

		if (questComplete && !showDance) {
			theText.text = "Yeah!! Let me dance for you! Hold your camera!";

			showDance = true;

			DisableQuestButton ();

			if (Input.GetMouseButtonDown (0)) {
				DisableTextBox ();
				theText.text = "Hold your camera!";

			}
		}

		//cheat
		if (Input.GetKey (KeyCode.Z)) {
			foundLeave = true;
		}

	}



	public void EnableTextBox(){
		
		textBox.SetActive(true);
		dialog.SetActive(true);

	}

	public void DisableTextBox(){
//		print ("disabled.");

		textBox.SetActive(false);
		dialog.SetActive(false);

		isTalking = false;
	}

	public void EnableButton(){

		//buttons.SetActive (true);
		LeftButton.SetActive(true);
		RightButton.SetActive(true);

	}

	public void DisableButton(){
		
		//buttons.SetActive (false);
		LeftButton.SetActive(false);
		RightButton.SetActive(false);
//		isActive = false;
	}

	void EnableQuestButton(){
		QuestButton.SetActive (true);
	}

	void DisableQuestButton(){
		QuestButton.SetActive (false);
	}

//	public void LoadScript(TextAsset theText){
//
//		if (theText != null) {
//			textLines = new string[1];
//			textLines = (theText.text.Split('\n'));
//		}
//
//	}

	//Button functions
	public void LoadNextDialogue1(){

		leftClicked++;
		print ("leftClicked:" + leftClicked + ", rightClicked:" + rightClicked);

		if (isTalking) {
			
			if (leftClicked == 1) {
				//theText.text = textLines [5];
				currentLine = 5;
				leftButtonText.text = "Can I take a picture of your happy dance?";
				rightButtonText.text = "I'd love to see you dancing!";
			}

			if (leftClicked == 2 && rightClicked == 0) {
//				theText.text = textLines [10];
				currentLine = 10;

				leftButtonText.text = "Cool!";
				RightButton.SetActive (false);
			}
			
			if (leftClicked == 1 && rightClicked == 1) {
//				theText.text = textLines [14];
				currentLine = 14;

				leftButtonText.text = "Ok.";
				RightButton.SetActive (false);

				findLeave = true;
			}

			if (leftClicked == 3 || (leftClicked == 2 && rightClicked == 1)) {
				DisableButton ();
				DisableTextBox ();

				showDance = true;
				isTalking = false;

				talked = true;
			}

		}

	}

	public void LoadNextDialogue2(){

		rightClicked++;
//		print ("leftClicked:" + leftClicked + ", rightClicked:" + rightClicked);

		if (isTalking) {
			
			if (rightClicked == 1) {
				//theText.text = textLines [7];
				currentLine = 7;
				leftButtonText.text = "I'm a reporter, can you dance now?";
				rightButtonText.text = "Can I take a picture of your happy dance?";
			}
			/*
			if (leftClicked == 0 && rightClicked == 2) {
				theText.text = textLines [12];
				rightButtonText.text = "Cool!";
				GameObject.Find ("LeftButton").SetActive (false);

			}
			*/

			if (leftClicked == 1 && rightClicked == 1 || leftClicked == 0 && rightClicked == 2) {
				currentLine = 14;
				rightButtonText.text = "Ok.";

				LeftButton.SetActive (false);

				findLeave = true;
			}
			if (rightClicked == 3 || (leftClicked == 1 && rightClicked == 2)) {

				DisableButton ();
				DisableTextBox ();

				isTalking = false;

				talked = true;

			}
		}


	}

	public void CompleteQuest(){
		if (foundLeave) {
			questComplete = true;
			findLeave = false;
		}
	}

	public void QuestButtonClick(){
		clicked = true;
	}
}
