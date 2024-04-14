using UnityEngine;
using System.Collections;

public class RightCover : MonoBehaviour {
	
	public Animator Animator; 
	
	void Start () {
		
	}
	
	void Update () {
		
	}
	
	public void removeRightCover(){
		Animator.SetTrigger("removeRightCover"); 
	}

	public void applyRightCover(){
		Animator.SetTrigger("applyRightCover"); 
	}
}
