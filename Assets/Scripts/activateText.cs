using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class activateText : MonoBehaviour {

	public TextAsset theText;

	int startLine;
	int endLine;

	public textBoxManager theTextBox;

	public bool destroyIt;

	private playerControl move;
	private RaycastHit hit;

	private Transform cam;

	// Use this for initialization
	void Start () {
		move = GameObject.Find ("FPSController").GetComponent<playerControl>();
		theTextBox = GameObject.FindObjectOfType<textBoxManager> ();

		cam = GameObject.Find ("FirstPersonCharacter").transform;

		startLine = 0;
		endLine = 2;
	}

	void OnTriggerStay(Collider other){
		
		if (other.tag == "Player" && Input.GetKey(KeyCode.E)) {
			if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, 100.0f)) {
				if (hit.transform.CompareTag ("Character")) {
					
					move.canMove = false;

					theTextBox.LoadScript (theText);
					theTextBox.currentLine = startLine;
					theTextBox.endAtLine = endLine;
					theTextBox.EnableTextBox ();
				}
			}
		}
			if (destroyIt) {
				Destroy (gameObject);
			}
		}
	}
