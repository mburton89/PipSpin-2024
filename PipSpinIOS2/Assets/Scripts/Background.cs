using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	public Animator Animator; 
	
	void Start () {
		
	}
	
	void Update () {
		
	}
	
	public void initiateGameOverAnimation(){
		Animator.SetTrigger("BOGameOver"); 
	}
}
