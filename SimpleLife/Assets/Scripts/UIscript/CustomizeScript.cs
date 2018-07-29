using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//using UnityEditor.Animations;
public class CustomizeScript : MonoBehaviour {
	private DialogueManager dManager;

	public Text raceText;
	public Text hairText;
	public Text earsText;
	public Text noseText;
	public Text eyesText;
	public Text facialText;
	public Slider raceSlider;
	public Slider hairSlider;
	public Slider earsSlider;
	public Slider eyesSlider;
	public Slider noseSlider;
	public Slider facialHairSlider;
	public Button GenderButton;
	public Image OptionSliderImage;
	public Image DescriptionImage;
	
	public Text DescriptionText;
	public Button AcceptedButton;
	public Image LoadingImage;


	public string mainGameScen;

	public SpriteRenderer body;
	public SpriteRenderer hair;
	public SpriteRenderer ears;
	public SpriteRenderer eyes;
	public SpriteRenderer nose;
	public SpriteRenderer facial;


	private enum enumColorChoice {RACE, HAIR, EARS, NOSE, EYES, FACIAL, NONE};
	private enumColorChoice colorChoiceEnum;

  //  public Texture2D colorPicker;  
	public GameObject colorPickerWheel;
	
   // private Rect colorPanelRect  = new Rect(Screen.width/20,Screen.height/20,Screen.width/4,Screen.height/4);
	private Color col= Color.white;
	public PlayerController thePlayer;
	public GameObject playerObject;
	public GameObject uiObject;
	public CameraControler theCamera;
	public menuScript menuScript;
	public loadingScript theLoadingScript;
	private Slider hpSlider;

