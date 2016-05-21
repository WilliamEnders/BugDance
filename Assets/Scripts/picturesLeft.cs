using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class picturesLeft : MonoBehaviour {

	public Text txt;
	public takePicture num;

	// Use this for initialization
	void Start () {
		txt = GetComponent<Text> ();
		num = GameObject.Find ("FirstPersonCharacter").GetComponent<takePicture> ();
	}
	
	// Update is called once per frame
	void Update () {
		txt.text = ( 6 - num.invNum).ToString () + " more photos";
	}
}
