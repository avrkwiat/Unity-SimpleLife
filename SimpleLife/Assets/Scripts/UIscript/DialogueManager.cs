using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public GameObject dBox;
	public Text dtext;

	public bool dialogActive;

	public string[] dialogLines;
	public int currentLine;
	private PlayerController thePlayer;
	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {

		if(dialogActive && (Input.GetButtonUp("Submit")||thePlayer.joyAction.Pressed)){
			if(currentLine >= dialogLines.Length){
				dBox.SetActive(false);
				dialogActive = false;
				currentLine = 0;

				thePlayer.isControllerEnable = true;
				
			}else{
				dtext.text = dialogLines[currentLine];
				
			}
			currentLine++;	
			thePlayer.joyAction.Pressed = false;
		}
		
		
	}
	public void showDialog(){
		thePlayer.isControllerEnable = false;
		thePlayer.myRigidbody.velocity = Vector2.zero;
		dialogActive = true;
		thePlayer.joyAction.Pressed = true;
		dBox.SetActive(true);
	}
	public void closeDialog(){
		thePlayer.isControllerEnable = true;
		NpcMovement.canMove = true;
		dialogActive = false;
		//currentLine = 0;
		thePlayer.joyAction.Pressed = false;
		dBox.SetActive(false);
	}

}
