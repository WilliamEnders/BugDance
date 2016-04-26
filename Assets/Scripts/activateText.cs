using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class activateText : MonoBehaviour {

	public TextAsset theText;

	int startLine;
	int endLine;

	public textBoxManager theTextBox;

	public bool destroyIt;

	private FirstPersonController fps;
	private RaycastHit hit;

	private Transform cam;

	// Use this for initialization
	void Start () {
		theTextBox = GameObject.FindObjectOfType<textBoxManager> ();
		fps = GameObject.Find ("FPSController").GetComponent<FirstPersonController> ();
		cam = GameObject.Find ("FirstPersonCharacter").transform;

		startLine = 0;
		endLine = 2;
	}

	void OnTriggerStay(Collider other){
		
		if (other.tag == "Player" && Input.GetKey(KeyCode.E)) {
			if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, 100.0f)) {
				if (hit.transform.CompareTag ("Character")) {
					fps.m_MouseLook.SetCursorLock (false);

					if (theTextBox.showDance && theTextBox.dialogFinished) {
						
						theTextBox.theText.text = "Hold your camera!";

					} else if (theTextBox.findLeave && theTextBox.dialogFinished) {

						theTextBox.theText.text = "Did you find some great leaves?";

					} else {
							theTextBox.LoadScript (theText);
							theTextBox.currentLine = startLine;
							theTextBox.endAtLine = endLine;
							theTextBox.EnableTextBox ();
					}
				}
			}
		}
			if (destroyIt) {
				Destroy (gameObject);
			}
		}
	}
