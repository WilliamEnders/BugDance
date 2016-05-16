using UnityEngine;
using System.Collections;

public class caterpillarPlaying : MonoBehaviour {

	Animator animator;

	float timer;
	float timeGap;

	float rotation;

	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator>();

		timer = 0;
		timeGap = 5;

//		rotation = transform.rotation.x;
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

		if (timer >= timeGap * 3) {
			GetComponent<SpriteRenderer> ().flipX = false;

			animator.SetBool ("startWalk", false);
			animator.SetBool ("endWalk", true);
		}
		else if (timer >= timeGap * 2) {
			GetComponent<SpriteRenderer> ().flipX = true;
			animator.SetBool ("startWalk", true);
			animator.SetBool ("endWalk", false);

			transform.position += new Vector3 (0.5f * Time.deltaTime, 0, 0);

		}
		else if (timer >= timeGap) {

			animator.SetBool ("startWalk", false);
			animator.SetBool ("endWalk", true);

		}
		else if (timer >= 0) {
			animator.SetBool ("startWalk", true);
			animator.SetBool ("endWalk", false);

			transform.position -= new Vector3 (0.5f * Time.deltaTime, 0, 0);

		}
			
	}
}