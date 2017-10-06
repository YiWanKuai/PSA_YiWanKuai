using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Freeze : MonoBehaviour {

    private GameManager gm;
    private Text text;
    private Image image;

    // Use this for initialization
    void Start () {
        text = GetComponentInChildren<Text>();
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        image = GetComponent<Image>();
    }

    public void FreezeGame() {
        if(gm.Unpaused() && !gm.isFrozen)
        StartCoroutine(StartFreezeGame());
    }
	
	// Update is called once per frame
	IEnumerator StartFreezeGame () {
        gm.isFrozen = true;
        int waitTime = PlayerPrefs.GetInt("freezeLevel") + 5;
        image.color = Color.gray;
        while(waitTime > 0) {
            text.text = waitTime.ToString();
            yield return new WaitForSeconds(1f);
            waitTime--;
        }
        image.color = Color.white;
        gm.isFrozen = false;
	}
}
