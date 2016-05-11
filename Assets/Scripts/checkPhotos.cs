using UnityEngine;
using System.Collections;

public class checkPhotos : MonoBehaviour {

	public Transform[] inv;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider info){
		if(info.CompareTag("Player")){
			for(int i=0; i < info.GetComponentInChildren<takePicture>().invNum; i++){
				inv[i] = info.GetComponentInChildren<takePicture> ().inventory [i];
			}
		}
	}
}
