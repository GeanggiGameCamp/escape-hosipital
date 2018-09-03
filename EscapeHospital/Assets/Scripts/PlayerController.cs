using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float maxSpeed;
    public Text gameOver;
    public GameObject bullet;
    public float time;
    public GameObject player;

    private const string Format = "f0";
    private float playerLifeTime;
    private Transform firePosR;
    private Transform firePosL;
    private int updateKey;
    private bool _fireRight = true;
    private float _speed = 10.0f;

    // Use this for initialization
    void Start()
    {
        gameOver.enabled = false;
        firePosR = transform.Find("firePosR");
        firePosL = transform.Find("firePosL");
        player.transform.position = new Vector3(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY"), this.transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Collect Items
        
        if (other.gameObject.CompareTag("Gun"))
        {
            other.gameObject.SetActive(false);
            PlayerPrefs.SetInt("playerHasGun", 1);

        }        

        //Hit Enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameOver.enabled = true;
            _speed = 0.0f;
            StartCoroutine(GoToMainMenu());
        }
    }

    IEnumerator GoToMainMenu()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Main");
        this.gameObject.SetActive(false);
    }

    bool ToBool(int PlayerPref)
    {
        if (PlayerPref == 0) return false;
        else return true;
    }

    private void FixedUpdate()
    {

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * _speed;
        if(Input.GetAxis("Horizontal")>0)
        {
            _fireRight = true;
            this.GetComponent<SpriteRenderer>().flipX = true;
        }

        else if(Input.GetAxis("Horizontal")<0)
        {
            _fireRight = false;
            this.GetComponent<SpriteRenderer>().flipX = false;
        }

        transform.Translate(x, 0, 0);

        
        //Fire Bullet
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (ToBool(PlayerPrefs.GetInt("playerHasGun")))
            Fire();

        }

        float f = PlayerPrefs.GetFloat("PosX");
        Debug.Log(f);

    }

    private void Fire()
    {
        if (_fireRight)
        {
            bullet.GetComponent<SpriteRenderer>().flipX = true;
            bullet.GetComponent<Bullet_Controller>().speed = new Vector2(7.0f, 0.0f);
            Instantiate(bullet, firePosR.position, Quaternion.identity);
        }

        else
        {
            bullet.GetComponent<SpriteRenderer>().flipX = false;
            bullet.GetComponent<Bullet_Controller>().speed = new Vector2(-7.0f, 0.0f);
            Instantiate(bullet, firePosL.position, Quaternion.identity);
        }
    }
}
