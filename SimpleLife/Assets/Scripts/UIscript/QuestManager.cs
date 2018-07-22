using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {
	public QuestObject[] questArray;
	public DialogueManager theDM;

	public bool[] questCompleted;
	// Use this for initialization
	void Start () {
		questCompleted = new bool [questArray.Length];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowQuestText(string textQuest){
		theDM.dialogLines = new string[1];
		theDM.dialogLines[0] = textQuest;
		theDM.currentLine=0;
		theDM.showDialog();
	}
}
