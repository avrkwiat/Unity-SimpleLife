using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {
	public static bool mcExists;
	public AudioSource[] musicTracker;
	public int currenTrack;
	public bool musicCanPlay;

	// Use this for initialization
	void Start () {
		if (!mcExists)
        {
            mcExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(musicCanPlay){
			if(!musicTracker[currenTrack].isPlaying){
				musicTracker[currenTrack].Play();
			}
		}else{
			musicTracker[currenTrack].Stop();
		}
	}

	public void SwitchTrack(int newTrack){
		musicTracker[currenTrack].Stop();
		currenTrack = newTrack;
		musicTracker[currenTrack].Play();
	}
}
