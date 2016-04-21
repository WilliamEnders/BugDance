using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;


public class textBoxManager : MonoBehaviour {

	public GameObject textBox;
	public Text theText;

	public TextAsset textFiles;
	public string[] textLines;

	public int currentLine;
	public int endAtLine;

//	public PlayerController player;
	GameObject player;

	public bool isActive = false;
	public bool stopPlayerMovement = false;

	void Start(){

//		player = GameObject.FindObjectOfType<playerControl>();
		player = GameObject.Find("Player");

		if (textFiles != null) {
			textLines = (textFiles.text.Split('\n'));
		}

		if (endAtLine == 0) {
			endAtLine = textLines.Length - 1;
		}

		if (isActive) {
			EnableTextBox();

		} else {
			DisableTextBox();
		}
	}

	void Update(){

		if (!isActive) {
			return;

//			if (textBox.activeInHierarchy){
//				DisableTextBox();
//			}
		} else {
			EnableTextBox ();
		}

		theText.text = textLines [currentLine];

		if (Input.GetKeyDown (KeyCode.Return)) {
			currentLine++;
		}

		if (currentLine > endAtLine) {
			DisableTextBox ();
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

	public void ReloadScript(TextAsset theText){

		if (theText != null) {
			textLines = new string[1];
			textLines = (theText.text.Split('\n'));
		}

	}
}
