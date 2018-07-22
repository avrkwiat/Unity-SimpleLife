using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchivmentScriptUnlock : MonoBehaviour {
    public float moveSpeed;
    public string text;
    public Text displayNumber;
	public Image imageBackground;
	// Use this for initialization
	void Start () {
		//imageBackground.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width/4,Screen.height/8);
	}
	
	// Update is called once per frame
	void Update () {
        displayNumber.text = text;
        transform.position = new Vector3(transform.position.x, transform.position.y + (moveSpeed*Time.deltaTime),transform.position.z);
    }
}

