using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public Slider healthBar;
    public Text HPtext;
    public Text LVLtext;
    private PlayerHealthManager playerHealth;
    private PlayerStats thePS;

    public static bool UIexist;

	// Use this for initialization
	void Start () {

        playerHealth = FindObjectOfType<PlayerHealthManager>();

        thePS = FindObjectOfType<PlayerStats>();
        if (!UIexist)
        {
            UIexist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            if(SceneManager.GetActiveScene().name != "CustomizeScen"){
                Destroy(gameObject);
            }

        }

    }
	
	// Update is called once per frame
	void Update () {
        if(thePS == null){
			var clone = FindObjectOfType<PlayerStats>();
            thePS = clone;
			
		}else{
            LVLtext.text = "LVL: "+ thePS.currentLevel;  
        }
        if(playerHealth == null){
			var clone = FindObjectOfType<PlayerHealthManager>();
			playerHealth = clone;
		}else{
            healthBar.maxValue = playerHealth.playerMaxHealth;
            healthBar.value = playerHealth.playerCurrentHealth;
            HPtext.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
        }

    }
}
