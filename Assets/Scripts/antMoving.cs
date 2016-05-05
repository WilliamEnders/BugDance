using UnityEngine;
using System.Collections;

public class antMoving : MonoBehaviour {

	GameObject Ant;
	Animator animator;

	float timer;
	float timeGap;

	// Use this for initialization
	void Start () {

		Ant = GameObject.Find ("Ant");
		animator = GetComponent<Animator>();

		timer = 0;
		timeGap = 2;
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		//walk
		if (timer >= timeGap) {
			animator.SetBool ("walkToRight", true);
		}

		if (timer >= timeGap*2) {
			animator.SetBool ("walkToRight", false);
			animator.SetBool ("walkToLeft", true);
		}

		//stop walk
		if (timer >= timeGap*3) {
			animator.SetBool ("walkToRight", false);
			animator.SetBool ("walkToLeft", false);
		}

		//dance
		if (timer >= timeGap*4) {
			animator.SetBool ("Dance1", true);
		}
		if (timer >= timeGap*5) {
			animator.SetBool ("Dance1", false);
			animator.SetBool ("Dance2", true);
		}
		if (timer >= timeGap*7) {
			animator.SetBool ("Dance2", false);
			animator.SetBool ("Dance3", true);
		}

		//stop dance
		if (timer >= timeGap*9) {
			animator.SetBool ("Dance3", false);
		}


		if (timer >= 20) {
			timer = 0;
		}
	}

}
