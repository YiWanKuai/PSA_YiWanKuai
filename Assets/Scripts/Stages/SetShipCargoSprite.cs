using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShipCargoSprite : MonoBehaviour {


    private ShipController sc;
    public Sprite[] cargoes;
    private SpriteRenderer sr;

    // Use this for initialization
    void Start() {
        sc = GetComponentInParent<ShipController>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        switch (sc.getCurrCargo()) {
            case 1:
                sr.sprite = cargoes[0];
                break;
            case 2:
                sr.sprite = cargoes[1];
                break;
            case 3:
                sr.sprite = cargoes[2];
                break;
            default:
                this.transform.parent.gameObject.SetActive(false);
                break;
        }
    }
}
