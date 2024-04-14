using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MagentaDispenser : MonoBehaviour {
	
	//Directions
	public Vector2 up = new Vector2(0, 1);
	public Vector2 down = new Vector2(0, -1);
	public Vector2 left = new Vector2(-1, 0);
	public Vector2 right = new Vector2(1, 0);
	public Vector2 downRight = new Vector2 (1, -1);
	public Vector2 downLeft= new Vector2 (-1, -1);
	
	//	//Velocities
	//	public Vector2 medium = new Vector2(1, 1);
	//	public Vector2 fast = new Vector2(-1, 0);
	//	public Vector2 superFast = new Vector2(1, 0);
	//	public Vector2 superCrazyFast = new Vector2(0, 1);
	
	//Spawn Locations
	//	private Vector3 topLeftProjectileSpawnLocation = new Vector3 (-.75f, 5, 0);       
	//	private Vector3 topRightProjectileSpawnLocation = new Vector3 (.75f, 5, 0);
	//	private Vector3 bottomLeftProjectileSpawnLocation = new Vector3 (-.75f, -5, 0);
	//	private Vector3 bottomRightProjectileSpawnLocation = new Vector3 (.75f, -5, 0);
	//	private Vector3 leftTopProjectileSpawnLocation = new Vector3 (-5, .75f, 0);
	//	private Vector3 leftBottomProjectileSpawnLocation = new Vector3 (-5, -.75f, 0);
	//	private Vector3 rightTopProjectileSpawnLocation = new Vector3 (5, .75f, 0);
	//	private Vector3 rightBottomProjectileSpawnLocation = new Vector3 (5, -.75f, 0);  
	
	private Vector3 Left1ProjectileSpawnLocation = new Vector3 (-9.5f, 5f, 0);       
	private Vector3 Left2ProjectileSpawnLocation = new Vector3 (-8.05f, 6.5f, 0);      
	private Vector3 Right1ProjectileSpawnLocation = new Vector3 (8.05f, 6.5f, 0);  
	private Vector3 Right2ProjectileSpawnLocation = new Vector3 (9.55f, 5, 0);
	//	private Vector3 leftTopProjectileSpawnLocation = new Vector3 (-10, 3.65f, 0);
	//	private Vector3 leftBottomProjectileSpawnLocation = new Vector3 (-10, -3.65f, 0);
	//	private Vector3 rightTopProjectileSpawnLocation = new Vector3 (10, 3.65f, 0);
	//	private Vector3 rightBottomProjectileSpawnLocation = new Vector3 (10, -3.65f, 0); 
	
	public Projectile projectile;
	public Projectile projectile2;
	public virtual Vector2 direction { get; protected set;}
	private static System.Random random = new System.Random();
	public SpinningLine line;
	public Background background;
	public DateTime started; 
	public TimeSpan RunningTime{get{return DateTime.UtcNow - started;}}
	public MainMenu menu;

	public AudioClip CLow;
	public AudioClip D;
	public AudioClip E;
	public AudioClip F;
	public AudioClip G; 
	public AudioClip A;
	public AudioClip B;
	public AudioClip CHi;
	
	//public float projectileLaunchSpeed = 50 ;    
	public int gameSpeed;

	public float waitTime;  
	public float waitTime2;  
	public int activeProjectiles;
	public int spinningSpeed;
	
	public bool hasWaitedForFirstSpeedChange;
	public bool hasWaitedForSecondSpeedChange;
	public bool hasWaitedForThirdSpeedChange;
	public bool canFire; 
	public bool shouldBeSpinning;
	public bool shouldSpinUntilStopped;
	public bool notSpinning;
	
	void Start () {
		menu = FindObjectOfType<MainMenu> ();
		gameSpeed = menu.speedSelection;
		started = DateTime.UtcNow; 
		canFire = true;
		hasWaitedForFirstSpeedChange = false;
		hasWaitedForSecondSpeedChange = false;
		determineMagentaSpeeds();
		fireRandomSequence();

		Debug.Log("STARTING SPEED " + gameSpeed);
	}
	
	void Update () {
		HandleKeyboard();
		//background.transform.Rotate(0, 0, (spinningSpeed/4)* Time.deltaTime,Space.Self); 
		determineMagentaSpeeds();
		determineRemainingDistanceToSpinBG();  
	}
	
	public void HandleKeyboard(){
		
	}
	
	public void fireRandomSequence(){
		float scenarioNumber = random.Next (1, 3);
		if(scenarioNumber == 1){   
			float sequenceNumber = random.Next (1, 7);
			if(sequenceNumber == 1){   
				initiateBackForth1();
			}else if(sequenceNumber == 2){
				initiateBackForth2();
			}else if(sequenceNumber == 3){
				initiateFunPattern1();
			}else if(sequenceNumber == 4){
				initiateFunPattern2();
			}else if(sequenceNumber == 5){
				initiateFunPattern3();
			}else if(sequenceNumber == 6){ 
				initiateFunPattern4();    
			}
		}else if(scenarioNumber == 2){
			float sequenceNumber2 = random.Next (7, 11);
			if(sequenceNumber2 == 7){ 
				initiateSpiralLeftSequence();
			}else if(sequenceNumber2 == 8){ 
				initiateSpiralRightSequence();
			}else if(sequenceNumber2 == 9){ 
				initiateSpiralLeft2Sequence();
			}else if(sequenceNumber2 == 10){ 
				initiateSpiralRight2Sequence();
			} 
		}
//		float sequenceNumber = random.Next (1, 11);
//		if(sequenceNumber == 1){   
//			initiateBackForth1();
//		}else if(sequenceNumber == 2){
//			initiateBackForth2();
//		}else if(sequenceNumber == 3){
//			initiateFunPattern1();
//		}else if(sequenceNumber == 4){
//			initiateFunPattern2();
//		}else if(sequenceNumber == 5){
//			initiateFunPattern3();
//		}else if(sequenceNumber == 6){ 
//			initiateFunPattern4();
//		}
//		else if(sequenceNumber == 7){ 
//			initiateSpiralLeftSequence();
//		}else if(sequenceNumber == 8){ 
//			initiateSpiralRightSequence();
//		}else if(sequenceNumber == 9){ 
//			initiateSpiralLeft2Sequence();
//		}else if(sequenceNumber == 10){ 
//			initiateSpiralRight2Sequence();
//		}  
	}
	
	public void fireFromLeft1(){
		if(canFire){
			initiateLeftBGBFAnimation();
			AudioSource.PlayClipAtPoint(CLow, transform.position);
			var liveProjectile = (Projectile)Instantiate (projectile, Left1ProjectileSpawnLocation, transform.rotation); 
			liveProjectile.Initialize (gameObject, downRight, new Vector2(1, -1)); 
			liveProjectile.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
			activeProjectiles ++;
		}
	}
	
	public void fireFromLeft2(){
		if(canFire){
			initiateLeftBGBFAnimation();
			AudioSource.PlayClipAtPoint(E, transform.position);
			var liveProjectile = (Projectile)Instantiate (projectile2, Left2ProjectileSpawnLocation, transform.rotation); 
			liveProjectile.Initialize (gameObject, downRight, new Vector2(1, -1));  
			liveProjectile.GetComponent<SpriteRenderer>().color = Color.black; 		
			liveProjectile.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
			activeProjectiles ++; 
		}
	}
	
	public void fireFromRight1(){  
		if(canFire){
			initiateRightBGBFAnimation();
			AudioSource.PlayClipAtPoint(G, transform.position);
			var liveProjectile = (Projectile)Instantiate (projectile, Right1ProjectileSpawnLocation, transform.rotation); 
			liveProjectile.Initialize (gameObject, downLeft, new Vector2(-1, -1));  
			activeProjectiles ++;
			liveProjectile.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
		}
	}
	
	public void fireFromRight2(){
		if(canFire){
			initiateRightBGBFAnimation();
			AudioSource.PlayClipAtPoint(CHi, transform.position);  
			var liveProjectile = (Projectile)Instantiate (projectile2, Right2ProjectileSpawnLocation, transform.rotation); 
			liveProjectile.Initialize (gameObject, downLeft, new Vector2(-1, -1));  
			activeProjectiles ++;
			liveProjectile.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
		}
	}
	
	public void initiateBackForth1(){
		StartCoroutine(BackForth1Co());                
	}
	
	private IEnumerator BackForth1Co(){
		fireFromLeft1();
		yield return new WaitForSeconds (waitTime2); 
		stopSpinning();
		initiateLeftBGBFAnimation();
		fireFromRight2();
		yield return new WaitForSeconds (waitTime2); 
		initiateRightBGBFAnimation();
		fireFromLeft1();
		yield return new WaitForSeconds (waitTime2); 
		initiateLeftBGBFAnimation();
		fireFromRight2();  
		yield return new WaitForSeconds (waitTime2);  
		initiateRightBGBFAnimation();
		fireRandomSequence(); 
	}
	
	public void initiateBackForth2(){
		StartCoroutine(BackForth2Co());                
	}
	
	private IEnumerator BackForth2Co(){
		fireFromRight1();
		yield return new WaitForSeconds (waitTime2);   
		stopSpinning();
		fireFromLeft2();
		yield return new WaitForSeconds (waitTime2);     
		fireFromRight1();
		yield return new WaitForSeconds (waitTime2);       
		fireFromLeft2();
		yield return new WaitForSeconds (waitTime2);  
		fireRandomSequence(); 
	}
	
	public void initiateFunPattern1(){
		StartCoroutine(funPatternCo());    
	}
	
	private IEnumerator funPatternCo(){
		fireFromLeft1();
		yield return new WaitForSeconds (waitTime); 
		stopSpinning();
		//initiateLeftBGBFAnimation();
		fireFromLeft2();
		yield return new WaitForSeconds (waitTime); 
		fireFromRight2();
		yield return new WaitForSeconds (waitTime);
		//initiateRightBGBFAnimation();
		fireFromRight1();
		yield return new WaitForSeconds (waitTime); 
		fireFromLeft1();
		yield return new WaitForSeconds (waitTime); 
		//initiateLeftBGBFAnimation();
		fireFromLeft2();
		yield return new WaitForSeconds (waitTime ); 
		fireFromRight2();
		yield return new WaitForSeconds (waitTime); 
		//initiateRightBGBFAnimation();
		fireFromRight1();  
		yield return new WaitForSeconds (waitTime2); 
		fireRandomSequence();
	}
	
	public void initiateFunPattern2(){
		StartCoroutine(funPattern2Co());    
	}
	
	private IEnumerator funPattern2Co(){
		fireFromLeft2();
		yield return new WaitForSeconds (waitTime); 
		stopSpinning();
		fireFromLeft1();
		yield return new WaitForSeconds (waitTime); 
		//initiateLeftBGBFAnimation();
		fireFromRight1();
		yield return new WaitForSeconds (waitTime); 
		fireFromRight2();
		yield return new WaitForSeconds (waitTime); 
		//initiateRightBGBFAnimation();
		fireFromLeft2();
		yield return new WaitForSeconds (waitTime); 
		fireFromLeft1();
		yield return new WaitForSeconds (waitTime); 
		//initiateLeftBGBFAnimation();
		fireFromRight1();
		yield return new WaitForSeconds (waitTime); 
		fireFromRight2();  
		yield return new WaitForSeconds (waitTime2); 
		//initiateRightBGBFAnimation();
		fireRandomSequence();
	}
	
	public void initiateFunPattern3(){
		StartCoroutine(funPattern3Co());    
	}
	
	private IEnumerator funPattern3Co(){
		fireFromLeft1();
		yield return new WaitForSeconds (waitTime);
		stopSpinning();
		//initiateLeftBGBFAnimation();
		fireFromLeft2();
		yield return new WaitForSeconds (waitTime2); 
		fireFromRight1();
		yield return new WaitForSeconds (waitTime); 
		fireFromRight2();
		yield return new WaitForSeconds (waitTime2); 
		//initiateRightBGBFAnimation();
		fireFromLeft1();
		yield return new WaitForSeconds (waitTime); 
		//initiateLeftBGBFAnimation();
		fireFromLeft2();
		yield return new WaitForSeconds (waitTime2);      
		fireFromRight1();
		yield return new WaitForSeconds (waitTime); 
		fireFromRight2();  
		yield return new WaitForSeconds (waitTime2);  
		//initiateRightBGBFAnimation();
		fireRandomSequence();
	}
	
	public void initiateFunPattern4(){
		StartCoroutine(funPattern4Co());    
	}
	
	private IEnumerator funPattern4Co(){
		fireFromLeft2();
		yield return new WaitForSeconds (waitTime);
		stopSpinning();
		fireFromLeft1();
		yield return new WaitForSeconds (waitTime2);
		//initiateLeftBGBFAnimation();
		fireFromRight2();
		yield return new WaitForSeconds (waitTime); 
		//initiateRightBGBFAnimation();
		fireFromRight1();
		yield return new WaitForSeconds (waitTime2); 
		fireFromLeft2();
		yield return new WaitForSeconds (waitTime); 
		fireFromLeft1();
		yield return new WaitForSeconds (waitTime2); 
		//initiateLeftBGBFAnimation();
		fireFromRight2();
		yield return new WaitForSeconds (waitTime); 
		//initiateRightBGBFAnimation();
		fireFromRight1();    
		yield return new WaitForSeconds (waitTime2); 
		fireRandomSequence();
	}

	public void initiateSpiralLeftSequence(){
		StartCoroutine(SpiralLeftCo());                
	}
	
	private IEnumerator SpiralLeftCo(){

		fireFromLeft1();
		yield return new WaitForSeconds (waitTime); 
		spinningSpeed = line.spinningSpeed;
		shouldBeSpinning = true;
		fireFromRight1();
		yield return new WaitForSeconds (waitTime); 
		fireFromLeft1();
		yield return new WaitForSeconds (waitTime); 
		fireFromRight1();
		yield return new WaitForSeconds (waitTime); 
		fireFromLeft1();
		yield return new WaitForSeconds (waitTime); 
		fireFromRight1();
		yield return new WaitForSeconds (waitTime); 
		fireFromLeft1();
		yield return new WaitForSeconds (waitTime); 
		fireFromRight1();
		yield return new WaitForSeconds (waitTime2); 
		fireRandomSequence();
	}
	
	public void initiateSpiralRightSequence(){
		StartCoroutine(SpiralRightCo());                
	}
	
	private IEnumerator SpiralRightCo(){

		fireFromRight2();
		yield return new WaitForSeconds (waitTime); 
		spinningSpeed = -line.spinningSpeed; 
		shouldBeSpinning = true;
		fireFromLeft2();
		yield return new WaitForSeconds (waitTime); 
		fireFromRight2();
		yield return new WaitForSeconds (waitTime); 
		fireFromLeft2();
		yield return new WaitForSeconds (waitTime); 
		fireFromRight2();
		yield return new WaitForSeconds (waitTime); 
		fireFromLeft2();
		yield return new WaitForSeconds (waitTime); 
		fireFromRight2();
		yield return new WaitForSeconds (waitTime); 
		fireFromLeft2();
		yield return new WaitForSeconds (waitTime2); 
		fireRandomSequence();
	}
	
	public void initiateSpiralLeft2Sequence(){
		StartCoroutine(SpiralLeft2Co());                
	}
	
	private IEnumerator SpiralLeft2Co(){

		fireFromRight1();
		yield return new WaitForSeconds (waitTime); 
		spinningSpeed = line.spinningSpeed;
		shouldBeSpinning = true;
		fireFromLeft1();
		yield return new WaitForSeconds (waitTime); 
		fireFromRight1();
		yield return new WaitForSeconds (waitTime); 
		fireFromLeft1();
		yield return new WaitForSeconds (waitTime2); 
		fireRandomSequence();
	}
	
	public void initiateSpiralRight2Sequence(){
		StartCoroutine(SpiralRight2Co());                
	}
	
	private IEnumerator SpiralRight2Co(){

		fireFromLeft2();
		yield return new WaitForSeconds (waitTime); 
		spinningSpeed = -line.spinningSpeed; 
		shouldBeSpinning = true;
		fireFromRight2();
		yield return new WaitForSeconds (waitTime); 
		fireFromLeft2();
		yield return new WaitForSeconds (waitTime); 
		fireFromRight2();
		yield return new WaitForSeconds (waitTime2); 
		fireRandomSequence(); 
	}
	
	public void initiateLeftBGBFAnimation(){
		//background.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("itsAlmostLikeANinjeeStar2", typeof(Sprite)) as Sprite;
	}
	
	public void initiateRightBGBFAnimation(){
		//background.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("itsAlmostLikeANinjeeStar", typeof(Sprite)) as Sprite;
	}
	
	//	public void determineRedSpeeds(){
	//		if(RunningTime.TotalSeconds >= 0 && RunningTime.TotalSeconds < 15f){  
	//			projectile.Speed = 2;
	//			projectile2.Speed = 2;
	//		} 
	//		else if(RunningTime.TotalSeconds >= 15f){  
	//			projectile.Speed = 3;
	//			projectile2.Speed = 3;
	//		} 
	//	}
	
	public void waitForFirstSpeedChange(){
		StartCoroutine(waitForFirstSpeedChangeCo());                
	}
	
	private IEnumerator waitForFirstSpeedChangeCo(){
		//Dont do shit
		if(hasWaitedForFirstSpeedChange == false){
			hasWaitedForFirstSpeedChange = true;
			canFire = false;
			yield return new WaitForSeconds (waitTime * 4); 
			canFire = true;
			line.spinningSpeed = 222;  
		}
	}
	
	public void waitForSecondSpeedChange(){
		StartCoroutine(waitForSecondSpeedChangeCo());                
	}
	
	private IEnumerator waitForSecondSpeedChangeCo(){
		//Dont do shit
		if(hasWaitedForSecondSpeedChange == false){
			hasWaitedForSecondSpeedChange = true;
			canFire = false;
			yield return new WaitForSeconds (waitTime * 4); 
			canFire = true;
			line.spinningSpeed = 291; 
		}
	}

	public void waitForThirdSpeedChange(){
		StartCoroutine(waitForThirdSpeedChangeCo());                
	}
	
	private IEnumerator waitForThirdSpeedChangeCo(){
		//Dont do shit
		if(hasWaitedForThirdSpeedChange == false){
			hasWaitedForThirdSpeedChange = true;
			canFire = false;
			yield return new WaitForSeconds (waitTime * 4); 
			canFire = true;
			line.spinningSpeed = 400; 
		}
	}

	public void determineMagentaSpeeds(){ 
		//if(RunningTime.TotalSeconds >= 0 && RunningTime.TotalSeconds < 15){  
		if(gameSpeed == 1){ 
			projectile.Speed = 2.5f;
			projectile2.Speed = 2.5f;  
			waitTime = .5f;
			waitTime2 = 1;
			line.spinningSpeed = 179;  
			hasWaitedForFirstSpeedChange = false;    
		} 
		
		//else if(RunningTime.TotalSeconds >= 15 && RunningTime.TotalSeconds < 30){  
		else if(gameSpeed == 2){  
			waitForFirstSpeedChange();
			projectile.Speed = 3f;
			projectile2.Speed = 3f;    
			waitTime = .4f;      
			waitTime2 = .8f;  
			//			line.spinningSpeed = 222;  
		} 
		
		//if(RunningTime.TotalSeconds >= 30){// && RunningTime.TotalSeconds < 45){  
		else if(gameSpeed == 3){ 
			waitForSecondSpeedChange();
			projectile.Speed = 3.5f;  
			projectile2.Speed = 3.5f;   
			waitTime = .3f;
			waitTime2 = .6f;    
			//			line.spinningSpeed = 289; 
		} 

		else if(gameSpeed == 4){ 
			waitForThirdSpeedChange();
			projectile.Speed = 4.5f;  
			projectile2.Speed = 4.5f;   
			waitTime = .2f;
			waitTime2 = .4f;    
			//			line.spinningSpeed = 289; 
		} 
		
		//		if(RunningTime.TotalSeconds >= 0 && RunningTime.TotalSeconds < 1500){  
		//			projectile.Speed = 3.5f;
		//			projectile2.Speed = 3.5f;  
		//			waitTime = .2f;
		//			waitTime2 = .4f;
		//			line.spinningSpeed = 440;  
		//			hasWaitedForFirstSpeedChange = false;    
		//		}  
	}

	public void stopSpinning(){
		shouldBeSpinning = false;
		//determineRemainingDistanceToSpinBG();  
		//spinningSpeed = spinningSpeed/10;
		//background.transform.rotation = Quaternion.Euler(0,0,45);   
	}

	public void determineRemainingDistanceToSpinBG(){
		int currentSpinningRotation = (int)Math.Ceiling(background.transform.rotation.eulerAngles.z);
		int remainingDistanceToSpin = currentSpinningRotation % 45;   
		//Debug.Log((remainingDistanceToSpin) + "REMAINDER");       

		if(shouldBeSpinning || remainingDistanceToSpin != 0){
			background.transform.Rotate(0, 0, (spinningSpeed/4)* Time.deltaTime,Space.Self);
		}
	}
//
//	public void determineBGSpins(){
//		if(shouldBeSpinning){
//			background.transform.Rotate(0, 0, (spinningSpeed/4)* Time.deltaTime,Space.Self); 
//		}else if(shouldSpinUntilStopped){
//			spinUntilAt45DegreeAngle();
//		}else{
//
//		}
//	}
}
