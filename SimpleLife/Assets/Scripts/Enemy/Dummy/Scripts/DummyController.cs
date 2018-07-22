using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DummyController : MonoBehaviour {
    public float moveSpeed;


    private Rigidbody2D myRigidbody;
    private bool moving;

    public float timeBeetwenMove;
    private float timeBeetwenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;

    private Vector3 moveDirection;
    private GameObject thePlayer;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();

        //timeBeetwenMoveCounter = timeBeetwenMove;
        //timeToMoveCounter = timeToMove;
        timeBeetwenMoveCounter = Random.Range(timeBeetwenMove*0.75f, timeBeetwenMove*1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
    }
	
	// Update is called once per frame
	void Update () {
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = moveDirection;

            if (timeToMoveCounter < 0f)
            {
                moving = false;
                //timeBeetwenMoveCounter = timeBeetwenMove;
                timeBeetwenMoveCounter = Random.Range(timeBeetwenMove * 0.75f, timeBeetwenMove * 1.25f);
            }
        }
        else
        {
            timeBeetwenMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;

            if (timeBeetwenMoveCounter < 0f)
            {
                moving = true;
                //timeToMoveCounter = timeToMove;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);

                moveDirection = new Vector3(Random.Range(-1f,1f)*moveSpeed, Random.Range(-1f, 1f) * moveSpeed,0f);
            }
        }


	}


}
