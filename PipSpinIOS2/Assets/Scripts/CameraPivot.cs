using UnityEngine;
using System.Collections;

public class CameraPivot : MonoBehaviour {
	
	public Animator Animator; 
	
	void Start () {
		
	}
	
	void Update () {
		
	}
	
	public void rotateGameOver(){
		Animator.SetTrigger("rotateGameOver"); 
	}
	
	public void rotateStartGame(){
		Animator.SetTrigger("rotateStartGame");   
	}    
}
