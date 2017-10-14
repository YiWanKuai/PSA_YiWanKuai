using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailBehaviour : MonoBehaviour {

    public GameObject trail1;
    public GameObject trail2;

    private Animator anim1;
    private Animator anim2;
    private bool isLeaving;

    // Use this for initialization
    void Start () {
        //anim1.SetTrigger("Idle");
        //anim2.SetTrigger("Idle");
        trail1.SetActive(true);
        trail2.SetActive(false);
        isLeaving = false;
        anim1 = trail1.GetComponent<Animator>();
        anim2 = trail2.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!this.gameObject.GetComponent<ShipController>().getDockStatus() && isLeaving == false)
        {   
            anim1.SetTrigger("Move");
            anim2.SetTrigger("Move");
        }
        if(this.gameObject.GetComponent<ShipController>().getDockStatus() && isLeaving == false)
        {
            trail1.SetActive(false);
            isLeaving = true;
        }
        if(!this.gameObject.GetComponent<ShipController>().getDockStatus() && isLeaving == true)
        {
            trail2.SetActive(true);
            anim2.SetTrigger("Move");
            isLeaving = false;
        }
	}

}
