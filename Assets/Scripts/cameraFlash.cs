using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class cameraFlash : MonoBehaviour {

	public float speed;
	public bool up;
	public Image flash;
	private float current;

	// Use this for initialization
	void Start () {
		up = false;
		flash = GetComponent<Image>();
	}
	
	// Update is called once per frame
	 void Update () {
		if(up){
			flash.color = Color.Lerp (Color.white,new Color(1,1,1,0),current);
			current += speed;
		}
		if(flash.color == new Color(1,1,1,0)){
			up = false;
			current = 0;
		}
	}
}
