using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorReset : MonoBehaviour
{
    public static bool keyIsUsed = false;
    public static bool docIsGotten = false;
    public static bool keyIsGotten = false;
    public static bool capsuleIsGotten = false;
    public static bool capsuleIsGotten2 = false;
    public static bool officeKeyIsGotten = false;
    public bool isStartMenu;

    public static bool gunIsGotten = false;
    public static bool capsuleIsUsed = false;
    public static bool boxIsOpen = false;
    public static bool shelfIsUsed = false;

    private static int _floorNum = 3;

    private void Start()
    {
        if(isStartMenu)
        {
            _floorNum = 3;
        }

        else if (!isStartMenu)
        {
            _floorNum--;
            SceneManager.LoadScene("Floor" + _floorNum);
        }

        PlayerPrefs.SetInt("playerHasGun", 0);
        keyIsUsed = false;
        docIsGotten = false;
        keyIsGotten = false;
        capsuleIsGotten = false;
        capsuleIsGotten2 = false;
        officeKeyIsGotten = false;

        gunIsGotten = false;
        capsuleIsUsed = false;
        boxIsOpen = false;
        shelfIsUsed = false;



        
    }

}
