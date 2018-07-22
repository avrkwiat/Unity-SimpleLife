using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovement : MonoBehaviour {
	public float moveSpeed;
	private Vector2 minWalkPoint;
	private Vector2 maxWalkPoint;
	private Rigidbody2D myRigidBody;
	public bool isWalking;
	public float walkTime;
	private float walkCounter;
	public float waitTime;
	private float waitCounter;

	private int walkDirection;
	public Collider2D walkZone;
	private bool hasWalkZone;
	public static bool canMove;
	private DialogueManager theDM;
	private Animator anim;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();

		theDM = FindObjectOfType<DialogueManager>();

		waitCounter = waitTime;
		walkCounter = walkTime;

		ChoiceDirection();
		if(walkZone != null){
			minWalkPoint = walkZone.bounds.min;
			maxWalkPoint = walkZone.bounds.max;
			hasWalkZone = true;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!theDM.dialogActive){
			canMove = true;
		}
		if(!canMove){
			myRigidBody.velocity = Vector2.zero;
			isWalking = false;
			waitCounter = waitTime;
			return;
		}
		if(isWalking){
			walkCounter -= Time.deltaTime;
			anim.SetBool("PlayerMoving", isWalking);
			switch(walkDirection){
				case 0 : 
					myRigidBody.velocity = new Vector2(0,moveSpeed);
					anim.SetFloat("LastMoveY", 1);
					anim.SetFloat("LastMoveX", 0);
					anim.SetFloat("MoveX", 0);
                    anim.SetFloat("MoveY", 1);
					if(hasWalkZone && transform.position.y > maxWalkPoint.y){
						isWalking = false;
						waitCounter = waitTime;
					}
				break;
				case 1 : 
					myRigidBody.velocity = new Vector2(moveSpeed,0);
					anim.SetFloat("LastMoveX", 1);
					anim.SetFloat("LastMoveY", 0);
					anim.SetFloat("MoveX", 1);
                    anim.SetFloat("MoveY", 0);
					if(hasWalkZone && transform.position.x > maxWalkPoint.x){
						isWalking = false;
						waitCounter = waitTime;
					}
				break;
				case 2 : 
					myRigidBody.velocity = new Vector2(0,-moveSpeed);
					anim.SetFloat("LastMoveY", -1);
					anim.SetFloat("LastMoveX", 0);
					anim.SetFloat("MoveX", 0);
                    anim.SetFloat("MoveY", -1);
					if(hasWalkZone && transform.position.y < minWalkPoint.y){
						isWalking = false;
						waitCounter = waitTime;
					}
				break;
				case 3 : 
					myRigidBody.velocity = new Vector2(-moveSpeed,0);
					anim.SetFloat("LastMoveX", -1);
					anim.SetFloat("LastMoveY", 0);
					anim.SetFloat("MoveX", -1);
                    anim.SetFloat("MoveY", 0);
					if(hasWalkZone && transform.position.x < minWalkPoint.x){
						isWalking = false;
						waitCounter = waitTime;
					}
				break;
				
            
            
			}
			
			if(walkCounter < 0){
				isWalking = false;
				
				waitCounter = waitTime;
			}
		}else{
			waitCounter-=Time.deltaTime;
			myRigidBody.velocity = Vector2.zero;

			if(waitCounter < 0){
				ChoiceDirection();
			}
		}
		anim.SetBool("PlayerMoving", isWalking);
	}

	public void ChoiceDirection(){
		walkDirection = Random.Range(0,4);
		isWalking = true;
		walkCounter = walkTime;
	}
}
