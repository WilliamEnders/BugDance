using UnityEngine;
using System.Collections;

public class beeAnimation : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator>();

	}

	// Update is called once per frame
	void Update () {

		if (GameObject.FindObjectOfType<beeTalking> ().showDance) {
			animator.SetBool ("dance", true);
		}
	}

}
