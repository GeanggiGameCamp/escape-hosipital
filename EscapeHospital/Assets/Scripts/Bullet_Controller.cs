using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour {

    public Vector2 speed;
    public float delay;

    private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("bullet hits the enemy");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    /*private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("bullet hits the enemy");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }*/



    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed;

        //Destroy bullet with delay
        Destroy(gameObject, delay);
		
	}
	
	
	void Update () {

        rb.velocity = speed;
		
	}

    
}
