using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCollider : MonoBehaviour {

    public Text testText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            testText.enabled = true;
        }
    }

    // Use this for initialization
    void Start () {
        testText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
