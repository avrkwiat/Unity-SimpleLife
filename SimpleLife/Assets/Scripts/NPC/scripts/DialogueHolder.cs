using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHolder : MonoBehaviour {

	//public string dialogue;
	
	//public Text actionText;
	public string interaction;
	private DialogueManager dManager;

	public string[] dialogLines;

	// Use this for initialization
	void Start () {
		dManager = FindObjectOfType<DialogueManager>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other){
		
		if(other.gameObject.name == "player"){	

			if(Input.GetButtonUp("Submit")||other.GetComponent<PlayerController>().joyAction.Pressed){
					//dManager.showBox(dialogue);
					
					if(!dManager.dialogActive){
						NpcMovement.canMove = false;
						dManager.currentLine=0;
						dManager.dialogLines = dialogLines;
						
						dManager.showDialog();
					}
			}

		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name == "player"){	
			other.GetComponent<PlayerController>().joyAction.gameObject.SetActive(true);
			other.GetComponent<PlayerController>().actionText.text = interaction;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name == "player"){	
			other.GetComponent<PlayerController>().joyAction.gameObject.SetActive(false);
			other.GetComponent<PlayerController>().actionText.text = "Active Button";
		}
	}
}
