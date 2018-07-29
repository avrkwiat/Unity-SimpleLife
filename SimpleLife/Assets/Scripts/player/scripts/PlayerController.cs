using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public bool isMan;
    public float moveSpeed;
    public bool isControllerEnable;
    public bool attacking;
    public bool spellAttacking;


    public bool isAccelerometr;
    public float sensAnalog;
    public float maxSpeedAnalog;
    private float moveSpeedAnalogX;
    private float moveSpeedAnalogY;

    public string manuScene;
 

    //joy analog UI

    public Joystick joystick;
    public JoyButton joyAttack;
    protected JoyButton joyMenu;
    public JoyButton joySpell;
    public JoyButton joyAction;
    public JoyButton[] arrayButton;
	public GameObject uICanvasObject;
    public Text actionText;

    private float accelerometrX;
    private float accelerometrY;

    private Animator anim;
    private bool playerMoving;
    public bool playerDie;
    public Vector2 lastMove;

    public Rigidbody2D myRigidbody;

    public static bool playerExists;

    public string startPoint;
    public string activeScene = "CustomizeScen";
    private bool findJoybutton = false;
    private SFXManager sfxMan;


    // Use this for initialization
    void Start ()
    {
        sfxMan = FindObjectOfType<SFXManager>();

        if(uICanvasObject==null){
            uICanvasObject = GameObject.Find("UIcanvas");
            //find joystick
            joystick = uICanvasObject.GetComponentInChildren<Joystick>(); 
            //find button gui
            arrayButton = uICanvasObject.GetComponentsInChildren<JoyButton>();
            for(int i=0;i<arrayButton.Length;i++){
                if(arrayButton[i].GetComponent<JoyButton>().name == "menuButton"){
                    joyMenu = arrayButton[i];
                }else if(arrayButton[i].GetComponent<JoyButton>().name == "attackButton"){
                    joyAttack = arrayButton[i];
                }else if (arrayButton[i].GetComponent<JoyButton>().name == "spellButton"){
                    joySpell = arrayButton[i];
                }else if(arrayButton[i].GetComponent<JoyButton>().name == "actionButton"){
                    joyAction = arrayButton[i];         
                }
            }
        }

        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            if(SceneManager.GetActiveScene().name != "CustomizeScen"){
                Destroy(gameObject);
            }
            
        }
        
	}
	
	// Update is called once per frame
	void Update () {
       
        playerMoving = false;
        if (isControllerEnable)
        {
            
                        //joystick
                        if (!attacking)
                        {
                            if (isAccelerometr){
                                accelerometrX = Input.acceleration.x;
                                accelerometrY = Input.acceleration.y;
                            }else{
                                accelerometrX = 0;
                                accelerometrY = 0;   
                            }

                            if ((Mathf.Abs(Input.GetAxisRaw("Horizontal")) > sensAnalog) || (Mathf.Abs(Input.GetAxisRaw("Vertical")) > sensAnalog) || Mathf.Abs(joystick.Horizontal) > sensAnalog || Mathf.Abs(joystick.Vertical) > sensAnalog || (Mathf.Abs(accelerometrX) > sensAnalog) || (Mathf.Abs(accelerometrY) > sensAnalog))
                            {
                                moveSpeedAnalogX = (Mathf.Abs(Input.GetAxisRaw("Horizontal") + joystick.Horizontal+ accelerometrX) * moveSpeed / maxSpeedAnalog);
                                moveSpeedAnalogY = (Mathf.Abs(Input.GetAxisRaw("Vertical") + joystick.Vertical+ accelerometrY) * moveSpeed / maxSpeedAnalog);
                                //diagonal speed reduce
                                if(Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.7 && Mathf.Abs(Input.GetAxisRaw("Horizontal"))>0.7){
                                    moveSpeedAnalogX = ((0.7f + joystick.Horizontal+ accelerometrX) * moveSpeed / maxSpeedAnalog);
                                    moveSpeedAnalogY = ((0.7f + joystick.Vertical+ accelerometrY) * moveSpeed / maxSpeedAnalog);

                                }
                                if ((Mathf.Abs(Input.GetAxisRaw("Horizontal")) > Mathf.Abs(Input.GetAxisRaw("Vertical"))) || Mathf.Abs(joystick.Horizontal) > Mathf.Abs(joystick.Vertical) || (Mathf.Abs(accelerometrX)>Mathf.Abs(accelerometrY)))
                                {

                                    if (Input.GetAxisRaw("Horizontal") < 0 || joystick.Horizontal < 0 || accelerometrX<0)
                                    {
                                    //myRigidbody.velocity = new Vector2(-moveSpeedAnalogX, myRigidbody.velocity.y);
                                        if (Input.GetAxisRaw("Vertical") < 0 || joystick.Vertical < 0 || accelerometrY < 0) {
                                            myRigidbody.velocity = new Vector2(-moveSpeedAnalogX, -moveSpeedAnalogY);
                                        }
                                        else
                                        {
                                            myRigidbody.velocity = new Vector2(-moveSpeedAnalogX, moveSpeedAnalogY);
                                        }
                                        
                                        playerMoving = true;
                                        lastMove = new Vector2(-1, 0f);
                                    }
                                    else
                                    {
                                        //myRigidbody.velocity = new Vector2(moveSpeedAnalogX, myRigidbody.velocity.y);
                                        if (Input.GetAxisRaw("Vertical") < 0 || joystick.Vertical < 0 || accelerometrY<0) {
                                            myRigidbody.velocity = new Vector2(moveSpeedAnalogX, -moveSpeedAnalogY);
                                        }else
                                        {
                                            myRigidbody.velocity = new Vector2(moveSpeedAnalogX, moveSpeedAnalogY);
                                        }
                                        playerMoving = true;
                                        lastMove = new Vector2(1, 0f);
                                    }
                                }
                                else
                                {

                                    if (Input.GetAxisRaw("Vertical") < 0 || joystick.Vertical < 0 || accelerometrY < 0)
                                    {
                                        //myRigidbody.velocity = new Vector2(moveSpeedAnalogX, -moveSpeedAnalogY);
                                        if (Input.GetAxisRaw("Horizontal") < 0 || joystick.Horizontal < 0 || accelerometrX < 0) {
                                            myRigidbody.velocity = new Vector2(-moveSpeedAnalogX, -moveSpeedAnalogY);
                                        }
                                        else
                                        {
                                            myRigidbody.velocity = new Vector2(moveSpeedAnalogX, -moveSpeedAnalogY);
                                        }
                                        playerMoving = true;
                                        lastMove = new Vector2(0f, -1);
                                    }
                                    else
                                    {
                                        //myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, moveSpeedAnalogY);
                                        if (Input.GetAxisRaw("Horizontal") < 0 || joystick.Horizontal < 0 || accelerometrX < 0) {
                                            myRigidbody.velocity = new Vector2(-moveSpeedAnalogX, moveSpeedAnalogY);
                                        }
                                        else
                                        {
                                            myRigidbody.velocity = new Vector2(moveSpeedAnalogX, moveSpeedAnalogY);
                                        }
                                        playerMoving = true;
                                        lastMove = new Vector2(0f, 1);
                                    }

                                }
                                
                            }
                            
                            anim.SetFloat("MoveX", lastMove.x);
                            anim.SetFloat("MoveY", lastMove.y);

                            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) <= sensAnalog && (Mathf.Abs(joystick.Horizontal) <= sensAnalog) && (Mathf.Abs(accelerometrX)<= sensAnalog))
                            {
                                myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
                            }
                            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) <= sensAnalog && (Mathf.Abs(joystick.Vertical) <= sensAnalog) && (Mathf.Abs(accelerometrY) <= sensAnalog))
                            {
                                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
                            }

                            //attack
                            if (Input.GetAxisRaw("Fire1")>0 || joyAttack.Pressed)
                            {
                                    attacking = true;
                                    myRigidbody.velocity = Vector2.zero;
                                    anim.SetBool("maleAttack", true);
                                    sfxMan.playerMaleAttack.Play();
                            }
                            //attack spell
                            if (Input.GetAxisRaw("Fire3")>0 || joySpell.Pressed)
                            {
                                    spellAttacking = true;
                                    myRigidbody.velocity = Vector2.zero;
                                    anim.SetBool("spellAttack", true);
                            }
                               // myRigidbody.velocity = new Vector2(joystick.Horizontal * 100f, myRigidbody.velocity.y);
                        }

                
                ///

            anim.SetBool("PlayerMoving", playerMoving);
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);
            
        }
        anim.SetBool("isDeath", playerDie);


        if (Input.GetButtonUp("Cancel") || joyMenu.Pressed)
        {
            
            if(!menuScript.isMenuRun){
                menuScript.isMenuRun = true;
                SceneManager.LoadScene(manuScene, LoadSceneMode.Additive);
            }


        }
        
        

    }

    public void attackAnimationDone()
    {
        attacking = false;
        anim.SetBool("maleAttack", false);
    }
    public void spellAnimationDone()
    {
        spellAttacking = false;
        anim.SetBool("spellAttack", false);
    }
}
