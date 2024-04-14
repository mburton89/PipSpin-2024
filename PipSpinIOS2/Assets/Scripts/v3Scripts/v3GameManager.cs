using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class v3GameManager : MonoBehaviour {

	public DateTime started;
	public TimeSpan RunningTime{get{return DateTime.UtcNow - started;}}
	public bool isInsaneMode;
	public int normalModeScore;

	void Start () {
		started = DateTime.UtcNow; 
		establishLevelSettings();
	}

	void Update () {
		determineSpeeds();
	}

	public void establishLevelSettings(){
		if(isInsaneMode){
			initiateSpeed(5);
		}else{
			initiateSpeed(1);
		}
	}

	public void determineSpeeds(){
		if(isInsaneMode){
			if(RunningTime.TotalSeconds > 16){
				initiateSpeed(9);
				return;
			}else if(RunningTime.TotalSeconds > 12){
				initiateSpeed(8);
				return;
			}else if(RunningTime.TotalSeconds > 8){
				initiateSpeed(7); 
				return;
			}else if(RunningTime.TotalSeconds > 4){
				initiateSpeed(6);
				return;
			}else{
				initiateSpeed(5);
			}
		}else{
			if(RunningTime.TotalSeconds > 32){
				initiateSpeed(9);
				return;
			}else if(RunningTime.TotalSeconds > 28){
				initiateSpeed(8);
				return;
			}else if(RunningTime.TotalSeconds > 24){
				initiateSpeed(7);
				return;
			}else if(RunningTime.TotalSeconds > 20){
				initiateSpeed(6);
				return;
			}else if(RunningTime.TotalSeconds > 16){
				initiateSpeed(5);
				return;
			}else if(RunningTime.TotalSeconds > 12){
				initiateSpeed(4);
				return;
			}else if(RunningTime.TotalSeconds > 8){
				initiateSpeed(3);
				return;
			}else if(RunningTime.TotalSeconds > 4){
				initiateSpeed(2);
				return;
			}else{
				initiateSpeed(1);
			}
		}
	}

	public void initiateSpeed(int speed){
		if(speed == 1){

		}else if(speed == 2){
			
		}else if(speed == 3){
			
		}else if(speed == 4){
			
		}else if(speed == 5){
			
		}else if(speed == 6){
			
		}else if(speed == 7){
			
		}else if(speed == 8){
			
		}else if(speed == 9){
		
		}
	}

	public void endGame(){
		//DISPLAY GAME OVER ANIMATIONS

		//RECORD SCORE
		normalModeScore =  (int)RunningTime.TotalSeconds;
		PlayerPrefs.SetInt("normalHighScore", normalModeScore);

		//RETURN TO MAIN MENU
		Application.LoadLevel(1);
	}
}
