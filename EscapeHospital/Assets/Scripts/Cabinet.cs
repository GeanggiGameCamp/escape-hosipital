using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour {

    bool active;
    public GameObject player;

	// Use this for initialization
	void Start () {
        active = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(active)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //player.enabled= false;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        active = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        active = false;
    }

}
