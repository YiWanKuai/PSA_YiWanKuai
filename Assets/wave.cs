using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave : MonoBehaviour {


	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
		anim.SetTrigger("Move");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
