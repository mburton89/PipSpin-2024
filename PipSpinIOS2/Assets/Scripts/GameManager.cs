using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour {
	
	private static GameManager _instance;
	public static GameManager Instance{get{return _instance ?? (_instance = new GameManager());}}
	public Background background;
	public SpinningLine line;
	public DateTime started; 
	public Projectile projectile;
	public FiringPatterns patterns;
	public HUDTab upperTab;
	public HUDTab leftTab;
	public HUDTab rightTab;
	//public HUDTab lowerTab;
	public v3PairsDispenser projectileDispenser;
	public CameraPivot camera;
	public LightRay lightRay;
	public GameObject GreenImages;

	//NATHALIE IS SMOKING HOT AND SHE'S MY GF. BOOYAH

	public TimeSpan RunningTime{get{return DateTime.UtcNow - started;}}
	public double pointsAlreadyAccumulated;
	public double timePoints; 

	public float projectileSpeedNegOne = 2.492f; //1.65f
	public float projectileSpeedZero = 2.492f; //2.1f
	public float projectileSpeed1 = 2.492f;
	public float projectileSpeed2 = 2.9f;
	public float projectileSpeed3 = 3.3f;
	public float projectileSpeed4 = 3.695f; 
	public float projectileSpeed5 = 4.1f; 
	public float projectileSpeed6 = 4.53f; 
	public float projectileSpeed7 = 4.88f; //
	public float projectileSpeed8 = 5.29f; 
	public float projectileSpeed9 = 5f; 
	public float projectileSpeed10 = 5.7f; 

	public float firstWaitTimeNegOne = 2f; //40 BPM
	public float firstWaitTimeZero = 1.5f; //50 BPM
	public float firstWaitTime1 = 1f; //60 BPM
	public float firstWaitTime2 = .8571428f; //70 BPM
	public float firstWaitTime3 = .75f; //80 BPM
	public float firstWaitTime4 = .6666667f; //90BPM
	public float firstWaitTime5 = .6f; //100BPM
	public float firstWaitTime6 = .5454545f; //110BPM
	public float firstWaitTime7 = .5f; //120BPM
	public float firstWaitTime8 = .4615385f; //130BPM
	public float firstWaitTime9 = .4285714f; //140BPM
	public float firstWaitTime10 = .4f; //150BPM
	
	public int lineSpinningSpeedNegOne = 181; //124
	public int lineSpinningSpeedZero = 181; //149
	public int lineSpinningSpeed1 = 181;
	public int lineSpinningSpeed2 = 214;
	public int lineSpinningSpeed3 = 241;
	public int lineSpinningSpeed4 = 276;
	public int lineSpinningSpeed5 = 302;
	public int lineSpinningSpeed6 = 336;
	public int lineSpinningSpeed7 = 359;
	public int lineSpinningSpeed8 = 390;
	public int lineSpinningSpeed9 = 424; //NOT USING
	public int lineSpinningSpeed10 = 445;

	public float speedChangeWaitTime = 4;
	public float secondWaitTime1 = 1.5f;
	public float secondWaitTime2 = 1.2f;
	public float secondWaitTime3 = .9f;
	public float secondWaitTime4 = .6f;

	public float lineRotation;

//	public int lineSpinningSpeed1 = 150;
//	public int lineSpinningSpeed2 = 178;
//	public int lineSpinningSpeed3 = 224;
//	public int lineSpinningSpeed4 = 296;
	
	public bool isGameOver;
	public bool isInsaneMode;

	public bool isComingFromFirstLevel;
	public bool isComingFromSecondLevel;

	public int menuSpeedNumber;

	//public int speed;

	public int Points {get; private set;}  

	public AudioClip cameraEndSound;
	public AudioClip gameOverSound;
	
	private GameManager(){
		//contructor to instantiate GameManager Singleton
	}

	void Start () {
		//Time.timeScale = 0.5f;  

		started = DateTime.UtcNow;    
	}

//	void Update () {
////		if(Application.loadedLevel == 1){
////			HandleKeyboard();   
////			//HandleUserTouches(); 
////		}
//
//		//timePoints = (RunningTime.TotalSeconds * 10 + pointsAlreadyAccumulated);
//		//Debug.Log("timePoints == " + timePoints);
////		Debug.Log("timePoints: " + timePoints);
////		if(RunningTime.TotalSeconds > 15f){  
////			PlayerPrefs.SetInt("Mode", PlayerPrefs.GetInt("Mode") + 1);
////			determineMode();			 
////		} 
//	}

	public void HandleKeyboard(){
		if (Input.GetKey(KeyCode.UpArrow)) {
			restartSession(); 
		}
	} 

	public void HandleUserTouches(){
		for (int i = 0; i < Input.touchCount; i++){  
			Touch touch = Input.GetTouch(i);
			if (touch.phase >= TouchPhase.Began){ //&& touch.tapCount == 1){
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);  
					restartSession();
			}
		}
	}
	 
	public void displayGameOverScreen(){
		line.canSpin = false;
		initiateGameOverAnimation();
		recordScore();
		//goToGameOverScene();
	}

	public void initiateGameOverAnimation(){
		StartCoroutine(initiateGameOverAnimationCo()); 
	}

	private IEnumerator initiateGameOverAnimationCo(){ 
//		upperTab.lowerUpperTab();
//		leftTab.lowerUpperTab();
//		rightTab.lowerUpperTab();
		//lowerTab.lowerUpperTab();
		//lightRay.flicker();
		projectileDispenser.canFire = false;
		AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
		//AudioSource.PlayClipAtPoint(cameraEndSound, transform.position);
		Projectile[] projectiles = FindObjectsOfType(typeof(Projectile)) as Projectile[];
		foreach (Projectile projectile in projectiles){
			//projectile.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
			projectile.GetComponent<Projectile>().Speed = 0;
			//projectile.rigidbody.velocity = Vector3.zero;
			//projectile.rigidbody.angularVelocity = Vector3.zero;
		}

		yield return new WaitForSeconds (.25f);
		camera.rotateGameOver(); 

		yield return new WaitForSeconds (.125f);
		GreenImages.SetActive(true);
		yield return new WaitForSeconds (.375f);
        //Application.LoadLevel(1);
        //SceneManager.LoadScene(1);

        if (PlayerPrefs.GetInt("hasHackerEdition") != 1){
            determineNextScene();
        }else {
            SceneManager.LoadScene(1);
        }
	}

	public void restartSession(){
		//isGameOver = false;
		Debug.Log("MORE SHTUFF");
//		upperTab.raiseUpperTab();  
//		leftTab.raiseLeftTab();
//		rightTab.lowerRightTab();
//		lowerTab.openLowerTab(); 
		returnToGame();
	}

	public void ResetPointsToZero(){
		Points = 0;     
	} 

	public void ResetPoints(int points){ 
		Points = points;
	}  
	
	public void AddPoints(int pointsToAdd){
		Points += pointsToAdd;
	}

	public void determineMode(){
		resetTimer();
	}

	public void resetTimer(){
		started = DateTime.UtcNow;
	}
 
	public void returnToGame(){
		StartCoroutine(returnToGameCo());    
	}
	
	private IEnumerator returnToGameCo(){   
		yield return new WaitForSeconds (.1f);   
		if(Application.loadedLevel == 1){  
			Debug.Log("SMELLOOO");
			Application.LoadLevel(0); 
		} 
	}

	public void recordScore(){
		float score;
		score = (float)RunningTime.TotalSeconds;  
		if(Application.loadedLevel == 1){
			if(score > PlayerPrefs.GetFloat("insaneModeHighScore")){
				PlayerPrefs.SetFloat("insaneModeHighScore",score);
			}
		}else{
			if(score > PlayerPrefs.GetFloat("normalModeHighScore")){
				PlayerPrefs.SetFloat("normalModeHighScore",score);
			}
		}
	}

    public void determineNextScene() 
	{
        SceneManager.LoadScene(1);
  //      if (PlayerPrefs.GetInt("PlayerLevel") > 1)
		//{
		//	PlayerPrefs.SetInt("adCounter", PlayerPrefs.GetInt("adCounter") + 1);
		//	if (Advertisement.IsReady())
		//	{
		//		if (PlayerPrefs.GetInt("adCounter") >= 7)
		//		{
		//			SceneManager.LoadScene(5);
		//		}
		//		else
		//		{
		//			SceneManager.LoadScene(1);
		//		}
		//	}
		//	else
		//	{
		//		SceneManager.LoadScene(1);
		//	}
		//}
		//else
		//{
			
		//}
	}
}