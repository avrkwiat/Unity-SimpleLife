using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOverride : MonoBehaviour {
		public AnimationCreaterUtils animUtils;
		Animator theNPCAnimator;
		string path="";
		public bool isMale=true;

		public AnimationCreaterUtils.enumRaceFemale enumOverrideRaceFemale;
		public AnimationCreaterUtils.enumRaceMale enumOverrideRaceMale;
		private AnimationCreaterUtils.enumRace enumOverrideRace;
		public Color bodyColor;
		public SpriteRenderer bodySprite;
		public AnimationCreaterUtils.enumHair enumOverrideHair;
		public Color hairColor;
		public SpriteRenderer hairSprite;
		public AnimationCreaterUtils.enumEars enumOverrideEars;
		public Color earsColor;
		public SpriteRenderer earsSprite;
		public AnimationCreaterUtils.enumEyes enumOverrideEyes;
		public Color eyesColor;
		public SpriteRenderer eyesSprite;
		public AnimationCreaterUtils.enumNose enumOverrideNose;
		public Color noseColor;
		public SpriteRenderer noseSprite;
		public AnimationCreaterUtils.enumFacial enumOverrideFacial;
		public Color facialColor;
		public SpriteRenderer facialSprite;
		public AnimationCreaterUtils.enumArmsFemale enumOverrideArmsFemale;
		public AnimationCreaterUtils.enumArmsMale enumOverrideArmsMale;
		private AnimationCreaterUtils.enumArms enumOverrideArms;
		public Color armsColor;
		public SpriteRenderer armsSprite;
		public AnimationCreaterUtils.enumBackFemale enumOverrideBackFemale;
		public AnimationCreaterUtils.enumBackMale enumOverrideBackMale;
		private AnimationCreaterUtils.enumBack enumOverrideBack;
		public Color backColor;
		public SpriteRenderer backSprite;
		public AnimationCreaterUtils.enumChestFemale enumOverrideChestFemale;
		public AnimationCreaterUtils.enumChestMale enumOverrideChestMale;
		private AnimationCreaterUtils.enumChest enumOverrideChest;
		public Color chestColor;
		public SpriteRenderer chestSprite;
		public AnimationCreaterUtils.enumFeetFemale enumOverrideFeetFemale;
		public AnimationCreaterUtils.enumFeetMale enumOverrideFeetMale;
		private AnimationCreaterUtils.enumFeet enumOverrideFeet;
		public Color feetColor;
		public SpriteRenderer feetSprite;
		public AnimationCreaterUtils.enumHandFemale enumOverrideHandFemale;
		public AnimationCreaterUtils.enumHandMale enumOverrideHandMale;
		private AnimationCreaterUtils.enumHand enumOverrideHand;
		public Color handColor;
		public SpriteRenderer handSprite;
		public AnimationCreaterUtils.enumHeadFemale enumOverrideHeadFemale;
		public AnimationCreaterUtils.enumHeadMale enumOverrideHeadMale;
		private AnimationCreaterUtils.enumHead enumOverrideHead;
		public Color headColor;
		public SpriteRenderer headSprite;
		public AnimationCreaterUtils.enumLegsFemale enumOverrideLegsFemale;
		public AnimationCreaterUtils.enumLegsMale enumOverrideLegsMale;
		private AnimationCreaterUtils.enumLegs enumOverrideLegs;
		public Color legsColor;
		public SpriteRenderer legsSprite;
		public AnimationCreaterUtils.enumNeckFemale enumOverrideNeckFemale;
		public AnimationCreaterUtils.enumNeckMale enumOverrideNeckMale;
		private AnimationCreaterUtils.enumNeck enumOverrideNeck;
		public Color neckColor;
		public SpriteRenderer neckSprite;
		public AnimationCreaterUtils.enumWaistFemale enumOverrideWaistFemale;
		public AnimationCreaterUtils.enumWaistMale enumOverrideWaistMale;
		private AnimationCreaterUtils.enumWaist enumOverrideWaist;
		public Color waistColor;
		public SpriteRenderer waistSprite;


	// Use this for initialization
	void Start () {
		animUtils = GetComponent<AnimationCreaterUtils>();
		theNPCAnimator = GetComponent<Animator>();
		string enumHand="";

		//load body animation	
		bodySprite.color = bodyColor;
		if(isMale){
			enumOverrideRace = (AnimationCreaterUtils.enumRace) System.Enum.Parse( typeof( AnimationCreaterUtils.enumRace ),enumOverrideRaceMale.ToString() );
		}else{
			enumOverrideRace = (AnimationCreaterUtils.enumRace) System.Enum.Parse( typeof( AnimationCreaterUtils.enumRace ),enumOverrideRaceFemale.ToString() );
		}
		path =animUtils.backBodyName((int)enumOverrideRace );
		animUtils.loadAnimationClip(path,isMale,"body","Animation/Character/");				
		animUtils.customizeAnimationSet(animUtils.arrayOneObjectAnimationHandler,(int)enumOverrideRace,"body",theNPCAnimator);	



		//load hair animation
		hairSprite.color = hairColor;
		path =animUtils.backHairName((int)enumOverrideHair);
		animUtils.loadAnimationClip(path,isMale,"hair","Animation/Character/");
		animUtils.customizeAnimationSet(animUtils.arrayOneObjectAnimationHandler,(int)enumOverrideHair,"hair",theNPCAnimator);
		


		//load ears animation
		earsSprite.color = earsColor;
		path =animUtils.backEarsName((int)enumOverrideEars);
		animUtils.loadAnimationClip(path,isMale,"ears","Animation/Character/");
		animUtils.customizeAnimationSet(animUtils.arrayOneObjectAnimationHandler,(int)enumOverrideEars,"ears",theNPCAnimator);

		//load eyes animation
		eyesSprite.color = eyesColor;
		path =animUtils.backEyesName((int)enumOverrideEyes);
		animUtils.loadAnimationClip(path,isMale,"eyes","Animation/Character/");
		animUtils.customizeAnimationSet(animUtils.arrayOneObjectAnimationHandler,(int)enumOverrideEyes,"eyes",theNPCAnimator);

		//load nose animation
		noseSprite.color = noseColor;
		path =animUtils.backNoseName((int)enumOverrideNose);
		animUtils.loadAnimationClip(path,isMale,"nose","Animation/Character/");
		animUtils.customizeAnimationSet(animUtils.arrayOneObjectAnimationHandler,(int)enumOverrideNose,"nose",theNPCAnimator);

		//load facialhair aniamtion
		facialSprite.color = facialColor;
		path =animUtils.backFacialName((int)enumOverrideFacial);
		animUtils.loadAnimationClip(path,isMale,"facial","Animation/Character/");
		animUtils.customizeAnimationSet(animUtils.arrayOneObjectAnimationHandler,(int)enumOverrideFacial,"facial",theNPCAnimator);

/////////////////////////////////////items/////////////////////////////

		//load arms aniamtion
		if(isMale){
			enumOverrideArms = (AnimationCreaterUtils.enumArms) System.Enum.Parse( typeof( AnimationCreaterUtils.enumArms ),enumOverrideArmsMale.ToString() );
		}else{
			enumOverrideArms = (AnimationCreaterUtils.enumArms) System.Enum.Parse( typeof( AnimationCreaterUtils.enumArms ),enumOverrideArmsFemale.ToString() );
		}
		armsSprite.color = armsColor;
		path =animUtils.backArmsName((int)enumOverrideArms);
		animUtils.loadAnimationClip(path,isMale,"arms","Animation/items/");
		animUtils.customizeAnimationSet(animUtils.arrayOneObjectAnimationHandler,(int)enumOverrideArms,"arms",theNPCAnimator);
	
		//load back aniamtion
		if(isMale){
			enumOverrideBack = (AnimationCreaterUtils.enumBack) System.Enum.Parse( typeof( AnimationCreaterUtils.enumBack ),enumOverrideBackMale.ToString() );
		}else{
			enumOverrideBack = (AnimationCreaterUtils.enumBack) System.Enum.Parse( typeof( AnimationCreaterUtils.enumBack ),enumOverrideBackFemale.ToString() );
		}
		backSprite.color = backColor;
		path =animUtils.backBackName((int)enumOverrideBack);
		animUtils.loadAnimationClip(path,isMale,"back","Animation/items/");
		animUtils.customizeAnimationSet(animUtils.arrayOneObjectAnimationHandler,(int)enumOverrideBack,"back",theNPCAnimator);
	
		//load Chest aniamtion
		if(isMale){
			enumOverrideChest = (AnimationCreaterUtils.enumChest) System.Enum.Parse( typeof( AnimationCreaterUtils.enumChest ),enumOverrideChestMale.ToString() );
		}else{
			enumOverrideChest = (AnimationCreaterUtils.enumChest) System.Enum.Parse( typeof( AnimationCreaterUtils.enumChest ),enumOverrideChestFemale.ToString() );
		}
		chestSprite.color = chestColor;
		path =animUtils.backChestName((int)enumOverrideChest);
		animUtils.loadAnimationClip(path,isMale,"chest","Animation/items/");
		animUtils.customizeAnimationSet(animUtils.arrayOneObjectAnimationHandler,(int)enumOverrideChest,"chest",theNPCAnimator);

		//load Feet aniamtion
		if(isMale){
			enumOverrideFeet = (AnimationCreaterUtils.enumFeet) System.Enum.Parse( typeof( AnimationCreaterUtils.enumFeet ),enumOverrideFeetMale.ToString() );
		}else{
			enumOverrideFeet = (AnimationCreaterUtils.enumFeet) System.Enum.Parse( typeof( AnimationCreaterUtils.enumFeet ),enumOverrideFeetFemale.ToString() );
		}
		feetSprite.color = feetColor;
		path =animUtils.backFeetName((int)enumOverrideFeet);
		animUtils.loadAnimationClip(path,isMale,"feet","Animation/items/");
		animUtils.customizeAnimationSet(animUtils.arrayOneObjectAnimationHandler,(int)enumOverrideFeet,"feet",theNPCAnimator);

		//load Hand aniamtion
		if(isMale){
			enumOverrideHand = (AnimationCreaterUtils.enumHand) System.Enum.Parse( typeof( AnimationCreaterUtils.enumHand ),enumOverrideHandMale.ToString() );
		}else{
			enumOverrideHand = (AnimationCreaterUtils.enumHand) System.Enum.Parse( typeof( AnimationCreaterUtils.enumHand ),enumOverrideHandFemale.ToString() );
		}
		handSprite.color = handColor;
		path =animUtils.backHandName((int)enumOverrideHand);
		animUtils.loadAnimationClip(path,isMale,"hand","Animation/items/");
		animUtils.customizeAnimationSet(animUtils.arrayOneObjectAnimationHandler,(int)enumOverrideHand,"hand",theNPCAnimator);

		//load Head aniamtion
		if(isMale){
			enumOverrideHead = (AnimationCreaterUtils.enumHead) System.Enum.Parse( typeof( AnimationCreaterUtils.enumHead ),enumOverrideHeadMale.ToString() );
		}else{
			enumOverrideHead = (AnimationCreaterUtils.enumHead) System.Enum.Parse( typeof( AnimationCreaterUtils.enumHead ),enumOverrideHeadFemale.ToString() );
		}
		headSprite.color = headColor;
		path =animUtils.backHeadName((int)enumOverrideHead);
		animUtils.loadAnimationClip(path,isMale,"head","Animation/items/");
		animUtils.customizeAnimationSet(animUtils.arrayOneObjectAnimationHandler,(int)enumOverrideHead,"head",theNPCAnimator);

		//load Legs aniamtion
		if(isMale){
			enumOverrideLegs = (AnimationCreaterUtils.enumLegs) System.Enum.Parse( typeof( AnimationCreaterUtils.enumLegs ),enumOverrideLegsMale.ToString() );
		}else{
			enumOverrideLegs = (AnimationCreaterUtils.enumLegs) System.Enum.Parse( typeof( AnimationCreaterUtils.enumLegs ),enumOverrideLegsFemale.ToString() );
		}
		legsSprite.color = legsColor;
		path =animUtils.backLegsName((int)enumOverrideLegs);
		animUtils.loadAnimationClip(path,isMale,"legs","Animation/items/");
		animUtils.customizeAnimationSet(animUtils.arrayOneObjectAnimationHandler,(int)enumOverrideLegs,"legs",theNPCAnimator);

		//load Neck aniamtion
		if(isMale){
			enumOverrideNeck = (AnimationCreaterUtils.enumNeck) System.Enum.Parse( typeof( AnimationCreaterUtils.enumNeck ),enumOverrideNeckMale.ToString() );
		}else{
			enumOverrideNeck = (AnimationCreaterUtils.enumNeck) System.Enum.Parse( typeof( AnimationCreaterUtils.enumNeck ),enumOverrideNeckFemale.ToString() );
		}
		neckSprite.color = neckColor;
		path =animUtils.backNeckName((int)enumOverrideNeck);
		animUtils.loadAnimationClip(path,isMale,"neck","Animation/items/");
		animUtils.customizeAnimationSet(animUtils.arrayOneObjectAnimationHandler,(int)enumOverrideNeck,"neck",theNPCAnimator);
		

		//load Waist aniamtion
		if(isMale){
			enumOverrideWaist = (AnimationCreaterUtils.enumWaist) System.Enum.Parse( typeof( AnimationCreaterUtils.enumWaist ),enumOverrideWaistMale.ToString() );
		}else{
			enumOverrideWaist = (AnimationCreaterUtils.enumWaist) System.Enum.Parse( typeof( AnimationCreaterUtils.enumWaist ),enumOverrideWaistFemale.ToString() );
		}
		waistSprite.color = waistColor;
		path =animUtils.backWaistName((int)enumOverrideWaist);
		animUtils.loadAnimationClip(path,isMale,"waist","Animation/items/");
		animUtils.customizeAnimationSet(animUtils.arrayOneObjectAnimationHandler,(int)enumOverrideWaist,"waist",theNPCAnimator);
	}
	
	// Update is called once per frame
	void Update () {


	}

}
