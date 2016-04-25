using UnityEngine;
using System.Collections;

public class billboardLook : MonoBehaviour {

	public Transform cameraTransform;

	void Start(){
	}

	void Update() {
		Vector3 v = cameraTransform.position - transform.position;
		v.x = v.z = 0.0f;
		transform.LookAt(cameraTransform.position - v); 
	}
}
