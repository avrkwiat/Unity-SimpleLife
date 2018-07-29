using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundsAndPlayerHandlerr : MonoBehaviour {
	private BoxCollider2D bounds;
	private CameraControler theCamera;
	// Use this for initialization
	void Start () {
		bounds = GetComponent<BoxCollider2D>();
		theCamera = FindObjectOfType<CameraControler>();
		theCamera.setBounds(bounds);

		theCamera.fallowTarget = FindObjectOfType<PlayerController>().gameObject;
	}

	
}