using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fillNewspaper : MonoBehaviour {

	public Transform[] inv;

	public Transform[] imageFrames;

	public string[] clip1;
	public string[] clip2;
	public string[] clip3;

	// Use this for initialization
	void Start () {

		Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(imageFrames [5].GetComponent<Image> ().sprite == null){
			for(int i=0; i < inv.Length; i++){
				Image img = imageFrames [i].GetComponent<Image> ();
				Text txt = imageFrames [i].GetComponentInChildren<Text> ();
				pictureInfo info = inv [i].GetComponent<pictureInfo> ();
				img.sprite = Sprite.Create(info.texture, new Rect(0,0,info.texture.width,info.texture.height),new Vector2(0.5f,0.5f));
				if(info.subject == "Nothing"){
					txt.text = "We're not really sure what this picture is of, but we still love it!";
				}else if(info.subject == "Stump"){
					txt.text = "This picture is mostly stump, but that doesn't mean it isn't newsworthy!";
				}else{
					txt.text = clip1 [i] + " " + info.subject + " " + clip2[i];
					if(info.isDancing){
						txt.text += " " + clip3 [i];
					}
				}
			}



		}
	}
}
