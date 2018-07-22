using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
 #endif

public class AnimationCreaterUtils : MonoBehaviour {

#if UNITY_EDITOR
EditorCurveBinding spriteBinding;
 #endif
public PlayerController thePlayer;
public AnimationClip[] arrayOneObjectAnimationHandler; 

public enum enumAnimationPlace {RACE, HAIR, EARS, NOSE, EYES, FACIALHAIR, NONE};
public enumAnimationPlace enumAnimator;

public enum enumRaceMale {BLACK, DARK, ELF, LIGHT,TANNED, SKELETON, ORC, REDORC, NONE};
//public enumRaceMale raceMaleEnum;
public enum enumRaceFemale {BLACK, DARK, ELF, LIGHT,TANNED, ORC, REDORC, NONE};
//public enumRaceFemale raceFemaleEnum;
public enum enumRace {BLACK, DARK, ELF, LIGHT,TANNED, SKELETON, ORC, REDORC, NONE};
public enumRace raceEnum;

public enum enumHair {BANGS, LBANGS, SBANGS, BEDHEAD, BUNCHES, JEWFRO, LONG, LHAWK, LKNOT, LOOSE, MESSY, PAGE, PARTED, PIXIE, PLAIN, PONYTAIL, PRINCESS, SHAWK, SKNOT, SHOULDERL, SHOULDERR, SWOOP, UNKEMPT, XLONG, XLONGKNOT, NONE};
public enumHair hairEnum;
public enum enumEars {BIGDARK, BIGELF, BIGLIGHT, BIGTANNED, ELVENDARK, ELVEN, ELVENLIGHT, ELVENTANNED, LONGDARK, LONGELF, LONGLIGHT, LONGTANNED, NONE};
public enumEars earsEnum;
public enum enumEyes {BLUE, BROWN, GRAY, GREEN, PURPLE, RED, NONE};
public enumEyes eyesEnum;
public enum enumNose {BIGDARK, BIGELF, BIGLIGHT, BIGTANNED, BUTTONDARK, STRAIGHT, NONE};
public enumNose noseEnum;
public enum enumFacial {BEARD, BIGSTACHE, FIVECLOCK, FRANCHSTACHE, MUSTACHE,  NONE};
public enumFacial facialEnum;
////////////////items/////////////////////
//woman platemail
public enum enumArmsFemale {LEATHER, PLATEMAIL,  NONE};
public enum enumArmsMale {LEATHER, PLATEMAIL, SINGLEATHER,  NONE};
public enum enumArms {LEATHER, PLATEMAIL, SINGLEATHER,  NONE};
public enumArms armsEnum;
//quiever only man
public enum enumBackFemale {QUIVER, CAPE, TATTERCAPE,TRIMCAPE,  NONE};
public enum enumBackMale {QUIVER,  NONE};
public enum enumBack {QUIVER, CAPE, TATTERCAPE,TRIMCAPE,  NONE};
public enumBack backEnum;
//shirtleess<-- only man
public enum enumChestFemale {APRON, TABARD, CHAINMAIL,LEATHER,PLATEMAIL, SHIRTLESS, CORSET, DRESS, OVERSKIRT, TIGHTDRESS, TUNIC, UNDERDRESS, VEST,  NONE};
public enum enumChestMale {APRON, TABARD, CHAINMAIL,LEATHER,PLATEMAIL, SHIRTLONG, SHIRTLESS,  NONE};
public enum enumChest {APRON, TABARD, CHAINMAIL,LEATHER,PLATEMAIL, SHIRTLONG, SHIRTLESS, CORSET, DRESS, OVERSKIRT, TIGHTDRESS, TUNIC, UNDERDRESS, VEST,  NONE};
public enumChest chestEnum;
//platemail <-- only man
public enum enumFeetFemale {SHOES, PLATEMAIL, BOOTS, SLIPPERS,  NONE};
public enum enumFeetMale {SHOES, PLATEMAIL, NONE};
public enum enumFeet {SHOES, PLATEMAIL, BOOTS, SLIPPERS,  NONE};
public enumFeet feetEnum;
//paltemail only man
public enum enumHandFemale {PLATEMAIL, CLOTH,  NONE};
public enum enumHandMale {PLATEMAIL,  NONE};
public enum enumHand {PLATEMAIL, CLOTH,  NONE};
public enumHand handEnum;
public enum enumHeadFemale {BANDANA, CHAINMAIL, CROWN, HOOD, LEATHER, MASK, PLATEMAIL, REINFORCED, SPIKED,  NONE};
public enum enumHeadMale {BANDANA, CHAINMAIL, CROWN, HOOD, LEATHER, MASK, PLATEMAIL, REINFORCED, SPIKED,  NONE};
public enum enumHead {BANDANA, CHAINMAIL, CROWN, HOOD, LEATHER, MASK, PLATEMAIL, REINFORCED, SPIKED,  NONE};
public enumHead headEnum;
//skirt only man
public enum enumLegsFemale {PANTS, PLATEMAIL, SKIRT, OVERSKIRT,  NONE};
public enum enumLegsMale {PANTS, PLATEMAIL, SKIRT,  NONE};
public enum enumLegs {PANTS, PLATEMAIL, SKIRT, OVERSKIRT,  NONE};
public enumLegs legsEnum;
public enum enumNeckFemale {CAPECLIP, CAPETIE,  NONE};
public enum enumNeckMale {SCRAFT, NONE};
public enum enumNeck {SCRAFT, CAPECLIP, CAPETIE,  NONE};
public enumNeck neckEnum;
public enum enumWaistFemale {CLOTH, LEATHER,  NONE};
public enum enumWaistMale {CLOTH, LEATHER,  NONE};
public enum enumWaist {CLOTH, LEATHER,  NONE};
public enumWaist waistEnum;

int numberFrame;
string sufix;
string endNameFile;
protected  Animator thePlayerAnimator;
protected AnimatorOverrideController animatorOverrideController ;

void Start(){

}
public string nameToRace(int i){
	string path="";
	switch(i){
				case (int)enumRace.BLACK:
					path = "Fanatic";
				break;
				case (int)enumRace.DARK:
					path = "Slave";
				break;
				case (int)enumRace.ELF:
					path = "Ethernal";
				break;
				case (int)enumRace.LIGHT:
					path = "Lighter";
				break;
				case (int)enumRace.TANNED:
					path = "Pecer";
				break;
				case (int)enumRace.SKELETON:
					path = "Undead";		
				break;
				case (int)enumRace.ORC:
					path = "Orc";
				break;
				case (int)enumRace.REDORC:
					path = "Gundler";
				break;
				case (int)enumRace.NONE:
					path = "default";
				break;
				default:
					path="default";
				break;
			}
	return path;
}
public string backBodyName(int i){
	string path="";
	switch(i){
				case (int)enumRace.BLACK:
					path = "black";
				break;
				case (int)enumRace.DARK:
					path = "dark";
				break;
				case (int)enumRace.ELF:
					path = "darkelf";
				break;
				case (int)enumRace.LIGHT:
					path = "light";
				break;
				case (int)enumRace.TANNED:
					path = "tanned";
				break;
				case (int)enumRace.SKELETON:
					path = "skeleton";		
				break;
				case (int)enumRace.ORC:
					path = "orc";
				break;
				case (int)enumRace.REDORC:
					path = "redorc";
				break;
				case (int)enumRace.NONE:
					path = "default";
				break;
				default:
					path="default";
				break;
			}
	return path;
}
public string backHairName(int i){
	string path="";
	switch(i){
				case (int)enumHair.BANGS:
					path = "bangs";
				break;
				case (int)enumHair.LBANGS:
					path = "bangslong";
				break;
				case (int)enumHair.SBANGS:
					path = "bangsshort";
				break;
				case (int)enumHair.BEDHEAD:
					path = "bedhead";
				break;
				case (int)enumHair.BUNCHES:
					path = "bunches";
				break;
				case (int)enumHair.JEWFRO:
					path = "jewfro";
				break;
				case (int)enumHair.LONG:
					path = "long";
				break;
				case (int)enumHair.LHAWK:
					path = "longhawk";
				break;
				case (int)enumHair.LKNOT:
					path = "longknot";
				break;
				case (int)enumHair.LOOSE:
					path = "loose";
				break;
				case (int)enumHair.MESSY:
					path = "messy1";
				break;
				case (int)enumHair.PAGE:
					path = "mohawk";
				break;
				case (int)enumHair.PARTED:
					path = "page";
				break;
				case (int)enumHair.PIXIE:
					path = "parted";
				break;
				case (int)enumHair.PLAIN:
					path = "pixie";
				break;
				case (int)enumHair.PONYTAIL:
					path = "plain";
				break;
				case (int)enumHair.PRINCESS:
					path = "princess";
				break;
				case (int)enumHair.SHAWK:
					path = "shorthawk";
				break;
				case (int)enumHair.SKNOT:
					path = "shortknot";
				break;
				case (int)enumHair.SHOULDERL:
					path = "shoulderl";
				break;
				case (int)enumHair.SHOULDERR:
					path = "shoulderr";
				break;
				case (int)enumHair.SWOOP:
					path = "swoop";
				break;
				case (int)enumHair.UNKEMPT:
					path = "unkempt";
				break;
				case (int)enumHair.XLONG:
					path = "xlong";
				break;
				case (int)enumHair.XLONGKNOT:
					path = "xlongknot";
				break;
				case (int)enumHair.NONE:
					path = "default";
				break;
				default:
					path="default";
				break;
			}
	return path;
}
public string backEarsName(int i){
	string path="";
	switch(i){
				case (int)enumEars.BIGDARK:
					path = "bigdark";
				break;
				case (int)enumEars.BIGELF:
					path = "bigdarkelf";
				break;
				case (int)enumEars.BIGLIGHT:
					path = "biglight";
				break;
				case (int)enumEars.BIGTANNED:
					path = "bigtanned";
				break;
				case (int)enumEars.ELVENDARK:
					path = "elvendark";
				break;
				case (int)enumEars.ELVEN:
					path = "elvendarkelf";
				break;
				case (int)enumEars.ELVENLIGHT:
					path = "elvenlight";
				break;
				case (int)enumEars.ELVENTANNED:
					path = "elventanned";
				break;
				case (int)enumEars.LONGDARK:
					path = "longdark";
				break;
				case (int)enumEars.LONGELF:
					path = "longdarkelf";
				break;
				case (int)enumEars.LONGLIGHT:
					path = "longlight";
				break;
				case (int)enumEars.LONGTANNED:
					path = "longtanned";
				break;
				case (int)enumEars.NONE:
					path = "default";
				break;
				default:
					path="default";
				break;
			}
	return path;
}
public string backEyesName(int i){
	string path="";
	switch(i){
				case (int)enumEyes.BLUE:
					path = "blue";
				break;
				case (int)enumEyes.BROWN:
					path = "brown";
				break;
				case (int)enumEyes.GRAY:
					path = "gray";
				break;
				case (int)enumEyes.GREEN:
					path = "green";
				break;
				case (int)enumEyes.PURPLE:
					path = "purple";
				break;
				case (int)enumEyes.RED:
					path = "red";
				break;
				case (int)enumEars.NONE:
					path = "default";
				break;
				default:
					path="default";
				break;
			}
	return path;
}
public string backNoseName(int i){
	string path="";
	switch(i){
				case (int)enumNose.BIGDARK:
					path = "bignose_dark";
				break;
				case (int)enumNose.BIGELF:
					path = "bignose_darkelf";
				break;
				case (int)enumNose.BIGLIGHT:
					path = "bignose_light";
				break;
				case (int)enumNose.BIGTANNED:
					path = "bignose_tanned";
				break;
				case (int)enumNose.BUTTONDARK:
					path = "buttonnose_dark";
				break;
				case (int)enumNose.STRAIGHT:
					path = "straightnose_dark";
				break;
				case (int)enumNose.NONE:
					path = "default";
				break;
				default:
					path="default";
				break;
			}
	return path;
}

public string backFacialName(int i){
	string path="";
	switch(i){
				case (int)enumFacial.BEARD:
					path = "beard";
				break;
				case (int)enumFacial.BIGSTACHE:
					path = "bigstache";
				break;
				case (int)enumFacial.FIVECLOCK:
					path = "fiveoclock";
				break;
				case (int)enumFacial.FRANCHSTACHE:
					path = "frenchstache";
				break;
				case (int)enumFacial.MUSTACHE:
					path = "mustache";
				break;
				case (int)enumFacial.NONE:
					path = "default";
				break;
				default:
					path="default";
				break;
			}
	return path;
}
public string backArmsName(int i){
	string path="";
	switch(i){
				case (int)enumArms.LEATHER:
					path = "leather";
				break;
				case (int)enumArms.PLATEMAIL:
					path = "platemail";
				break;
				case (int)enumArms.SINGLEATHER:
					path = "single_leather";
				break;
				case (int)enumArms.NONE:
					path = "default";
				break;
				default:
					path="default";
				break;
			}
	return path;
}
public string backBackName(int i){
	string path="";
	switch(i){
				case (int)enumBack.QUIVER:
					path = "quiver";
				break;
				case (int)enumBack.CAPE:
					path = "cape";
				break;
				case (int)enumBack.TATTERCAPE:
					path = "tattercape";
				break;
				case (int)enumBack.TRIMCAPE:
					path = "trimcape";
				break;
				case (int)enumBack.NONE:
					path = "default";
				break;
				default:
					path="default";
				break;
			}
	return path;
}
public string backChestName(int i){
	string path="";
	switch(i){
				case (int)enumChest.APRON:
					path = "apron";
				break;
				case (int)enumChest.TABARD:
					path = "chain_tabard";
				break;
				case (int)enumChest.CHAINMAIL:
					path = "chainmail";
				break;
				case (int)enumChest.LEATHER:
					path = "leather";
				break;
				case (int)enumChest.PLATEMAIL:
					path = "platemail";
				break;
				case (int)enumChest.SHIRTLONG:
					path = "shirt_longsleeve";
				break;
				case (int)enumChest.SHIRTLESS:
					path = "shirt_sleeveless";
				break;
				case (int)enumChest.CORSET:
					path = "corset";
				break;
				case (int)enumChest.DRESS:
					path = "dress_w_sash_female";
				break;
				case (int)enumChest.OVERSKIRT:
					path = "overskirt";
				break;
				case (int)enumChest.TIGHTDRESS:
					path = "tightdress";
				break;
				case (int)enumChest.TUNIC:
					path = "tunic";
				break;
				case (int)enumChest.UNDERDRESS:
					path = "underdress";
				break;
				case (int)enumChest.VEST:
					path = "vest";
				break;
				case (int)enumChest.NONE:
					path = "default";
				break;
				default:
					path="default";
				break;
			}
	return path;
}
public string backFeetName(int i){
	string path="";
	switch(i){
				case (int)enumFeet.PLATEMAIL:
					path = "platemail";
				break;
				case (int)enumFeet.SHOES:
					path = "shoes";
				break;
				case (int)enumFeet.BOOTS:
					path = "boots";
				break;
				case (int)enumFeet.SLIPPERS:
					path = "slippers";
				break;
				case (int)enumFeet.NONE:
					path = "default";
				break;
				default:
					path="default";
				break;
			}
	return path;
}
public string backHandName(int i){
	string path="";
	switch(i){
				case (int)enumHand.PLATEMAIL:
					path = "platemail";
				break;
				case (int)enumHand.CLOTH:
					path = "cloth";
				break;		
				case (int)enumHand.NONE:
					path = "default";
				break;
				default:
					path="default";
				break;
			}
	return path;
}
public string backHeadName(int i){
	string path="";
	switch(i){
				case (int)enumHead.BANDANA:
					path = "bandana";
				break;
				case (int)enumHead.CHAINMAIL:
					path = "chainmail";
				break;	
				case (int)enumHead.CROWN:
					path = "crown";
				break;
				case (int)enumHead.HOOD:
					path = "hood";
				break;
				case (int)enumHead.LEATHER:
					path = "leather";
				break;
				case (int)enumHead.MASK:
					path = "mask";
				break;
				case (int)enumHead.PLATEMAIL:
					path = "platemail";
				break;
				case (int)enumHead.REINFORCED:
					path = "reinforced";
				break;	
				case (int)enumHead.SPIKED:
					path = "spiked";
				break;	
				case (int)enumHead.NONE:
					path = "default";
				break;
				default:
					path="default";
				break;
			}
	return path;
}
public string backLegsName(int i){
	string path="";
	switch(i){
				case (int)enumLegs.PANTS:
					path = "pants";
				break;
				case (int)enumLegs.PLATEMAIL:
					path = "platemail";
				break;
				case (int)enumLegs.SKIRT:
					path = "skirt";
				break;
				case (int)enumLegs.OVERSKIRT:
					path = "overskirt";
				break;		
				case (int)enumLegs.NONE:
					path = "default";
				break;
				default:
					path="default";
				break;
			}
	return path;
}
public string backNeckName(int i){
	string path="";
	switch(i){
				case (int)enumNeck.SCRAFT:
					path = "scarf";
				break;
				case (int)enumNeck.CAPECLIP:
					path = "capeclip";
				break;
				case (int)enumNeck.CAPETIE:
					path = "capetie";
				break;		
				case (int)enumNeck.NONE:
					path = "default";
				break;
				default:
					path="default";
				break;
			}
	return path;
}
public string backWaistName(int i){
	string path="";
	switch(i){
				case (int)enumWaist.CLOTH:
					path = "cloth";
				break;
				case (int)enumWaist.LEATHER:
					path = "leather";
				break;		
				case (int)enumLegs.NONE:
					path = "default";
				break;
				default:
					path="default";
				break;
			}
	return path;
}
public void loadAnimationClip(string catalogName, bool isMan,string characterPart,string path){

	if(catalogName !="default"){
		if(isMan){
			arrayOneObjectAnimationHandler = Resources.LoadAll<AnimationClip>(path+characterPart+"/male/"+catalogName);
		}else{

			arrayOneObjectAnimationHandler = Resources.LoadAll<AnimationClip>(path+characterPart+"/female/"+catalogName);
		}
		
	}else{
		arrayOneObjectAnimationHandler = Resources.LoadAll<AnimationClip>(path+characterPart+"/default");
	}
	

}

public void customizeAnimationSet(AnimationClip[] other,int actual,string nameAnimationPrefix,Animator overideAnimator){
	string moveName;
	int placeInArray=0;
	int animationCount = 6;

	//playerObject = GameObject.Find("player");
	//thePlayerAnimator = playerObject.GetComponent<Animator>();
	if(animatorOverrideController == null){	
		//animatorOverrideController = new AnimatorOverrideController(thePlayerAnimator.runtimeAnimatorController);
		animatorOverrideController = new AnimatorOverrideController(overideAnimator.runtimeAnimatorController);
	}
	//thePlayerAnimator.runtimeAnimatorController = animatorOverrideController;
	overideAnimator.runtimeAnimatorController  = animatorOverrideController;
	
	moveName = "die";

	animatorOverrideController[nameAnimationPrefix+"_"+moveName] = other[4];

	

	for(int j=0;j<animationCount;j++){
		switch(j){
			case 0:
				moveName = "bow";
				placeInArray = 0;
			break;
			case 1:
				moveName = "face";
				placeInArray = 5;
			break;
			case 2:
				moveName = "slash";
				placeInArray = 9;
			break;
			case 3:
				moveName = "spell";
				placeInArray = 13;
			break;
			case 4:
				moveName = "thrust";
				placeInArray = 17;
			break;
			case 5:
				moveName = "walk";
				placeInArray = 21;
			break;
		}

		for(int i=0;i<4;i++){	
				switch(i){
					case 0:
						animatorOverrideController[nameAnimationPrefix+"_"+moveName+"_down"] = other[placeInArray+i];
					break;
					case 1:
						animatorOverrideController[nameAnimationPrefix+"_"+moveName+"_left"] = other[placeInArray+i];
					break;
					case 2:
						animatorOverrideController[nameAnimationPrefix+"_"+moveName+"_right"] = other[placeInArray+i];
					break;
					case 3:
						animatorOverrideController[nameAnimationPrefix+"_"+moveName+"_up"] = other[placeInArray+i];
					break;
				}	
		}	
		
		
	}	
}


#if UNITY_EDITOR
	public void CreateSprite(string pathSpriteReander, string nameSprite, string PathToSprite){

		Sprite[] sprites = Resources.LoadAll<Sprite>(PathToSprite); // load all sprites in "assets/Resources/sprite" folder
			
		for(int k=0;k<=24;k++){			
			switch(k){
				case 0:
					numberFrame=6;
					sufix = "_hu_0";
					endNameFile = "_player_die.anim";
				break;
				case 1:
					numberFrame=7;
					sufix = "_sc_d_0";
					endNameFile = "_player_spell_down.anim";
				break;
				case 2:
					numberFrame=7;
					sufix = "_sc_l_0";
					endNameFile = "_player_spell_left.anim";
				break;
				case 3:
					numberFrame=7;
					sufix = "_sc_r_0";
					endNameFile = "_player_spell_right.anim";
				break;
				case 4:
					numberFrame=7;
					sufix = "_sc_t_0";
					endNameFile = "_player_spell_up.anim";
				break;
				case 5:
					numberFrame=13;
					sufix = "_sh_d_0";
					endNameFile = "_player_bow_down.anim";
				break;
				case 6:
					numberFrame=13;
					sufix = "_sh_l_0";
					endNameFile = "_player_bow_left.anim";
				break;
				case 7:
					numberFrame=13;
					sufix = "_sh_r_0";
					endNameFile = "_player_bow_right.anim";
				break;
				case 8:
					numberFrame=13;
					sufix = "_sh_t_0";
					endNameFile = "_player_bow_up.anim";
				break;
				case 9:
					numberFrame=6;
					sufix = "_sl_d_0";
					endNameFile = "_player_slash_down.anim";
				break;
				case 10:
					numberFrame=6;
					sufix = "_sl_l_0";
					endNameFile = "_player_slash_left.anim";
				break;
				case 11:
					numberFrame=6;
					sufix = "_sl_r_0";
					endNameFile = "_player_slash_right.anim";
				break;
				case 12:
					numberFrame=6;
					sufix = "_sl_t_0";
					endNameFile = "_player_slash_up.anim";
				break;
				case 13:
					numberFrame=8;
					sufix = "_th_d_0";
					endNameFile = "_player_thrust_down.anim";
				break;
				case 14:
					numberFrame=8;
					sufix = "_th_l_0";
					endNameFile = "_player_thrust_left.anim";
				break;
				case 15:
					numberFrame=8;
					sufix = "_th_r_0";
					endNameFile = "_player_thrust_right.anim";
				break;
				case 16:
					numberFrame=8;
					sufix = "_th_t_0";
					endNameFile = "_player_thrust_up.anim";
				break;
				case 17:
					numberFrame=9;
					sufix = "_wc_d_0";
					endNameFile = "_player_walk_down.anim";
				break;
				case 18:
					numberFrame=9;
					sufix = "_wc_l_0";
					endNameFile = "_player_walk_left.anim";
				break;
				case 19:
					numberFrame=9;
					sufix = "_wc_r_0";
					endNameFile = "_player_walk_right.anim";
				break;
				case 20:
					numberFrame=9;
					sufix = "_wc_t_0";
					endNameFile = "_player_walk_up.anim";
				break;
				case 21:
					numberFrame=1;
					sufix = "_wc_d_0";
					endNameFile = "_player_face_down.anim";
				break;
				case 22:
					numberFrame=1;
					sufix = "_wc_l_0";
					endNameFile = "_player_face_left.anim";
				break;
				case 23:
					numberFrame=1;
					sufix = "_wc_r_0";
					endNameFile = "_player_face_right.anim";
				break;
				case 24:
					numberFrame=1;
					sufix = "_wc_t_0";
					endNameFile = "_player_face_up.anim";
				break;
			}
			AnimationClip animClip;
			ObjectReferenceKeyframe[] spriteKeyFrames;

			animClip = new AnimationClip();

			animClip.frameRate = 10;   // FPS
			spriteBinding = new EditorCurveBinding();
			
			//Animation Die
			spriteBinding.type = typeof(SpriteRenderer);
			spriteBinding.path = pathSpriteReander;
			spriteBinding.propertyName = "m_Sprite";
			
			spriteKeyFrames = new ObjectReferenceKeyframe[numberFrame];
			int actualSprite=0;
			for(int j=0;j<sprites.Length;j++){
				if (sprites[j].name == nameSprite+sufix) {
					actualSprite = j;
					break;
				}
			}
			for(int i = 0; i < spriteKeyFrames.Length; i++) {
             			spriteKeyFrames[i] = new ObjectReferenceKeyframe();
						spriteKeyFrames[i].time = 0.1f*i;
						spriteKeyFrames[i].value = sprites[actualSprite+i];
			}

			AnimationClipSettings animClipSett = new AnimationClipSettings();
     		animClipSett.loopTime = true;
    		AnimationUtility.SetAnimationClipSettings(animClip, animClipSett);
			AnimationUtility.SetObjectReferenceCurve(animClip, spriteBinding, spriteKeyFrames);
			AssetDatabase.CreateAsset(animClip, "Assets/"+nameSprite+endNameFile);
    		AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
		}	
			
	}
 #endif
}
