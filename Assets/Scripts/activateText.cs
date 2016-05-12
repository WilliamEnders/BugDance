using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class activateText : MonoBehaviour {

	private playerControl move;
	private RaycastHit hit;
	private Transform cam;

	public GameObject mouse;

	// Use this for initialization
	void Start () {
		move = GameObject.Find ("FPSController").GetComponent<playerControl>();

		cam = GameObject.Find ("FirstPersonCharacter").transform;

	}

	void OnTriggerEnter(Collider other){
		if(!mouse.activeSelf){
			mouse.SetActive (true);
			mouse.GetComponent<Animator> ().SetBool ("canTalk", true);
		}
		if(other.CompareTag("PickUp") && other.name == "Leaf" && other.transform.parent == null && GetComponent<textBoxManager>().findLeave){
			GetComponent<textBoxManager> ().foundLeave = true;
			GetComponent<AudioSource> ().Play ();
			Destroy (other.gameObject);
		}

	}

	void OnTriggerExit(){
		mouse.SetActive (false);
		mouse.GetComponent<Animator> ().SetBool ("canTalk", false);
	}

	void OnTriggerStay(Collider other){
		if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, 100.0f)) {
			if (other.tag == "Player" && Input.GetMouseButtonDown (0) && !cam.GetComponent<takePicture> ().cameraMode) {
				if (hit.transform.CompareTag ("Character")) {
					mouse.SetActive (false);
					mouse.GetComponent<Animator> ().SetBool ("canTalk", false);
					move.canMove = false;

					GetComponent<textBoxManager> ().isActive = true;
					GetComponent<textBoxManager> ().isTalking = true;

				}
			}
		} else {
			mouse.SetActive (false);
			mouse.GetComponent<Animator> ().SetBool ("canTalk", false);
		}
	}
}