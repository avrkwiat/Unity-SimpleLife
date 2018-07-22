using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour {
    public GameObject fallowTarget;
    private Vector3 targetPos;
    public Vector2 offset;
    public float moveSpeed;

    private static bool cameraExists;

    // Use this for initialization
    void Start () {
  
       // fallowTarget = clone.gameObject;
        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        var clone = FindObjectOfType<PlayerController>();
        if(clone != null){
            fallowTarget = clone.gameObject;
            targetPos = new Vector3(fallowTarget.transform.position.x+offset.x, fallowTarget.transform.position.y+offset.y, transform.position.z );
            transform.position = Vector3.Lerp(transform.position,targetPos,moveSpeed*Time.deltaTime);
        }
        
    }
}
