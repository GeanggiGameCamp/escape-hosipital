using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelf : MonoBehaviour {

    public GameObject included;

    //private static bool _used = false;

    public void Start()
    {
        included.SetActive(false);

        if (FloorReset.shelfIsUsed) this.gameObject.SetActive(false);
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //interactiveStuff.SetActive(false);
                included.SetActive(true);
                FloorReset.shelfIsUsed= true;
            }
        }
    }
}
