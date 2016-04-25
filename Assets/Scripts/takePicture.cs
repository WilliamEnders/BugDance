using UnityEngine;
using System.Collections;

public class takePicture : MonoBehaviour {
	
	public bool grab;
	public GameObject polaroid;
	private RaycastHit hit;

	private Vector2 mouseVel;

	private playerControl cont;

	void Start(){
		cont = GetComponentInParent<playerControl> ();
	}


	void Update(){

		if(cont.canMove){

		if(Input.GetMouseButtonDown(0)){
			grab = true;
		}

		if(Input.GetMouseButtonDown(1)){
			if (Physics.Raycast (transform.position + transform.forward, transform.forward, out hit, 100.0f)) {
				if(hit.transform.CompareTag("PickUp")){
					hit.transform.GetComponent<Rigidbody> ().useGravity = false;
					hit.transform.parent = transform;

				}
			}
		}
		if (Input.GetMouseButton (1)) {

			mouseVel = new Vector2 (Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"));

			if (hit.transform.CompareTag ("PickUp")) {
				hit.transform.position = transform.position + transform.forward;
				hit.transform.rotation = transform.rotation;
			}
		}
		if(Input.GetMouseButtonUp(1)){
			if (hit.transform.CompareTag ("PickUp")) {
				hit.transform.GetComponent<Rigidbody> ().useGravity = true;
				hit.transform.parent = null;
				hit.transform.GetComponent<Rigidbody> ().AddForce (transform.right * (mouseVel.x * 100f));
				hit.transform.GetComponent<Rigidbody> ().AddForce (transform.up * (mouseVel.y * 100f));
			}
		}

		}


	}

	void OnPostRender() {
		if (grab) {
			GameObject pol = Instantiate (polaroid,transform.position + transform.forward,transform.rotation) as GameObject;
			Texture2D tex2D = new Texture2D(Screen.width, Screen.height);
			tex2D.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
			tex2D.Apply();
			pol.GetComponent<Renderer>().material.mainTexture = tex2D;
			grab = false;
		}
	}
}