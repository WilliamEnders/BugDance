using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class activateText : MonoBehaviour {

	public TextAsset theText;

	public int startLine;
	public int endLine;

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
	}

	void OnTriggerStay(Collider other){
		
		if (other.tag == "Player" && Input.GetKey(KeyCode.E)) {
			if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, 100.0f)) {
				if (hit.transform.CompareTag ("Character")) {
					fps.m_MouseLook.SetCursorLock (false);
					theTextBox.ReloadScript (theText);
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
