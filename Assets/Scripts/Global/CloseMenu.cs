using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour {

	public void Close() {
        Destroy(this.transform.parent.gameObject);
    }
}
