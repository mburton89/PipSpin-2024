using UnityEngine;
using System.Collections;

public class HUDTab : MonoBehaviour {

	public Animator Animator; 
	
	void Start () {

	}

	void Update () {
	
	}

	public void startGameFlicker(){
		gameObject.GetComponent<Animator>().enabled = true;
		gameObject.GetComponent<SpriteRenderer>().enabled = true;
		Animator.SetTrigger("startGameFlicker"); 
	}
}
