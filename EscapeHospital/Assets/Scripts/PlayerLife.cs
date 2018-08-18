using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour {
    private const string Format = "f0";
    public Text Timer;
    public Text gameOver;
    public float playerLifeTime;
    public GameObject item;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
            playerLifeTime += 10;
        }
    }

    // Use this for initialization
    void Start () {

        gameOver.enabled = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        playerLifeTime -= Time.deltaTime;
        Timer.text = playerLifeTime.ToString(Format);
        print (playerLifeTime);
        if(playerLifeTime <= 0)
        {
            playerLifeTime = 0;
            print(playerLifeTime);
            gameOver.enabled = true;
        }

        
		
	}
}
