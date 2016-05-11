using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class reporterTalking : MonoBehaviour {

	public GameObject textBox;
	public Text theText;

	public TextAsset textFiles;
	public string[] textLines;

	public int currentLine;
	public int endAtLine;

	public GameObject boss;

	public bool isTalking;
	public bool bossTalking;
	public bool playerTalking;

	Animator anim;

	void Start(){

		isTalking = true;

		if (textFiles != null) {
			textLines = (textFiles.text.Split('\n'));
		}

		if (endAtLine == 0) {
			endAtLine = textLines.Length - 1;
		}

		anim = GetComponent<Animator> ();

	}

	void Update(){

		//begin dialog
		if (isTalking) {

			EnableTextBox ();
			theText.text = textLines [currentLine];

			if (Input.GetKeyDown (KeyCode.Return)) {
				currentLine++;
			}

			if (currentLine == endAtLine) {
				DisableTextBox ();
				isTalking = false;
			}

			ChangeAnim ();

		}

		if (playerTalking) {
			anim.SetBool ("isTalking", true);
		} else {
			anim.SetBool ("isTalking", false);
		}


		//start Game
		if (!isTalking) {
			SceneManager.LoadScene(1);
		}

	}

	public void EnableTextBox(){

		textBox.SetActive(true);

	}

	public void DisableTextBox(){

		textBox.SetActive(false);
		isTalking = false;
	}

	void ChangeAnim(){

		//Talking
		if(currentLine <= 8 && currentLine > 0){

			boss.SetActive (true);

			//boss Talking
			if (currentLine == 1 || currentLine == 3 || currentLine == 6 || currentLine == 8) {
				
				bossTalking = true;
				playerTalking = false;

			} else {
				
				bossTalking = false;

				//player Talking
				if (currentLine == 2 || currentLine == 5 || currentLine == 7) {
					playerTalking = true;
				}
			}

		}else{
			boss.SetActive(false);
		}

	}

}
