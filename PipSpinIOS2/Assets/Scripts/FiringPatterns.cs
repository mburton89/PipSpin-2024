using UnityEngine;
using System.Collections;

public class FiringPatterns : MonoBehaviour {

	public ProjectileDispenser dispenser;
	public float waitTime;
//	private static System.Random random = new System.Random();
//
//	void Start () {   
//		//initiateSpiralSequence(); 
//	}
//	    
//	void Update () {  
//		HandleKeyboard();
//	}   
//	   
//	public void HandleKeyboard(){
//		if (Input.GetKeyDown(KeyCode.M)) {
//			//fireOneShotSequence();
//		}else if (Input.GetKeyDown(KeyCode.N)) {
//			fireTwoSpiralSequence(false, true);
//		}else if (Input.GetKeyDown(KeyCode.B)) { 
//			fireTwoBackForthSequence(true, true);  
//		}else if (Input.GetKeyDown(KeyCode.V)) {
//			fireSpiralTwoNegativeSpiralTwo(true); 
//		}else if (Input.GetKeyDown(KeyCode.C)) { 
//			fireBackForthNegativeBackForth(true);  
//		}
//	}
//
//	public void determineSequence(){
//		if(PlayerPrefs.GetInt("Mode") == 0){
//			//initiateWhiteMode();
//		}else if(PlayerPrefs.GetInt("Mode") == 1){
//			firePurpleSequence();
//		}else if(PlayerPrefs.GetInt("Mode") == 2){
//			fireBlueSequence();
//		}else if(PlayerPrefs.GetInt("Mode") == 3){
//			fireGreenSequence();
//		}else if(PlayerPrefs.GetInt("Mode") == 4){
//			fireYellowSequence();
//		}else if(PlayerPrefs.GetInt("Mode") == 5){
//			fireOrangeSequence();
//		}else if(PlayerPrefs.GetInt("Mode") == 6){
//			fireRedSequence();
//		}else if(PlayerPrefs.GetInt("Mode") == 7){
//			//firePurpleSequence();
//		}
//	}
//
//	public void firePurpleSequence(){
//		float sequenceNumber = random.Next (2, 4);
//		if(sequenceNumber == 1){ 
//			//fireOneShotSequence();
//		}else if(sequenceNumber == 2){
//			fireTwoSpiralSequence(false, false);
//		}else if(sequenceNumber == 3){
//			fireTwoBackForthSequence(false, false);
//		}
//	}
//
//	public void fireBlueSequence(){
//		float sequenceNumber = random.Next (2, 5);
//		if(sequenceNumber == 1){ 
//			//fireOneShotSequence();
//		}else if(sequenceNumber == 2){
//			fireTwoSpiralSequence(true, false);
//		}else if(sequenceNumber == 3){
//			fireTwoBackForthSequence(true, false);
//		}else if(sequenceNumber == 4){
//			fireTwoSpiralSequence(false, true);
//		}
//	}
//
//	public void fireGreenSequence(){
//		float sequenceNumber = random.Next (2, 6);
//		if(sequenceNumber == 1){ 
//			//fireOneShotSequence();
//		}else if(sequenceNumber == 2){
//			fireTwoSpiralSequence(true, false);
//		}else if(sequenceNumber == 3){
//			fireTwoBackForthSequence(true, false);
//		}else if(sequenceNumber == 4){
//			fireTwoSpiralSequence(true, true);
//		}else if(sequenceNumber == 5){
//			fireTwoBackForthSequence(false, true);
//		}
//	}
//
//	public void fireYellowSequence(){
//		float sequenceNumber = random.Next (2, 7);
//		if(sequenceNumber == 1){ 
//			//fireOneShotSequence();
//		}else if(sequenceNumber == 2){
//			fireTwoSpiralSequence(true, false);
//		}else if(sequenceNumber == 3){
//			fireTwoBackForthSequence(true, false);
//		}else if(sequenceNumber == 4){
//			fireTwoSpiralSequence(true, true);
//		}else if(sequenceNumber == 5){
//			fireTwoBackForthSequence(true, true);
//		}else if(sequenceNumber == 6){
//			fireSpiralTwoNegativeSpiralTwo(false);
//		}
//	}
//
//	public void fireOrangeSequence(){
//		float sequenceNumber = random.Next (2, 8);
//		if(sequenceNumber == 1){ 
//			//fireOneShotSequence();
//		}else if(sequenceNumber == 2){
//			fireTwoSpiralSequence(true, false);
//		}else if(sequenceNumber == 3){
//			fireTwoBackForthSequence(true, false);
//		}else if(sequenceNumber == 4){
//			fireTwoSpiralSequence(true, true);
//		}else if(sequenceNumber == 5){
//			fireTwoBackForthSequence(true, true);
//		}else if(sequenceNumber == 6){
//			fireSpiralTwoNegativeSpiralTwo(true);
//		}else if(sequenceNumber == 7){
//			fireBackForthNegativeBackForth(false);
//		}
//	}
//
//		public void fireRedSequence(){
//		float sequenceNumber = random.Next (2, 5);
//		if(sequenceNumber == 1){ 
//			//fireOneShotSequence();
//		}else if(sequenceNumber == 2){
//			fireTwoSpiralSequence(true, false);
//		}else if(sequenceNumber == 3){
//			fireTwoBackForthSequence(true, false);
//		}else if(sequenceNumber == 4){
//			fireTwoSpiralSequence(true, true);
//		}else if(sequenceNumber == 5){
//			fireTwoBackForthSequence(true, true);  
//		}else if(sequenceNumber == 6){
//			fireSpiralTwoNegativeSpiralTwo(true);
//		}else if(sequenceNumber == 7){
//			fireBackForthNegativeBackForth(true);
//		}
//	}
//	
////	public void fireOneShotSequence(){
////		float sequenceNumber = random.Next (1, 5);
////		if(sequenceNumber == 1){ 
////			dispenser.fireFromTopLeft();
////			dispenser.fireFromBottomRight();
////		}else if(sequenceNumber == 2){
////			dispenser.fireFromTopRight();
////			dispenser.fireFromBottomLeft();
////		}else if(sequenceNumber == 3){
////			dispenser.fireFromLeftTop();
////			dispenser.fireFromRightBottom();
////		}else if(sequenceNumber == 4){
////			dispenser.fireFromLeftBottom();
////			dispenser.fireFromRightTop();
////		} 
////		yield return new WaitForSeconds (waitTime);
////		determineSequence();
////	}
//
//	public void fireTwoSpiralSequence(bool capableOfDoubleShot, bool is4Spawns){
//		StartCoroutine(TwoSpiralCo(capableOfDoubleShot, is4Spawns)); 
//	}
//	
//	private IEnumerator TwoSpiralCo(bool capableOfDoubleShot, bool is4Spawns){
//		bool isDoubleShot = false;
//		bool isClockwise = false;
//		bool isFourSpawns = is4Spawns;
//		float sequenceNumber;
//
//		//DETERMINE DOUBLESHOT
//		if(capableOfDoubleShot){
//			float doubleShotNumber = random.Next (1, 3);
//			if(doubleShotNumber == 1){
//				isDoubleShot = true;  
//			}
//		} 
//
//		//DETERMINE CLOCKWISE
//		float isClockwiseNumber = random.Next (1, 3);
//		if(isClockwiseNumber == 1){
//			isClockwise = true;
//		} 
//
//		if(isClockwise){
//			//DETERMINE SEQUENCE
//			sequenceNumber = random.Next (1, 5);
//			if(sequenceNumber == 1){ 
//				dispenser.fireFromLeft2(); 
//				if(isDoubleShot){
//					dispenser.fireFromRight1();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromLeftTop();
//				if(isDoubleShot){
//					dispenser.fireFromRightBottom();
//				}
//				if(isFourSpawns){
//					yield return new WaitForSeconds (waitTime); 
//					dispenser.fireFromLeft2();
//					if(isDoubleShot){
//						dispenser.fireFromRight1();
//					}
//					yield return new WaitForSeconds (waitTime);     
//					dispenser.fireFromLeftTop();
//					if(isDoubleShot){
//						dispenser.fireFromRightBottom();
//					}
//				}
//				
//			}else if(sequenceNumber == 2){ 
//				dispenser.fireFromLeftTop();
//				if(isDoubleShot){
//					dispenser.fireFromRightBottom();
//				}
//				yield return new WaitForSeconds (waitTime);   
//				dispenser.fireFromRight1();
//				if(isDoubleShot){
//					dispenser.fireFromLeft2();
//				}
//				if(isFourSpawns){
//					yield return new WaitForSeconds (waitTime); 
//					dispenser.fireFromLeftTop();
//					if(isDoubleShot){
//						dispenser.fireFromRightBottom();
//					}
//					yield return new WaitForSeconds (waitTime);   
//					dispenser.fireFromRight1();
//					if(isDoubleShot){
//						dispenser.fireFromLeft2();
//					}
//				}
//				
//			}else if(sequenceNumber == 3){
//				dispenser.fireFromRight1();
//				if(isDoubleShot){
//					dispenser.fireFromLeft2();
//				}
//				yield return new WaitForSeconds (waitTime);   
//				dispenser.fireFromRightBottom();
//				if(isDoubleShot){
//					dispenser.fireFromLeftTop();
//				}
//				if(isFourSpawns){
//					yield return new WaitForSeconds (waitTime); 
//					dispenser.fireFromRight1();
//					if(isDoubleShot){
//						dispenser.fireFromLeft2();
//					}
//					yield return new WaitForSeconds (waitTime);   
//					dispenser.fireFromRightBottom();
//					if(isDoubleShot){
//						dispenser.fireFromLeftTop();
//					}
//				}
//				
//			}else if(sequenceNumber == 4){
//				dispenser.fireFromRightBottom();
//				if(isDoubleShot){
//					dispenser.fireFromLeftTop();
//				}
//				yield return new WaitForSeconds (waitTime);   
//				dispenser.fireFromLeft2();
//				if(isDoubleShot){
//					dispenser.fireFromRight1();
//				}
//				if(isFourSpawns){
//					yield return new WaitForSeconds (waitTime);   
//					dispenser.fireFromRightBottom();
//					if(isDoubleShot){
//						dispenser.fireFromLeftTop();
//					}
//					yield return new WaitForSeconds (waitTime);   
//					dispenser.fireFromLeft2();
//					if(isDoubleShot){
//						dispenser.fireFromRight1();
//					}
//				}
//			} 
//		}else{
//			//DETERMINE SEQUENCE
//			sequenceNumber = random.Next (1, 5);
//			if(sequenceNumber == 1){ 
//				dispenser.fireFromLeft1();
//				if(isDoubleShot){
//					dispenser.fireFromRight2();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromLeftBottom();
//				if(isDoubleShot){
//					dispenser.fireFromRightTop();
//				}
//				if(isFourSpawns){
//					yield return new WaitForSeconds (waitTime);  
//					dispenser.fireFromLeft1();
//					if(isDoubleShot){
//						dispenser.fireFromRight2();
//					}
//					yield return new WaitForSeconds (waitTime);     
//					dispenser.fireFromLeftBottom();
//					if(isDoubleShot){
//						dispenser.fireFromRightTop();
//					}
//				}
//
//			}else if(sequenceNumber == 2){
//				dispenser.fireFromLeftBottom();
//				if(isDoubleShot){
//					dispenser.fireFromRightTop();
//				}
//				yield return new WaitForSeconds (waitTime);   
//				dispenser.fireFromRight2();
//				if(isDoubleShot){
//					dispenser.fireFromLeft1();
//				}
//				if(isFourSpawns){
//					yield return new WaitForSeconds (waitTime);   
//					dispenser.fireFromLeftBottom();
//					if(isDoubleShot){
//						dispenser.fireFromRightTop();
//					}
//					yield return new WaitForSeconds (waitTime);   
//					dispenser.fireFromRight2();
//					if(isDoubleShot){
//						dispenser.fireFromLeft1();
//					}
//				}
//
//			}else if(sequenceNumber == 3){
//				dispenser.fireFromRight2();
//				if(isDoubleShot){
//					dispenser.fireFromLeft1();
//				}
//				yield return new WaitForSeconds (waitTime);   
//				dispenser.fireFromRightTop();
//				if(isDoubleShot){
//					dispenser.fireFromLeftBottom();
//				}
//				if(isFourSpawns){
//					yield return new WaitForSeconds (waitTime);
//					dispenser.fireFromRight2();
//					if(isDoubleShot){
//						dispenser.fireFromLeft1();
//					}
//					yield return new WaitForSeconds (waitTime);   
//					dispenser.fireFromRightTop();
//					if(isDoubleShot){
//						dispenser.fireFromLeftBottom();
//					}
//				}
//				
//			}else if(sequenceNumber == 4){
//				dispenser.fireFromRightTop();
//				if(isDoubleShot){
//					dispenser.fireFromLeftBottom();
//				}
//				yield return new WaitForSeconds (waitTime);   
//				dispenser.fireFromLeft1();
//				if(isDoubleShot){
//					dispenser.fireFromRight2();
//				}
//				if(isFourSpawns){
//					yield return new WaitForSeconds (waitTime); 
//					dispenser.fireFromRightTop();
//					if(isDoubleShot){
//						dispenser.fireFromLeftBottom();
//					}
//					yield return new WaitForSeconds (waitTime);   
//					dispenser.fireFromLeft1();
//					if(isDoubleShot){
//						dispenser.fireFromRight2();
//					}
//				}
//			} 
//		}
//		yield return new WaitForSeconds (waitTime);
//		determineSequence();
//	}
//
//	public void fireTwoBackForthSequence(bool capableOfDoubleShot, bool is4Spawns){
//		StartCoroutine(TwoBackForthCo(capableOfDoubleShot, is4Spawns)); 
//	}
//	
//	private IEnumerator TwoBackForthCo(bool capableOfDoubleShot, bool is4Spawns){
//		bool isDoubleShot = false;
//		bool isClockwise = false;
//		bool isFourSpawns = is4Spawns;
//		float sequenceNumber;
//		
//		//DETERMINE DOUBLESHOT
//		if(capableOfDoubleShot){
//			float doubleShotNumber = random.Next (1, 3);
//			if(doubleShotNumber == 1){
//				isDoubleShot = true;
//			}
//		}
//		//isDoubleShot = true; 
//		//DETERMINE CLOCKWISE
//		float isClockwiseNumber = random.Next (1, 3);
//		if(isClockwiseNumber == 1){
//			isClockwise = true;
//		} 
//		
//		if(isClockwise){
//			//DETERMINE SEQUENCE
//			sequenceNumber = random.Next (1, 5);
//			if(sequenceNumber == 1){ 
//				dispenser.fireFromLeft1();
//				if(isDoubleShot){
//					dispenser.fireFromRight2();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromLeftTop();
//				if(isDoubleShot){
//					dispenser.fireFromRightBottom();
//				}
//				if(isFourSpawns){
//					yield return new WaitForSeconds (waitTime); 
//					dispenser.fireFromLeft1();
//					if(isDoubleShot){
//						dispenser.fireFromRight2();
//					}
//					yield return new WaitForSeconds (waitTime);     
//					dispenser.fireFromLeftTop();
//					if(isDoubleShot){
//						dispenser.fireFromRightBottom();
//					}
//				}
//				
//			}else if(sequenceNumber == 2){ 
//				dispenser.fireFromLeftBottom();
//				if(isDoubleShot){
//					dispenser.fireFromRightTop();
//				}
//				yield return new WaitForSeconds (waitTime);   
//				dispenser.fireFromRight1();
//				if(isDoubleShot){
//					dispenser.fireFromLeft2();
//				}
//				if(is4Spawns){
//					yield return new WaitForSeconds (waitTime); 
//					dispenser.fireFromLeftBottom();
//					if(isDoubleShot){
//						dispenser.fireFromRightTop();
//					}
//					yield return new WaitForSeconds (waitTime);   
//					dispenser.fireFromRight1();
//					if(isDoubleShot){
//						dispenser.fireFromLeft2();
//					}
//				}
//
//			}else if(sequenceNumber == 3){
//				dispenser.fireFromRight2();
//				if(isDoubleShot){
//					dispenser.fireFromLeft1();
//				}
//				yield return new WaitForSeconds (waitTime);   
//				dispenser.fireFromRightBottom();
//				if(isDoubleShot){
//					dispenser.fireFromLeftTop();
//				}
//				if(isFourSpawns){
//					yield return new WaitForSeconds (waitTime);   
//					dispenser.fireFromRight2();
//					if(isDoubleShot){
//						dispenser.fireFromLeft1();
//					}
//					yield return new WaitForSeconds (waitTime);   
//					dispenser.fireFromRightBottom();
//					if(isDoubleShot){
//						dispenser.fireFromLeftTop();
//					}
//				}
//				
//			}else if(sequenceNumber == 4){
//				dispenser.fireFromRightTop();
//				if(isDoubleShot){
//					dispenser.fireFromLeftBottom();
//				}
//				yield return new WaitForSeconds (waitTime);   
//				dispenser.fireFromLeft2();
//				if(isDoubleShot){
//					dispenser.fireFromRight1();
//				}
//				if(isFourSpawns){
//					yield return new WaitForSeconds (waitTime);   
//					dispenser.fireFromRightTop();
//					if(isDoubleShot){
//						dispenser.fireFromLeftBottom();
//					}
//					yield return new WaitForSeconds (waitTime);   
//					dispenser.fireFromLeft2();
//					if(isDoubleShot){
//						dispenser.fireFromRight1();
//					}
//				}
//			} 
//		}else{
//			//DETERMINE SEQUENCE COUNTER CLOCKWISE
//			sequenceNumber = random.Next (1, 5);
//			if(sequenceNumber == 1){ 
//				dispenser.fireFromLeft2();
//				if(isDoubleShot){
//					dispenser.fireFromRight1();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromLeftBottom();
//				if(isDoubleShot){
//					dispenser.fireFromRightTop();
//				}
//				if(isFourSpawns){
//					yield return new WaitForSeconds (waitTime);  
//					dispenser.fireFromLeft2();
//					if(isDoubleShot){
//						dispenser.fireFromRight1();
//					}
//					yield return new WaitForSeconds (waitTime);     
//					dispenser.fireFromLeftBottom();
//					if(isDoubleShot){
//						dispenser.fireFromRightTop();
//					}
//				}
//				
//			}else if(sequenceNumber == 2){
//				dispenser.fireFromLeftTop();
//				if(isDoubleShot){
//					dispenser.fireFromRightBottom();
//				}
//				yield return new WaitForSeconds (waitTime);   
//				dispenser.fireFromRight2();
//				if(isDoubleShot){
//					dispenser.fireFromLeft1();
//				}
//				if(isFourSpawns){
//					yield return new WaitForSeconds (waitTime);   
//					dispenser.fireFromLeftTop();
//					if(isDoubleShot){
//						dispenser.fireFromRightBottom();
//					}
//					yield return new WaitForSeconds (waitTime);   
//					dispenser.fireFromRight2();
//					if(isDoubleShot){
//						dispenser.fireFromLeft1();
//					}
//				}
//				
//			}else if(sequenceNumber == 3){
//				dispenser.fireFromRight1();
//				if(isDoubleShot){
//					dispenser.fireFromLeft2();
//				}
//				yield return new WaitForSeconds (waitTime);   
//				dispenser.fireFromRightTop();
//				if(isDoubleShot){
//					dispenser.fireFromLeftBottom();
//				}
//				if(isFourSpawns){
//					yield return new WaitForSeconds (waitTime);
//					dispenser.fireFromRight1();
//					if(isDoubleShot){
//						dispenser.fireFromLeft2();
//					}
//					yield return new WaitForSeconds (waitTime);   
//					dispenser.fireFromRightTop();
//					if(isDoubleShot){
//						dispenser.fireFromLeftBottom();
//					}
//				}
//				
//			}else if(sequenceNumber == 4){
//				dispenser.fireFromRightBottom();
//				if(isDoubleShot){
//					dispenser.fireFromLeftTop();
//				}
//				yield return new WaitForSeconds (waitTime);   
//				dispenser.fireFromLeft1();
//				if(isDoubleShot){
//					dispenser.fireFromRight2();
//				}
//				if(isFourSpawns){
//					yield return new WaitForSeconds (waitTime); 
//					dispenser.fireFromRightBottom();
//					if(isDoubleShot){
//						dispenser.fireFromLeftTop();
//					}
//					yield return new WaitForSeconds (waitTime);   
//					dispenser.fireFromLeft1();
//					if(isDoubleShot){
//						dispenser.fireFromRight2();
//					}
//				}
//			} 
//		}
//		yield return new WaitForSeconds (waitTime);
//		determineSequence();
//	}
//
//	public void fireSpiralTwoNegativeSpiralTwo (bool capableOfDoubleShot){
//		StartCoroutine(SpiralTwoNegativeSpiralTwoCo(capableOfDoubleShot)); 
//	}
//	
//	private IEnumerator SpiralTwoNegativeSpiralTwoCo(bool capableOfDoubleShot){
//		bool isDoubleShot = false;
//		bool isClockwise = false;
//		float sequenceNumber;
//
//		//DETERMINE DOUBLESHOT
//		if(capableOfDoubleShot){
//			float doubleShotNumber = random.Next (1, 3);
//			if(doubleShotNumber == 1){
//				isDoubleShot = true;
//			}
//		}
//		//isDoubleShot = true; 
//		//DETERMINE CLOCKWISE
//		float isClockwiseNumber = random.Next (1, 3);
//		if(isClockwiseNumber == 1){
//			isClockwise = true;
//		}
//
//		if(isClockwise){
//			//DETERMINE SEQUENCE
//			sequenceNumber = random.Next (1, 5);
//			if(sequenceNumber == 1){ 
//				dispenser.fireFromLeft2();
//				if(isDoubleShot){
//					dispenser.fireFromRight1();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromLeftTop();
//				if(isDoubleShot){
//					dispenser.fireFromRightBottom();
//				}
//				yield return new WaitForSeconds (waitTime); 
//				dispenser.fireFromLeft1();
//				if(isDoubleShot){
//					dispenser.fireFromRight2();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromLeftBottom();
//				if(isDoubleShot){
//					dispenser.fireFromRightTop();
//				}
//			}else if(sequenceNumber == 2){ 
//				dispenser.fireFromRightBottom();
//				if(isDoubleShot){
//					dispenser.fireFromLeftTop();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromLeft2();
//				if(isDoubleShot){
//					dispenser.fireFromRight1();
//				}
//				yield return new WaitForSeconds (waitTime); 
//				dispenser.fireFromRightTop();
//				if(isDoubleShot){
//					dispenser.fireFromLeftBottom();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromLeft1();
//				if(isDoubleShot){
//					dispenser.fireFromRight2();
//				}
//			}else if(sequenceNumber == 3){ 
//				dispenser.fireFromRight1();
//				if(isDoubleShot){
//					dispenser.fireFromLeft2();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromRightBottom();
//				if(isDoubleShot){
//					dispenser.fireFromLeftTop();
//				}
//				yield return new WaitForSeconds (waitTime); 
//				dispenser.fireFromRight2();
//				if(isDoubleShot){
//					dispenser.fireFromLeft1();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromRightTop();
//				if(isDoubleShot){
//					dispenser.fireFromLeftBottom();
//				}
//			}else if(sequenceNumber == 4){ 
//				dispenser.fireFromLeftTop();
//				if(isDoubleShot){
//					dispenser.fireFromRightBottom();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromRight1();
//				if(isDoubleShot){
//					dispenser.fireFromLeft2();
//				}
//				yield return new WaitForSeconds (waitTime); 
//				dispenser.fireFromLeftBottom();
//				if(isDoubleShot){
//					dispenser.fireFromRightTop();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromRight2();
//				if(isDoubleShot){
//					dispenser.fireFromLeft1();
//				}
//			}
//		}else{
//			//DETERMINE SEQUENCE COUNTER CLOCKWISE
//			sequenceNumber = random.Next (1, 5);
//			if(sequenceNumber == 1){ 
//				dispenser.fireFromLeft1();
//				if(isDoubleShot){
//					dispenser.fireFromRight2();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromRightTop();
//				if(isDoubleShot){
//					dispenser.fireFromLeftBottom();
//				}
//				yield return new WaitForSeconds (waitTime); 
//				dispenser.fireFromLeft2();
//				if(isDoubleShot){
//					dispenser.fireFromRight1();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromRightBottom();
//				if(isDoubleShot){
//					dispenser.fireFromLeftTop();
//				}
//			}else if(sequenceNumber == 2){ 
//				dispenser.fireFromRightTop();
//				if(isDoubleShot){
//					dispenser.fireFromLeftBottom();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromRight2();
//				if(isDoubleShot){
//					dispenser.fireFromLeft1();
//				}
//				yield return new WaitForSeconds (waitTime); 
//				dispenser.fireFromRightBottom();
//				if(isDoubleShot){
//					dispenser.fireFromLeftTop();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromRight1();
//				if(isDoubleShot){
//					dispenser.fireFromLeft2();
//				}
//			}else if(sequenceNumber == 3){ 
//				dispenser.fireFromRight2();
//				if(isDoubleShot){
//					dispenser.fireFromLeft1();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromLeftBottom();
//				if(isDoubleShot){
//					dispenser.fireFromRightTop();
//				}
//				yield return new WaitForSeconds (waitTime); 
//				dispenser.fireFromRight1();
//				if(isDoubleShot){
//					dispenser.fireFromLeft2();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromLeftTop();
//				if(isDoubleShot){
//					dispenser.fireFromRightBottom();
//				}
//			}else if(sequenceNumber == 4){ 
//				dispenser.fireFromLeftBottom();
//				if(isDoubleShot){
//					dispenser.fireFromRightTop();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromLeft1();
//				if(isDoubleShot){
//					dispenser.fireFromRight2();
//				}
//				yield return new WaitForSeconds (waitTime); 
//				dispenser.fireFromLeftTop();
//				if(isDoubleShot){
//					dispenser.fireFromRightBottom();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromLeft2();
//				if(isDoubleShot){
//					dispenser.fireFromRight1();
//				}
//			}
//		}
//		yield return new WaitForSeconds (waitTime);
//		determineSequence();
//	}
//
//
//
//	public void fireBackForthNegativeBackForth (bool capableOfDoubleShot){
//		StartCoroutine(BFNegBFCo(capableOfDoubleShot)); 
//	}
//	
//	private IEnumerator BFNegBFCo(bool capableOfDoubleShot){
//		bool isDoubleShot = false;
//		bool isClockwise = false;
//		float sequenceNumber;
//		
//		//DETERMINE DOUBLESHOT
//		if(capableOfDoubleShot){
//			float doubleShotNumber = random.Next (1, 3);
//			if(doubleShotNumber == 1){
//				isDoubleShot = true;
//			}
//		}
//		//isDoubleShot = true;   
//		//DETERMINE CLOCKWISE
//		float isClockwiseNumber = random.Next (1, 3);
//		if(isClockwiseNumber == 1){
//			isClockwise = true;
//		} 
//		
//		if(isClockwise){
//			//DETERMINE SEQUENCE
//			sequenceNumber = random.Next (1, 5);
//			if(sequenceNumber == 1){   
//				dispenser.fireFromLeftTop();
//				if(isDoubleShot){
//					dispenser.fireFromRightBottom();
//				}
//				yield return new WaitForSeconds (waitTime); 
//				dispenser.fireFromLeft1();
//				if(isDoubleShot){
//					dispenser.fireFromRight2();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromLeftBottom();
//				if(isDoubleShot){
//					dispenser.fireFromRightTop();
//				}
//				yield return new WaitForSeconds (waitTime);  
//				dispenser.fireFromLeft2();
//				if(isDoubleShot){
//					dispenser.fireFromRight1();
//				}
//			}else if(sequenceNumber == 2){ 
//				dispenser.fireFromLeft2();
//				if(isDoubleShot){
//					dispenser.fireFromRight1();
//				}
//				yield return new WaitForSeconds (waitTime); 
//				dispenser.fireFromRightTop();
//				if(isDoubleShot){
//					dispenser.fireFromLeftBottom();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromLeft1();
//				if(isDoubleShot){
//					dispenser.fireFromRight2();
//				}
//				yield return new WaitForSeconds (waitTime);  
//				dispenser.fireFromRightBottom();
//				if(isDoubleShot){
//					dispenser.fireFromLeftTop();
//				}
//
//			}else if(sequenceNumber == 3){     
//				dispenser.fireFromRightBottom();
//				if(isDoubleShot){
//					dispenser.fireFromLeftTop();
//				}
//				yield return new WaitForSeconds (waitTime); 
//				dispenser.fireFromRight2();
//				if(isDoubleShot){
//					dispenser.fireFromLeft1();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromRightTop();
//				if(isDoubleShot){
//					dispenser.fireFromLeftBottom();
//				}
//				yield return new WaitForSeconds (waitTime); 
//				dispenser.fireFromRight1();
//				if(isDoubleShot){
//					dispenser.fireFromLeft2();
//				}
//			}else if(sequenceNumber == 4){   
//				dispenser.fireFromRight1();
//				if(isDoubleShot){
//					dispenser.fireFromLeft2();
//				}
//				yield return new WaitForSeconds (waitTime); 
//				dispenser.fireFromLeftBottom();
//				if(isDoubleShot){
//					dispenser.fireFromRightTop();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromRight2();
//				if(isDoubleShot){
//					dispenser.fireFromLeft1();
//				}
//				yield return new WaitForSeconds (waitTime); 
//				dispenser.fireFromLeftTop();
//				if(isDoubleShot){
//					dispenser.fireFromRightBottom();
//				}
//			}
//		}else{
//			//DETERMINE SEQUENCE COUNTER CLOCKWISE
//			sequenceNumber = random.Next (1, 5);
//			if(sequenceNumber == 1){    
//				dispenser.fireFromRightTop();
//				if(isDoubleShot){
//					dispenser.fireFromLeftBottom();
//				}
//				yield return new WaitForSeconds (waitTime); 
//				dispenser.fireFromLeft2();
//				if(isDoubleShot){
//					dispenser.fireFromRight1();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromRightBottom();
//				if(isDoubleShot){
//					dispenser.fireFromLeftTop();
//				}
//				yield return new WaitForSeconds (waitTime);  
//				dispenser.fireFromLeft1();
//				if(isDoubleShot){
//					dispenser.fireFromRight2();
//				}
//			}else if(sequenceNumber == 2){     
//				dispenser.fireFromRight2();
//				if(isDoubleShot){
//					dispenser.fireFromLeft1();
//				}
//				yield return new WaitForSeconds (waitTime); 
//				dispenser.fireFromRightBottom();
//				if(isDoubleShot){
//					dispenser.fireFromLeftTop();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromRight1();
//				if(isDoubleShot){
//					dispenser.fireFromLeft2();
//				}
//				yield return new WaitForSeconds (waitTime); 
//				dispenser.fireFromRightTop();
//				if(isDoubleShot){
//					dispenser.fireFromLeftBottom();
//				}
//			}else if(sequenceNumber == 3){     
//				dispenser.fireFromLeftBottom();
//				if(isDoubleShot){
//					dispenser.fireFromRightTop();
//				}
//				yield return new WaitForSeconds (waitTime); 
//				dispenser.fireFromRight1();
//				if(isDoubleShot){
//					dispenser.fireFromLeft2();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromLeftTop();
//				if(isDoubleShot){
//					dispenser.fireFromRightBottom();
//				}
//				yield return new WaitForSeconds (waitTime); 
//				dispenser.fireFromRight2();
//				if(isDoubleShot){
//					dispenser.fireFromLeft1();
//				}
//			}else if(sequenceNumber == 4){    
//				dispenser.fireFromLeft1();
//				if(isDoubleShot){
//					dispenser.fireFromRight2();
//				}
//				yield return new WaitForSeconds (waitTime); 
//				dispenser.fireFromLeftTop();
//				if(isDoubleShot){
//					dispenser.fireFromRightBottom();
//				}
//				yield return new WaitForSeconds (waitTime);     
//				dispenser.fireFromLeft2();
//				if(isDoubleShot){
//					dispenser.fireFromRight1();
//				}
//				yield return new WaitForSeconds (waitTime); 
//				dispenser.fireFromLeftBottom();
//				if(isDoubleShot){
//					dispenser.fireFromRightTop();
//				}
//			}
//		}
//		yield return new WaitForSeconds (waitTime);
//		determineSequence();
//	}
//
//	public void initiateCScaleSequence(){
//		StartCoroutine(CScaleCo());                
//	}
//	
//	private IEnumerator CScaleCo(){
//		dispenser.fireFromLeft2();
//		//fireFromBottomLeft();
//		yield return new WaitForSeconds (waitTime); 
//		dispenser.fireFromRightTop();
//		//fireFromLeftBottom();
//		yield return new WaitForSeconds (waitTime); 
//		dispenser.fireFromRightBottom();
//		//fireFromLeftTop();
//		yield return new WaitForSeconds (waitTime); 
//		dispenser.fireFromRight2();
//		//fireFromTopLeft();
//		yield return new WaitForSeconds (waitTime); 
//		dispenser.fireFromRight1();
//		//fireFromTopRight();
//		yield return new WaitForSeconds (waitTime);  
//		dispenser.fireFromLeftBottom();
//		//fireFromRightTop();
//		yield return new WaitForSeconds (waitTime); 
//		dispenser.fireFromLeftTop();
//		//fireFromRightBottom();
//		yield return new WaitForSeconds (waitTime); 
//		dispenser.fireFromLeft1();
//		//fireFromBottomRight(); 
//		yield return new WaitForSeconds (waitTime); 
//		determineSequence();
//	}
//
//	public void initiateSpiralSequence(){
//		StartCoroutine(SpiralCo());                
//	}
//	
//	private IEnumerator SpiralCo(){
//		dispenser.fireFromLeft2();
//		//dispenser.fireFromBottomLeft();
//		yield return new WaitForSeconds (waitTime); 
//		dispenser.fireFromRightBottom();
//		//dispenser.fireFromLeftTop();
//		yield return new WaitForSeconds (waitTime); 
//		dispenser.fireFromRight1();
//		//dispenser.fireFromTopRight();
//		yield return new WaitForSeconds (waitTime);  
//		dispenser.fireFromLeftTop();
//		//dispenser.fireFromRightBottom();
//		yield return new WaitForSeconds (waitTime); 
//		dispenser.fireFromLeft2();
//		//dispenser.fireFromBottomLeft();
//		yield return new WaitForSeconds (waitTime); 
//		dispenser.fireFromRightBottom();
//		//dispenser.fireFromLeftTop();
//		yield return new WaitForSeconds (waitTime); 
//		dispenser.fireFromRight1();
//		//dispenser.fireFromTopRight();
//		yield return new WaitForSeconds (waitTime);  
//		dispenser.fireFromLeftTop();
//		//dispenser.fireFromRightBottom();
//		yield return new WaitForSeconds (waitTime); 
//		dispenser.fireFromLeft2();
//		//dispenser.fireFromBottomLeft();
//		yield return new WaitForSeconds (waitTime); 
//		dispenser.fireFromRightBottom();
//		//dispenser.fireFromLeftTop();
//		yield return new WaitForSeconds (waitTime); 
//		dispenser.fireFromRight1();
//		//dispenser.fireFromTopRight();
//		yield return new WaitForSeconds (waitTime);  
//		dispenser.fireFromLeftTop();
//		//dispenser.fireFromRightBottom();
//		yield return new WaitForSeconds (waitTime); 
//
//		determineSequence();
//	}
}
