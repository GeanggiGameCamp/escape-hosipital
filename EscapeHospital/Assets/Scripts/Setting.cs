using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour {


	// Use this for initialization
	void Awake () {
        PlayerPrefs.SetInt("playerHasGun", 0);
        PlayerPrefs.SetInt("keyCount", 0);
        PlayerPrefs.SetFloat("PlayerLifeTime", 100f);
        PlayerPrefs.SetInt("DocCount", 0);
        PlayerPrefs.SetInt("FirstSet", 1);

        PlayerPrefs.SetFloat("PosX", -8f);
        PlayerPrefs.SetFloat("PosY", -3f);

        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
