using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class checkPhotos : MonoBehaviour {

	public Transform[] inv;
	public Transform[] imageFrames;
	public GameObject newspaper;
	
	private Transform cam;
	// Use this for initialization
	void Start () {
		cam = GameObject.Find ("FirstPersonCharacter").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(inv[0]!=null){
			print ("wowow");
			Texture2D textureSprite = inv [0].GetComponent<pictureInfo> ().texture;
			imageFrames [0].GetComponent<Image> ().sprite = Sprite.Create(textureSprite, new Rect(0,0,textureSprite.width,textureSprite.height),new Vector2(0.5f,0.5f));
		}
	}

	void OnTriggerStay(Collider info){
		if(info.tag == "Player" && Input.GetMouseButtonDown (0)&& !cam.GetComponent<takePicture>().cameraMode){
		newspaper.SetActive (true);
			if(info.CompareTag("Player")){
				for(int i=0; i < info.GetComponentInChildren<takePicture>().invNum; i++){
					inv[i] = info.GetComponentInChildren<takePicture> ().inventory [i];
				}
			}
		}
	}
}
