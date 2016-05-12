using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class playerControl : MonoBehaviour {


//	public TextAsset textFiles;
//	public string[] textLines;
	private FirstPersonController fps;
	public bool canMove;
	public GameObject retical;

	void Start(){
		fps = GameObject.Find ("FPSController").GetComponent<FirstPersonController> ();
//		if (textFiles != null) {
//			textLines = (textFiles.text.Split());
//		}

		canMove = true;
	}
	
	// Update is called once per frame
	void Update(){
		if (canMove) {
			GetComponent<FirstPersonController> ().m_WalkSpeed = 5;
			fps.m_MouseLook.SetCursorLock (true);
			fps.m_MouseLook.XSensitivity = 2;
			fps.m_MouseLook.YSensitivity = 2;
			//GetComponentInChildren<binoTest> ().look = false;
			retical.SetActive (true);
		} else {
			GetComponent<FirstPersonController> ().m_WalkSpeed = 0;
			fps.m_MouseLook.SetCursorLock (false);
			fps.m_MouseLook.XSensitivity = 0;
			fps.m_MouseLook.YSensitivity = 0;
			GetComponentInChildren<binoTest> ().look = true;
			retical.SetActive (false);
		}

	}

}
