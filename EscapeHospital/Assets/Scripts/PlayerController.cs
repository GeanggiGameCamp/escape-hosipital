using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class PlayerController : MonoBehaviour {

    Rigidbody2D playerRigidBody;
    CapsuleCollider2D playerCollider;

    public Text scoreText;
    public float maxSpeed = 100f;

    private float Score = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            Score++;
        }
    }
    private float hSpeed = 0f;
    private bool facingRight = true;
    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        //playerCollider = GetComponent<CapsuleCollider>();
    }

    
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    

    private void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 50.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Translate(x, 0, 0);

        //Score Text Script

        scoreText.text = "점수 : " + Score.ToString("f0");


    }

    void ShowFailText()
    {

    }
}
