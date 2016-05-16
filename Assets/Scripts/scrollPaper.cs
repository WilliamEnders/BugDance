using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scrollPaper : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<RectTransform> ().localPosition += new Vector3(0, Input.GetAxis ("Mouse ScrollWheel") * 40,0);
	}
}
