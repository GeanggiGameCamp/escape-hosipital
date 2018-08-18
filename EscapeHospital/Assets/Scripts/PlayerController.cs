using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class PlayerController : MonoBehaviour {

    Rigidbody2D playerRigidBody;
    CapsuleCollider2D playerCollider;

    public float maxSpeed = 100f;
    public Text Timer;
    public Text gameOver;
    public float playerLifeTime;
    public GameObject item;

    private const string Format = "f0";
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
            playerLifeTime += 10;
        }
    }
    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        //playerCollider = GetComponent<CapsuleCollider>();
    }

    // Use this for initialization
    void Start () {
        gameOver.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    

    private void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 50.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Translate(x, 0, 0);
        
        //Player Life Time Script
        playerLifeTime -= Time.deltaTime;
        Timer.text = "남은시간 : " + playerLifeTime.ToString(Format);
        print(playerLifeTime);
        if (playerLifeTime <= 0)
        {
            playerLifeTime = 0;
            print(playerLifeTime);
            gameOver.enabled = true;
        }
    }

    void ShowFailText()
    {

    }
}
