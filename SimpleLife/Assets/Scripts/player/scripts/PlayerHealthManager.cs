using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour {
    public int playerMaxHealth;
    public int playerCurrentHealth;

    public float waitForReload;
    private float waitForReloadCurrent;
    private bool reloading;

    // Use this for initialization
    void Start () {
        playerCurrentHealth = playerMaxHealth;
        waitForReloadCurrent = waitForReload;
    }
	
	// Update is called once per frame
	void Update () {
        if (playerCurrentHealth < 0)
        {
            //gameObject.SetActive(false);
            reloading = true;
        }
        if (reloading)
        {
            //waitForReloadCurrent -= Time.deltaTime;
            gameObject.GetComponent<PlayerController>().playerDie = true;
            gameObject.GetComponent<PlayerController>().isControllerEnable = false;
            gameObject.GetComponent<PlayerController>().myRigidbody.velocity = new Vector2(0, 0);

            /* 
            if (waitForReloadCurrent < 0)
            {
                reloading = false;

                gameObject.SetActive(true);
                gameObject.GetComponent<PlayerController>().playerDie = false;
                gameObject.GetComponent<PlayerController>().isControllerEnable = true;
                SetMaxHealth();
                SceneManager.LoadScene(0, LoadSceneMode.Single);
                waitForReloadCurrent = waitForReload;
            }*/

        }
    }

    public void HurtPlayer(int damageToGive)
    {
        playerCurrentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }
}
