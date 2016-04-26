using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class playerControl : MonoBehaviour {


	public TextAsset textFiles;
	public string[] textLines;

	public bool canMove;

	void Start(){
		
		if (textFiles != null) {
			textLines = (textFiles.text.Split());
		}

		canMove = true;
	}
	
	// Update is called once per frame
	void Update(){
		if (canMove) {
			GetComponent<FirstPersonController> ().m_WalkSpeed = 5;
		} else {
			GetComponent<FirstPersonController> ().m_WalkSpeed = 0;
		}

	}

}
