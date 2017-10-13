using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cargoCountDisplay : MonoBehaviour {

	private ShipController sc;
	private Text text;

	// Use this for initialization
	void Start () {
		sc = GetComponentInParent<ShipController>();
		text = GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {
		text.text = sc.getcargoCount ();
		if (sc.toTheLeft) {
			this.transform.parent.gameObject.SetActive(false);
		}
		
	}
}
