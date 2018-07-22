using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour {

    public GameObject sword;

	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        sword.SetActive(gameObject.GetComponent<PlayerController>().attacking);

    }


}
