using UnityEngine;
using System.Collections;

public class bossTalking : MonoBehaviour {

	Animator anim;
	bool isTalking = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		Invoke ("talking", 0.01f);

	
	}

	void talking(){
		
		anim.SetBool ("isTalking", true);

	}
}
