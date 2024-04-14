using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RedDispenser : MonoBehaviour {
	
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
	
	private Vector3 Left1ProjectileSpawnLocation = new Vector3 (-9.522f, 5f, 0);       
	private Vector3 Left2ProjectileSpawnLocation = new Vector3 (-8.05f, 6.5f, 0);      
	private Vector3 Right1ProjectileSpawnLocation = new Vector3 (8.05f, 6.5f, 0);  
	private Vector3 Right2ProjectileSpawnLocation = new Vector3 (9.522f, 5, 0);
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
	public int activeProjectiles;
	public int spinningSpeed;

	public bool hasWaitedForFirstSpeedChange;
	public bool hasWaitedForSecondSpeedChange;
	public bool hasWaitedForThirdSpeedChange;
	public bool canFire;
	
	void Start () {
		started = DateTime.UtcNow; 
		canFire = true;
		hasWaitedForFirstSpeedChange = false;
		hasWaitedForSecondSpeedChange = false;
		determineRedSpeeds();
		fireRandomSequence();
	}
	
	void Update () {
		HandleKeyboard();
		determineRedSpeeds();
	}
	
	public void HandleKeyboard(){
		
	}
	
	public void fireRandomSequence(){
		float sequenceNumber = random.Next (3, 7);
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
	}
	
	public void fireFromLeft1(){
		if(canFire){
			initiateLeftBGBFAnimation();
			//AudioSource.PlayClipAtPoint(CHi, transform.position);
			var liveProjectile = (Projectile)Instantiate (projectile, Left1ProjectileSpawnLocation, transform.rotation); 
			liveProjectile.Initialize (gameObject, downRight, new Vector2(1, -1)); 
			liveProjectile.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
			activeProjectiles ++;
		}
	}
	
	public void fireFromLeft2(){
		if(canFire){
			initiateLeftBGBFAnimation();
			//AudioSource.PlayClipAtPoint(CLow, transform.position);
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
			//AudioSource.PlayClipAtPoint(G, transform.position);
			var liveProjectile = (Projectile)Instantiate (projectile, Right1ProjectileSpawnLocation, transform.rotation); 
			liveProjectile.Initialize (gameObject, downLeft, new Vector2(-1, -1));  
			activeProjectiles ++;
			liveProjectile.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
		}
	}
	
	public void fireFromRight2(){
		if(canFire){
			initiateRightBGBFAnimation();
			//AudioSource.PlayClipAtPoint(F, transform.position);  
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

	public void initiateLeftBGBFAnimation(){
		background.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("itsAlmostLikeANinjeeStar2", typeof(Sprite)) as Sprite;
	}

	public void initiateRightBGBFAnimation(){
		background.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("itsAlmostLikeANinjeeStar", typeof(Sprite)) as Sprite;
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
			yield return new WaitForSeconds (2); 
			canFire = true;
			line.spinningSpeed = GameManager.Instance.lineSpinningSpeed2;  
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
			yield return new WaitForSeconds (2); 
			canFire = true;
			line.spinningSpeed = GameManager.Instance.lineSpinningSpeed3;   
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
			yield return new WaitForSeconds (2); 
			canFire = true;
			line.spinningSpeed = GameManager.Instance.lineSpinningSpeed4;  
		}
	}

	public void determineRedSpeeds(){
		if(RunningTime.TotalSeconds >= 0 && RunningTime.TotalSeconds < 15){  
			projectile.Speed = GameManager.Instance.projectileSpeed1;
			projectile2.Speed = GameManager.Instance.projectileSpeed1; 
			waitTime = GameManager.Instance.firstWaitTime1;
			waitTime2 = GameManager.Instance.secondWaitTime1;
			line.spinningSpeed = GameManager.Instance.lineSpinningSpeed1;  
			hasWaitedForFirstSpeedChange = false; 
		} 

		else if(RunningTime.TotalSeconds >= 15 && RunningTime.TotalSeconds < 30){  
			waitForFirstSpeedChange();
			projectile.Speed = GameManager.Instance.projectileSpeed2;
			projectile2.Speed = GameManager.Instance.projectileSpeed2; 
			waitTime = GameManager.Instance.firstWaitTime2;
			waitTime2 = GameManager.Instance.secondWaitTime2; 
		} 
		
		else if(RunningTime.TotalSeconds >= 30 && RunningTime.TotalSeconds < 45){  
			waitForSecondSpeedChange();
			projectile.Speed = GameManager.Instance.projectileSpeed3;
			projectile2.Speed = GameManager.Instance.projectileSpeed3; 
			waitTime = GameManager.Instance.firstWaitTime3;
			waitTime2 = GameManager.Instance.secondWaitTime3;
		} 
		
		else if(RunningTime.TotalSeconds >= 45){// && RunningTime.TotalSeconds < 45){  
			waitForThirdSpeedChange();
			projectile.Speed = GameManager.Instance.projectileSpeed4;
			projectile2.Speed = GameManager.Instance.projectileSpeed4; 
			waitTime = GameManager.Instance.firstWaitTime4;
			waitTime2 = GameManager.Instance.secondWaitTime4; 
		}  
	}
}
