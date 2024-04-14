using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GreenDispenser : MonoBehaviour {
	
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
	public Animator Animator; 
	
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
		hasWaitedForThirdSpeedChange = false;
		determineGreenSpeeds();
		fireRandomSequence();
	}
	
	void Update () {
		HandleKeyboard();
		determineGreenSpeeds();
	}
	
	public void HandleKeyboard(){
		
	}
	
	public void fireRandomSequence(){
		initiateRandomLocations();
	}
	
	public void fireFromLeft1(){
		if(canFire){
			//Animator.SetTrigger("NegPulse"); 
			AudioSource.PlayClipAtPoint(CLow, transform.position);
			var liveProjectile = (Projectile)Instantiate (projectile, Left1ProjectileSpawnLocation, transform.rotation); 
			liveProjectile.Initialize (gameObject, downRight, new Vector2(1, -1)); 
			liveProjectile.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
			activeProjectiles ++;
		}
	}
	
	public void fireFromLeft2(){
		if(canFire){
			//Animator.SetTrigger("NegPulse");    
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
			//Animator.SetTrigger("NegPulse");
			AudioSource.PlayClipAtPoint(G, transform.position);
			var liveProjectile = (Projectile)Instantiate (projectile, Right1ProjectileSpawnLocation, transform.rotation); 
			liveProjectile.Initialize (gameObject, downLeft, new Vector2(-1, -1));  
			activeProjectiles ++;
			liveProjectile.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
		}
	}
	
	public void fireFromRight2(){
		if(canFire){             
			//Animator.SetTrigger("NegPulse");
			AudioSource.PlayClipAtPoint(CHi, transform.position);  
			var liveProjectile = (Projectile)Instantiate (projectile2, Right2ProjectileSpawnLocation, transform.rotation); 
			liveProjectile.Initialize (gameObject, downLeft, new Vector2(-1, -1));  
			activeProjectiles ++;
			liveProjectile.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;  
		}
	}
	
	public void initiateRandomLocations(){
		StartCoroutine(fireFromRandomLocationsCo());                
	}
	
	private IEnumerator fireFromRandomLocationsCo(){
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
		yield return new WaitForSeconds (waitTime); 
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
		yield return new WaitForSeconds (waitTime); 
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
		yield return new WaitForSeconds (waitTime); 
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
		yield return new WaitForSeconds (waitTime); 
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
		yield return new WaitForSeconds (waitTime); 
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
		yield return new WaitForSeconds (waitTime); 
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
		yield return new WaitForSeconds (waitTime); 
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
		yield return new WaitForSeconds (waitTime); 
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

	public void determineGreenSpeeds(){
		if(RunningTime.TotalSeconds >= 0 && RunningTime.TotalSeconds < 15){  
			projectile.Speed = GameManager.Instance.projectileSpeed1;
			projectile2.Speed = GameManager.Instance.projectileSpeed1; 
			waitTime = GameManager.Instance.firstWaitTime1 * 1.5f;
			waitTime2 = GameManager.Instance.secondWaitTime1;
			line.spinningSpeed = GameManager.Instance.lineSpinningSpeed1;  
			hasWaitedForFirstSpeedChange = false;    
		} 
		
		else if(RunningTime.TotalSeconds >= 15 && RunningTime.TotalSeconds < 30){  
			waitForFirstSpeedChange();
			projectile.Speed = GameManager.Instance.projectileSpeed2;
			projectile2.Speed = GameManager.Instance.projectileSpeed2; 
			waitTime = GameManager.Instance.firstWaitTime2 * 1.5f;
			waitTime2 = GameManager.Instance.secondWaitTime2;
		} 
		
		else if(RunningTime.TotalSeconds >= 30 && RunningTime.TotalSeconds < 45){  
			waitForSecondSpeedChange();
			projectile.Speed = GameManager.Instance.projectileSpeed3;
			projectile2.Speed = GameManager.Instance.projectileSpeed3; 
			waitTime = GameManager.Instance.firstWaitTime3 * 1.5f;
			waitTime2 = GameManager.Instance.secondWaitTime3;
		} 
		
		else if(RunningTime.TotalSeconds >= 45){
			waitForThirdSpeedChange();
			projectile.Speed = GameManager.Instance.projectileSpeed4;
			projectile2.Speed = GameManager.Instance.projectileSpeed4; 
			waitTime = GameManager.Instance.firstWaitTime4 * 1.5f;
			waitTime2 = GameManager.Instance.secondWaitTime4;
		} 
	}
}
