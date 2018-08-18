using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cabinet : MonoBehaviour
{

    public GameObject player;

    bool playerIsActive;

    // Use this for initialization
    void Start()
    {
        playerIsActive = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!playerIsActive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.SetActive(true);
                Debug.Log("player get out of cabinet");
                playerIsActive = true;
            }
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (playerIsActive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.SetActive(false);
                Debug.Log("player is hiding");
                playerIsActive = false;
                Debug.Log(playerIsActive);
            }
        }
    }
}