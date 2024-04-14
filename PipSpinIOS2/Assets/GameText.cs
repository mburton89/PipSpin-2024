using UnityEngine;
using System.Collections;

public class GameText : MonoBehaviour {

	void Start () {
		gameObject.GetComponent<MeshRenderer>().sortingLayerName = "Player";
		gameObject.GetComponent<MeshRenderer>().sortingOrder = 6;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
