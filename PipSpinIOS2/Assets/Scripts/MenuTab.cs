using UnityEngine;
using System.Collections;

public class MenuTab : MonoBehaviour {

	public Animator Animator; 
	
	void Start () {
		
	}
	
	void Update () {
		
	}
	
	public void menuTabStartGame(){
		Animator.SetTrigger("menuTabStartGame");   
	}  
}
