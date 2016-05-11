using UnityEngine;
using System.Collections;

public class antMoving : MonoBehaviour {

	Animator animator;

	float timer;
	float timeGap;

	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator>();

		timer = 0;
		timeGap = 2;
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer >= timeGap * 3) {
			timer = 0;
		}

		ChangeAnim ();
	}

	void ChangeAnim ()
	{
		
		if (GetComponent<antTalking> ().findPartner && !GetComponent<antTalking> ().isTalking) {
			//walk
			if (timer >= timeGap) {
				animator.SetBool ("walkToRight", true);
			}

			//change direction
			if (timer >= timeGap * 2) {
				animator.SetBool ("walkToRight", false);
				animator.SetBool ("walkToLeft", true);
			}

			if (timer >= timeGap * 3) {
				animator.SetBool ("walkToRight", true);
				animator.SetBool ("walkToLeft", false);
			}

		} else if (GetComponent<antTalking> ().isTalking) {
			animator.SetBool ("walkToRight", false);
			animator.SetBool ("walkToLeft", true);
		}

		if (GetComponent<antTalking> ().showDance)

			//dance
			if (timer >= timeGap) {
			animator.SetBool ("Dance1", true);
		}
		if (timer >= timeGap * 2) {
			animator.SetBool ("Dance1", false);
			animator.SetBool ("Dance2", true);
		}
		if (timer >= timeGap * 3) {
			animator.SetBool ("Dance2", false);
			animator.SetBool ("Dance3", true);
		}
		//stop dance
//			if (timer >= timeGap*9) {
//				animator.SetBool ("Dance3", false);
//			}
	}
}