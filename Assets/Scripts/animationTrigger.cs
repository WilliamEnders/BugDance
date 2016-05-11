using UnityEngine;
using System.Collections;

public class animationTrigger : MonoBehaviour {

	GameObject Caterpillar;
	Animator animator;

	// Use this for initialization
	void Start () {

		Caterpillar = GameObject.Find ("Caterpillar");
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Caterpillar.GetComponent<textBoxManager> ().showDance) {
			animator.SetBool ("startDance", true);
		}

		if (Caterpillar.GetComponent<textBoxManager> ().findLeave && !Caterpillar.GetComponent<textBoxManager> ().isTalking) {
			animator.SetBool ("startWalk", true);
			animator.SetBool ("endWalk", false);

		} else {
			animator.SetBool ("endWalk", true);
			animator.SetBool ("startWalk", false);
		}
	
	}
}
