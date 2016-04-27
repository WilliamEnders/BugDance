﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class playerControl : MonoBehaviour {


	public TextAsset textFiles;
	public string[] textLines;
	private FirstPersonController fps;
	public bool canMove;

	void Start(){
		fps = GameObject.Find ("FPSController").GetComponent<FirstPersonController> ();
		if (textFiles != null) {
			textLines = (textFiles.text.Split());
		}

		canMove = true;
	}
	
	// Update is called once per frame
	void Update(){
		if (canMove) {
			GetComponent<FirstPersonController> ().m_WalkSpeed = 5;
			fps.m_MouseLook.SetCursorLock (true);
		} else {
			GetComponent<FirstPersonController> ().m_WalkSpeed = 0;
			fps.m_MouseLook.SetCursorLock (false);
		}

	}

}
