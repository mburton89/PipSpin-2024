using UnityEngine;
using System.Collections;

public class LowerHUDTab : MonoBehaviour {
	
	public Animator Animator; 
	
	void Start () {
		
	}
	
	void Update () {
		
	}
	
	public void closeLowerTab(){
		Animator.SetTrigger("LowerTabGoUp");   
		//		Animator.SetTrigger("LeftTabGoRight");
		//		Animator.SetTrigger("RightTabGoLeft");
		//		Debug.Log("STUFFFFF");  
	}
	
	public void openLowerTab(){
		Animator.SetTrigger("LowerTabGoDown");
		//		Animator.SetTrigger("LeftTabGoLeft");
		//		Animator.SetTrigger("RightTabGoRight");
	}
}
