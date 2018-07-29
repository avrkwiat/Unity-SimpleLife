using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour {
	public VolumeController[] vcObjects;
	public float maxVolumeLevel = 1.0f;
	public float currenVolumeLevel;
	// Use this for initialization
	void Start () {
		vcObjects = FindObjectsOfType<VolumeController>();
		if(currenVolumeLevel> maxVolumeLevel){
			currenVolumeLevel = maxVolumeLevel;
		}
		for(int i = 0; i< vcObjects.Length;i++){
			vcObjects[i].SetAudioLevel(currenVolumeLevel);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
