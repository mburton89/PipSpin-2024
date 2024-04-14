using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SuperInsaneDispenser : MonoBehaviour {
	
	//DIRECTIONS
	public Vector2 downRight = new Vector2 (1, -1);
	public Vector2 downLeft = new Vector2 (-1, -1);
	
	//PROJECTILE SPAWN LOCATIONS
	//	private Vector3 Left1ProjectileSpawnLocation = new Vector3 (-10.5f, 5f, 0);       
	//	private Vector3 Left2ProjectileSpawnLocation = new Vector3 (-5.5f, 5f, 0);      
	//	private Vector3 Right1ProjectileSpawnLocation = new Vector3 (5.5f, 5f, 0);  
	//	private Vector3 Right2ProjectileSpawnLocation = new Vector3 (10.5f, 5, 0);
	
	private Vector3 Left1ProjectileSpawnLocation = new Vector3 (-11f, 5.5f, 0);       
	private Vector3 Left2ProjectileSpawnLocation = new Vector3 (-6f, 5.5f, 0);      
	private Vector3 Right1ProjectileSpawnLocation = new Vector3 (6f, 5.5f, 0);  
	private Vector3 Right2ProjectileSpawnLocation = new Vector3 (11f, 5.5f, 0); 
	
	//OBJECTS
	public Projectile projectile;
	public Projectile projectile2;
	public virtual Vector2 direction { get; protected set;}
	public SpinningLine line;
	public Background background;
	public DateTime started; 
	public TimeSpan RunningTime{get{return DateTime.UtcNow - started;}}
	private static System.Random random = new System.Random();
	
	//VARIABLES
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
	
	void Start () {
		line.transform.Rotate(0,0,GameManager.Instance.lineRotation);
		hasMostRecentlyFired1And2 = true;
		canFire = true; 
		started = DateTime.UtcNow; 
		establishInitialSpeeds(); 

		//determineSpeeds();
		//initiateSpinScenario();
		//fireRandomSequence(); 
	}

	void Update () {
		//determineSpeeds();
	}
	
	public void fire1And2(){
		if(canFire){
			
			//PROJECTILE 1
			var liveProjectile = (Projectile)Instantiate (projectile, Left1ProjectileSpawnLocation, transform.rotation); 
			liveProjectile.Initialize (gameObject, downRight, new Vector2(1, -1)); 
			liveProjectile.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
			
			//PROJECTILE 2
			var liveProjectile2 = (Projectile)Instantiate (projectile, Left2ProjectileSpawnLocation, transform.rotation); 
			liveProjectile2.Initialize (gameObject, downRight, new Vector2(1, -1));
			liveProjectile2.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
			
			hasMostRecentlyFired1And2 = true;
			hasMostRecentlyFired1And3 = false;
			hasMostRecentlyFired2And4 = false;
			hasMostRecentlyFired3And4 = false;
		}
	}
	
	public void fire1And3(){
		if(canFire){
			
			//PROJECTILE 1
			var liveProjectile = (Projectile)Instantiate (projectile, Left1ProjectileSpawnLocation, transform.rotation); 
			liveProjectile.Initialize (gameObject, downRight, new Vector2(1, -1));
			liveProjectile.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
			
			//PROJECTILE 3
			var liveProjectile3 = (Projectile)Instantiate (projectile, Right1ProjectileSpawnLocation, transform.rotation); 
			liveProjectile3.Initialize (gameObject, downLeft, new Vector2(-1, -1));
			liveProjectile3.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
			
			hasMostRecentlyFired1And2 = false;
			hasMostRecentlyFired1And3 = true;
			hasMostRecentlyFired2And4 = false;
			hasMostRecentlyFired3And4 = false;
		}
	}
	
	public void fire2And4(){
		if(canFire){
			//PROJECTILE 2
			var liveProjectile2 = (Projectile)Instantiate (projectile, Left2ProjectileSpawnLocation, transform.rotation); 
			liveProjectile2.Initialize (gameObject, downRight, new Vector2(1, -1)); 
			liveProjectile2.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
			
			//PROJECTILE 4
			var liveProjectile4 = (Projectile)Instantiate (projectile, Right2ProjectileSpawnLocation, transform.rotation); 
			liveProjectile4.Initialize (gameObject, downLeft, new Vector2(-1, -1));
			liveProjectile4.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
			
			hasMostRecentlyFired1And2 = false;
			hasMostRecentlyFired1And3 = false;
			hasMostRecentlyFired2And4 = true;
			hasMostRecentlyFired3And4 = false;
		}
	}
	
	public void fire3And4(){
		if(canFire){
			
			//PROJECTILE 3
			var liveProjectile3 = (Projectile)Instantiate (projectile, Right1ProjectileSpawnLocation, transform.rotation); 
			liveProjectile3.Initialize (gameObject, downLeft, new Vector2(-1, -1)); 
			liveProjectile3.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
			
			//PROJECTILE 4
			var liveProjectile4 = (Projectile)Instantiate (projectile, Right2ProjectileSpawnLocation, transform.rotation); 
			liveProjectile4.Initialize (gameObject, downLeft, new Vector2(-1, -1));
			liveProjectile4.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
			
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
			Debug.Log("THAT IS HAPPENING LALALALL");
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
				Debug.Log ("isFiringClockwise");
			}else{
				fire1And3();
				Debug.Log ("isFiringCOUNTERClockwise");
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
			Debug.Log ("BackAndForthIntersectingCo");
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
			Debug.Log ("initiateBackAndForthPairsScenario");
			fire1And2();
			yield return new WaitForSeconds (waitTime); 
			fire3And4();
			yield return new WaitForSeconds (waitTime);
			sequenceNumber2 ++;
		}
		fireRandomSequence();
	} 
	
	//SPEED STUFF
//	public void establishInitialSpeeds(){
//		projectile.Speed = GameManager.Instance.projectileSpeed9;
//		projectile2.Speed = GameManager.Instance.projectileSpeed9; 
//		waitTime = GameManager.Instance.firstWaitTime9;
//		waitTime2 = GameManager.Instance.secondWaitTime1;//dontmatter
//		line.spinningSpeed = GameManager.Instance.lineSpinningSpeed9;  
//		hasWaitedForFirstSpeedChange = false; 	
//	}

	public void establishInitialSpeeds(){
		StartCoroutine(establishInitialSpeedsCo()); 
	}
	
	private IEnumerator establishInitialSpeedsCo(){
		projectile.Speed = GameManager.Instance.projectileSpeed9;
		projectile2.Speed = GameManager.Instance.projectileSpeed9; 
		waitTime = GameManager.Instance.firstWaitTime9;
		//waitTime2 = GameManager.Instance.secondWaitTime5;
		line.spinningSpeed = GameManager.Instance.lineSpinningSpeed9;  
		hasWaitedForFirstSpeedChange = false; 
		yield return new WaitForSeconds (1); 
		canFire = true;
		fireRandomSequence();
	}
	
	public void determineSpeeds(){
		if(RunningTime.TotalSeconds >= 0 && RunningTime.TotalSeconds < 10){  
			establishInitialSpeeds(); //TODO Determine Speeds is not needed in update for this scene
		}
	}
	
	public void wait(){
		StartCoroutine(waitCo());                
	}
	
	private IEnumerator waitCo(){
		yield return new WaitForSeconds (waitTime); 
		fireRandomSequence();
	}
}
