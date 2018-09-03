using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCapsule : MonoBehaviour {

    public GameObject panel;
    public Text text;

    //private static bool _used = false;

    private void Start()
    {
        if(FloorReset.capsuleIsUsed) this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D others)
    {

        if (others.gameObject.CompareTag("Player"))
        {
            float updateTime = PlayerPrefs.GetFloat("PlayerLifeTime")+30f;
            PlayerPrefs.SetFloat("PlayerLifeTime", updateTime);
            panel.SetActive(true);
            StartCoroutine(OnPanel());
            PlayerPrefs.Save();

            FloorReset.capsuleIsUsed = true;
        }

    }

    IEnumerator OnPanel()
    {
        text.text = "캡슐약을 얻었다. 플레이어 수명이 늘어납니다.";
        yield return new WaitForSeconds(0.5f);
        panel.SetActive(false);
        Destroy(this.gameObject);
        //this.gameObject.SetActive(false);
    }
}
