using UnityEngine;
using System.Collections;

public class RightHUDTab : MonoBehaviour {
	
	public Animator Animator; 
	
	void Start () {
		
	}
	
	void Update () {
		
	}
	
	public void lowerRightTab(){
		Animator.SetTrigger("RightTabGoLeft");
	}  
	
	public void raiseRightTab(){
		Animator.SetTrigger("RightTabGoRight");
	}
}
