using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Document : MonoBehaviour {

    public GameObject panel;
    public Text text;
    // Use this for initialization
    void Start () {
		if(FloorReset.docIsGotten) this.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D others)
    {

        if (others.gameObject.CompareTag("Player"))
        {
            int updateDoc = PlayerPrefs.GetInt("DocCount");
            PlayerPrefs.SetInt("DocCount", ++updateDoc);
            panel.SetActive(true);
            StartCoroutine(OnPanel());
            FloorReset.keyIsUsed = true;
        }

    }

    IEnumerator OnPanel()
    {
        text.text = "문서를 획득했다.";
        yield return new WaitForSeconds(0.5f);
        panel.SetActive(false);
        Destroy(this.gameObject);
        //this.gameObject.SetActive(false);
    }
 
}
