using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CyanDispenser : MonoBehaviour {
	
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
	
	private Vector3 Left1ProjectileSpawnLocation = new Vector3 (-9.55f, 5f, 0);       
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
	public Animator Animator; 
	//public HUDTab upperTab;
	
	public AudioClip CLow;
	public AudioClip D;
	public AudioClip E;
	public AudioClip F;
	public AudioClip G; 
	public AudioClip A;
	public AudioClip B;
	public AudioClip CHi;
	
	//public float projectileLaunchSpeed = 50 ;    
	public float waitTime;  
	public float waitTime2; 
	public float waitTime3;  
	public int activeProjectiles;
	public int spinningSpeed;
	
	public bool hasWaitedForFirstSpeedChange;
	public bool hasWaitedForSecondSpeedChange;
	public bool canFire; 
	public bool shouldBeSpinning;
	public bool shouldSpinUntilStopped;
	public bool notSpinning;

	public HUDTab upperTab;  
	public LeftHUDTab leftTab;   
	public RightHUDTab rightTab;
	public LowerHUDTab lowerTab;
	
	public bool isGameOver;
	
	void Start () {
		started = DateTime.UtcNow; 
		canFire = true;
		hasWaitedForFirstSpeedChange = false;
		hasWaitedForSecondSpeedChange = false;
		determineCyanSpeeds();
		fireRandomSequence();   
	}
	
	void Update () {
		HandleKeyboard();
		//HandleUserTouches();
		//background.transform.Rotate(0, 0, (spinningSpeed/4)* Time.deltaTime,Space.Self); 
		determineCyanSpeeds();
		determineRemainingDistanceToSpinBG();  
	}
	
	public void HandleKeyboard(){
		if(isGameOver){
			if (Input.GetKey(KeyCode.UpArrow)) {
				restartSession();
			}
		}
	}



	public void displayGameOverScreen(){
		isGameOver = true;
		canFire = false;
		leftTab.lowerLeftTab();
		rightTab.lowerRightTab();
		lowerTab.closeLowerTab(); 
	}
	
	public void restartSession(){
		isGameOver = false;
		canFire = true;
		leftTab.raiseLeftTab();
		rightTab.lowerRightTab();
		lowerTab.openLowerTab(); 
	}
	
	public void fireRandomSequence(){
		float scenarioNumber = random.Next (1, 3);
		if(scenarioNumber == 1){   
			initiateRandomLocations();
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
 
	}
	
	public void fireFromLeft1(){
		if(canFire){
			//Animator.SetTrigger("Pulse"); 
			AudioSource.PlayClipAtPoint(CHi, transform.position);
			var liveProjectile = (Projectile)Instantiate (projectile, Left1ProjectileSpawnLocation, transform.rotation); 
			liveProjectile.Initialize (gameObject, downRight, new Vector2(1, -1)); 
			liveProjectile.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
			activeProjectiles ++;
		}
	}
	
	public void fireFromLeft2(){
		if(canFire){
			//Animator.SetTrigger("Pulse"); 
			AudioSource.PlayClipAtPoint(CLow, transform.position);
			var liveProjectile = (Projectile)Instantiate (projectile2, Left2ProjectileSpawnLocation, transform.rotation); 
			liveProjectile.Initialize (gameObject, downRight, new Vector2(1, -1));  
			liveProjectile.GetComponent<SpriteRenderer>().color = Color.black; 		
			liveProjectile.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
			activeProjectiles ++; 
		}
	}
	
	public void fireFromRight1(){  
		if(canFire){
			//Animator.SetTrigger("Pulse"); 
			AudioSource.PlayClipAtPoint(G, transform.position);
			var liveProjectile = (Projectile)Instantiate (projectile, Right1ProjectileSpawnLocation, transform.rotation); 
			liveProjectile.Initialize (gameObject, downLeft, new Vector2(-1, -1));    
			activeProjectiles ++;                
			liveProjectile.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
		}     
	}    
	
	public void fireFromRight2(){
		if(canFire){
			//Animator.SetTrigger("Pulse"); 
			AudioSource.PlayClipAtPoint(F, transform.position);  
			var liveProjectile = (Projectile)Instantiate (projectile2, Right2ProjectileSpawnLocation, transform.rotation); 
			liveProjectile.Initialize (gameObject, downLeft, new Vector2(-1, -1));  
			activeProjectiles ++;
			liveProjectile.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
		}
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

	public void initiateRandomLocations(){
		StartCoroutine(fireFromRandomLocationsCo());                
	}
	
	private IEnumerator fireFromRandomLocationsCo(){
		stopSpinning();
		float sequenceNumber = random.Next (1, 5);
		if(sequenceNumber == 1){ 
			fireFromLeft1();
		}else if(sequenceNumber == 2){
			fireFromLeft2();
		}else if(sequenceNumber == 3){ 
			fireFromRight2();
		}else if(sequenceNumber == 4){
			fireFromRight1();
		}
		yield return new WaitForSeconds (waitTime3); 
		float sequenceNumber2 = random.Next (1, 5);
		if(sequenceNumber2 == 1){ 
			fireFromLeft1();
		}else if(sequenceNumber2 == 2){
			fireFromLeft2();
		}else if(sequenceNumber2 == 3){ 
			fireFromRight2();
		}else if(sequenceNumber2 == 4){
			fireFromRight1();
		}
		yield return new WaitForSeconds (waitTime3); 
		float sequenceNumber3 = random.Next (1, 5);
		if(sequenceNumber3 == 1){ 
			fireFromLeft1();
		}else if(sequenceNumber3 == 2){
			fireFromLeft2();
		}else if(sequenceNumber3 == 3){ 
			fireFromRight2();
		}else if(sequenceNumber3 == 4){
			fireFromRight1();
		}
		yield return new WaitForSeconds (waitTime3); 
		float sequenceNumber4 = random.Next (1, 5);
		if(sequenceNumber4 == 1){ 
			fireFromLeft1();
		}else if(sequenceNumber4 == 2){
			fireFromLeft2();
		}else if(sequenceNumber4 == 3){ 
			fireFromRight2();
		}else if(sequenceNumber4 == 4){
			fireFromRight1();
		}
		yield return new WaitForSeconds (waitTime3); 
		float sequenceNumber5 = random.Next (1, 5);
		if(sequenceNumber5 == 1){ 
			fireFromLeft1();
		}else if(sequenceNumber5 == 2){
			fireFromLeft2();
		}else if(sequenceNumber5 == 3){ 
			fireFromRight2();
		}else if(sequenceNumber5 == 4){
			fireFromRight1();
		}
		yield return new WaitForSeconds (waitTime3); 
		float sequenceNumber6 = random.Next (1, 5);
		if(sequenceNumber6 == 1){ 
			fireFromLeft1();
		}else if(sequenceNumber6 == 2){
			fireFromLeft2();
		}else if(sequenceNumber6 == 3){ 
			fireFromRight2();
		}else if(sequenceNumber6 == 4){
			fireFromRight1();
		}
		yield return new WaitForSeconds (waitTime3); 
		float sequenceNumber7 = random.Next (1, 5);
		if(sequenceNumber7 == 1){ 
			fireFromLeft1();
		}else if(sequenceNumber7 == 2){
			fireFromLeft2();
		}else if(sequenceNumber7 == 3){ 
			fireFromRight2();
		}else if(sequenceNumber7 == 4){
			fireFromRight1();
		}
		yield return new WaitForSeconds (waitTime3); 
		float sequenceNumber8 = random.Next (1, 5);
		if(sequenceNumber8 == 1){ 
			fireFromLeft1();
		}else if(sequenceNumber8 == 2){
			fireFromLeft2();
		}else if(sequenceNumber8 == 3){ 
			fireFromRight2();
		}else if(sequenceNumber8 == 4){
			fireFromRight1();
		}
		yield return new WaitForSeconds (waitTime2); 
		fireRandomSequence();
	}
	
	public void initiateLeftBGBFAnimation(){
		//background.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("itsAlmostLikeANinjeeStar2", typeof(Sprite)) as Sprite;
	}
	
	public void initiateRightBGBFAnimation(){
		// background.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("itsAlmostLikeANinjeeStar", typeof(Sprite)) as Sprite;
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
			line.spinningSpeed = 290; 
		}
	}
	
	public void determineCyanSpeeds(){ 
		if(RunningTime.TotalSeconds >= 0 && RunningTime.TotalSeconds < 15){  
			projectile.Speed = 2.5f;
			projectile2.Speed = 2.5f;  
			waitTime = .5f;
			waitTime2 = 1;
			waitTime3 = .75f;
			line.spinningSpeed = 179;  
			hasWaitedForFirstSpeedChange = false;    
		} 
		
		else if(RunningTime.TotalSeconds >= 15 && RunningTime.TotalSeconds < 30){  
			waitForFirstSpeedChange();
			projectile.Speed = 3f;
			projectile2.Speed = 3f;    
			waitTime = .4f;      
			waitTime2 = .8f; 
			waitTime3 = .6f;
			//			line.spinningSpeed = 222;  
		} 
		
		if(RunningTime.TotalSeconds >= 30){// && RunningTime.TotalSeconds < 45){  
			waitForSecondSpeedChange();
			projectile.Speed = 3.5f;  
			projectile2.Speed = 3.5f;   
			waitTime = .3f;
			waitTime2 = .6f; 
			waitTime3 = .45f;
			//			line.spinningSpeed = 289; 
		} 
		
		//		if(RunningTime.TotalSeconds >= 0 && RunningTime.TotalSeconds < 1500){  
		//			projectile.Speed = 3.5f;
		//			projectile2.Speed = 3.5f;  
		//			waitTime = .2f;
		//			waitTime2 = .4f;
		//          waitTime3 = .3f;
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
		int remainingDistanceToSpin = currentSpinningRotation % 90;   
		//Debug.Log((remainingDistanceToSpin) + " REMAINDER");       
		
		if(shouldBeSpinning || remainingDistanceToSpin != 45){
			background.transform.Rotate(0, 0, (spinningSpeed/4)* Time.deltaTime,Space.Self);
		}
	}

	public void endSession(){
//		//stopProjectiles();
//		//disableSpinning
//		displayGameOverTab();
	}

//	public void restartSession(){
//
//	}
//
//	public void displayGameOverTab(){
//
//	}
}
