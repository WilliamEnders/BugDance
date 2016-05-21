using UnityEngine;
using System.Collections;

public class ladybugAnimation : MonoBehaviour {

	Animator animator;

	float timer;
	float timeGap;
		
	int randomAnim;

	void Start () {

		animator = GetComponent<Animator>();

		timer = 0;
		timeGap = 2;
		randomAnim = 0;
	}

	void Update () {

		timer += Time.deltaTime;
	
		if (timer >= timeGap * 2) {
			randomAnim = Random.Range(0, 3);
			timer = 0;
		}
	
		ChangeAnim ();
	}

	void ChangeAnim (){
			//idle
			if (randomAnim == 3) {

				animator.SetBool ("isTalking", false);
				animator.SetBool ("isWalking", false);
				animator.SetBool ("isDancing", false);

			}
		//dance
		else if (randomAnim == 2) {

			animator.SetBool ("isTalking", false);
			animator.SetBool ("isWalking", false);
			animator.SetBool ("isDancing", true);

		}
		//walk
		else if (randomAnim == 1) {

			animator.SetBool ("isTalking", false);
			animator.SetBool ("isWalking", true);
			animator.SetBool ("isDancing", false);

		}
		//talk
		else if (randomAnim == 0) {

			animator.SetBool ("isTalking", true);
			animator.SetBool ("isWalking", false);
			animator.SetBool ("isDancing", false);

		}
	}
}