	public AnimationCreaterUtils animUtils;
	Animator thePlayerAnimator;
	private bool isGhost=false;
   
/*    void OnGUI() {

			GUI.DrawTexture(colorPanelRect, colorPicker);
			if (GUI.RepeatButton(colorPanelRect, ""))
			{
				Vector2 pickpos  = Event.current.mousePosition;
				float aaa  = pickpos.x - colorPanelRect.x;
		
				float bbb  =  pickpos.y - colorPanelRect.y;
			
				int aaa2  = (int)(aaa * (colorPicker.width / (colorPanelRect.width + 0.0f)));
		
				int bbb2  =  (int)((colorPanelRect.height - bbb) * (colorPicker.height / (colorPanelRect.height + 0.0f)));
		
				col  = colorPicker.GetPixel(aaa2, bbb2);
		
				switch (colorChoiceEnum){

					case enumColorChoice.RACE: 		
						body.color = col;						
					break;

					case enumColorChoice.HAIR:
						hair.color = col;						
					break;

					case enumColorChoice.EARS:
						ears.color = col;						
					break;

					case enumColorChoice.EYES:
						eyes.color = col;					
					break;

					case enumColorChoice.NOSE:
						nose.color = col;						
					break;

					case enumColorChoice.FACIAL:
						facial.color = col;						
					break;
				}
				//Debug.Log(aaa2 + "||||||" + bbb2);

			}


	}*/
	// Use this for initialization
	void Start () {
		theCamera = FindObjectOfType<CameraControler>();
		theCamera.GetComponent<Camera>().orthographicSize = 2.0f;
		theCamera.offset = new Vector2(0.77f,-0.33f);

		///size image, button, cricleColor etc
		colorPickerWheel.GetComponent<ColorWheelControl>().PickColor(Color.white);
		float widthImage = Screen.width/2.1f;
		float heightImage = Screen.height;
		float circelWidth = widthImage/2.3f;
		float buttonWidth = widthImage/3;
		float buttonHeight = heightImage/9;
		float sliderWidth = widthImage*0.7f;
		float sliderHeight = heightImage/9;
		float sliderSpaceWidth = widthImage*0.4f;
		float sliderSpaceHieght = heightImage/9/2.4f;
		float textWidth = widthImage/4;
		OptionSliderImage.GetComponent<RectTransform>().sizeDelta = new Vector2(widthImage,heightImage);
		
		colorPickerWheel.GetComponent<RectTransform>().sizeDelta = new Vector2(circelWidth,circelWidth);
		colorPickerWheel.GetComponent<RectTransform>().anchoredPosition= new Vector3(-circelWidth,circelWidth/1.8f,0);
		colorPickerWheel.GetComponent<ColorWheelControl>().refreshSize();
		
		AcceptedButton.GetComponent<RectTransform>().sizeDelta = new Vector2(buttonWidth,buttonWidth);
		AcceptedButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(-widthImage-buttonWidth*0.8f,buttonHeight+buttonHeight/4,0);
		GenderButton.GetComponent<RectTransform>().sizeDelta = new Vector2(buttonWidth,buttonWidth);
		GenderButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(-widthImage-buttonWidth*0.8f,-buttonHeight-buttonHeight/4,0);
		
		raceSlider.GetComponent<RectTransform>().sizeDelta = new Vector2(sliderWidth,sliderHeight);
		raceSlider.GetComponent<RectTransform>().anchoredPosition = new Vector3(-sliderSpaceWidth,-sliderSpaceHieght,0);
		hairSlider.GetComponent<RectTransform>().sizeDelta = new Vector2(sliderWidth,sliderHeight);
		hairSlider.GetComponent<RectTransform>().anchoredPosition = new Vector3(-sliderSpaceWidth,-sliderSpaceHieght-sliderHeight,0);
		earsSlider.GetComponent<RectTransform>().sizeDelta = new Vector2(sliderWidth,sliderHeight);
		earsSlider.GetComponent<RectTransform>().anchoredPosition = new Vector3(-sliderSpaceWidth,-sliderSpaceHieght-(2*sliderHeight),0);
		eyesSlider.GetComponent<RectTransform>().sizeDelta = new Vector2(sliderWidth,sliderHeight);
		eyesSlider.GetComponent<RectTransform>().anchoredPosition = new Vector3(-sliderSpaceWidth,-sliderSpaceHieght-(3*sliderHeight),0);
		noseSlider.GetComponent<RectTransform>().sizeDelta = new Vector2(sliderWidth,sliderHeight);
		noseSlider.GetComponent<RectTransform>().anchoredPosition = new Vector3(-sliderSpaceWidth,-sliderSpaceHieght-(4*sliderHeight),0);
		facialHairSlider.GetComponent<RectTransform>().sizeDelta = new Vector2(sliderWidth,sliderHeight);
		facialHairSlider.GetComponent<RectTransform>().anchoredPosition = new Vector3(-sliderSpaceWidth,-sliderSpaceHieght-(5*sliderHeight),0);
		
		raceText.GetComponent<RectTransform>().sizeDelta = new Vector2(textWidth,sliderHeight);
		raceText.GetComponent<RectTransform>().anchoredPosition = new Vector3(-sliderWidth-textWidth/2,0,0);
		hairText.GetComponent<RectTransform>().sizeDelta = new Vector2(textWidth,sliderHeight);
		hairText.GetComponent<RectTransform>().anchoredPosition = new Vector3(-sliderWidth-textWidth/2,0,0);
		earsText.GetComponent<RectTransform>().sizeDelta = new Vector2(textWidth,sliderHeight);
		earsText.GetComponent<RectTransform>().anchoredPosition = new Vector3(-sliderWidth-textWidth/2,0,0);
		eyesText.GetComponent<RectTransform>().sizeDelta = new Vector2(textWidth,sliderHeight);
		eyesText.GetComponent<RectTransform>().anchoredPosition = new Vector3(-sliderWidth-textWidth/2,0,0);
		noseText.GetComponent<RectTransform>().sizeDelta = new Vector2(textWidth,sliderHeight);
		noseText.GetComponent<RectTransform>().anchoredPosition = new Vector3(-sliderWidth-textWidth/2,0,0);
		facialText.GetComponent<RectTransform>().sizeDelta = new Vector2(textWidth,sliderHeight);
		facialText.GetComponent<RectTransform>().anchoredPosition = new Vector3(-sliderWidth-textWidth/2,0,0);

		//size descripton image
		DescriptionImage.GetComponent<RectTransform>().sizeDelta = new Vector2(widthImage/1.8f,heightImage/1.8f);

		LoadingImage.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width+100,Screen.height+100);
		LoadingImage.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,0,10);
		


		dManager = playerObject.GetComponent<DialogueManager>();
		animUtils = playerObject.GetComponent<AnimationCreaterUtils>();
		thePlayerAnimator = playerObject.GetComponent<Animator>();
		menuScript = GetComponent<menuScript>();
		theLoadingScript = GetComponent<loadingScript>();

		
		thePlayer.joyAction.gameObject.SetActive(false);
		thePlayer.joyAttack.gameObject.SetActive(false);
		thePlayer.joySpell.gameObject.SetActive(false);

		hpSlider = uiObject.GetComponentInChildren<Slider>();
		hpSlider.gameObject.SetActive(false);

		thePlayer.isMan = true;
		GenderButton.GetComponentInChildren<Text>().GetComponent<Text>().text = "MAN";

		raceSlider.maxValue = (int)AnimationCreaterUtils.enumRace.NONE-1;
 		raceSlider.value = (int)AnimationCreaterUtils.enumRace.BLACK;
		hairSlider.maxValue = (int)AnimationCreaterUtils.enumHair.NONE;
		hairSlider.value = (int)AnimationCreaterUtils.enumHair.NONE;
		earsSlider.maxValue = (int)AnimationCreaterUtils.enumEars.NONE;
		earsSlider.value = (int)AnimationCreaterUtils.enumEars.NONE;
		eyesSlider.maxValue = (int)AnimationCreaterUtils.enumEyes.NONE;
		eyesSlider.value = (int)AnimationCreaterUtils.enumEyes.NONE;
		noseSlider.maxValue = (int)AnimationCreaterUtils.enumNose.NONE;
		noseSlider.value = (int)AnimationCreaterUtils.enumNose.NONE;
		facialHairSlider.maxValue = (int)AnimationCreaterUtils.enumFacial.NONE;
		facialHairSlider.value = (int)AnimationCreaterUtils.enumFacial.NONE;
		
		//get actual texture to new gender from slider
		ChoiceRace();
		ChoiceHair();
		ChoiceEras();
		ChoiceEyes();
		ChoiceNose();
		ChoiceFacialHair();	
		
	
		//var clone1 = FindObjectOfType<CameraControler>();
		//clone1.GetComponent<Camera>().orthographicSize = 2.0f;
		//clone1.offset = new Vector2(0.77f,-0.33f);
	
	}
	
	// Update is called once per frame
	void Update () {
		if(playerObject!=null){
			col = colorPickerWheel.GetComponent<ColorWheelControl>().Selection;
			if(isGhost){
				col	= new Color(col.r, col.g, col.b, 0.4f);	
			}else{
				col	= new Color(col.r, col.g, col.b, 1f);
			}
			switch (colorChoiceEnum){
				case enumColorChoice.RACE:
						
					body.color = col;	
				
				break;

				case enumColorChoice.HAIR:
					hair.color = col;
						
				break;

				case enumColorChoice.EARS:
					ears.color = col;						
				break;

				case enumColorChoice.EYES:
					eyes.color = col;					
				break;

				case enumColorChoice.NOSE:
					nose.color = col;						
				break;

				case enumColorChoice.FACIAL:
					facial.color = col;						
				break;
			}
		}else{
			playerObject = GameObject.FindGameObjectWithTag("Player");
		}
		
		
		//Debug.Log(aaa2 + "||||||" + bbb2);

			
	}
	public void CustomizeAccepted(){
		#if UNITY_EDITOR
		//animUtils = GetComponent<AnimationCreaterUtils>();
		//animUtils.CreateSprite("back/back_place","back2_both_quiver","sprite/items/back/male/quiver");
 		#endif
		PlayerController.playerExists = true;
		UIManager.UIexist = true;
	
		DontDestroyOnLoad(playerObject);
		DontDestroyOnLoad(uiObject);

		thePlayer.activeScene = mainGameScen;
		
		menuScript.isGameRun = true;
		//var clone = FindObjectOfType<CameraControler>();
		//clone.GetComponent<Camera>().orthographicSize = 5.0f;
		//clone.offset = new Vector2(0,0);
		theCamera = FindObjectOfType<CameraControler>();
		theCamera.GetComponent<Camera>().orthographicSize = 5.0f;
		theCamera.offset = new Vector2(0,0);

		//thePlayer.joyAction.gameObject.SetActive(true);
		thePlayer.joyAttack.gameObject.SetActive(true);
		thePlayer.joySpell.gameObject.SetActive(true);
		hpSlider.gameObject.SetActive(true);

		theLoadingScript.loading.SetActive(true);
		StartCoroutine(theLoadingScript.LoadLevelWithBar(mainGameScen));
		//SceneManager.LoadScene(mainGameScen);

	}

	public void ChoiceGender(){
		
		thePlayer.isMan = !thePlayer.isMan;
		if(thePlayer.isMan){
			GenderButton.GetComponentInChildren<Text>().GetComponent<Text>().text = "MAN";
		}else{
			GenderButton.GetComponentInChildren<Text>().GetComponent<Text>().text = "WOMAN";
		}
		//get actual texture to new gender
		ChoiceRace();
		ChoiceHair();
		ChoiceEras();
		ChoiceEyes();
		ChoiceNose();
		ChoiceFacialHair();	
	}

	public void ChoiceRace(){
			string path="";

			path =animUtils.backBodyName((int)raceSlider.value);

			switch(path){
				case "black":
					mainGameScen = "Ubalib";
				break;
				case "dark": //slave
					mainGameScen = "Police";
				break;
				case "darkelf": //ethernal
					mainGameScen = "Telkawia";
				break;
				case "light":
					mainGameScen = "Trotlin";
				break;
				case "tanned":
					mainGameScen = "Grunled";
				break;
				case "skeleton":
					mainGameScen = "Police";
				break;
				case "orc":
					mainGameScen = "Mosicowa";
				break;
				case "redorc":
					mainGameScen = "Mosicowa";
				break;
				case "default":
					mainGameScen = "Start";
				break;
				default:
					mainGameScen = "Start";
				break;
			}

			if(path == "darkelf"){
				isGhost = true;
			}else{
				isGhost = false;
			}
					
			if(!thePlayer.isMan){
				if(path == "skeleton"){
					path="orc";
					raceSlider.value=(int)AnimationCreaterUtils.enumRace.ORC;
				}
			}
			thePlayer.startPoint = path;
			if(path !=""){
				animUtils.loadAnimationClip(path,thePlayer.isMan,"body","Animation/Character/");

				animUtils.raceEnum = (AnimationCreaterUtils.enumRace)raceSlider.value;
				raceText.text = animUtils.nameToRace((int)raceSlider.value);
			
				//raceText.text = animUtils.raceEnum.ToString();
				
				animUtils.customizeAnimationSet(animUtils.arrayOneObjectAnimationHandler,(int)raceSlider.value,"body",thePlayerAnimator);		

				
				if((animUtils.raceEnum == AnimationCreaterUtils.enumRace.ORC)||(animUtils.raceEnum == AnimationCreaterUtils.enumRace.REDORC)){
						earsSlider.value = earsSlider.maxValue;
						earsSlider.gameObject.SetActive(false);
					//	ChoiceEras();

						eyesSlider.value = eyesSlider.maxValue;
						eyesSlider.gameObject.SetActive(false);
					//	ChoiceEyes();
				}else{
						earsSlider.gameObject.SetActive(true);
						eyesSlider.gameObject.SetActive(true);
				}
				colorPickerWheel.GetComponent<ColorWheelControl>().Selection = Color.white;
				colorPickerWheel.GetComponent<ColorWheelControl>().PickColor(Color.white);

				if(isGhost){
					body.color	= new Color(body.color.r, body.color.g, body.color.b, 0.4f);
					hair.color	= new Color(hair.color.r, hair.color.g, hair.color.b, 0.4f);
					ears.color	= new Color(ears.color.r, ears.color.g, ears.color.b, 0.4f);
					eyes.color	= new Color(eyes.color.r, eyes.color.g, eyes.color.b, 0.4f);
					nose.color	= new Color(nose.color.r, nose.color.g, nose.color.b, 0.4f);
					facial.color	= new Color(facial.color.r, facial.color.g, facial.color.b, 0.4f);
				
				}else{
					body.color	= new Color(body.color.r, body.color.g, body.color.b, 1f);
					hair.color	= new Color(hair.color.r, hair.color.g, hair.color.b, 1f);
					ears.color	= new Color(ears.color.r, ears.color.g, ears.color.b, 1f);
					eyes.color	= new Color(eyes.color.r, eyes.color.g, eyes.color.b, 1f);
					nose.color	= new Color(nose.color.r, nose.color.g, nose.color.b, 1f);
					facial.color	= new Color(facial.color.r, facial.color.g, facial.color.b, 1f);
				}

				colorChoiceEnum = enumColorChoice.RACE;
			}
			
	}
	public void ChoiceHair(){		
			string path="";
	
			path =animUtils.backHairName((int)hairSlider.value);

			animUtils.loadAnimationClip(path,thePlayer.isMan,"hair","Animation/Character/");
			animUtils.customizeAnimationSet(animUtils.arrayOneObjectAnimationHandler,(int)hairSlider.value,"hair",thePlayerAnimator);


			animUtils.hairEnum = (AnimationCreaterUtils.enumHair)hairSlider.value;
			hairText.text = animUtils.hairEnum.ToString();

			colorPickerWheel.GetComponent<ColorWheelControl>().Selection = Color.white;
			colorPickerWheel.GetComponent<ColorWheelControl>().PickColor(Color.white);

			colorChoiceEnum = enumColorChoice.HAIR;
	}
		
	public void ChoiceEras(){
			string path="";

			path =animUtils.backEarsName((int)earsSlider.value);

			animUtils.loadAnimationClip(path,thePlayer.isMan,"ears","Animation/Character/");
			animUtils.customizeAnimationSet(animUtils.arrayOneObjectAnimationHandler,(int)earsSlider.value,"ears",thePlayerAnimator);

			animUtils.earsEnum = (AnimationCreaterUtils.enumEars)earsSlider.value;
			earsText.text = animUtils.earsEnum.ToString();

			colorPickerWheel.GetComponent<ColorWheelControl>().Selection = Color.white;
			colorPickerWheel.GetComponent<ColorWheelControl>().PickColor(Color.white);
			colorChoiceEnum = enumColorChoice.EARS;
			
	}	

	public void ChoiceEyes(){

			string path="";
	
			path =animUtils.backEyesName((int)eyesSlider.value);

			animUtils.loadAnimationClip(path,thePlayer.isMan,"eyes","Animation/Character/");
			animUtils.customizeAnimationSet(animUtils.arrayOneObjectAnimationHandler,(int)eyesSlider.value,"eyes",thePlayerAnimator);
				
			animUtils.eyesEnum = (AnimationCreaterUtils.enumEyes)eyesSlider.value;
			eyesText.text = animUtils.eyesEnum.ToString();

			colorPickerWheel.GetComponent<ColorWheelControl>().Selection = Color.white;
			colorPickerWheel.GetComponent<ColorWheelControl>().PickColor(Color.white);
			colorChoiceEnum = enumColorChoice.EYES;
			
			
	}
		
	public void ChoiceNose(){

			string path="";

			path =animUtils.backNoseName((int)noseSlider.value);

			animUtils.loadAnimationClip(path,thePlayer.isMan,"nose","Animation/Character/");
			animUtils.customizeAnimationSet(animUtils.arrayOneObjectAnimationHandler,(int)noseSlider.value,"nose",thePlayerAnimator);
				
			animUtils.noseEnum = (AnimationCreaterUtils.enumNose)noseSlider.value;
			noseText.text = animUtils.noseEnum.ToString();

			colorPickerWheel.GetComponent<ColorWheelControl>().Selection = Color.white;
			colorPickerWheel.GetComponent<ColorWheelControl>().PickColor(Color.white);
			colorChoiceEnum = enumColorChoice.NOSE;
			
			
	}
	public void ChoiceFacialHair(){

			string path="";

			path =animUtils.backFacialName((int)facialHairSlider.value);

			animUtils.loadAnimationClip(path,thePlayer.isMan,"facial","Animation/Character/");
			animUtils.customizeAnimationSet(animUtils.arrayOneObjectAnimationHandler,(int)facialHairSlider.value,"facial",thePlayerAnimator);
				
			animUtils.facialEnum = (AnimationCreaterUtils.enumFacial)facialHairSlider.value;
			facialText.text = animUtils.facialEnum.ToString();

			colorPickerWheel.GetComponent<ColorWheelControl>().Selection = Color.white;
			colorPickerWheel.GetComponent<ColorWheelControl>().PickColor(Color.white);
			colorChoiceEnum = enumColorChoice.FACIAL;
	}
}