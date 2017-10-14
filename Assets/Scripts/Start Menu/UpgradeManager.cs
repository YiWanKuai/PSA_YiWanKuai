using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour {

    public GameObject canvas;
    public GameObject uMenu;

    public void OpenUpgrades() {

        GameObject newCanvas = Instantiate(canvas) as GameObject;
        GameObject createImage = Instantiate(uMenu) as GameObject;
        createImage.transform.SetParent(newCanvas.transform, false);
    }

    public void UpgradeFreeze() {
        PlayerPrefs.SetInt("freezeLevel", (PlayerPrefs.HasKey("freezeLevel") ? PlayerPrefs.GetInt("freezeLevel") + 1 : 2));

        Statics.updateFreezeLevel();
    }

	public void UpgradeStandardize() {
		PlayerPrefs.SetInt("standardizeLevel", (PlayerPrefs.HasKey("standardizeLevel") ? PlayerPrefs.GetInt("standardizeLevel") + 1 : 2));
		Statics.updateStandardizeLevel ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
