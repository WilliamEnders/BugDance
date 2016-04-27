using UnityEngine;
using System.Collections;

public class takePicture : MonoBehaviour {
	
	public bool grab;
	public GameObject polaroid;
	private RaycastHit hit;

	private Vector2 mouseVel;

	private playerControl cont;

	private Transform temp;
	public bool cameraMode;
	public bool pickUp;

	public GameObject viewfinder;
	private cameraFlash flash;
	private float fov;

	void Start(){
		cont = GetComponentInParent<playerControl> ();
		temp = null;
		cameraMode = false;
		pickUp = false;
		viewfinder.SetActive (false);
		flash = GameObject.Find ("Flash").GetComponent<cameraFlash> ();
		fov = 60;
	}


	void Update(){

		if(Input.GetMouseButtonDown (1) && !pickUp && cont.canMove){
			cameraMode = true;
			viewfinder.SetActive (true);
			fov = 60;
		}
		if(Input.GetMouseButtonUp (1)){
			cameraMode = false;
			viewfinder.SetActive (false);
			GetComponent<Camera> ().fieldOfView = 60;
		}

		if(cameraMode){
			GetComponent<Camera> ().fieldOfView = fov;
			if (fov <= 60 && fov >= 10) {
				fov += Input.GetAxis ("Mouse ScrollWheel") * 6;
			} else if(fov < 10){
				fov = 10;
			}else if(fov > 60){
				fov = 60;
			}
		}

		if (cont.canMove) {

			if (cameraMode && Input.GetMouseButtonDown (0)) {
				grab = true;
				flash.up = true;
			}

			if (Input.GetMouseButtonDown (0) && !cameraMode) {
				if (Physics.Raycast (transform.position + transform.forward, transform.forward, out hit, 100.0f)) {
					if (hit.transform.CompareTag ("PickUp")) {
						hit.transform.GetComponent<Rigidbody> ().useGravity = false;
						hit.transform.parent = transform;
						temp = hit.transform;
						pickUp = true;

					}
				}
			}

			if (Input.GetMouseButton (0)) {
				if(temp != null){
					mouseVel = new Vector2 (Input.GetAxis ("Mouse X"), Input.GetAxis ("Mouse Y"));
					temp.position = transform.position + transform.forward;
					temp.rotation = transform.rotation;
				}
			}

			if (Input.GetMouseButtonUp (0)) {
				if (temp != null) {
					temp.GetComponent<Rigidbody> ().useGravity = true;
					temp.parent = null;
					temp.GetComponent<Rigidbody> ().AddForce (transform.right * (mouseVel.x * 100f));
					temp.GetComponent<Rigidbody> ().AddForce (transform.up * (mouseVel.y * 100f));
					temp = null;
					pickUp = false;
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