using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour {
	private AudioSource theAudio;
	private float audioLevel;
	public float defaultAudio;
	public bool isMusic;

	// Use this for initialization
	void Start () {
		theAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetAudioLevel(float volume){
		if(theAudio == null){
			theAudio = GetComponent<AudioSource>();	
		}
		audioLevel = defaultAudio * volume;
		theAudio.volume = audioLevel;
	}
}
