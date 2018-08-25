using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveStuff : MonoBehaviour
{

    public GameObject interactiveStuff;
    public GameObject included;

    public void Start()
    {
        included.SetActive(false);
    }
 

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                interactiveStuff.SetActive(false);
                included.SetActive(true);
            }
        }
    }

}
