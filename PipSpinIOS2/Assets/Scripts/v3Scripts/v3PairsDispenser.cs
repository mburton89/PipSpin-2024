using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class v3PairsDispenser : MonoBehaviour {

	//DIRECTIONS
	public Vector2 downRight = new Vector2 (1, -1);
	public Vector2 downLeft = new Vector2 (-1, -1);

	//PROJECTILE SPAWN LOCATIONS
//	private Vector3 Left1ProjectileSpawnLocation = new Vector3 (-10.5f, 5f, 0);       
//	private Vector3 Left2ProjectileSpawnLocation = new Vector3 (-5.5f, 5f, 0);      
//	private Vector3 Right1ProjectileSpawnLocation = new Vector3 (5.5f, 5f, 0);  
//	private Vector3 Right2ProjectileSpawnLocation = new Vector3 (10.5f, 5, 0);

//	private Vector3 Left1ProjectileSpawnLocation = new Vector3 (-11f, 5.5f, 0);       
//	private Vector3 Left2ProjectileSpawnLocation = new Vector3 (-6f, 5.5f, 0);      
//	private Vector3 Right1ProjectileSpawnLocation = new Vector3 (6f, 5.5f, 0);  
//	private Vector3 Right2ProjectileSpawnLocation = new Vector3 (11f, 5.5f, 0); 

	private Vector3 Left1ProjectileSpawnLocation = new Vector3 (-13f, 7.5f, 0);       
	private Vector3 Left2ProjectileSpawnLocation = new Vector3 (-8f, 7.5f, 0);      
	private Vector3 Right1ProjectileSpawnLocation = new Vector3 (8f, 7.5f, 0);  
	private Vector3 Right2ProjectileSpawnLocation = new Vector3 (13f, 7.5f, 0); 

	//OBJECTS
	public Projectile projectile;
	public Projectile projectile2;
	public virtual Vector2 direction { get; protected set;}
	public SpinningLine line;
	public Background background;
	public DateTime started; 
	public TimeSpan RunningTime{get{return DateTime.UtcNow - started;}}
	private static System.Random random = new System.Random();
	public GUISkin Skin;

	public AudioClip Woosh1;
	public AudioClip Clow;
	public AudioClip E;
	public AudioClip G;
	public AudioClip Chi;

	public HUDTab upperTab;
	public HUDTab leftTab;
	public HUDTab rightTab;

	//VARIABLES
	public double timePoints;
	public float waitTime;  
	public float waitTime2;  
	public int activeProjectiles;
	public int spinningSpeed;

	public bool canFire;
	public bool hasWaitedForFirstSpeedChange;
	public bool hasWaitedForSecondSpeedChange;
	public bool hasWaitedForThirdSpeedChange;
	public bool hasWaitedForFourthSpeedChange;
	public bool hasWaitedForFifthSpeedChange;
	public bool hasWaitedForSixthSpeedChange;
	public bool hasWaitedForSeventhSpeedChange;
	public bool hasWaitedForEighthSpeedChange;
	public bool hasWaitedForNinthSpeedChange;

	public bool hasMostRecentlyFired1And2;
	public bool hasMostRecentlyFired1And3;  
	public bool hasMostRecentlyFired2And4;
	public bool hasMostRecentlyFired3And4;

	private float startGameWaitTime = .25f;

	public MusicManager musicManager;
	public GameObject bgBuzz;
	public float initialBGbuzzPitch;

	public Color lineColor;
	public GameObject GreenEndGameImages;
	public GameObject LevelUpStuff;
	public GameObject IntroText;
	public GameObject IntroBG;

	void Start () {
		//determineSpeeds();
		//showIntro();

		hasMostRecentlyFired1And2 = true;
		canFire = false;
		started = DateTime.UtcNow;
		//establishInitialSpeeds();

		//GameManager.Instance.menuSpeedNumber = 10;

		determineSpeeds();
		//initiateSpinScenario(); 
		//fireRandomSequence(); 
		line.flicker();

		lineColor = line.GetComponent<SpriteRenderer>().color;
		GreenEndGameImages.SetActive(false);
		LevelUpStuff.SetActive(false);
	}
	
	// Update is called once per frame
//	void Update () {
//		//Debug.Log ("Line Rotation " + line.transform.rotation.eulerAngles.z);
//		//determineSpeeds();
//		//determinePoints();
//	}

	public void fire1And2(){
		if(canFire){

			//AudioSource.PlayClipAtPoint(Clow, transform.position);
			//AudioSource.PlayClipAtPoint(E, transform.position);

			//musicManager.play1a2Sound(waitTime);

			//PROJECTILE 1
			var liveProjectile = (Projectile)Instantiate (projectile, Left1ProjectileSpawnLocation, transform.rotation); 
			liveProjectile.Initialize (gameObject, downRight, new Vector2(1, -1), -1); 
			liveProjectile.GetComponent<SpriteRenderer>().color = lineColor;
			
			//PROJECTILE 2
			var liveProjectile2 = (Projectile)Instantiate (projectile, Left2ProjectileSpawnLocation, transform.rotation); 
			liveProjectile2.Initialize (gameObject, downRight, new Vector2(1, -1), 1);
			liveProjectile2.GetComponent<SpriteRenderer>().color = lineColor;

//			liveProjectile.GetComponent<AudioSource>().clip = musicManager.LineBuzzC1;
//			liveProjectile.GetComponent<AudioSource>().Play();
//
//			liveProjectile2.GetComponent<AudioSource>().clip = musicManager.LineBuzzE1;
//			liveProjectile2.GetComponent<AudioSource>().Play();

			bgBuzz.GetComponent<AudioSource>().pitch = initialBGbuzzPitch;
			//bgBuzz.GetComponent<AudioSource>().panStereo = -.8f;
			
			hasMostRecentlyFired1And2 = true;
			hasMostRecentlyFired1And3 = false;
			hasMostRecentlyFired2And4 = false;
			hasMostRecentlyFired3And4 = false;
		}
	}

	public void fire1And3(){
		if(canFire){

			//AudioSource.PlayClipAtPoint(Clow, transform.position);
			//AudioSource.PlayClipAtPoint(G, transform.position);

			//musicManager.play1a3Sound(waitTime);

			//PROJECTILE 1
			var liveProjectile = (Projectile)Instantiate (projectile, Left1ProjectileSpawnLocation, transform.rotation); 
			liveProjectile.Initialize (gameObject, downRight, new Vector2(1, -1), -1);
			liveProjectile.GetComponent<SpriteRenderer>().color = lineColor;
			
			//PROJECTILE 3
			var liveProjectile3 = (Projectile)Instantiate (projectile, Right1ProjectileSpawnLocation, transform.rotation); 
			liveProjectile3.Initialize (gameObject, downLeft, new Vector2(-1, -1), -1);
			liveProjectile3.GetComponent<SpriteRenderer>().color = lineColor;

//			liveProjectile.GetComponent<AudioSource>().clip = musicManager.LineBuzzC1;
//			liveProjectile.GetComponent<AudioSource>().Play();
//
//			liveProjectile3.GetComponent<AudioSource>().clip = musicManager.LineBuzzG1;
//			liveProjectile3.GetComponent<AudioSource>().Play();

			//bgBuzz.GetComponent<AudioSource>().pitch = .105f;
			bgBuzz.GetComponent<AudioSource>().pitch = initialBGbuzzPitch + .005f;
			//bgBuzz.GetComponent<AudioSource>().panStereo = -.2f;

			hasMostRecentlyFired1And2 = false;
			hasMostRecentlyFired1And3 = true;
			hasMostRecentlyFired2And4 = false;
			hasMostRecentlyFired3And4 = false;
		}
	}

	public void fire2And4(){
		if(canFire){

//			AudioSource.PlayClipAtPoint(E, transform.position);
//			AudioSource.PlayClipAtPoint(Chi, transform.position);

			//musicManager.play2a4Sound(waitTime);

			//PROJECTILE 2
			var liveProjectile2 = (Projectile)Instantiate (projectile, Left2ProjectileSpawnLocation, transform.rotation); 
			liveProjectile2.Initialize (gameObject, downRight, new Vector2(1, -1), 1); 
			liveProjectile2.GetComponent<SpriteRenderer>().color = lineColor;
			
			//PROJECTILE 4
			var liveProjectile4 = (Projectile)Instantiate (projectile, Right2ProjectileSpawnLocation, transform.rotation); 
			liveProjectile4.Initialize (gameObject, downLeft, new Vector2(-1, -1), 1);
			liveProjectile4.GetComponent<SpriteRenderer>().color = lineColor;

//			liveProjectile2.GetComponent<AudioSource>().clip = musicManager.LineBuzzE1;
//			liveProjectile2.GetComponent<AudioSource>().Play();
//
//			liveProjectile4.GetComponent<AudioSource>().clip = musicManager.LineBuzzC2;
//			liveProjectile4.GetComponent<AudioSource>().Play();

			bgBuzz.GetComponent<AudioSource>().pitch = initialBGbuzzPitch + .01f;
			//bgBuzz.GetComponent<AudioSource>().panStereo = .2f;

			hasMostRecentlyFired1And2 = false;
			hasMostRecentlyFired1And3 = false;
			hasMostRecentlyFired2And4 = true;
			hasMostRecentlyFired3And4 = false;
		}
	}

	public void fire3And4(){
		if(canFire){

			//AudioSource.PlayClipAtPoint(G, transform.position);
			//AudioSource.PlayClipAtPoint(Chi, transform.position);

			//musicManager.play3a4Sound(waitTime);

			//PROJECTILE 3
			var liveProjectile3 = (Projectile)Instantiate (projectile, Right1ProjectileSpawnLocation, transform.rotation); 
			liveProjectile3.Initialize (gameObject, downLeft, new Vector2(-1, -1), -1); 
			liveProjectile3.GetComponent<SpriteRenderer>().color = lineColor;
			
			//PROJECTILE 4
			var liveProjectile4 = (Projectile)Instantiate (projectile, Right2ProjectileSpawnLocation, transform.rotation); 
			liveProjectile4.Initialize (gameObject, downLeft, new Vector2(-1, -1), 1);
			liveProjectile4.GetComponent<SpriteRenderer>().color = lineColor;

//			liveProjectile3.GetComponent<AudioSource>().clip = musicManager.LineBuzzG1;
//			liveProjectile3.GetComponent<AudioSource>().Play();
//
//			liveProjectile4.GetComponent<AudioSource>().clip = musicManager.LineBuzzC2;
//			liveProjectile4.GetComponent<AudioSource>().Play();

			bgBuzz.GetComponent<AudioSource>().pitch = initialBGbuzzPitch + .015f;
			//bgBuzz.GetComponent<AudioSource>().panStereo = .8f;

			hasMostRecentlyFired1And2 = false;
			hasMostRecentlyFired1And3 = false;
			hasMostRecentlyFired2And4 = false;
			hasMostRecentlyFired3And4 = true;
		}
	}

	public void fireRandomSequence(){

		if(hasMostRecentlyFired1And2){
			fireScenarioCompatablePost1And2();
		}else if(hasMostRecentlyFired1And3){
			fireScenarioCompatablePost1And3();
		}else if(hasMostRecentlyFired2And4){
			fireScenarioCompatablePost2And4();
		}else if(hasMostRecentlyFired3And4){
			fireScenarioCompatablePost3And4();
		}
	}

	public void fireScenarioCompatablePost1And2(){
		float sequenceNumber = random.Next (1, 8);
		if(sequenceNumber == 1){ 
			fire1And3();
			wait ();
		}else if(sequenceNumber == 2){
			fire2And4();
			wait ();
		}else if(sequenceNumber == 3){
			fire3And4();
			wait ();
		}else if(sequenceNumber == 4 || sequenceNumber == 7){
			initiateSpinScenario();
		}else if(sequenceNumber == 5){
			initiateBackAndForthIntersectingScenario();
		}else if(sequenceNumber == 6){
			initiateBackAndForthPairsScenario();
		}
		//wait ();
	}

	public void fireScenarioCompatablePost1And3(){
		float sequenceNumber = random.Next (1, 8);
		if(sequenceNumber == 1){   
			fire1And2();
			wait ();
		}else if(sequenceNumber == 2){
			fire2And4();
			wait ();
		}else if(sequenceNumber == 3){
			fire3And4();
			wait ();
		}else if(sequenceNumber == 4 || sequenceNumber == 7){
			initiateSpinScenario();
		}else if(sequenceNumber == 5){
			initiateBackAndForthIntersectingScenario();
		}else if(sequenceNumber == 6){
			initiateBackAndForthPairsScenario();
		}
	}

	public void fireScenarioCompatablePost2And4(){
		float sequenceNumber = random.Next (1, 8);
		if(sequenceNumber == 1){   
			fire1And2();
			wait ();
		}else if(sequenceNumber == 2){
			fire1And3();
			wait ();
		}else if(sequenceNumber == 3){
			fire3And4();
			wait ();
		}else if(sequenceNumber == 4 || sequenceNumber == 7){
			initiateSpinScenario();
		}else if(sequenceNumber == 5){
			//Debug.Log("THAT IS HAPPENING LALALALL");
			initiateBackAndForthIntersectingScenario();
		}else if(sequenceNumber == 6){
			initiateBackAndForthPairsScenario();
		}
	}

	public void fireScenarioCompatablePost3And4(){
		float sequenceNumber = random.Next (1, 8);
		if(sequenceNumber == 1){   
			fire1And2();
			wait ();
		}else if(sequenceNumber == 2){
			fire1And3();
			wait ();
		}else if(sequenceNumber == 3){
			fire2And4();
			wait ();
		}else if(sequenceNumber == 4 || sequenceNumber == 7){
			initiateSpinScenario();
		}else if(sequenceNumber == 5){
			initiateBackAndForthIntersectingScenario();
		}else if(sequenceNumber == 6){
			initiateBackAndForthPairsScenario();
		}
	}

	public void initiateSpinScenario(){
		StartCoroutine(SpinClockwiseCo());                
	}
	
	private IEnumerator SpinClockwiseCo(){
		bool isContinuing = true;
		bool isFiringClockwise;

		float sequenceNumber = random.Next (1, 3);
		if(sequenceNumber == 1){
			isFiringClockwise = true;
		}else{
			isFiringClockwise = false;
		}

		float sequenceNumber2 = random.Next (1, 5);
		while(sequenceNumber2 < 5){

			if(isFiringClockwise){
				fire2And4();
				//Debug.Log ("isFiringClockwise");
			}else{
				fire1And3();
				//Debug.Log ("isFiringCOUNTERClockwise");
			}

			yield return new WaitForSeconds (waitTime); 
			sequenceNumber2 ++;
		}
		fireRandomSequence(); 
	}

	public void initiateBackAndForthIntersectingScenario(){
		StartCoroutine(BackAndForthIntersectingCo());                
	}
	
	private IEnumerator BackAndForthIntersectingCo(){
		float sequenceNumber2 = random.Next (1, 3);
		while(sequenceNumber2 < 3){
			//Debug.Log ("BackAndForthIntersectingCo");
			fire1And3();
			yield return new WaitForSeconds (waitTime); 
			fire2And4();
			yield return new WaitForSeconds (waitTime);
			sequenceNumber2 ++;
		}
		fireRandomSequence();
	} 

	public void initiateBackAndForthPairsScenario(){
		StartCoroutine(BackAndForthPairsCo());                
	}
	
	private IEnumerator BackAndForthPairsCo(){
		float sequenceNumber2 = random.Next (1, 3);
		while(sequenceNumber2 < 3){
			//Debug.Log ("initiateBackAndForthPairsScenario");
			fire1And2();
			yield return new WaitForSeconds (waitTime); 
			fire3And4();
			yield return new WaitForSeconds (waitTime);
			sequenceNumber2 ++;
		}
		fireRandomSequence();
	} 

	//SPEED STUFF
	public void establishNegOneSpeeds(){
		StartCoroutine(establishNegOneSpeedsCo()); 
	}
	
	private IEnumerator establishNegOneSpeedsCo(){
		projectile.Speed = GameManager.Instance.projectileSpeedNegOne;
		projectile2.Speed = GameManager.Instance.projectileSpeedNegOne; 
		waitTime = GameManager.Instance.firstWaitTimeNegOne;
		line.spinningSpeed = GameManager.Instance.lineSpinningSpeedNegOne;  
		line.GetComponent<AudioSource>().pitch = .68f;
		initialBGbuzzPitch = .1f;

		if(PlayerPrefs.GetInt("hasSeenIntro") != 1){
			showIntro();
			yield return new WaitForSeconds (3); 
			PlayerPrefs.SetInt("hasSeenIntro",1);
		}


		yield return new WaitForSeconds (startGameWaitTime); 
		canFire = true;

		fireRandomSequence();
	}

	public void establishZeroSpeeds(){
		StartCoroutine(establishZeroSpeedsCo()); 
	}
	
	private IEnumerator establishZeroSpeedsCo(){
		projectile.Speed = GameManager.Instance.projectileSpeedZero;
		projectile2.Speed = GameManager.Instance.projectileSpeedZero; 
		waitTime = GameManager.Instance.firstWaitTimeZero;
		line.spinningSpeed = GameManager.Instance.lineSpinningSpeedZero;  
		line.GetComponent<AudioSource>().pitch = .7f;
		initialBGbuzzPitch = .11f;
		yield return new WaitForSeconds (startGameWaitTime); 
		canFire = true;
		fireRandomSequence();
	}
	
	public void establishInitialSpeeds(){
		StartCoroutine(establishInitialSpeedsCo()); 
	}

	private IEnumerator establishInitialSpeedsCo(){
		projectile.Speed = GameManager.Instance.projectileSpeed1;
		projectile2.Speed = GameManager.Instance.projectileSpeed1; 
		waitTime = GameManager.Instance.firstWaitTime1;
		waitTime2 = GameManager.Instance.secondWaitTime1;
		line.spinningSpeed = GameManager.Instance.lineSpinningSpeed1; 
		line.GetComponent<AudioSource>().pitch = .72f;
		initialBGbuzzPitch = .12f;
		hasWaitedForFirstSpeedChange = false; 
		yield return new WaitForSeconds (startGameWaitTime); 
		canFire = true;
		fireRandomSequence();
	}

	public void establishSpeed4(){
		StartCoroutine(establishSpeed4Co());                
	}
	
	private IEnumerator establishSpeed4Co(){
//			hasWaitedForFirstSpeedChange = true;
//			canFire = false;
//			yield return new WaitForSeconds (2); 
//			canFire = true;
//			line.spinningSpeed = GameManager.Instance.lineSpinningSpeed2;  
//			projectile.Speed = GameManager.Instance.projectileSpeed2;
//			projectile2.Speed = GameManager.Instance.projectileSpeed2; 
//			waitTime = GameManager.Instance.firstWaitTime2;

		projectile.Speed = GameManager.Instance.projectileSpeed2;
		projectile2.Speed = GameManager.Instance.projectileSpeed2; 
		waitTime = GameManager.Instance.firstWaitTime2;
		line.spinningSpeed = GameManager.Instance.lineSpinningSpeed2; 
		line.GetComponent<AudioSource>().pitch = .74f;
		initialBGbuzzPitch = .13f;
		yield return new WaitForSeconds (startGameWaitTime); 
		canFire = true;
		fireRandomSequence();
	}
	
	public void establishSpeed5(){
		StartCoroutine(establishSpeed5Co());                
	}
	
	private IEnumerator establishSpeed5Co(){
		projectile.Speed = GameManager.Instance.projectileSpeed3;
		projectile2.Speed = GameManager.Instance.projectileSpeed3; 
		waitTime = GameManager.Instance.firstWaitTime3;
		line.spinningSpeed = GameManager.Instance.lineSpinningSpeed3; 
		line.GetComponent<AudioSource>().pitch = .76f;
		initialBGbuzzPitch = .14f;
		yield return new WaitForSeconds (startGameWaitTime); 
		canFire = true;
		fireRandomSequence();
	}
	
	public void establishSpeed6(){
		StartCoroutine(establishSpeed6Co());                
	}
	
	private IEnumerator establishSpeed6Co(){
		projectile.Speed = GameManager.Instance.projectileSpeed4;
		projectile2.Speed = GameManager.Instance.projectileSpeed4; 
		waitTime = GameManager.Instance.firstWaitTime4;
		line.spinningSpeed = GameManager.Instance.lineSpinningSpeed4;  
		line.GetComponent<AudioSource>().pitch = .78f;
		initialBGbuzzPitch = .15f;
		yield return new WaitForSeconds (startGameWaitTime); 
		canFire = true;
		fireRandomSequence();
	}

	public void establishSpeed7(){
		StartCoroutine(establishSpeed7Co());                
	}
	
	private IEnumerator establishSpeed7Co(){
		projectile.Speed = GameManager.Instance.projectileSpeed5;
		projectile2.Speed = GameManager.Instance.projectileSpeed5; 
		waitTime = GameManager.Instance.firstWaitTime5;
		line.spinningSpeed = GameManager.Instance.lineSpinningSpeed5; 
		line.GetComponent<AudioSource>().pitch = .8f;
		initialBGbuzzPitch = .16f;
		yield return new WaitForSeconds (startGameWaitTime); 
		canFire = true;
		fireRandomSequence();
	}




	public void establishSpeed8(){
		StartCoroutine(establishSpeed8Co());                
	}
	
	private IEnumerator establishSpeed8Co(){
		projectile.Speed = GameManager.Instance.projectileSpeed6;
		projectile2.Speed = GameManager.Instance.projectileSpeed6; 
		waitTime = GameManager.Instance.firstWaitTime6;
		line.spinningSpeed = GameManager.Instance.lineSpinningSpeed6;  
		line.GetComponent<AudioSource>().pitch = .82f;
		initialBGbuzzPitch = .17f;
		yield return new WaitForSeconds (startGameWaitTime); 
		canFire = true;
		fireRandomSequence();
	}
	
	public void establishSpeed9(){
		StartCoroutine(establishSpeed9Co());                
	}
	
	private IEnumerator establishSpeed9Co(){
		projectile.Speed = GameManager.Instance.projectileSpeed7;
		projectile2.Speed = GameManager.Instance.projectileSpeed7; 
		waitTime = GameManager.Instance.firstWaitTime7;
		line.spinningSpeed = GameManager.Instance.lineSpinningSpeed7;
		line.GetComponent<AudioSource>().pitch = .84f;
		initialBGbuzzPitch = .18f;
		yield return new WaitForSeconds (startGameWaitTime); 
		canFire = true;
		fireRandomSequence();
	}
	
	public void establishSpeed10(){
		StartCoroutine(establishSpeed10Co());                
	}
	
	private IEnumerator establishSpeed10Co(){
		projectile.Speed = GameManager.Instance.projectileSpeed8;
		projectile2.Speed = GameManager.Instance.projectileSpeed8; 
		waitTime = GameManager.Instance.firstWaitTime8;
		line.spinningSpeed = GameManager.Instance.lineSpinningSpeed8; 
		line.GetComponent<AudioSource>().pitch = .86f;
		initialBGbuzzPitch = .19f;
		yield return new WaitForSeconds (startGameWaitTime); 
		canFire = true;
		fireRandomSequence();
	}
	
//	public void waitForEighthSpeedChange(){
//		StartCoroutine(waitForEighthSpeedChangeCo());                
//	}
//	
//	private IEnumerator waitForEighthSpeedChangeCo(){
//		if(hasWaitedForEighthSpeedChange == false){
//			hasWaitedForEighthSpeedChange = true;
//			canFire = false;
//			yield return new WaitForSeconds (2); 
//			canFire = true;
//			line.spinningSpeed = GameManager.Instance.lineSpinningSpeed8;   
//			projectile.Speed = GameManager.Instance.projectileSpeed8;
//			projectile2.Speed = GameManager.Instance.projectileSpeed8; 
//			waitTime = GameManager.Instance.firstWaitTime8;
//		}
//	}

	public void determineSpeeds(){
		if(GameManager.Instance.menuSpeedNumber == 1){  
			establishNegOneSpeeds();
		}else if(GameManager.Instance.menuSpeedNumber == 2){  
			establishZeroSpeeds();
		}else if(GameManager.Instance.menuSpeedNumber == 3){  
			establishInitialSpeeds();
		}else if(GameManager.Instance.menuSpeedNumber == 4){  
			establishSpeed4();
		}else if(GameManager.Instance.menuSpeedNumber == 5){  
			establishSpeed5();
		}else if(GameManager.Instance.menuSpeedNumber == 6){  
			establishSpeed6();
		}else if(GameManager.Instance.menuSpeedNumber == 7){  
			establishSpeed7();
		}else if(GameManager.Instance.menuSpeedNumber == 8){  
			establishSpeed8();
		}else if(GameManager.Instance.menuSpeedNumber == 9){  
			establishSpeed9();
		}else if(GameManager.Instance.menuSpeedNumber == 10){  
			establishSpeed10();
		}

	}
	
//	public void determineSpeeds(){
//		if(RunningTime.TotalSeconds >= 0 && RunningTime.TotalSeconds < 4){  
//			//establishInitialSpeeds();
//		}
//		else if(RunningTime.TotalSeconds >= 4 && RunningTime.TotalSeconds < 8){  
//			//Debug.Log("waitForFirstSpeedChange");
//			waitForFirstSpeedChange();
//		}
//		else if(RunningTime.TotalSeconds >= 8 && RunningTime.TotalSeconds < 12){ 
//			//Debug.Log("waitFor2SpeedChange");
//			waitForSecondSpeedChange();
//		}
//		else if(RunningTime.TotalSeconds >= 12 && RunningTime.TotalSeconds < 16){ 
//			//Debug.Log("waitFor3SpeedChange");
//			waitForThirdSpeedChange();
//		}
//		else if(RunningTime.TotalSeconds >= 16 && RunningTime.TotalSeconds < 20){
//			//Debug.Log("waitFor4SpeedChange");
//			waitForFourthSpeedChange(); 
//		}
//		else if(RunningTime.TotalSeconds >= 20 && RunningTime.TotalSeconds < 24){ 
//			//Debug.Log("waitFor5tSpeedChange");
//			waitForFifthSpeedChange(); 
//		}
//		else if(RunningTime.TotalSeconds >= 24 && RunningTime.TotalSeconds < 28){  
//			//Debug.Log("waitFor6SpeedChange");
//			waitForSixthSpeedChange(); 
//		}
//		else if(RunningTime.TotalSeconds >= 32 && RunningTime.TotalSeconds < 36){  
//			//Debug.Log("waitFor7SpeedChange");
//			waitForSeventhSpeedChange(); 
//		}
//		else if(RunningTime.TotalSeconds >= 36 && RunningTime.TotalSeconds < 40){  
//			//Debug.Log("waitFor8SpeedChange");
//			waitForEighthSpeedChange(); 
//		}
//	}

	public void determinePoints(){
		if(line.canSpin){
			timePoints = RunningTime.TotalSeconds * 10;
		}
	}
	
	public void wait(){
		StartCoroutine(waitCo());                
	}
	
	private IEnumerator waitCo(){
		yield return new WaitForSeconds (waitTime); 
		fireRandomSequence();
	}

	public void stopFiringProjectiles(){
		canFire = false;
	}


	public void showIntro(){
		StartCoroutine(showIntroCo()); 
	}

	private IEnumerator showIntroCo(){ 
		IntroText.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
		IntroBG.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
		yield return new WaitForSeconds (3f);
		IntroText.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		IntroBG.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";

	}
//	public void OnGUI(){
//		GUI.skin = Skin; 
//		GUILayout.BeginArea(new Rect(0 ,0, Screen.width, Screen.height)); //also added padding for GameSkin on Inspector
//		{
//			GUILayout.BeginVertical(Skin.GetStyle("EnemyKillText"));
//			{
//				//if(Application.loadedLevel == 0){
//				GUILayout.Label(string.Format("{0}", "TIME: " + timePoints), Skin.GetStyle("EnemyKillText")); 
//				GUILayout.Label(string.Format("{0}", "SPEED: " + "TODO"), Skin.GetStyle("EnemyKillText")); 
//				//}
//			}
//			GUILayout.EndVertical();
//		}
//		GUILayout.EndArea();
//	}

}
