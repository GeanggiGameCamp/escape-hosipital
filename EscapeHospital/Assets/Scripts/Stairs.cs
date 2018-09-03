using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stairs : MonoBehaviour {

    public string targetSpace;
    public bool isLastScene = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(isLastScene)
            {
                if (PlayerPrefs.GetInt("DocCount") == 3) SceneManager.LoadScene("Ending1");
                else SceneManager.LoadScene("Ending2");
            }
            PlayerPrefs.SetFloat("PosX", -8f);
            PlayerPrefs.SetFloat("PosY", -3f);
            SceneManager.LoadScene(targetSpace);
        }
    }

}
