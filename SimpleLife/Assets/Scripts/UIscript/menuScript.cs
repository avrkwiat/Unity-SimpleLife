using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuScript : MonoBehaviour {
	public string mainGameScen;
	public static bool isGameRun;
	public static bool isMenuRun;
	private AsyncOperation async;
	private GameObject thePlayer;
	private GameObject theUI;

	public loadingScript theLoadingScript;

	void Start (){
		theLoadingScript = GetComponent<loadingScript>();
		theLoadingScript.loading.SetActive(false);
	}

	public void ContinueGame(){
		thePlayer = GameObject.FindGameObjectWithTag("Player");
		if(isGameRun){
			SceneManager.SetActiveScene(SceneManager.GetSceneByName(thePlayer.GetComponent<PlayerController>().activeScene));
			isMenuRun = false;
			SceneManager.UnloadScene(SceneManager.GetSceneByName("menuScen"));
		}
	}
	public void StartGame(){
		//find old player and destroy
		
		thePlayer = GameObject.FindGameObjectWithTag("Player");
		if(thePlayer!=null){
			Destroy(thePlayer);	
		}
		//find old UIcanvas and destroy
		theUI = GameObject.FindGameObjectWithTag("UItag");
		if(theUI!=null){
			Destroy(theUI);
		}

		isGameRun = true;
		isMenuRun = false;
		
		var clone1 = FindObjectOfType<CameraControler>();
		clone1.GetComponent<Camera>().orthographicSize = 2.0f;

		clone1.offset = new Vector2(0.77f,-0.33f);
		theLoadingScript.loading.SetActive(true);
		StartCoroutine(theLoadingScript.LoadLevelWithBar(mainGameScen));

		
	}

	public void QuiteGame(){
		if (Application.platform == RuntimePlatform.Android)
             {
                 AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                 activity.Call<bool>("moveTaskToBack", false);
             }
             else
             {
                 Application.Quit();
             }
		
	}
}
