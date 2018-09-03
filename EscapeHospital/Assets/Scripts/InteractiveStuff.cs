using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveStuff : MonoBehaviour
{

    public GameObject interactiveStuff;
    public GameObject included;

    //private static bool _used = false;

    public void Start()
    {
        included.SetActive(false);

        if (FloorReset.boxIsOpen) this.gameObject.SetActive(false);
    }
 

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                interactiveStuff.SetActive(false);
                included.SetActive(true);
                FloorReset.boxIsOpen = true;
                //Destroy(this.gameObject);
            }
        }
    }

}
