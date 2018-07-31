using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour {
	public VolumeController[] vcObjects;
	public float maxVolumeLevel = 1.0f;
	public float currenSoundVolumeLevel = 1.0f;
	public float currenMusicVolumeLevel = 0f;

	private static bool VolumeManExists;

	// Use this for initialization
	void Start () {
		if (!VolumeManExists)
        {
            VolumeManExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {


	}

	public void VolumeChange(){
		vcObjects = FindObjectsOfType<VolumeController>();
		if(currenSoundVolumeLevel> maxVolumeLevel){
			currenSoundVolumeLevel = maxVolumeLevel;
		}
		for(int i = 0; i< vcObjects.Length;i++){
			if(vcObjects[i].isMusic){
				vcObjects[i].SetAudioLevel(currenMusicVolumeLevel);
			}else{
				vcObjects[i].SetAudioLevel(currenSoundVolumeLevel);
			}
			
		}
	}
}
