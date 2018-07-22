using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScen : MonoBehaviour {
    public String orient;
    public GameObject gameSettings;

    private static bool SettingsExist;

    // Use this for initialization
    void Start () {
        if (!SettingsExist)
        {
            SettingsExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (gameSettings.gameObject.GetComponent<SettingsGame>().isAndroid)
        {
            if (orient == "H")
            {
                Screen.orientation = ScreenOrientation.LandscapeLeft;
            }
            if (orient == "V")
            {
                Screen.orientation = ScreenOrientation.LandscapeRight;
            }
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
