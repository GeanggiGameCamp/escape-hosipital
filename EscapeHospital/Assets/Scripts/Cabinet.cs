using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cabinet : MonoBehaviour
{

    public GameObject player;
    public GameObject panel;
    public Text text;

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
                player.GetComponent<PlayerController>().enabled = true;
                playerIsActive = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            panel.SetActive(true);
            StartCoroutine(OnPanel());
        }
    }

    IEnumerator OnPanel()
    {
        text.text = "캐비닛이다. Space를 이용해서 적의 눈을 피해 숨어있을 수 있다.";
        yield return new WaitForSeconds(1.0f);
        panel.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerIsActive)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    player.SetActive(false);
                    player.GetComponent<PlayerController>().enabled = false;
                    playerIsActive = false;
                    Debug.Log(playerIsActive);
                }
            }
        }
    }
}