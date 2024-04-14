using UnityEngine;
using System.Collections;

public class ScreenShotter : MonoBehaviour {

	public string picNumber;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Keypad1)){
			takeScreenshot35();
			//picNumber ++;
		}else if(Input.GetKeyDown(KeyCode.Keypad2)){
			takeScreenshot4();
			//picNumber ++;
		}else if(Input.GetKeyDown(KeyCode.Keypad3)){
			takeScreenshot47();
			//picNumber ++;
		}else if(Input.GetKeyDown(KeyCode.Keypad4)){
			takeScreenshot55();
			//picNumber ++;
		}else if(Input.GetKeyDown(KeyCode.Keypad5)){
			takeScreenshotiPad();
			//picNumber ++;
		}else if(Input.GetKeyDown(KeyCode.Keypad6)){
			takeScreenshotiPadPro();
			//picNumber ++;
		}
	}

	public void takeScreenshot35(){
		ScreenCapture.CaptureScreenshot("C:\\Users\\Matt\\Desktop\\PipSpinImages\\Screenshots\\3p5in_" + picNumber + "_PSScreenshot.png"); 
	}

	public void takeScreenshot4(){
		ScreenCapture.CaptureScreenshot("C:\\Users\\Matt\\Desktop\\PipSpinImages\\Screenshots\\4in_" + picNumber + "_PSScreenshot.png",2); 
	}

	public void takeScreenshot47(){
		ScreenCapture.CaptureScreenshot("C:\\Users\\Matt\\Desktop\\PipSpinImages\\Screenshots\\4p7in_" + picNumber + "_PSScreenshot.png",2); 
	}

	public void takeScreenshot55(){
		ScreenCapture.CaptureScreenshot("C:\\Users\\Matt\\Desktop\\PipSpinImages\\Screenshots\\5p5in_" + picNumber + "_PSScreenshot.png",3); 
	}

	public void takeScreenshotiPad(){
		ScreenCapture.CaptureScreenshot("C:\\Users\\Matt\\Desktop\\PipSpinImages\\Screenshots\\iPad_" + picNumber + "_PSScreenshot.png",2); 
	}

	public void takeScreenshotiPadPro(){
		ScreenCapture.CaptureScreenshot("C:\\Users\\Matt\\Desktop\\PipSpinImages\\Screenshots\\iPadPro_" + picNumber + "_PSScreenshot.png",4); 
	}
}
