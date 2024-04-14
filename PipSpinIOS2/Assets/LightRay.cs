using UnityEngine;
using System.Collections;

public class LightRay : MonoBehaviour {

	public Animator Animator;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void flicker(){
		Animator.SetTrigger("Flicker");
	}
}
