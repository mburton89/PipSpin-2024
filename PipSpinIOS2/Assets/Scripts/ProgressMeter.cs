using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressMeter : MonoBehaviour {
	
	public DateTime started; 
	public TimeSpan RunningTime{get{return DateTime.UtcNow - started;}}
	
	public BlinkingSlot slot1;
	public BlinkingSlot slot2;
	public BlinkingSlot slot3;
	public BlinkingSlot slot4;
	public BlinkingSlot slot5;
	public BlinkingSlot slot6;
	public BlinkingSlot slot7;
	public BlinkingSlot slot8;
	public BlinkingSlot slot9;
	public BlinkingSlot slot10;
	public BlinkingSlot slot11;
	public BlinkingSlot slot12;
	public BlinkingSlot slot13;
	public BlinkingSlot slot14;
	public BlinkingSlot slot15;
	
	public bool slot1IsLit;
	public bool slot2IsLit;
	public bool slot3IsLit;
	public bool slot4IsLit;
	public bool slot5IsLit;
	public bool slot6IsLit;
	public bool slot7IsLit;
	public bool slot8IsLit;
	public bool slot9IsLit;
	public bool slot10IsLit;
	public bool slot11IsLit;
	public bool slot12IsLit;
	public bool slot13IsLit;
	public bool slot14IsLit;
	public bool slot15IsLit;

	public GameObject leftNumber;
	public GameObject rightNumber;

	public v3PairsDispenser dispenser;
	public GameObject levelUpText;
	public SpinningLine line;

	public GameObject levelUpStuff;

	public MusicManager musicManager;
	public AudioClip robo1;
	public AudioClip robo2;
	public AudioClip robo3;
	public AudioClip levelUpSound;
	private static System.Random random = new System.Random();
	 
	public GameObject Light1;
	public GameObject Light2;
	public GameObject Light3;
	public GameObject Light4;
	public GameObject Light5;
	public GameObject Light6;
	
	private float nextActionTime;
	private float period = 6.0f;

	public GameObject BGBuzz;
	//private float period = .5f;
	
	// Use this for initialization
	void Start () {
		nextActionTime = 0; //Time.time + 5.0f;
		//started = DateTime.UtcNow;
		resetProgressMeter();  
		establishLeftAndRightNumber();
		setUpSmallNo10();
		if(leftNumber.GetComponent<SpriteRenderer>().sprite.name == "No10MiddleGrey"){
			period = 12.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Time.time > nextActionTime ) {
			nextActionTime = Time.time + period;  
//			Debug.Log("TIME: " + Time.time);
//			Debug.Log("NAT: " + nextActionTime);
			incrementBlinkingSlots();
		}
		
		//determineSlotsStatus();
	}

	public void incrementBlinkingSlots(){
		if(!slot1IsLit){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ProgressMeterLvl1", typeof(Sprite)) as Sprite;
			slot1IsLit = true;
		}else if(!slot2IsLit){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ProgressMeterLvl2", typeof(Sprite)) as Sprite;
			slot2IsLit = true;
		}else if(!slot3IsLit){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ProgressMeterLvl3", typeof(Sprite)) as Sprite;
			slot3IsLit = true;
		}else if(!slot4IsLit){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ProgressMeterLvl4", typeof(Sprite)) as Sprite;
			slot4IsLit = true;
		}else if(!slot5IsLit){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ProgressMeterLvl5", typeof(Sprite)) as Sprite;
			slot5IsLit = true;
		}else if(!slot6IsLit){
			if(leftNumber.GetComponent<SpriteRenderer>().sprite.name == "No10MiddleGrey"){
				if(PlayerPrefs.GetInt("PlayerLevel") == 10){
						PlayerPrefs.SetInt("PlayerLevel", 11);
				}
				displayLevel10BeatenScreen();
			}else{


				//JUST TOOK OUT
				//				gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ProgressMeterLvl6", typeof(Sprite)) as Sprite;
				//				slot6IsLit = true;
				//				dispenser.stopFiringProjectiles();
				//				levelUp();//MUST BE EXECUTED BEFORE loadNextLevel()
				//				displayLevelUpGraphic();
				loadNextLevel();
			}
		}
	}


	public void incrementBlinkingSlots1(){
		if(!slot1IsLit){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ProgressMeterLvl1", typeof(Sprite)) as Sprite;
			slot1IsLit = true;
		}else if(!slot2IsLit){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ProgressMeterLvl2", typeof(Sprite)) as Sprite;
			slot2IsLit = true;
		}else if(!slot3IsLit){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ProgressMeterLvl3", typeof(Sprite)) as Sprite;
			slot3IsLit = true;
		}else if(!slot4IsLit){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ProgressMeterLvl4", typeof(Sprite)) as Sprite;
			slot4IsLit = true;
		}else if(!slot5IsLit){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ProgressMeterLvl5", typeof(Sprite)) as Sprite;
			slot5IsLit = true;
		}else if(!slot6IsLit){
			if(leftNumber.GetComponent<SpriteRenderer>().sprite.name == "No10MiddleGrey"){
				displayLevel10BeatenScreen();
			}else{


				//JUST TOOK OUT
//				gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ProgressMeterLvl6", typeof(Sprite)) as Sprite;
//				slot6IsLit = true;
//				dispenser.stopFiringProjectiles();
//				levelUp();//MUST BE EXECUTED BEFORE loadNextLevel()
//				displayLevelUpGraphic();
				loadNextLevel();
			}
		}
	}

//	public void incrementBlinkingSlots(){
//		if(!slot1IsLit){
//			slot1.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
//			slot1IsLit = true;
//		}else if(!slot2IsLit){
//			slot2.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
//			slot2IsLit = true;
//		}else if(!slot3IsLit){
//			slot3.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
//			slot3IsLit = true;
//		}else if(!slot4IsLit){
//			slot4.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
//			slot4IsLit = true;
//		}else if(!slot5IsLit){
//			slot5.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
//			slot5IsLit = true;
//		}else if(!slot6IsLit){
//			slot6.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
//			slot6IsLit = true;
//		}else if(!slot7IsLit){
//			slot7.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
//			slot7IsLit = true;
//		}else if(!slot8IsLit){
//			slot8.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
//			slot8IsLit = true;
//		}else if(!slot9IsLit){
//			slot9.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
//			slot9IsLit = true;
//		}else if(!slot10IsLit){
//			slot10.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
//			slot10IsLit = true;
//		}else if(!slot11IsLit){
//			slot11.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
//			slot11IsLit = true;
//		}else if(!slot12IsLit){
//			slot12.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
//			slot12IsLit = true;
//		}else if(!slot13IsLit){
//			slot13.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
//			slot13IsLit = true;
//		}else if(!slot14IsLit){
//			slot14.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
//			slot14IsLit = true;
//		}else if(!slot15IsLit){
//			slot15.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
//			slot15IsLit = true;
//			dispenser.stopFiringProjectiles();
//			displayLevelUpGraphic();
//			loadNextLevel();
//		}
//	}
	
	//	public void determineSlotsStatus(){
	//		if(RunningTime.TotalSeconds >= 2 && RunningTime.TotalSeconds < 4){  
	//			slot1.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
	//		}else if(RunningTime.TotalSeconds >= 4 && RunningTime.TotalSeconds < 6){  
	//			slot2.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
	//		}else if(RunningTime.TotalSeconds >= 6 && RunningTime.TotalSeconds < 8){  
	//			slot3.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
	//		}else if(RunningTime.TotalSeconds >= 8 && RunningTime.TotalSeconds < 10){  
	//			slot4.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
	//		}else if(RunningTime.TotalSeconds >= 10 && RunningTime.TotalSeconds < 12){  
	//			slot5.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
	//		}else if(RunningTime.TotalSeconds >= 12 && RunningTime.TotalSeconds < 14){  
	//			slot6.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
	//		}else if(RunningTime.TotalSeconds >= 14 && RunningTime.TotalSeconds < 16){  
	//			slot7.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
	//		}else if(RunningTime.TotalSeconds >= 16 && RunningTime.TotalSeconds < 18){  
	//			slot8.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
	//		}else if(RunningTime.TotalSeconds >= 18 && RunningTime.TotalSeconds < 20){  
	//			slot9.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
	//		}else if(RunningTime.TotalSeconds >= 20 && RunningTime.TotalSeconds < 22){  
	//			slot10.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
	//		}else if(RunningTime.TotalSeconds >= 22 && RunningTime.TotalSeconds < 24){  
	//			slot11.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
	//		}else if(RunningTime.TotalSeconds >= 24 && RunningTime.TotalSeconds < 26){  
	//			slot12.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
	//		}else if(RunningTime.TotalSeconds >= 26 && RunningTime.TotalSeconds < 28){  
	//			slot13.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
	//		}else if(RunningTime.TotalSeconds >= 28 && RunningTime.TotalSeconds < 30){  
	//			slot14.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
	//		}else if(RunningTime.TotalSeconds >= 30){  
	//			slot15.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MiddleSlot", typeof(Sprite)) as Sprite;
	//		}
	//	}
	
	public void resetProgressMeter(){

		gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;

//		slot1.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
//		slot2.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
//		slot3.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
//		slot4.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
//		slot5.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
//		slot6.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
//		slot7.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
//		slot8.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
//		slot9.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
//		slot10.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
//		slot11.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
//		slot12.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
//		slot13.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
//		slot14.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
//		slot15.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
		
		slot1IsLit = false;
		slot2IsLit = false;
		slot3IsLit = false;
		slot4IsLit = false;
		slot5IsLit = false;
		slot6IsLit = false;
		slot7IsLit = false;
		slot8IsLit = false;
		slot9IsLit = false;
		slot10IsLit = false;
		slot11IsLit = false;
		slot12IsLit = false;
		slot13IsLit = false;
		slot14IsLit = false;
		slot15IsLit = false;
	}
	
	public void establishLeftAndRightNumber(){
		if(GameManager.Instance.menuSpeedNumber == 1){  
			leftNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No1Grey", typeof(Sprite)) as Sprite;
			rightNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No2", typeof(Sprite)) as Sprite;
		}else if(GameManager.Instance.menuSpeedNumber == 2){  
			leftNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No2Grey", typeof(Sprite)) as Sprite;
			rightNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No3", typeof(Sprite)) as Sprite;
		}else if(GameManager.Instance.menuSpeedNumber == 3){  
			leftNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No3Grey", typeof(Sprite)) as Sprite;
			rightNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No4", typeof(Sprite)) as Sprite;
		}else if(GameManager.Instance.menuSpeedNumber == 4){  
			leftNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No4Grey", typeof(Sprite)) as Sprite;
			rightNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No5", typeof(Sprite)) as Sprite;
		}else if(GameManager.Instance.menuSpeedNumber == 5){  
			leftNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No5Grey", typeof(Sprite)) as Sprite;
			rightNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No6", typeof(Sprite)) as Sprite;
		}else if(GameManager.Instance.menuSpeedNumber == 6){  
			leftNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No6Grey", typeof(Sprite)) as Sprite;
			rightNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No7", typeof(Sprite)) as Sprite;
		}else if(GameManager.Instance.menuSpeedNumber == 7){  
			leftNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No7Grey", typeof(Sprite)) as Sprite;
			rightNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No8", typeof(Sprite)) as Sprite;
		}else if(GameManager.Instance.menuSpeedNumber == 8){  
			leftNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No8Grey", typeof(Sprite)) as Sprite;
			rightNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No9", typeof(Sprite)) as Sprite;
		}else if(GameManager.Instance.menuSpeedNumber == 9){  
			leftNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No9Grey", typeof(Sprite)) as Sprite;
			rightNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No10Middle", typeof(Sprite)) as Sprite;
		}else if(GameManager.Instance.menuSpeedNumber == 10){  
			leftNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No10MiddleGrey", typeof(Sprite)) as Sprite;
			rightNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("QuestionMark2", typeof(Sprite)) as Sprite;
		}
	}

	public void displayLevelUpGraphic(){
		//levelUpText.GetComponent<SpriteRenderer>().enabled = true;
		levelUpStuff.SetActive(true); 
	}

	public void loadNextLevel(){
		StartCoroutine(loadNextLevelCo()); 
	}
	
	private IEnumerator loadNextLevelCo(){ 
		dispenser.stopFiringProjectiles();
		yield return new WaitForSeconds (1.5f);
		BGBuzz.GetComponent<AudioSource>().volume = 0; 
		AudioSource.PlayClipAtPoint(levelUpSound, transform.position); 
		gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ProgressMeterLvl6", typeof(Sprite)) as Sprite;
		slot6IsLit = true;
		levelUp();
		displayLevelUpGraphic();
		//musicManager.playLevelUpSound();
		yield return new WaitForSeconds (1.5f);
		playRoboNoise();
		yield return new WaitForSeconds (1.5f);
		line.canSpin = false;
		yield return new WaitForSeconds (.5f);
		GameManager.Instance.menuSpeedNumber = GameManager.Instance.menuSpeedNumber + 1;
		//Application.LoadLevel(2);
        SceneManager.LoadScene(2);
	}

	//MUST BE EXECUTED BEFORE loadNextLevel()
	public void levelUp(){
		if(PlayerPrefs.GetInt("PlayerLevel") < 10){
			if(PlayerPrefs.GetInt("PlayerLevel") == GameManager.Instance.menuSpeedNumber){
				PlayerPrefs.SetInt("PlayerLevel", GameManager.Instance.menuSpeedNumber + 1);
			}
		}
	}

	public void setUpSmallNo10(){
		rightNumber.transform.localScale = new Vector3(.375f, .375f, 1);
	}

	public void displayLevel10BeatenScreen(){
        //Unlock Achievement and submit score to leaderboard
        //Application.LoadLevel(3);
        SceneManager.LoadScene(3);
    }

	public void endLevel(){
		StartCoroutine(endLevelCo()); 
	}
	
	private IEnumerator endLevelCo(){ 
		dispenser.stopFiringProjectiles();
		yield return new WaitForSeconds (1.5f);
		//AudioSource.PlayClipAtPoint(levelUpSound, transform.position); 
		gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ProgressMeterLvl6", typeof(Sprite)) as Sprite;
		slot6IsLit = true;
		levelUp();
		displayLevelUpGraphic();
	}

	public void playRoboNoise(){
		float sequenceNumber = random.Next (1, 4);
		if(sequenceNumber == 1){ 
			AudioSource.PlayClipAtPoint(robo1, transform.position);
		}else if(sequenceNumber == 2){
			AudioSource.PlayClipAtPoint(robo2, transform.position);
		}else if(sequenceNumber == 3){
			AudioSource.PlayClipAtPoint(robo3, transform.position);
		}
	}
}
