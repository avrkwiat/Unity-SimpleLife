using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour {
	private QuestManager theQM;
	public int questNumber;
	public bool StartQuest;
	public bool EndQuest;
	public bool noNeedStartQuest;
	public GameObject floatNumber;
	public GameObject achivmentUnlock;
	private PlayerStats thePlayerStats;
	public int expToGive;
	// Use this for initialization
	void Start () {
		theQM = FindObjectOfType<QuestManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name == "player"){
			if(!theQM.questCompleted[questNumber]){
				if(StartQuest && !theQM.questArray[questNumber].gameObject.activeSelf){
					theQM.questArray[questNumber].gameObject.SetActive(true);
					theQM.questArray[questNumber].StartQuest();
				}
				if(noNeedStartQuest){
					if(EndQuest){
						var clone = (GameObject)Instantiate(floatNumber, new Vector3(other.transform.position.x, other.transform.position.y, -1), other.transform.rotation);
            			clone.GetComponent<FloatingNumbers>().moveNumber = expToGive;
						clone.GetComponent<FloatingNumbers>().text = "Exp: ";
						clone.GetComponent<FloatingNumbers>().displayNumber.color = Color.white;

						var clone1 = (GameObject)Instantiate(achivmentUnlock, new Vector3(other.transform.position.x, other.transform.position.y, -1), other.transform.rotation);
						//clone1.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width/4,Screen.height/8);
						//clone1.GetComponent<FloatingNumbers>().text = "You Found: ";
						clone1.GetComponent<AchivmentScriptUnlock>().text ="You unlock: " + theQM.questArray[questNumber].name;
						clone1.GetComponent<AchivmentScriptUnlock>().displayNumber.color = Color.black;

						thePlayerStats = FindObjectOfType<PlayerStats>();
						thePlayerStats.AddExperience(expToGive);
						
						theQM.questArray[questNumber].EndQuest();	
					}		
				}else{
					if(EndQuest&& theQM.questArray[questNumber].gameObject.activeSelf){
						var clone = (GameObject)Instantiate(floatNumber, new Vector3(other.transform.position.x, other.transform.position.y, -1), other.transform.rotation);
            			clone.GetComponent<FloatingNumbers>().moveNumber = expToGive;
						clone.GetComponent<FloatingNumbers>().text = "Exp: ";
						clone.GetComponent<FloatingNumbers>().displayNumber.color = Color.white;

						

						thePlayerStats = FindObjectOfType<PlayerStats>();
						thePlayerStats.AddExperience(expToGive);

						theQM.questArray[questNumber].EndQuest();	
					}	
				}
			}
		}
	}
}
