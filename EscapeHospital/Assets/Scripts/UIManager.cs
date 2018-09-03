using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour

{
    public string message;
    public GameObject panel;
    public Text panelText;
    
    private void Start()
    {
        panelText.text = message;
        if(FloorReset.officeKeyIsGotten) GameObject.Find("열쇠").GetComponent<SpriteRenderer>().enabled = false;

    }

    public void PrintMessage()
    {
        panelText.text = message;
        panel.SetActive(true);
        StartCoroutine(OffMessage());
    }

    IEnumerator OffMessage()
    {
        yield return new WaitForSeconds(1.0f);
        panel.SetActive(false);
    }

    public void GetKey()
    {
        if (!FloorReset.keyIsGotten)
        {
            int updateKey = PlayerPrefs.GetInt("keyCount");
            PlayerPrefs.SetInt("keyCount", ++updateKey);
            FloorReset.keyIsGotten = true;
        }

        else if(FloorReset.keyIsGotten)
        {
            panelText.text = "열쇠는 이미 얻었다.";
        }
    }

    public void GetOfficeKey()
    {
        if (!FloorReset.officeKeyIsGotten)
        {
            int updateKey = PlayerPrefs.GetInt("keyCount");
            PlayerPrefs.SetInt("keyCount", ++updateKey);
            FloorReset.officeKeyIsGotten = true;
            GameObject.Find("열쇠").GetComponent<SpriteRenderer>().enabled = false;
        }

        else if (FloorReset.officeKeyIsGotten)
        {
            panelText.text = "열쇠는 이미 얻었다.";
        }
    }

    public void GetDoc()
    {
        if (!FloorReset.docIsGotten)
        {
            int updateDoc = PlayerPrefs.GetInt("DocCount");
            PlayerPrefs.SetInt("DocCount", ++updateDoc);
            FloorReset.docIsGotten = true;
        }

        else if (FloorReset.docIsGotten)
        {
            panelText.text = "문서는 이미 얻었다.";
        }
    }

    public void GetCapsule()
    {
        if (!FloorReset.capsuleIsGotten)
        {
            float updateTime = PlayerPrefs.GetFloat("PlayerLifeTime") + 30f;
            PlayerPrefs.SetFloat("PlayerLifeTime", updateTime);
            PlayerPrefs.Save();
            FloorReset.capsuleIsGotten = true;
        }

        else if (FloorReset.capsuleIsGotten)
        {
            panelText.text = "캡슐은 이미 얻었다.";
        }
    }

    public void GetCapsule2()
    {
        if (!FloorReset.capsuleIsGotten2)
        {
            float updateTime = PlayerPrefs.GetFloat("PlayerLifeTime") + 30f;
            PlayerPrefs.SetFloat("PlayerLifeTime", updateTime);
            PlayerPrefs.Save();
            FloorReset.capsuleIsGotten2 = true;
        }

        else if (FloorReset.capsuleIsGotten2)
        {
            panelText.text = "캡슐은 이미 얻었다.";
        }
    }
}
