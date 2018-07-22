using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadNewArea : MonoBehaviour {
    public string leveToLoad;
    public string exitPoint;
    private loadingScript theLoadingScript;

	// Use this for initialization
	void Start () {
        theLoadingScript = GetComponent<loadingScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "player")
        {
            //var clone = other.GetComponentInParent<snowEffect>();
            if(other.GetComponent<PlayerController>().playerDie == false)
            {
                //diasable effect
                var theObject = GameObject.Find("Snow(Clone)");
                if (theObject != null){
                    Destroy(theObject);
                }
                other.GetComponent<PlayerController>().joyAction.gameObject.SetActive(false);
                other.GetComponent<PlayerController>().startPoint = exitPoint;

                other.GetComponent<PlayerController>().activeScene = leveToLoad;
                
                theLoadingScript.loading.SetActive(true);
		        StartCoroutine(theLoadingScript.LoadLevelWithBar(leveToLoad));
                //SceneManager.LoadScene(leveToLoad, LoadSceneMode.Single);
                

            }
            
        }
        
    }
}
