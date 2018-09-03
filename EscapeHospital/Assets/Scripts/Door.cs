using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    public GameObject panel;
    public Text text;
    public string sceneName;
    public GameObject Player;

    private static bool _doorIsOpen = false;

    private void OnTriggerEnter2D(Collider2D others)
    {

        if (others.gameObject.CompareTag("Player"))
        {
            panel.SetActive(true);
            Debug.Log("PlayerEnter");
            StartCoroutine(OnPanel());
        }
    }

    private void OnTriggerStay2D(Collider2D others)
    {
        if(others.gameObject.CompareTag("Player"))
        {
            if (_doorIsOpen)
            {
                if (Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(sceneName);
                PlayerPrefs.SetFloat("PosX", Player.transform.position.x);
                PlayerPrefs.SetFloat("PosY", Player.transform.position.y);
            }
        }
    }

    IEnumerator OnPanel()
    {
        if(_doorIsOpen)
        {
            text.text = "문이 열려있다.";
            yield return new WaitForSeconds(1.0f);
            panel.SetActive(false);
        }

        else if (PlayerPrefs.GetInt("keyCount") >= 1 && !_doorIsOpen)
        {
            int updateKey = PlayerPrefs.GetInt("keyCount");
            PlayerPrefs.SetInt("keyCount", --updateKey);
            _doorIsOpen = true;
            text.text = "문이 열렸다.";
            yield return new WaitForSeconds(1.0f);
            panel.SetActive(false);
        }

        else 
        {
            text.text = "문이 잠겨있다.";
            yield return new WaitForSeconds(1.0f);
            panel.SetActive(false);
        }
    }
}
