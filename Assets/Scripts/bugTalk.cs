using UnityEngine;
using System.Collections;

public class bugTalk : MonoBehaviour {

	bool talking;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
//			talking = true;
			//GetComponent<textBoxManager>().isActive = true;
		}
	}

}
