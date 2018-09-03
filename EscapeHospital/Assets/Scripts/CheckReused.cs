using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckReused : MonoBehaviour {

    public GameObject panel;
    public Text text;

    private void Start()
    {
        if (FloorReset.gunIsGotten)
            this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D others)
    {
        if (others.gameObject.CompareTag("Player"))
        {
            text.text = "총을 주웠다. 이 층에서 사용가능하다.";
            panel.SetActive(true);
            FloorReset.gunIsGotten = true;
        }
    }
}
