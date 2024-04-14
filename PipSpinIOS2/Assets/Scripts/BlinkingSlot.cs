using UnityEngine;
using System.Collections;

public class BlinkingSlot : MonoBehaviour {

	public Animator Animator;

	void Start () {
	
	}

	void Update () {
	
	}

	public void remainBlack(){
		Animator.SetTrigger("remainBlack");
	}

	public void remainGreen(){
		Animator.SetTrigger("remainGreen");
	}

	public void blink(){
		Animator.SetTrigger("blink");
	}
}
