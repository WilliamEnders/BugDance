using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class crossOverInfo : MonoBehaviour {

	public Transform[] inv;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(transform.gameObject);
	}

	void Update(){
		if (SceneManager.GetActiveScene ().buildIndex == 2) {
			for(int i = 0; i<inv.Length;i++){
				GameObject.Find("Newspaper").GetComponent<fillNewspaper>().inv[i] = inv[i];
			}
			Destroy (transform.gameObject);
		}
	}

	public void MigrateInfo(Collider info){
		for(int i=0; i < info.GetComponentInChildren<takePicture>().invNum; i++){
			inv[i] = info.GetComponentInChildren<takePicture> ().inventory [i];
			inv [i].transform.parent = null;
			DontDestroyOnLoad (inv[i].transform.gameObject);
		}
	}
}
