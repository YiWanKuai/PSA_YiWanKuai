using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoBehaviour : MonoBehaviour {

    public GameManager gm;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        Debug.Log("Im in");
        if(gm.getCargo() != null)
        {
            Debug.Log("iterator works");
            spawn();
        }
        gm.resetCargo();
    }

    void spawn()
    {
        GameObject currCargo = Instantiate(gm.getCargo(), this.gameObject.transform.position, this.transform.rotation, transform);
    }
}
