using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCargoDisplay : MonoBehaviour {

    private GameManager gm;
    public Sprite[] cargoes;
    private Image image;
    private RectTransform rt;
    //private SpriteRenderer sr;

    // Use this for initialization
    void Start () {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        image = GetComponent<Image>();
        rt = GetComponent<RectTransform>();
        //sr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		switch (gm.getCargoType()) {
            case 1:
                image.color = Color.white;
                rt.localScale = new Vector3(0.4f, 0.4f, 1f);
                image.sprite = cargoes[0];
                break;
            case 2:
                image.color = Color.white;
                rt.localScale = new Vector3(0.6f, 0.6f, 1f);
                image.sprite = cargoes[1];
                break;
            case 3:
                image.color = Color.white;
                image.sprite = cargoes[2];
                break;
            default:
                image.color = Color.clear;
                break;
        }
	}
}
