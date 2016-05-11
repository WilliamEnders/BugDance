using UnityEngine;
using System.Collections;

public class beeActivate : MonoBehaviour {

	private playerControl move;
	private RaycastHit hit;

	private Transform cam;

	// Use this for initialization
	void Start () {
		move = GameObject.Find ("FPSController").GetComponent<playerControl>();
		cam = GameObject.Find ("FirstPersonCharacter").transform;
	}

	void OnTriggerStay(Collider other){

		if (other.tag == "Player" && Input.GetKey(KeyCode.E)) {
			if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, 100.0f)) {
				if (hit.transform.CompareTag ("Character")) {

					move.canMove = false;

					//GetComponent<beeTalking> ().isTalking = true;
					if (!GetComponent<beeTalking> ().talked) {
						GetComponent<beeTalking> ().currentLine = 0;
						GetComponent<beeTalking> ().isTalking = true;
					}
				}
			}
		}

	}
}
