using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
	public int currentLevel;
	public int currentExp;
	public int[] toLevelUp;

	public int currentStr;
	public int currentDex;
	public int currentScout;
	public int currentMeditation;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(currentExp >= toLevelUp[currentLevel]){
			LvLUp();
		}
	}

	public void AddExperience(int expToGive){
		currentExp+=expToGive;
	}
	public void LvLUp(){
		currentLevel++;
	}
}
