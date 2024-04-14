using UnityEngine;
using System.Collections;

public class LeftHUDTab : MonoBehaviour {
	
	public Animator Animator; 
	
	void Start () {
		
	}
	
	void Update () {
		
	}
	
	public void lowerLeftTab(){
		Animator.SetTrigger("LeftTabGoRight");
		//		Animator.SetTrigger("RightTabGoLeft");
		//		Debug.Log("STUFFFFF");  
	}
	
	public void raiseLeftTab(){
		Animator.SetTrigger("LeftTabGoLeft");
		//		Animator.SetTrigger("RightTabGoRight");
	}
}
