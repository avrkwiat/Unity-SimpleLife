using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {
    public int damageToGive;
    public GameObject damageBrust;
    public GameObject damageNumber;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        /*
        if (collision.gameObject.name == "player")
        {
            //collision.gameObject.SetActive(false);
            reloading = true;
            thePlayer = collision.gameObject;
        }*/
        if (other.gameObject.name == "player")
        {
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
            Instantiate(damageBrust, other.transform.position, other.transform.rotation);

            var clone = (GameObject)Instantiate(damageNumber, new Vector3(other.transform.position.x, other.transform.position.y, -1), other.transform.rotation);
            clone.GetComponent<FloatingNumbers>().moveNumber = damageToGive;
        }
    }

}
