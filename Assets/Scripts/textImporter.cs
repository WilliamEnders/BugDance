using UnityEngine;
using System.Collections;

public class textImporter : MonoBehaviour {

	public TextAsset textFiles;
	public string[] textLines;

	void Start(){
		if (textFiles != null) {
			textLines = (textFiles.text.Split('\n'));
		}
	}

	void Update(){

	}
}
