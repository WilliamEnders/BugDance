using UnityEngine;
using System.Collections;

public class antPlaying : MonoBehaviour {

	Animator animator;

	float timer;
	float timeGap;

	float rotation;

	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator>();

		timer = 0;
		timeGap = 8;

	}

	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if (timer >= timeGap * 4) {
			timer = 0;
		}

		ChangeAnim ();
	}

	void ChangeAnim (){

		if (GetComponent<Rigidbody> () == null) {
			if (timer >= timeGap * 3) {
				animator.SetBool ("walkToLeft", false);
				animator.SetBool ("walkToRight", false);

			} else if (timer >= timeGap * 2) {

				animator.SetBool ("walkToLeft", true);
				animator.SetBool ("walkToRight", false);

				transform.position += new Vector3 (0.3f * Time.deltaTime, 0, 0);

			} else if (timer >= timeGap) {
				animator.SetBool ("walkToLeft", false);
				animator.SetBool ("walkToRight", false);

			} else if (timer >= 0) {
				animator.SetBool ("walkToLeft", false);
				animator.SetBool ("walkToRight", true);

				transform.position -= new Vector3 (0.3f * Time.deltaTime, 0, 0);

			}
		//the ones walking up
		} else {

			if (timer >= timeGap * 3) {
				animator.SetBool ("walkToLeft", false);
				animator.SetBool ("walkToRight", false);

			} else if (timer >= timeGap * 2) {

				animator.SetBool ("walkToLeft", true);
				animator.SetBool ("walkToRight", false);

				transform.position -= new Vector3 (0, 0.3f * Time.deltaTime, 0);

			} else if (timer >= timeGap) {
				animator.SetBool ("walkToLeft", false);
				animator.SetBool ("walkToRight", false);

			} else if (timer >= 0) {
				animator.SetBool ("walkToLeft", false);
				animator.SetBool ("walkToRight", true);

				transform.position += new Vector3 (0, 0.3f * Time.deltaTime, 0);

			}
		}

	}

}
