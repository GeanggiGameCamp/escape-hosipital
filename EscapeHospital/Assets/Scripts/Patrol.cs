using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Patrol : MonoBehaviour{

	public float speed;
    public Transform leftLimit;
    public Transform rightLimit;
    public bool isMovingRight;
    public bool isMovingLeft;

   

    void Start()
    {

			
	}

	void Update(){

        if(isMovingRight)
        {
		    transform.position = Vector2.MoveTowards(transform.position, rightLimit.position, Time.deltaTime*speed);

            ArriveRightLimit();

        }

        if (isMovingLeft)
        {
		    transform.position = Vector2.MoveTowards(transform.position, leftLimit.position, Time.deltaTime*speed);

            ArriveLeftLImit();
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