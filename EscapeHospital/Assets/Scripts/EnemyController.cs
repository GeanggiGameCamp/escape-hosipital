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
  


    private Transform target;
    private bool isPatrol;

    

    void Start () {

        
        isPatrol = true;

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }
	
	
	void Update () {

        //PlayerFollower Script
        if (Vector2.Distance(transform.position, target.position) < 10)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            isPatrol = false;
        }


        if(Vector2.Distance(transform.position, target.position) > 10)
        {
            isPatrol = true;
        }

        if (isPatrol)
        {
            //Patrol Script
            if (isMovingRight)
            {
                transform.position = Vector2.MoveTowards(transform.position, rightLimit.position, Time.deltaTime * speed);

                ArriveRightLimit();

            }

            if (isMovingLeft)
            {
                transform.position = Vector2.MoveTowards(transform.position, leftLimit.position, Time.deltaTime * speed);

                ArriveLeftLImit();
            }
        }
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
