using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public string nameOfSceneToLoad;

	// Use this for initialization
	void Start () {
		
	}
	
    public void Load () {
        SceneManager.LoadScene(nameOfSceneToLoad);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
