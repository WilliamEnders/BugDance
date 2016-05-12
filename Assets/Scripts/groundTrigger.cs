using UnityEngine;
using System.Collections;

public class groundTrigger : MonoBehaviour {


	void OnTriggerEnter(Collider info){
		if (info.CompareTag ("PickUp")) {
			if(info.name == "Leaf"){
				info.transform.position = new Vector3 (-18f,11.23f,-11f);
			}else{
			Destroy (info.transform.parent.gameObject);
			}
		}
	}
}
