using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGAdjust : MonoBehaviour {

    Vector3 pos;
    [HideInInspector] public float speed = 0.05f; 

	// Use this for initialization
	void Start () {
        speed = ResourceHandler.bgSpeed;
	}

    public void BGScale(float val)
    {

        this.transform.localScale = new Vector3(val, val, 1);
        ResourceHandler.bgScale = val;
    }

    public void BGSpeed(float val)
    {
        speed = val;
        ResourceHandler.bgSpeed = val;
    }

    private void Update()
    {
        if (ResourceHandler.isPlaying == true)
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        //..input arrowkeys to adjust Background
        if (Input.anyKey && ResourceHandler.isPlaying == false)
        {
            if (Input.GetKey("up"))
            {
                pos = gameObject.transform.position;
                pos.y += 0.01f;
                gameObject.transform.position = pos;
            }

            if (Input.GetKey("down"))
            {
                pos = gameObject.transform.position;
                pos.y -= 0.01f;
                gameObject.transform.position = pos;
            }

            if (Input.GetKey("left"))
            {
                pos = gameObject.transform.position;
                pos.x -= 0.01f;
                gameObject.transform.position = pos;
            }

            if (Input.GetKey("right"))
            {
                pos = gameObject.transform.position;
                pos.x += 0.01f;
                gameObject.transform.position = pos;
            }
            ResourceHandler.bgPos = gameObject.transform.position;
        }
    }
}
