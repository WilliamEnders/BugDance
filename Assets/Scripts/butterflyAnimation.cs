using UnityEngine;
using System.Collections;

public class butterflyAnimation: MonoBehaviour {

	Animator animator;

	float timer;
	float timeGap;

	int randomAnim;

	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator>();

		timer = 0;
		timeGap = 2;

		randomAnim = 0;
	}

	// Update is called once per frame
	void Update () {
		
		timer += Time.deltaTime;

		if (timer >= timeGap) {
			
			randomAnim = Random.Range(0, 3);
			timer = 0;
		}

		ChangeDirection ();
		ChangeAnim ();
	}

	void ChangeDirection(){
		if (randomAnim == 0) {
			transform.position += new Vector3 (0, 0.2f * Time.deltaTime, 0);
		}

		if (randomAnim == 1) {
			transform.position += new Vector3 (0.2f * Time.deltaTime, 0, 0.2f * Time.deltaTime);
			transform.Rotate (new Vector3 (0.2f * Time.deltaTime, 0, 0));

		}

		if (randomAnim == 2) {
			transform.position -= new Vector3 (0, 0.2f * Time.deltaTime, 0);
			transform.Rotate (new Vector3 (-0.8f * Time.deltaTime, 0, 0));
			GetComponent<SpriteRenderer> ().flipY = true;

		} else {
			GetComponent<SpriteRenderer> ().flipY = false;
		}

		if (randomAnim == 3) {
			transform.position -= new Vector3 (0.2f * Time.deltaTime, 0, 0.2f * Time.deltaTime);
			transform.Rotate (new Vector3 (0, 0, -0.5f * Time.deltaTime));
		}
//			GetComponent<SpriteRenderer> ().flipX = true;
//
//		} else {
//			GetComponent<SpriteRenderer> ().flipX = false;
//		}

			

	}

	void ChangeAnim ()
	{
		//idle
		if (randomAnim ==0) {

			animator.SetBool ("isFlying", false);

		}

		//fly
		if (randomAnim >= 1) {

			animator.SetBool ("isFlying", true);

		}

	}
}
