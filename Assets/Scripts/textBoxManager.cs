using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class textBoxManager : MonoBehaviour {

	public GameObject textBox;
	public Text theText;

	public TextAsset textFiles;
	public string[] textLines;

	public GameObject buttons;
//	public Button leftButton;
//	public Button rightButton;

	public int currentLine;
	public int endAtLine;

//	public PlayerController player;
	GameObject player;

	public bool isActive = false;
	public bool showButton = false;
	public bool stopPlayerMovement;

	void Start(){

//		player = GameObject.FindObjectOfType<playerControl>();
		player = GameObject.FindGameObjectWithTag("Player");

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
		}

		theText.text = textLines [currentLine];

		if (Input.GetKeyDown (KeyCode.Return)) {
			currentLine++;
		}

		if (currentLine == endAtLine) {
			
			EnableButton ();

		}else if (currentLine > endAtLine) {
			
			//DisableTextBox ();
			//DisableButton ();

			isActive = false;
		}
	}



	public void EnableTextBox(){
		
		textBox.SetActive(true);
		isActive = true;

		if (stopPlayerMovement) {
			player.GetComponent<playerControl> ().canMove = false;
		}
	}

	public void DisableTextBox(){
		
		textBox.SetActive(false);

		player.GetComponent<playerControl> ().canMove = true;
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
}
