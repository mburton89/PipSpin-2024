using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GUISkin Skin;
	public int speedSelection;

	void Start () {
		speedSelection = 1;
	}

	void Update () {
		HandleKeyboard();
	}
	
	public void HandleKeyboard(){
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			decreaseSpeedToChoose();
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			increaseSpeedToChoose();
		} else if (Input.GetKeyDown (KeyCode.S)) {
			startGame();
		}
	}

	public void increaseSpeedToChoose(){
//		if(PlayerPrefs.GetInt("HighestSpeedGottenTo") < speedSelection + 1){
			speedSelection ++;
//		}
	}

	public void decreaseSpeedToChoose(){
		speedSelection --;
	}

	public void startGame(){
		Application.LoadLevel (1);
		hideMenu();
	}

	public void hideMenu(){

	}

	public void OnGUI(){
		GUI.skin = Skin;
		GUILayout.BeginArea(new Rect(0 ,0, Screen.width, Screen.height)); //also added padding for GameSkin on Inspector
		{
			GUILayout.BeginVertical(Skin.GetStyle("EnemyKillText"));
			{
				//if(Application.loadedLevel == 0){
					GUILayout.Label(string.Format("{0}", speedSelection), Skin.GetStyle("EnemyKillText")); 
				//}
			}
			GUILayout.EndVertical();
		}
		GUILayout.EndArea();
	}
}
