using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("playerHasGun", 0);
        PlayerPrefs.SetInt("keyCount", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
