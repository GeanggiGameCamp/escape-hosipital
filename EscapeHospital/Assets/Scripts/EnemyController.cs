using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

    public float speed;
    public Transform leftLimit;
    public Transform rightLimit;
    public bool isMovingRight;
    public bool isMovingLeft;
    public GameObject player;
  

    private Transform target;
    private bool isPatrol;
    //private bool _isdead = false;
    

    void Start () {

        //if (_isdead) this.gameObject.SetActive(false);
        
        isPatrol = true;

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }
	
	
	void Update () {


        //PlayerFollower Script
        if (Vector2.Distance(transform.position, target.position) < 10 && player.activeSelf)
        {
            if(this.transform.position.x - target.position.x >= 0)
                this.GetComponent<SpriteRenderer>().flipX = false;
            else if(this.transform.position.x - target.position.x < 0)
                this.GetComponent<SpriteRenderer>().flipX = true;

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            isPatrol = false;
        }


        if(Vector2.Distance(transform.position, target.position) > 10 || !player.activeSelf)
        {
            isPatrol = true;
        }

        if (isPatrol)
        {
            //Patrol Script
            if (isMovingRight)
            {
                transform.position = Vector2.MoveTowards(transform.position, rightLimit.position, Time.deltaTime * speed);
                this.GetComponent<SpriteRenderer>().flipX = true;
                ArriveRightLimit();

            }

            if (isMovingLeft)
            {
                transform.position = Vector2.MoveTowards(transform.position, leftLimit.position, Time.deltaTime * speed);
                this.GetComponent<SpriteRenderer>().flipX = false;
                ArriveLeftLImit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D others)
    {
        if (others.gameObject.CompareTag("Bullet")) Destroy(this.gameObject);
    }

    void ArriveRightLimit()
    {
        if (Vector2.Distance(transform.position, rightLimit.position) < 0.2f)
        {
            isMovingRight = false;
            isMovingLeft = true;
        }

    }

    void ArriveLeftLImit()
    {
        if (Vector2.Distance(transform.position, leftLimit.position) < 0.2f)
        {
            isMovingLeft = false;
            isMovingRight = true;
        }

    }
}
