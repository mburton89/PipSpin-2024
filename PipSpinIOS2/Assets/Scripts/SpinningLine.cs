using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpinningLine : MonoBehaviour {

	public Animator Animator; 
	public AudioClip Bass;
	public AudioClip Snare;
	public int spinningSpeed;
	public bool canSpin;

	public GameObject leftSide;
	public GameObject rightSide;
	public AudioSource AudioSource;

	public MusicManager musicManager;

	private bool isLit;

	void Start () {
		//AudioSource.GetComponent<AudioSource>().clip = musicManager.CurrentLineBuzz;

		//if(Application.loadedLevel != 0){
			canSpin = true;
		//}
		Animator.enabled = false;
	}

	void Update () {
	
		if(canSpin){
            darkenBothSides();
			HandleKeyboard();
			HandleUserTouches();
			determineSound();
			//AudioSource.enabled = false;
		}else{
			//determineRemainingDistanceToSpin();
			Animator.enabled = true;

			//gameObject.GetComponentInChildren<Animator>().enabled = true;
			//Animator.SetTrigger("LineVanish");
			//gameObject.GetComponentInChildren<Animator>().SetTrigger("LineVanish");
		}
	}

	public void HandleKeyboard(){
		if (Input.GetKey(KeyCode.LeftArrow)) {
			spinLineCounterClockwise();
			//AudioSource.enabled = true;
		}else if (Input.GetKey (KeyCode.RightArrow)) {
			spinLineClockwise();
			//AudioSource.enabled = true;
		}else{
			//darkenBothSides();
			//AudioSource.enabled = false;
		}
	} 

	public void HandleUserTouches(){
		for (int i = 0; i < Input.touchCount; i++){  
			Touch touch = Input.GetTouch(i);
			if (touch.phase >= TouchPhase.Began){ //&& touch.tapCount == 1){
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);  
				if(touchPosition.x < 0){
					spinLineCounterClockwise();  
					//AudioSource.enabled = true;
				}else if(touchPosition.x > 0){
					spinLineClockwise();    
					//AudioSource.enabled = true;
				}
			}//else{
				//darkenBothSides();
			//}
		}
	}

	public void spinOnMenu(){
		transform.Rotate(0, 0, -spinningSpeed* Time.deltaTime,Space.Self);
	}

	public void spinLineClockwise(){
		transform.Rotate(0, 0, -spinningSpeed* Time.deltaTime,Space.Self);    
		lightUpRightSide();
	}
	       
	public void spinLineCounterClockwise(){
		transform.Rotate(0, 0, spinningSpeed * Time.deltaTime,Space.Self); 
		lightUpLeftSide();
	}

	public void lightUpLeftSide(){
		leftSide.GetComponent<SpriteRenderer>().enabled = true;
		rightSide.GetComponent<SpriteRenderer>().enabled = false;
		isLit = true;
	}

	public void lightUpRightSide(){
		rightSide.GetComponent<SpriteRenderer>().enabled = true;
		leftSide.GetComponent<SpriteRenderer>().enabled = false;
		isLit = true;
	}

	public void darkenBothSides(){
		leftSide.GetComponent<SpriteRenderer>().enabled = false;
		rightSide.GetComponent<SpriteRenderer>().enabled = false;
		isLit = false;
	}

	public void determineRemainingDistanceToSpin(){
		int currentSpinningRotation = (int)Math.Ceiling(transform.rotation.eulerAngles.z);
		int remainingDistanceToSpin = currentSpinningRotation % 180;   
//		if(remainingDistanceToSpin != 45){
//			transform.Rotate(0, 0, (200)* Time.deltaTime,Space.Self);
//		}

		if(remainingDistanceToSpin < 40 || remainingDistanceToSpin > 50){
			transform.Rotate(0, 0, (200)* Time.deltaTime,Space.Self);
		}

		Debug.Log((remainingDistanceToSpin) + " REMAINDER");       
		
//		if(remainingDistanceToSpin != 45){
//			transform.Rotate(0, 0, (spinningSpeed)* Time.deltaTime,Space.Self);
//		}
	}

	public void rotateStartGame(){
		Animator.SetTrigger("RotateAgainstCamera");   
	}    

	public void initiateStartGameAnimtaion(){
		gameObject.GetComponent<SpriteRenderer>().enabled = true;
		Animator.enabled = true;
		Animator.SetTrigger("lineStartGame");   
	}

	public void flicker(){
		StartCoroutine(flickerCo()); 
	}
	
	private IEnumerator flickerCo(){ 
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		yield return new WaitForSeconds (.025f);
		gameObject.GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds (.025f);
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		yield return new WaitForSeconds (.025f);
		gameObject.GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds (.025f);
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		yield return new WaitForSeconds (.025f);
		gameObject.GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds (.025f);
	}

	public void determineSound(){
		if(isLit){

			AudioSource.volume = 0.17f;
			//AudioSource.enabled = true;
		}else{
			AudioSource.volume = 0.05f;
			//AudioSource.enabled = false;
		}
	}
}
