using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour {
//
	public bool isGreen;
	public bool isCyan;
	public bool isBlue;
	public bool isMagenta;
	public bool isPurple;
	public bool isRed;
	public bool isOrange;
	public bool isAmber;
	public bool isWhite;

	void Awake () {
		determineColor();
	}
		
//	void Start () {
//		//isGreen = true;
//		//PlayerPrefs.SetString("Color","d");
//		determineColor();
//	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.C)){
			turnColor();
		}else if(Input.GetKeyDown(KeyCode.I)){
			invertColors();
		}
	}

	public void invertColors () {
		SpriteRenderer[] nonBlackRenderers;
		SpriteRenderer[] blackRenderers;

		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
		foreach (SpriteRenderer render in renderers) {
			if (render.color != Color.black) {
				//nonBlackRenderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
				render.color = Color.cyan;
			}else{
				render.color = Color.blue;
			}

		}

//		foreach (SpriteRenderer nonBlackRender in renderers) {
//			nonBlackRender.color = Color.black;
//		}
//		foreach (SpriteRenderer blackRender in renderers) {
//			blackRender.color = Color.green;
//		} 

		isGreen = true;
		isWhite = false;
		PlayerPrefs.SetString("Color","Green");
	}

	public void turnGreen () {
		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
		foreach (SpriteRenderer render in renderers) {
			if (render.color != Color.black) {
				render.color = Color.green;
			}
		}
		isGreen = true;
		isWhite = false;
		PlayerPrefs.SetString("Color","Green");
	}

	public void turnCyan () {
		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
		foreach (SpriteRenderer render in renderers) {
			if (render.color != Color.black) {
				render.color = Color.cyan;
			}
		}
		isCyan = true;
		isGreen = false;
		PlayerPrefs.SetString("Color","Cyan");
	}

	public void turnBlue(){
		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
		foreach (SpriteRenderer render in renderers) {
			if (render.color != Color.black) {
				render.color = Color.blue;
			}
		}
		isBlue = true;
		isCyan = false;
		PlayerPrefs.SetString("Color","Blue");
	}

	public void turnMagenta () {
		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
		foreach (SpriteRenderer render in renderers) {
			if (render.color != Color.black) {
				render.color = Color.magenta;
			}
		}
		isMagenta = true;
		isBlue = false;
		PlayerPrefs.SetString("Color","Magenta");
	}

	public void turnPurple () {
		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
		foreach (SpriteRenderer render in renderers) {
			if (render.color != Color.black) {
				render.color = new Color(.7f, .1f, .85f, 1f);
			}
		}
		isPurple = true;
		isMagenta = false;
		PlayerPrefs.SetString("Color","Purple");
	}

	public void turnRed () {
		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
		foreach (SpriteRenderer render in renderers) {
			if (render.color != Color.black) {
				render.color = Color.red;
			}
		}
		isRed = true;
		isPurple = false;
		PlayerPrefs.SetString("Color","Red");
	}

	public void turnOrange () {
		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
		foreach (SpriteRenderer render in renderers) {
			if (render.color != Color.black) {
				render.color = new Color(1, .6f, 0.0f, 1f);
			}
		}
		isOrange = true;
		isRed = false;
		PlayerPrefs.SetString("Color","Orange");
	}

	public void turnAmber () {
		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
		foreach (SpriteRenderer render in renderers) {
			if (render.color != Color.black) {
				render.color = Color.yellow;
			}
		}
		isAmber = true;
		isOrange = false;
		PlayerPrefs.SetString("Color","Amber");
	}

	public void turnWhite () {
		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
		foreach (SpriteRenderer render in renderers) {
			if (render.color != Color.black) {
				render.color = Color.white;
			}
		}
		isWhite = true;
		isAmber = false;
		PlayerPrefs.SetString("Color","White");
	}

	public void turnColor () {
		if(isGreen){
			turnCyan();
			return;
		}
		else if(isCyan){
			turnBlue();
			return;
		}
		else if(isBlue){
			turnMagenta();
			return;
		}
		else if(isMagenta){
			turnPurple();
			return;
		}
		else if(isPurple){
			turnRed();
			return;
		}
		else if(isRed){
			turnOrange();
			return;
		}
		else if(isOrange){
			turnAmber();
			return;
		}
		else if(isAmber){
			turnWhite();
			return;
		}
		else if(isWhite){
			turnGreen();
			return;
		}
		else{
			turnCyan();
			return;
		}
	}


//	public void turnColor () {
//		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
//		foreach (SpriteRenderer render in renderers) {
//			if (render.color != Color.black) {
//				render.color = Color.green;
//
//			}	
//		}
//	}

	public void resetColorBools(bool trueBool){
		isGreen = false;
		isCyan = false;
		isBlue = false;
		isMagenta = false;
		isPurple = false;
		isRed = false;
		isOrange = false;
		isAmber = false;
		isWhite = false;

		trueBool = true;
	}

	public void determineColor(){
		if(PlayerPrefs.GetString("Color") == "Green"){
			turnGreen();
		}else if(PlayerPrefs.GetString("Color") == "Cyan"){
			turnCyan();
		}else if(PlayerPrefs.GetString("Color") == "Blue"){
			turnBlue();
		}else if(PlayerPrefs.GetString("Color") == "Magenta"){
			turnMagenta();
		}else if(PlayerPrefs.GetString("Color") == "Purple"){
			turnPurple();
		}else if(PlayerPrefs.GetString("Color") == "Red"){
			turnRed();
		}else if(PlayerPrefs.GetString("Color") == "Orange"){
			turnOrange();
		}else if(PlayerPrefs.GetString("Color") == "Amber"){
			turnAmber();
		}else if(PlayerPrefs.GetString("Color") == "White"){
			turnWhite();
		}
	}
}
