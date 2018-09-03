using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Text Timer;
    public Text KeyNum;
    public Text DocNum;
    public Text gameOver;

    private const string Format = "f0";
    private float playerLifeTime;

    // Use this for initialization
    void Start () {
        Timer.enabled = true;
        playerLifeTime = PlayerPrefs.GetFloat("PlayerLifeTime");
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void FixedUpdate()
    {
        playerLifeTime = PlayerPrefs.GetFloat("PlayerLifeTime");
        playerLifeTime -= Time.deltaTime;
        PlayerPrefs.SetFloat("PlayerLifeTime", playerLifeTime);
        Timer.text = "남은시간 : " + PlayerPrefs.GetFloat("PlayerLifeTime").ToString(Format);

        if (playerLifeTime <= 0)
        {
            playerLifeTime = 0;
            gameOver.enabled = true;
            Timer.enabled = false;
            StartCoroutine(GoToMainMenu());
        }

        
        KeyNum.text = "열쇠 개수 : " + PlayerPrefs.GetInt("keyCount").ToString();
        DocNum.text = "문서 개수 : " + PlayerPrefs.GetInt("DocCount").ToString();

        PlayerPrefs.Save();
    }

    IEnumerator GoToMainMenu()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Main");
    }
}
