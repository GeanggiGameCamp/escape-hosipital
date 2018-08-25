using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class PlayerController : MonoBehaviour {

    public float maxSpeed = 100f;
    public Text Timer;
    public Text gameOver;
    public float playerLifeTime;
    public GameObject item;
    public GameObject leftBullet, rightBullet;

    private Rigidbody2D playerRigidBody;
    private CapsuleCollider2D playerCollider;
    private const string Format = "f0";
    private Transform firePos;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Collect Items
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("TimeCapsule"))
        {
            other.gameObject.SetActive(false);
            playerLifeTime += 10;
        }
        if (other.gameObject.CompareTag("Gun"))
        {
            other.gameObject.SetActive(false);
            PlayerPrefs.SetInt("playerHasGun", 1);

        }

        //Hit Enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            gameOver.enabled = true;
            Timer.enabled = false;

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
        firePos = transform.Find("firePos");
        

    }
	
	// Update is called once per frame
	void Update () {


		
	}

    bool ToBool(int PlayerPref)
    {
        if (PlayerPref == 1) return true;
        else return false;
    }

    private void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 50.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Translate(x, 0, 0);
        
        //Player Life Time Script
        playerLifeTime -= Time.deltaTime;
        Timer.text = "남은시간 : " + playerLifeTime.ToString(Format);
        //print(playerLifeTime);
        if (playerLifeTime <= 0)
        {
            playerLifeTime = 0;
            print(playerLifeTime);
            gameOver.enabled = true;
            Timer.enabled = false;
        }

        
        //Fire Bullet
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (ToBool(PlayerPrefs.GetInt("playerHasGun")))
            Fire();

        }

    }

    private void Fire()
    {
        Instantiate(rightBullet, firePos.position, Quaternion.identity);
    }

    
}
