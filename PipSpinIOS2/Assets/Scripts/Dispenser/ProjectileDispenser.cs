using UnityEngine;
using System.Collections;

public class ProjectileDispenser : MonoBehaviour {

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

	void Start () {
		fireRandomSequence();
	}

	void Update () {
		HandleKeyboard();
		//fireRandomSequence();
	}

	public void HandleKeyboard(){

		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			fireFromLeft1();
			fireFromRight1(); 
		}else if (Input.GetKeyDown(KeyCode.Alpha2)) {
			fireFromLeft2();
			fireFromRight2(); 
		}else if (Input.GetKeyDown(KeyCode.Alpha3)) {   
			fireFromRight1();
			fireFromRight2();   
		}else if (Input.GetKeyDown(KeyCode.Alpha4)) {
			fireFromRight2();
		}else if (Input.GetKeyDown(KeyCode.Alpha5)) {
			initiateBackForth1();
		}else if (Input.GetKeyDown(KeyCode.Alpha6)) {
			initiateBackForth2();
		}else if (Input.GetKeyDown(KeyCode.Alpha7)) {
			initiateSpiralLeftSequence();
		}else if (Input.GetKeyDown(KeyCode.Alpha8)) {
			initiateSpiralRightSequence();
		}else if (Input.GetKeyDown(KeyCode.Alpha9)) {
			initiateRandomLocations();
		}else if (Input.GetKeyDown(KeyCode.Alpha0)) {
			initiateFunPattern1();
		}else if (Input.GetKeyDown(KeyCode.Q)) {
			initiateFunPattern2(); 
		}else if (Input.GetKeyDown(KeyCode.W)) {
			initiateFunPattern3(); 
		}else if (Input.GetKeyDown(KeyCode.E)) {
			initiateFunPattern4(); 
		}
	}

	public void fireRandomSequence(){
		float sequenceNumber = random.Next (1, 10);
		if(sequenceNumber == 1){ 
			initiateBackForth1();
		}else if(sequenceNumber == 2){
			initiateBackForth2();
		}else if(sequenceNumber == 3){
			initiateSpiralLeftSequence();
		}else if(sequenceNumber == 4){
			initiateSpiralRightSequence();
		}else if(sequenceNumber == 5){ 
			initiateRandomLocations();
		}else if(sequenceNumber == 6){
			initiateFunPattern1();
		}else if(sequenceNumber == 7){
			initiateFunPattern2();
		}else if(sequenceNumber == 8){
			initiateFunPattern3();
		}else if(sequenceNumber == 9){ 
			initiateFunPattern4();
		}
	}

	public void fireFromLeft1(){
		AudioSource.PlayClipAtPoint(CHi, transform.position);
		var liveProjectile = (Projectile)Instantiate (projectile, Left1ProjectileSpawnLocation, transform.rotation); 
		liveProjectile.Initialize (gameObject, downRight, new Vector2(1, -1)); 
		liveProjectile.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
		//liveProjectile.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + 45 , transform.rotation.w);

		activeProjectiles ++;
	}

	public void fireFromLeft2(){
		AudioSource.PlayClipAtPoint(CLow, transform.position);
		var liveProjectile = (Projectile)Instantiate (projectile2, Left2ProjectileSpawnLocation, transform.rotation); 
		liveProjectile.Initialize (gameObject, downRight, new Vector2(1, -1));  
		liveProjectile.GetComponent<SpriteRenderer>().color = Color.black; 

		liveProjectile.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
		activeProjectiles ++;
	}
	
	public void fireFromRight1(){
		AudioSource.PlayClipAtPoint(G, transform.position);
		var liveProjectile = (Projectile)Instantiate (projectile, Right1ProjectileSpawnLocation, transform.rotation); 
		liveProjectile.Initialize (gameObject, downLeft, new Vector2(-1, -1));  
		activeProjectiles ++;
		//liveProjectile.GetComponent<SpriteRenderer>().color = Color.black; 
		liveProjectile.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
		//liveProjectile.GetComponent<SpriteRenderer>().color = Color.red;  

	}

	public void fireFromRight2(){
		AudioSource.PlayClipAtPoint(F, transform.position);  
		var liveProjectile = (Projectile)Instantiate (projectile2, Right2ProjectileSpawnLocation, transform.rotation); 
		liveProjectile.Initialize (gameObject, downLeft, new Vector2(-1, -1));  
		activeProjectiles ++;
		liveProjectile.GetComponent<SpriteRenderer>().color = Color.black; 
		//liveProjectile.GetComponent<SpriteRenderer>().color = Color.blue; 
		liveProjectile.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;  
	}

	public void initiateBackForth1(){
		StartCoroutine(BackForth1Co());                
	}
	
	private IEnumerator BackForth1Co(){
		fireFromLeft1();
		yield return new WaitForSeconds (waitTime2);     
		fireFromRight2();
		yield return new WaitForSeconds (waitTime2);     
		fireFromLeft1();
		yield return new WaitForSeconds (waitTime2);     
		fireFromRight2();  
		yield return new WaitForSeconds (waitTime2);  
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

	public void initiateSpiralLeftSequence(){
		StartCoroutine(SpiralLeftCo());                
	}
	
	private IEnumerator SpiralLeftCo(){
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
		//fireFromLeft2();
		yield return new WaitForSeconds (waitTime);     
		fireFromLeft2();
		//fireFromRight2();
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

	public void initiateFunPattern1(){
		StartCoroutine(funPatternCo());    
	}

	private IEnumerator funPatternCo(){
		fireFromLeft1();
		yield return new WaitForSeconds (waitTime); 
		fireFromLeft2();
		yield return new WaitForSeconds (waitTime); 
		fireFromRight2();
		yield return new WaitForSeconds (waitTime); 
		fireFromRight1();
		yield return new WaitForSeconds (waitTime); 
		fireFromLeft1();
		yield return new WaitForSeconds (waitTime); 
		fireFromLeft2();
		yield return new WaitForSeconds (waitTime ); 
		fireFromRight2();
		yield return new WaitForSeconds (waitTime); 
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
		fireFromRight1();
		yield return new WaitForSeconds (waitTime); 
		fireFromRight2();
		yield return new WaitForSeconds (waitTime); 
		fireFromLeft2();
		yield return new WaitForSeconds (waitTime); 
		fireFromLeft1();
		yield return new WaitForSeconds (waitTime); 
		fireFromRight1();
		yield return new WaitForSeconds (waitTime); 
		fireFromRight2();  
		yield return new WaitForSeconds (waitTime2); 
		fireRandomSequence();
	}

	public void initiateFunPattern3(){
		StartCoroutine(funPattern3Co());    
	}
	
	private IEnumerator funPattern3Co(){
		fireFromLeft1();
		yield return new WaitForSeconds (waitTime); 
		fireFromLeft2();
		yield return new WaitForSeconds (waitTime2); 
		fireFromRight1();
		yield return new WaitForSeconds (waitTime); 
		fireFromRight2();
		yield return new WaitForSeconds (waitTime2); 
		fireFromLeft1();
		yield return new WaitForSeconds (waitTime); 
		fireFromLeft2();
		yield return new WaitForSeconds (waitTime2);      
		fireFromRight1();
		yield return new WaitForSeconds (waitTime); 
		fireFromRight2();  
		yield return new WaitForSeconds (waitTime2);  
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
		fireFromRight2();
		yield return new WaitForSeconds (waitTime); 
		fireFromRight1();
		yield return new WaitForSeconds (waitTime2); 
		fireFromLeft2();
		yield return new WaitForSeconds (waitTime); 
		fireFromLeft1();
		yield return new WaitForSeconds (waitTime2); 
		fireFromRight2();
		yield return new WaitForSeconds (waitTime); 
		fireFromRight1();  
		yield return new WaitForSeconds (waitTime2); 
		fireRandomSequence();
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
		yield return new WaitForSeconds (waitTime2); 
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
		yield return new WaitForSeconds (waitTime2); 
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
		yield return new WaitForSeconds (waitTime2); 
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
		yield return new WaitForSeconds (waitTime2); 
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
		yield return new WaitForSeconds (waitTime2); 
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
		yield return new WaitForSeconds (waitTime2); 
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
		yield return new WaitForSeconds (waitTime2); 
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
}
