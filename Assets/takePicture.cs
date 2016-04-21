using UnityEngine;
using System.Collections;

public class takePicture : MonoBehaviour {
	
	public bool grab;
	public GameObject polaroid;
	private RaycastHit hit;

	void Update(){
		if(Input.GetKeyDown(KeyCode.Q)){
			grab = true;
		}

		if(Input.GetMouseButtonDown(0)){
			if (Physics.Raycast (transform.position + transform.forward, transform.forward, out hit, 100.0f)) {
				if(hit.transform.CompareTag("PickUp")){
					hit.transform.GetComponent<Rigidbody> ().useGravity = false;
				}
			}
		}
		if (Input.GetMouseButton (0)) {
			if (hit.transform.CompareTag ("PickUp")) {
				hit.transform.position = transform.position + transform.forward;
				hit.transform.rotation = transform.rotation;
			}
		}
		if(Input.GetMouseButtonUp(0)){
			if (hit.transform.CompareTag ("PickUp")) {
				hit.transform.GetComponentInChildren<BoxCollider> ().enabled = true;
				hit.transform.GetComponent<Rigidbody> ().useGravity = true;
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