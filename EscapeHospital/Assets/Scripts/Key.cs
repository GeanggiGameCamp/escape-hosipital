using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public GameObject panel;
    public Text text;

    private void Start()
    {
        if (FloorReset.keyIsUsed) this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D others)
    {

        if (others.gameObject.CompareTag("Player"))
        {
            int updateKey = PlayerPrefs.GetInt("keyCount");
            PlayerPrefs.SetInt("keyCount", ++updateKey);
            panel.SetActive(true);
            StartCoroutine(OnPanel());
            FloorReset.keyIsUsed = true;
        }

    }

    IEnumerator OnPanel()
    {
        text.text = "열쇠를 얻었다";
        yield return new WaitForSeconds(1.0f);
        panel.SetActive(false);
        Destroy(this.gameObject);
        this.gameObject.SetActive(false);
    }

}
