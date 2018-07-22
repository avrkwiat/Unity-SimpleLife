using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtsEnemy : MonoBehaviour {
    public int damageToGive;
    public GameObject damageBrust;
    public GameObject damageNumber;

    // Use this for initialization
    void Start () {
        //damageBrust.renderer.sortingLayerName("worldObject");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            // Destroy(other.gameObject);
            
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
            Instantiate(damageBrust, new Vector3(other.transform.position.x, other.transform.position.y,-1), other.transform.rotation);
            var clone = (GameObject)Instantiate(damageNumber, new Vector3(other.transform.position.x, other.transform.position.y, -1), other.transform.rotation);
            //clone.GetComponent<FloatingNumbers>().text = "Hp: -";
            clone.GetComponent<FloatingNumbers>().moveNumber = damageToGive;
        }
    }
}
