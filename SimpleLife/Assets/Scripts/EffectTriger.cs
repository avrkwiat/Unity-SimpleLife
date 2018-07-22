using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTriger : MonoBehaviour {
    public GameObject snowEffect;
 //   public bool isSnow=false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "player")
        {
             var theObject = GameObject.Find("Snow(Clone)");
            if (theObject == null){
                var clone = Instantiate(snowEffect, snowEffect.transform.position, snowEffect.transform.rotation);
                clone.transform.SetParent(other.transform);
            }
        }

    }
}
