using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {
    private PlayerController thePlayer;
    private CameraControler theCamera;

    public string pointName; 

    public Vector2 StartDirection;

	// Use this for initialization
	void Start () {

        thePlayer = FindObjectOfType<PlayerController>();
        if (thePlayer.startPoint == pointName)
        {
            thePlayer.transform.position = transform.position;
            thePlayer.lastMove = StartDirection;

            theCamera = FindObjectOfType<CameraControler>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
