using UnityEngine;
using System.Collections;
using UnityStandardAssets.Utility;

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
	public GameObject inv;
	public int invNum;
	private cameraFlash flash;
	private float fov;

	public LayerMask layerMask;

	private int timer;

	public Transform[] inventory;


	void Start(){
		invNum = 0;
		timer = 0;
		cont = GetComponentInParent<playerControl> ();
		temp = null;
		cameraMode = false;
		pickUp = false;
		viewfinder.SetActive (false);
		flash = GameObject.Find ("Flash").GetComponent<cameraFlash> ();
		fov = 60;


	}


	void Update(){

		if(timer > 0){
			timer--;
		}

		if(Input.GetKeyDown(KeyCode.Q)){
			if(invNum > 0){
			Destroy (inventory[invNum-1].gameObject);
			inventory [invNum-1] = null;
			invNum--;
			}
		}

		if(pickUp && Input.GetMouseButtonDown (1)){
			
			inventory [invNum] = temp;
			Destroy (temp.GetComponent<Rigidbody>());
			Destroy (temp.GetComponentInChildren<BoxCollider>());
			temp.transform.parent = inv.transform.GetChild (invNum);
			temp.transform.localPosition = Vector3.back;
			temp.transform.localScale = new Vector3 (50,50,50);
			invNum++;
			
		}

		if(Input.GetMouseButtonDown (1) && !pickUp && cont.canMove){
			GetComponent<binoTest> ().look = true;
			cameraMode = true;
			viewfinder.SetActive (true);
			inv.SetActive (false);
			fov = 60;

		}
		if(Input.GetMouseButtonUp (1)){
			GetComponent<binoTest> ().look = false;
			cameraMode = false;
			viewfinder.SetActive (false);
			inv.SetActive (true);
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

			if (cameraMode && Input.GetMouseButtonDown (0) && timer == 0) {
				grab = true;
				flash.up = true;
				timer = 60;
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
					if (temp.parent == transform) {
						mouseVel = new Vector2 (Input.GetAxis ("Mouse X"), Input.GetAxis ("Mouse Y"));
						temp.position = transform.position + transform.forward;
						temp.rotation = transform.rotation;
					}
				}
			}

			if (Input.GetMouseButtonUp (0)) {
				if (temp != null) {
					if(temp.parent == transform){
					temp.GetComponent<Rigidbody> ().useGravity = true;
					temp.parent = null;
					temp.GetComponent<Rigidbody> ().AddForce (transform.right * (mouseVel.x * 100f));
					temp.GetComponent<Rigidbody> ().AddForce (transform.up * (mouseVel.y * 100f));
					}
					temp = null;
					pickUp = false;
				}
			}

		}
	}

	void OnPostRender() {
		if (grab) {
			GetComponent<AudioSource> ().Play ();
			GameObject pol = Instantiate (polaroid, transform.position + transform.forward, transform.rotation) as GameObject;
			Texture2D tex2D = new Texture2D (Screen.width, Screen.height);
			tex2D.ReadPixels (new Rect (0, 0, Screen.width, Screen.height), 0, 0, false);
			tex2D.Apply ();
			pol.GetComponent<Renderer> ().material.mainTexture = tex2D;
			pol.GetComponent<Renderer> ().material.SetTextureScale ("_MainTex", new Vector2(1/Camera.main.aspect,1f));
			pol.GetComponent<Renderer> ().material.SetTextureOffset ("_MainTex", new Vector2((1-(1/Camera.main.aspect))*.5f,0f));

			if (Physics.Raycast (transform.position + transform.forward, transform.forward, out hit, 100.0f,layerMask)) {
				pol.GetComponent<pictureInfo> ().subject = hit.transform.name;
				pol.GetComponent<pictureInfo> ().texture = tex2D;
				if(hit.transform.CompareTag("Character")){
				pol.GetComponent<pictureInfo> ().isDancing = hit.transform.GetComponent<textBoxManager> ().showDance;
				}
			}
			pol.transform.GetComponent<Rigidbody> ().useGravity = false;
			pol.transform.parent = transform;
			temp = pol.transform;
			pickUp = true;
			grab = false;

			pol = null;
		}
	}

}