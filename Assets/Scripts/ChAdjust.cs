using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChAdjust : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void CHScale(float val)
    {

        this.transform.localScale = new Vector3(val, val, 1);
        ResourceHandler.chScale = val;
    }
}
