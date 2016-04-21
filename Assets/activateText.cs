using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class activateText : MonoBehaviour {

	public TextAsset theText;

	public int startLine;
	public int endLine;

	public textBoxManager theTextBox;

	public bool destroyIt;

	// Use this for initialization
	void Start () {
		theTextBox = GameObject.FindObjectOfType<textBoxManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			theTextBox.ReloadScript (theText);
			theTextBox.currentLine = startLine;
			theTextBox.endAtLine = endLine;
			theTextBox.EnableTextBox ();

			if (destroyIt) {
				Destroy (gameObject);
			}
		}
	}
}
