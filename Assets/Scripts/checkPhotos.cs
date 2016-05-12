using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class checkPhotos : MonoBehaviour {

	public Transform[] inv;
	public Transform[] imageFrames;
	
	private Transform cam;

	private crossOverInfo crossOver;

	private fadeToBlack fade;
	// Use this for initialization
	void Start () {
		fade = GameObject.Find ("Fade").GetComponent<fadeToBlack> ();
		crossOver = GameObject.Find ("CrossOver").GetComponent<crossOverInfo> ();
		cam = GameObject.Find ("FirstPersonCharacter").transform;
	}

	void OnTriggerStay(Collider info){
		if(info.tag == "Player" && Input.GetMouseButtonDown (0)&& !cam.GetComponent<takePicture>().cameraMode && cam.GetComponent<takePicture>().invNum == 6){
			if(info.CompareTag("Player")){
				crossOver.MigrateInfo (info);
				fade.FadeOut ();
			}
		}
	}
}
