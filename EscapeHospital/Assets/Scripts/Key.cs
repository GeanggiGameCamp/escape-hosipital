using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public GameObject player;

    bool KeyIsActive;

    // Use this for initialization
    private void Start()
    {
        KeyIsActive = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (KeyIsActive)
        {
        }
    }
}
