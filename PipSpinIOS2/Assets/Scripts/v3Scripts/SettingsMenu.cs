using UnityEngine;
using System.Collections;

public class SettingsMenu : MonoBehaviour {
		
	void Start () {
		
	}
	
	void Update () {
		HandleKeyboard();
		HandleUserTouches();
	}
	
	public void HandleKeyboard(){
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			returnToMainMenu();
		} else if (Input.GetKeyDown(KeyCode.Alpha2)) {
			returnToMainMenu();
		} 
	}
	
	public void HandleUserTouches(){
		for (int i = 0; i < Input.touchCount; i++){  
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began){
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);  
				if(touchPosition.x < 1 && touchPosition.x > -1){
					// 
				}else if(touchPosition.x < -1){
					//
				}
			}
		}
	}
	
	
	public void muteGame(){

	}

	public void rateGame(){

	}

	public void viewMoreGame(){
		
	}

	public void returnToMainMenu(){
		Application.LoadLevel (0);
	}

}
