using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clearSelection : MonoBehaviour {

	private GameManager gm;
	private Text text;
	private Image image;
	private int coolDown = 15;

	// Use this for initialization
	void Start () {
		text = GetComponentInChildren<Text>();
		gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
		image = GetComponent<Image>();
	}

	public void ClearGame() {
		if (gm.Unpaused ())
			gm.resetCargo ();
		//StartCoroutine(StartStandardizeGame());
	}
	/*
	IEnumerator StartStandardizeGame () {
		gm.isStandardized = true;
		int waitTime = PlayerPrefs.GetInt("freezeLevel") + 5;
		int rechargeTime = coolDown;
		image.color = Color.green;
		while(waitTime > 0) {
			text.text = waitTime.ToString();
			yield return new WaitForSeconds(1f);
			waitTime--;
		}
		gm.isStandardized = false;
		image.color = Color.gray;
		while (rechargeTime > 0) {
			text.text = rechargeTime.ToString ();
			yield return new WaitForSeconds (1f);
			rechargeTime--;
		}
		image.color = Color.white;
		text.text = "";
	}
	*/
}
