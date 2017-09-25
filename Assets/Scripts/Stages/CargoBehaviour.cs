using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoBehaviour : MonoBehaviour {

    public GameManager gm;
    private int currCount;
	// Use this for initialization
	void Start () {
        currCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if(gm.getCargo() != null && currCount < 10)
        {
            spawn();
            gm.resetCargo();
            shiftSP();
        }
        
    }

    void spawn()
    {
        GameObject currCargo = Instantiate(gm.getCargo(), this.gameObject.transform.GetChild(0).transform.position, this.transform.GetChild(0).transform.rotation, this.transform);
        currCargo.GetComponent<SpriteRenderer>().sortingOrder = currCount;
        currCount++;
    }

    void shiftSP()
    {
        this.gameObject.transform.GetChild(0).transform.position = new Vector3(this.gameObject.transform.GetChild(0).transform.position.x, this.gameObject.transform.GetChild(0).transform.position.y + 0.21f, this.gameObject.transform.GetChild(0).transform.position.z);
    }
}
