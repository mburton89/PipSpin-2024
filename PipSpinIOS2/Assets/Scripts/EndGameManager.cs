using UnityEngine;
using System.Collections;

public class EndGameManager : MonoBehaviour {

	//BOOT UP SCREEN STUFF
	public GameObject fullBG;
	public GameObject Cover1;
	public GameObject Cover2;
	public GameObject Cover3;
	public GameObject textRow1;

	void Start () {
		bootUp();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void bootUp(){
		StartCoroutine(bootUpCo()); 
	}

	private IEnumerator bootUpCo(){ 
		//middleText.SetActive(false);
		yield return new WaitForSeconds (8f);
		Cover1.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		yield return new WaitForSeconds (3f);
		Cover2.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		yield return new WaitForSeconds (3f);
		Cover3.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		yield return new WaitForSeconds (3f);
		Application.LoadLevel(1);
	}
}
