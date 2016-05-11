using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fadeToBlack : MonoBehaviour {

	public bool fadeIn;
	public bool fadeOut;
	private Image fade;
	public float a;


	// Use this for initialization
	void Start () {
		fadeIn = true;
		fadeOut = false;
		fade = GetComponent<Image> ();
		a = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(fadeIn){
			AudioListener.volume = 1-a;
			fade.color = new Color (0,0,0,a);
			a -= 0.01f;
			if(a <= 0){
				a = 0;
				fadeIn = false;
			}
		}
		if(fadeOut){
			AudioListener.volume = 1-a;
			fade.color = new Color (0,0,0,a);
			a += 0.01f;
			if(a >= 1){
				SceneManager.LoadScene(1);
			}
		}
	}

	public void FadeOut(){
		fadeOut = true;
	}

}
