using System;
using System.Collections;
using System.Collections.Generic;  
using System.Linq;
using UnityEngine;

public class GameHud : MonoBehaviour{
	
	public GUISkin Skin;
	public SpinningLine line;
	public TimeSpan RunningTime{get{return DateTime.UtcNow - started;}}
	public DateTime started; 

	public void Start () {
	
		started = DateTime.UtcNow; 
		line = FindObjectOfType<SpinningLine> (); 
	}

	public void OnGUI(){
		GUI.skin = Skin;
		GUILayout.BeginArea(new Rect(0 ,0, Screen.width, Screen.height)); //also added padding for GameSkin on Inspector
		{
			GUILayout.BeginVertical(Skin.GetStyle("EnemyKillText")); 
			{
				//if(Application.loadedLevel == 0){
				GUILayout.Label(string.Format("{0}", "TIME: " + (RunningTime.TotalSeconds * 10 + GameManager.Instance.pointsAlreadyAccumulated).ToString("f0")), Skin.GetStyle("EnemyKillText")); 
				GUILayout.Label(string.Format("{0}", "SPEED: " + ("TODO")), Skin.GetStyle("EnemyKillText")); 
				//}
			}
			GUILayout.EndVertical();
		}
		GUILayout.EndArea();
	}

//	public void OnGUI(){
//		GUI.skin = Skin;
//		GUI.color = line.GetComponent<SpriteRenderer>().color;
//		
//		GUILayout.BeginArea(new Rect(0 ,0, Screen.width, Screen.height)); //also added padding for GameSkin on Inspector
//		{
//			GUILayout.BeginVertical(Skin.GetStyle("EnemyKillText"));
//			{
//				//if(Application.loadedLevel == 1){
//				GUILayout.Label(string.Format("{0}", "RunningTime.TotalSeconds", Skin.GetStyle("EnemyKillText"));   
//				//}
//				
//				//				if(Application.loadedLevel == 0 || Application.loadedLevel == 4){
//				//					GUILayout.Label(string.Format("NINJEVADE"), Skin.GetStyle("EnemyKillText")); 
//				//				}
//				
//				//				if(Application.loadedLevel == 2){
//				//					GUILayout.Label(string.Format("GAME OVER"), Skin.GetStyle("EnemyKillText"));
//				//				}
//				
//				//		UNCOMMENT FOR TIME GUI
//				//				var time = LevelManager.Instance.RunningTime;
//				//				GUILayout.Label(string.Format(
//				//					"{0:00}:{1:00} with {2} bonus", 
//				//					time.Minutes + (time.Hours * 60), 
//				//					time.Seconds,
//				//				    LevelManager.Instance.CurrentTimeBonus), Skin.GetStyle("TimeText"));
//			}
//			GUILayout.EndVertical();
//		}
//		GUILayout.EndArea();
//	}
}