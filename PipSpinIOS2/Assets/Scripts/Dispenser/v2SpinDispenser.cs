using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class v2SpinDispenser : MonoBehaviour {
	
	//Directions
	public Vector2 up = new Vector2(0, 1);
	public Vector2 down = new Vector2(0, -1);
	public Vector2 left = new Vector2(-1, 0);
	public Vector2 right = new Vector2(1, 0);
	public Vector2 downRight = new Vector2 (1, -1);
	public Vector2 downLeft= new Vector2 (-1, -1);
	
	//V2 Look Over these again. Ys and Xs should correlate
	//	private Vector3 Left1ProjectileSpawnLocation = new Vector3 (-9.522f, 5f, 0);       
	//	private Vector3 Left2ProjectileSpawnLocation = new Vector3 (-8.05f, 6.5f, 0);      
	//	private Vector3 Right1ProjectileSpawnLocation = new Vector3 (8.05f, 6.5f, 0);  
	//	private Vector3 Right2ProjectileSpawnLocation = new Vector3 (9.522f, 5, 0);
	
	//V3
	private Vector3 Left1ProjectileSpawnLocation = new Vector3 (-10.5f, 5f, 0);       
	private Vector3 Left2ProjectileSpawnLocation = new Vector3 (-5.5f, 5f, 0);      
	private Vector3 Right1ProjectileSpawnLocation = new Vector3 (5.5f, 5f, 0);  
	private Vector3 Right2ProjectileSpawnLocation = new Vector3 (10.5f, 5, 0);
	
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
		determineBlueSpeeds();  
		fireRandomSequence();
	}
	
	void Update () {
		HandleKeyboard();
		background.transform.Rotate(0, 0, (spinningSpeed/4)* Time.deltaTime,Space.Self); 
		determineBlueSpeeds();
	}
	
	public void HandleKeyboard(){
		
	}
	
	public void fireRandomSequence(){
		float sequenceNumber = random.Next (1, 2);
		if(sequenceNumber == 1){
			initiateSpiralLeftSequence();
		}else if(sequenceNumber == 2){
			initiateSpiralRightSequence(); 
		}else if(sequenceNumber == 3){ 
			initiateSpiralLeft2Sequence(); 
		}else if(sequenceNumber == 4){    
			initiateSpiralRight2Sequence();  
		}
	}
	
	public void fireFromLeft1(){
		if(canFire){
			//AudioSource.PlayClipAtPoint(CHi, transform.position);
			var liveProjectile = (Projectile)Instantiate (projectile, Left1ProjectileSpawnLocation, transform.rotation); 
			liveProjectile.Initialize (gameObject, downRight, new Vector2(1, -1)); 
			liveProjectile.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
			activeProjectiles ++;
		}
	}
	
	public void fireFromLeft2(){
		if(canFire){
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
			//AudioSource.PlayClipAtPoint(G, transform.position);
			var liveProjectile = (Projectile)Instantiate (projectile, Right1ProjectileSpawnLocation, transform.rotation); 
			liveProjectile.Initialize (gameObject, downLeft, new Vector2(-1, -1));  
			activeProjectiles ++;
			liveProjectile.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
		}
	}
	
	public void fireFromRight2(){
		if(canFire){
			//AudioSource.PlayClipAtPoint(F, transform.position);  
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
		//yield return new WaitForSeconds (waitTime); 
		spinningSpeed = line.spinningSpeed;
		fireFromRight1();
		yield return new WaitForSeconds (waitTime * 2); 
		fireFromLeft1();
		//yield return new WaitForSeconds (waitTime); 
		fireFromRight1();
		yield return new WaitForSeconds (waitTime * 2); 
		fireFromLeft1();
		//yield return new WaitForSeconds (waitTime); 
		fireFromRight1();
		yield return new WaitForSeconds (waitTime * 2); 
		fireFromLeft1();
		//yield return new WaitForSeconds (waitTime); 
		fireFromRight1();
		yield return new WaitForSeconds (waitTime * 2); //TODO CHANGE BACK TO waitTime2!!!!
		fireRandomSequence();
	}


	public void initiateSpiralLeftBSequence(){
		StartCoroutine(SpiralLeftBCo());                
	}
	
	private IEnumerator SpiralLeftBCo(){
		
		fireFromLeft1();
		yield return new WaitForSeconds (waitTime); 
		spinningSpeed = line.spinningSpeed;
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
		yield return new WaitForSeconds (waitTime); //TODO CHANGE BACK TO waitTime2!!!!
		fireRandomSequence();
	}


	
	public void initiateSpiralRightSequence(){
		StartCoroutine(SpiralRightCo());                
	}

//	public void initiateSpiralLeftSequence(){
//		StartCoroutine(SpiralLeftCo());                
//	}
//	
//	private IEnumerator SpiralLeftCo(){
//		
//		fireFromLeft1();
//		yield return new WaitForSeconds (waitTime); 
//		spinningSpeed = line.spinningSpeed;
//		fireFromRight1();
//		yield return new WaitForSeconds (waitTime); 
//		fireFromLeft1();
//		yield return new WaitForSeconds (waitTime); 
//		fireFromRight1();
//		yield return new WaitForSeconds (waitTime); 
//		fireFromLeft1();
//		yield return new WaitForSeconds (waitTime); 
//		fireFromRight1();
//		yield return new WaitForSeconds (waitTime); 
//		fireFromLeft1();
//		yield return new WaitForSeconds (waitTime); 
//		fireFromRight1();
//		yield return new WaitForSeconds (waitTime2); //TODO CHANGE BACK TO waitTime2!!!!
//		fireRandomSequence();
//	}
//	
//	public void initiateSpiralRightSequence(){
//		StartCoroutine(SpiralRightCo());                
//	}
	
	private IEnumerator SpiralRightCo(){
		
		fireFromRight2();
		yield return new WaitForSeconds (waitTime); 
		spinningSpeed = -line.spinningSpeed; 
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
		fireFromRight2();
		yield return new WaitForSeconds (waitTime); 
		fireFromLeft2();
		yield return new WaitForSeconds (waitTime); 
		fireFromRight2();
		yield return new WaitForSeconds (waitTime2); 
		fireRandomSequence(); 
	}
	
	public void waitForFirstSpeedChange(){
		StartCoroutine(waitForFirstSpeedChangeCo());                
	}
	
	private IEnumerator waitForFirstSpeedChangeCo(){
		//Dont do shit
		if(hasWaitedForFirstSpeedChange == false){
			hasWaitedForFirstSpeedChange = true;
			canFire = false;
			yield return new WaitForSeconds (4); 
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
			yield return new WaitForSeconds (4); 
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
			yield return new WaitForSeconds (4); 
			canFire = true;
			line.spinningSpeed = GameManager.Instance.lineSpinningSpeed4;     
		}
	}
	
	public void determineBlueSpeeds(){
		//TESTED
		if(RunningTime.TotalSeconds >= 0 && RunningTime.TotalSeconds < 15){  
			projectile.Speed = GameManager.Instance.projectileSpeed1;
			projectile2.Speed = GameManager.Instance.projectileSpeed1; 
			waitTime = GameManager.Instance.firstWaitTime1;
			waitTime2 = GameManager.Instance.secondWaitTime1;
			line.spinningSpeed = GameManager.Instance.lineSpinningSpeed1;  //179
			hasWaitedForFirstSpeedChange = false;    
		} 
		
		//TESTED
		else if(RunningTime.TotalSeconds >= 15 && RunningTime.TotalSeconds < 30){  
			waitForFirstSpeedChange();   
			projectile.Speed = GameManager.Instance.projectileSpeed2;
			projectile2.Speed = GameManager.Instance.projectileSpeed2; 
			waitTime = GameManager.Instance.firstWaitTime2;
			waitTime2 = GameManager.Instance.secondWaitTime2;
		} 
		
		//TESTED
		else if(RunningTime.TotalSeconds >= 30 && RunningTime.TotalSeconds < 45){  
			waitForSecondSpeedChange();
			projectile.Speed = GameManager.Instance.projectileSpeed3;
			projectile2.Speed = GameManager.Instance.projectileSpeed3; 
			waitTime = GameManager.Instance.firstWaitTime3;
			waitTime2 = GameManager.Instance.secondWaitTime3;
		} 
		
		//		//TESTED
		else if(RunningTime.TotalSeconds >= 45){// && RunningTime.TotalSeconds < 45){  
			waitForThirdSpeedChange();
			projectile.Speed = GameManager.Instance.projectileSpeed4;
			projectile2.Speed = GameManager.Instance.projectileSpeed4; 
			waitTime = GameManager.Instance.firstWaitTime4;
			waitTime2 = GameManager.Instance.secondWaitTime4;
		} 
	}
	
	
}
