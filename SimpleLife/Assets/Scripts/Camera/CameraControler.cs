using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraControler : MonoBehaviour {
    public GameObject fallowTarget;
    private Vector3 targetPos;
    public Vector2 offset;
    public float moveSpeed;
    public BoxCollider2D boundBox;
    private Vector3 minBounds;
    private Vector3 maxBounds;
    private Camera theCamera;
    public float halfWidht;
    public float halfHeight;

    private static bool cameraExists;

    // Use this for initialization
    void Start () {
         
        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if(boundBox != null){
            minBounds = boundBox.bounds.min;
            maxBounds = boundBox.bounds.max;

            theCamera = GetComponent<Camera>();
            halfHeight = theCamera.orthographicSize;
            halfWidht = halfHeight * Screen.width/ Screen.height;
        }
    }
	
	// Update is called once per frame
	void Update () {
        
        if(fallowTarget != null){
            targetPos = new Vector3(fallowTarget.transform.position.x+offset.x, fallowTarget.transform.position.y+offset.y, transform.position.z );
            transform.position = Vector3.Lerp(transform.position,targetPos,moveSpeed*Time.deltaTime);
            if(boundBox != null){
                float clampedX = Mathf.Clamp(transform.position.x,minBounds.x + halfWidht, maxBounds.x - halfWidht);
                float clampedY = Mathf.Clamp(transform.position.y,minBounds.y + halfHeight, maxBounds.y - halfHeight);
                transform.position = new Vector3(clampedX,clampedY,transform.position.z);
            }
        }
        
    }

    public void setBounds(BoxCollider2D newBounds){
        boundBox = newBounds;

        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;
        
        theCamera = GetComponent<Camera>();
        halfHeight = theCamera.orthographicSize;
        halfWidht = halfHeight * Screen.width/ Screen.height;
    }
}
