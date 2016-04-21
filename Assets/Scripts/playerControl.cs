using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerControl : MonoBehaviour {

	float playerSpeed = 5.0f;

	public TextAsset textFiles;
	public string[] textLines;

	public bool canMove = true;

	void Start(){
		
		if (textFiles != null) {
			textLines = (textFiles.text.Split());
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (!canMove) {
			return;
		}else{
		//if (canMove) {
			
			if (Input.GetAxis ("Horizontal") != 0) {
				//go left
				if (Input.GetAxisRaw ("Horizontal") < 0) {

					transform.position -= new Vector3 (playerSpeed * Time.deltaTime, 0, 0);
				//go right
				} else if (Input.GetAxisRaw ("Horizontal") > 0) {
					
					transform.position += new Vector3 (playerSpeed * Time.deltaTime, 0, 0);
				}

			}
		//}
		}
	
	}
}
