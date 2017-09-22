using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
	
    public void Load (string nameOfSceneToLoad) {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nameOfSceneToLoad);
    }

    public void Reload() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
