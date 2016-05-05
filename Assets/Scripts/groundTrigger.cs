using UnityEngine;
using System.Collections;

public class groundTrigger : MonoBehaviour {


	void OnTriggerEnter(Collider info){
		if (info.CompareTag ("PickUp")) {
			Destroy (info.transform.parent.gameObject);
		}
	}
}
