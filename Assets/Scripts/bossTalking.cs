using UnityEngine;
using System.Collections;

public class bossTalking : MonoBehaviour {

	Animator anim;
	bool isTalking;
	bool isHearing;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		isTalking = GameObject.Find("player").GetComponent<reporterTalking>().bossTalking;

		if (isTalking) {
			anim.SetBool ("isTalking", true);
		} else {
			anim.SetBool ("isTalking", false);
		}
	}
}
