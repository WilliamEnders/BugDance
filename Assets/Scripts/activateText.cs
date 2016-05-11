using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class activateText : MonoBehaviour {

	private playerControl move;
	private RaycastHit hit;
	private Transform cam;

	// Use this for initialization
	void Start () {
		move = GameObject.Find ("FPSController").GetComponent<playerControl>();

		cam = GameObject.Find ("FirstPersonCharacter").transform;

	}

	void OnTriggerStay(Collider other){

		if(other.CompareTag("PickUp") && other.name == "Leaf"){
			GetComponent<textBoxManager> ().foundLeave = true;
		}
		
		if (other.tag == "Player" && Input.GetKey(KeyCode.E)) {
			if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, 100.0f)) {
				if (hit.transform.CompareTag ("Character")) {
					
					move.canMove = false;

					GetComponent<textBoxManager> ().isActive = true;
					GetComponent<textBoxManager> ().isTalking = true;

//					if (!GetComponent<textBoxManager> ().talked) {
//						GetComponent<textBoxManager> ().currentLine = 0;
//						GetComponent<textBoxManager> ().isActive = true;
//						GetComponent<textBoxManager> ().isTalking = true;
//					}
//
				}
			}
		}
	}
}