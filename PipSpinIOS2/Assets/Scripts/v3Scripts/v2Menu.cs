using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
//using GooglePlayGames;
//using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class v2Menu : MonoBehaviour {

	public GameObject NormalButton;
	public GameObject InsaneButton;
	public RightCover rightCover;

	public CameraPivot camera;
	public GameObject line;
    //public GameObject line2;
    //public GameObject line3;
	public HUDTab rightTab;
	public HUDTab leftTab;
	public HUDTab upperMenuTab; 

	public GUISkin Skin;
	public string levelTitle;
	public bool isDisplayingInsaneMode;

	public GameObject levelNumber;
	public GameObject leftArrow;
	public GameObject rightArrow;

	public GameObject row1Text;
	public GameObject row2Text;
	public GameObject row3Text;
	public GameObject row4Text;
	public GameObject row5Text;

	public GameObject upperLeftButton;
	public GameObject upperRightButton;
	public GameObject optionsMenu;
	public GameObject howToPlayMenu;
	public GameObject playButton;
	public GameObject statsButton;

	public GameObject GreenImages;

	public Projectile projectile;

	public int lineSpinningSpeed;
	public int levelNumberOnScreen;

	public GameObject unlockLvlText;
	public GameObject unlockLvlNumber;
	public GameObject lightRay;

	public SpinningLine gameLine;

	private float nextActionTime;
	private float period = 5.0f;
	private float projectileSpeed;

	private bool canFireProjectile;

	private static System.Random random = new System.Random();

	public AudioClip buttonTap;

	public MusicManager musicManager;
	public AudioSource lineBGsound;
	public AudioClip cameraStartSound;
	public AudioSource buttonTap2;

	public GameObject OptionsMenu;
	public GameObject HowToPlayMenu;
    public GameObject MoreGamesMenu;

	public bool isOnOptionsMenu;
	public bool isOnHowToPlayMenu;
    public bool isOnMoreGamesMenu;

	public ColorChanger colorChanger;
	public GameObject chooseColorsText;
	public GameObject hackerEditionButton;
	public GameObject requiresHackerEditionText;
    public GameObject wannaGetHackerEditionText;
    public GameObject thankYouText;

	void Start () {
		isOnOptionsMenu = false;
		isOnHowToPlayMenu = false;
		OptionsMenu.transform.position = new Vector3(OptionsMenu.transform.position.x, OptionsMenu.transform.position.y - 10, 1);
		HowToPlayMenu.transform.position = new Vector3(OptionsMenu.transform.position.x, OptionsMenu.transform.position.y - 10, 1);
        MoreGamesMenu.transform.position = new Vector3(MoreGamesMenu.transform.position.x, MoreGamesMenu.transform.position.y - 10, 1);
		//RESETS PLAYER PREFS. TAKE OUT
		//PlayerPrefs.SetInt("isFirstTimePlaying",0);

		//PlayerPrefs.SetInt("PlayerLevel",11);
		//PlayerPrefs.SetInt("hasHackerEdition",0);

		if(PlayerPrefs.GetInt("isFirstTimePlaying") != 1){
			PlayerPrefs.SetInt("PlayerLevel",1);
			PlayerPrefs.SetInt("isFirstTimePlaying",1);
		}

		//PlayerPrefs.SetInt("hasSeenColors",0);
		//if(playerprefs.getint("playerlevel") > 1){
			//if(playerprefs.getint("hasseencolors") != 1){
				//displaychoosecolorstext();
			//}
		//}

		canFireProjectile = true;
		nextActionTime = Time.time + 2.0f;


		if(PlayerPrefs.GetInt("hasSetUpInitialMenu") != 1){
			setUpMenu();
		}else{
			setUpMenu2();
		}
		//determineArrowStatus();
		flicker();
		determineLineHumSound();
		determineHackerEditionStatus();
        determineBuyHackerEditionTextStatus();
        determineThankYouStatus();

        //Debug.Log("adCounter= " + PlayerPrefs.GetInt("adCounter"));
       
        //Debug.Log("hasHackerEd= " + PlayerPrefs.GetInt("hasHackerEdition"));
	}
	
	void Update () {
		HandleKeyboard();
		HandleUserTouches();
		determineLineSpinningSpeed();
		line.transform.Rotate(0, 0, -lineSpinningSpeed * Time.deltaTime,Space.Self);
        //line2.transform.Rotate(0, 0, -lineSpinningSpeed * Time.deltaTime,Space.Self);
        //line3.transform.Rotate(0, 0, -lineSpinningSpeed * Time.deltaTime,Space.Self);

		initiateMenuProjectileFiringSequence();
	}
	
	public void HandleKeyboard(){
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			toggleLevelToTheLeft();
		} else if (Input.GetKeyDown(KeyCode.RightArrow)) {
			toggleLevelToTheRight();
		}

        if (isOnOptionsMenu)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                closeOptions();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                toggleSound();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                changeColor();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                openPipSpinPage();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                displayMoreGamesMenu();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                showHackerEditionScreen();
            }
        }

        else if (isOnHowToPlayMenu)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                closeHowToPlayMenu();
            }
        }

        else if (isOnMoreGamesMenu) {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                closeMoreGamesMenu();
            }else if (Input.GetKeyDown(KeyCode.Alpha2)){
                openNinjevadePage();
            }else if (Input.GetKeyDown(KeyCode.Alpha3)){
                openPinPongPage();
            }
        }

        else {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                openOptions();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                displayHowToPlayMenu();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                displayLeaderboards();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                startGame();
            }
        }

//		if(row4Text.GetComponent<SpriteRenderer>().sprite.name.Equals("PlayText")){
//			if (Input.GetKeyDown (KeyCode.Alpha1)) {
//				openOptions();
//			} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
//				displayHowToPlayMenu();
//			} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
//				displayLeaderboards();
//			} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
//				startGame();
//			} 
//		}
//
//		else if(row4Text.GetComponent<SpriteRenderer>().sprite.name.Equals("LevelUpText")){
//			if (Input.GetKeyDown (KeyCode.Alpha1)) {
//				goToMainMenu();
//			} 
//		}
//
//		else if(row4Text.GetComponent<SpriteRenderer>().sprite.name.Equals("MoreGamesText")){
//			if (Input.GetKeyDown (KeyCode.Alpha1)) {
//				goToMainMenu();
//			} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
//				toggleSound();
//			} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
//				openPipSpinPage();
//			} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
//				openMatthewBurtonDevPage();
//			} 
//		}
	}

	public void HandleUserTouches(){
		for (int i = 0; i < Input.touchCount; i++){  
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began){
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position); 

				//TODO: TOUCH STUFF
				if(isOnOptionsMenu){
                    //Small Buttons
                    if(touchPosition.x > 1 && touchPosition.x < 2.1 && touchPosition.y > -1.3){
                        toggleSound();
					}else if(touchPosition.x > -3.5 && touchPosition.x < -2.5 && touchPosition.y > -1.3){
						closeOptions();
					}

                    //Rectangle Buttons
                    else if(touchPosition.x > -2.8 && touchPosition.x < 1.4 && touchPosition.y > -2.43 && touchPosition.y < -1.6){
						changeColor();
					}else if(touchPosition.x > -2.8 && touchPosition.x < 1.4 && touchPosition.y > -3.05 && touchPosition.y < -2.45){
						openPipSpinPage();
					}else if(touchPosition.x > -2.8 && touchPosition.x < 1.4 && touchPosition.y > -3.66 && touchPosition.y < -3.06){
                        displayMoreGamesMenu();
					}else if (touchPosition.x > -2.8 && touchPosition.x < 1.4 && touchPosition.y > -4.4 && touchPosition.y < -3.67){
                        showHackerEditionScreen();
						//goToHackerEditionMenu();
					}
				}
				
				else if(isOnHowToPlayMenu){
					if(touchPosition.x > 2.5 && touchPosition.x < 3.5 && touchPosition.y > -1.3){
						closeHowToPlayMenu();
					}
				}

                else if(isOnMoreGamesMenu){
                    if (touchPosition.x > -3.5 && touchPosition.x < -2.5 && touchPosition.y > -1.3){
                        closeMoreGamesMenu();
                    }else if(touchPosition.x > -3 && touchPosition.x < 1.5 && touchPosition.y > -3.05 && touchPosition.y < -1.6){
						openNinjevadePage();
					}else if(touchPosition.x > -3 && touchPosition.x < 1.5 && touchPosition.y > -4.5 && touchPosition.y < -3.1){
						openPinPongPage();
					}
				}
				
				else{
					if(touchPosition.x > .97 && touchPosition.x < 1.75 && touchPosition.y > -5.5 && touchPosition.y < -4.6){
						toggleLevelToTheRight();
					}else if(touchPosition.x > -1.75 && touchPosition.x < -.97 && touchPosition.y > -5.5 && touchPosition.y < -4.6){
						toggleLevelToTheLeft();
					}

					else if(touchPosition.x > 1.751 && touchPosition.x < 6.4 && touchPosition.y > -6 && touchPosition.y < -3.5){
						startGame();
					}else if(touchPosition.x > -3.4 && touchPosition.x < -1.751 && touchPosition.y > -5.5 && touchPosition.y < -4.6){
						displayLeaderboards();
					}else if(touchPosition.x > -3.4 && touchPosition.x < -2.5 && touchPosition.y > -1.3){
						openOptions();
					}else if(touchPosition.x > 2.5 && touchPosition.x < 3.5 && touchPosition.y > -1.3){
						displayHowToPlayMenu();
					}
				}

//				if(row4Text.GetComponent<SpriteRenderer>().sprite.name.Equals("PlayText")){
//					if (touchPosition.x > 1.7 && touchPosition.y > 3.6 && touchPosition.y < 5.2) {
//						openOptions();
//					} else if (touchPosition.x > 1.7 && touchPosition.y > 2 && touchPosition.y < 3.6) {
//						displayHowToPlayMenu();
//					} else if (touchPosition.x > 1.7 && touchPosition.y > 0.375 && touchPosition.y < 2) {
//						displayLeaderboards();
//					} else if (touchPosition.x > 1.7 && touchPosition.y > -1.4 && touchPosition.y < 0.375) {
//						startGame();
//					} 
//				}
//				
//				else if(row4Text.GetComponent<SpriteRenderer>().sprite.name.Equals("LevelUpText")){
//					if (touchPosition.x > 1.7 && touchPosition.y > 3.6 && touchPosition.y < 5.2) {
//						goToMainMenu();
//					} 
//				}
//				
//				else if(row4Text.GetComponent<SpriteRenderer>().sprite.name.Equals("MoreGamesText")){
//					if (touchPosition.x > 1.7 && touchPosition.y > 3.6 && touchPosition.y < 5.2) {
//						goToMainMenu();
//					} else if (touchPosition.x > 1.7 && touchPosition.y > 2 && touchPosition.y < 3.6) {
//						toggleSound();
//					} else if (touchPosition.x > 1.7 && touchPosition.y > 0.375 && touchPosition.y < 2) {
//						openPipSpinPage();
//					} else if (touchPosition.x > 1.7 && touchPosition.y > -1.4 && touchPosition.y < 0.375) {
//						openMatthewBurtonDevPage();
//					} 
//				}
			}
		}
	}

	public void determineHackerEditionStatus(){
		if(PlayerPrefs.GetInt("hasHackerEdition") == 1){
			row5Text.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("HackerEditionText", typeof(Sprite)) as Sprite;
			hackerEditionButton.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("HackerEditionText2Inv", typeof(Sprite)) as Sprite;
		}else{
			row5Text.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("HackerEditionTextInv", typeof(Sprite)) as Sprite;
			hackerEditionButton.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("HackerEditionText2", typeof(Sprite)) as Sprite;
		}
	}

	public void toggleDifficulty(){
		if(isDisplayingInsaneMode == true){
			displayNormalModeScreen();
		}else{
			displayInsaneModeScreen();
		}
	}

	public void displayInsaneModeScreen(){
		//Show InsaneSprite
		//Flip Colors
		NormalButton.GetComponent<SpriteRenderer> ().enabled = false;
		InsaneButton.GetComponent<SpriteRenderer> ().enabled = true;
		isDisplayingInsaneMode = true;
	}

	public void displayNormalModeScreen(){
		//Show InsaneSprite
		//Flip Colors
		InsaneButton.GetComponent<SpriteRenderer> ().enabled = false;
		NormalButton.GetComponent<SpriteRenderer> ().enabled = true;
		isDisplayingInsaneMode = false;
	}
	
	public void startGame(){
		if(unlockLvlNumber.GetComponent<SpriteRenderer> ().enabled == false){
			StartCoroutine(startGameCo()); 
		}
	}
	
	private IEnumerator startGameCo(){ 
		//AudioSource.PlayClipAtPoint(buttonTap, transform.position);
		buttonTap2.Play();

		playButton.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("playTextInv", typeof(Sprite)) as Sprite;
		determineSpeed();
		GreenImages.GetComponent<Animator>().enabled = true;
		lightRay.GetComponent<SpriteRenderer> ().enabled = false;

		AudioSource.PlayClipAtPoint(cameraStartSound, transform.position);
		//rightCover.applyRightCover();
		//line.rotateStartGame();
		yield return new WaitForSeconds (.125f);

		playButton.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("playText", typeof(Sprite)) as Sprite;
		camera.rotateStartGame();
		Projectile[] projectiles = FindObjectsOfType(typeof(Projectile)) as Projectile[];
		foreach (Projectile projectile in projectiles){
			//projectile.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
			projectile.GetComponent<Projectile>().Speed = 14;
			//projectile.rigidbody.velocity = Vector3.zero;
			//projectile.rigidbody.angularVelocity = Vector3.zero;
		}
		canFireProjectile = false;
		yield return new WaitForSeconds (.44f);
		gameLine.initiateStartGameAnimtaion();
		//leftTab.startGameFlicker();
		//rightTab.startGameFlicker();
		//upperMenuTab.startGameFlicker();
		yield return new WaitForSeconds (.11f);

//		if(isDisplayingInsaneMode == true){
//			
//			Application.LoadLevel(1);
//		}else{
//			GameManager.Instance.isInsaneMode = false;
//			Application.LoadLevel(2);
//		}
		//Application.LoadLevel(2);
        SceneManager.LoadScene(2);
    }

	public void determineSpeed(){
		if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No1")){
			GameManager.Instance.menuSpeedNumber = 1;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No2")){
			GameManager.Instance.menuSpeedNumber = 2;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No3")){
			GameManager.Instance.menuSpeedNumber = 3;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No4")){
			GameManager.Instance.menuSpeedNumber = 4;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No5")){
			GameManager.Instance.menuSpeedNumber = 5;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No6")){
			GameManager.Instance.menuSpeedNumber = 6;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No7")){
			GameManager.Instance.menuSpeedNumber = 7;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No8")){
			GameManager.Instance.menuSpeedNumber = 8;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No9")){
			GameManager.Instance.menuSpeedNumber = 9;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No10")){
			GameManager.Instance.menuSpeedNumber = 10;
		}
	}

	public void toggleLevelToTheRight(){


		flashRightArrow();

		if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No1")){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No1", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No2", typeof(Sprite)) as Sprite;
			leftArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			//fireProjectile(.2f);
			levelNumberOnScreen = 2;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No2")){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No2", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No3", typeof(Sprite)) as Sprite;
			//fireProjectile(.3f);
			levelNumberOnScreen = 3;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No3")){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No3", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No4", typeof(Sprite)) as Sprite;
			//fireProjectile(.4f);
			levelNumberOnScreen = 4;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No4")){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No4", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No5", typeof(Sprite)) as Sprite;
			//fireProjectile(.5f);
			levelNumberOnScreen = 5;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No5")){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No5", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No6", typeof(Sprite)) as Sprite;
			//fireProjectile(.6f);
			levelNumberOnScreen = 6;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No6")){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No6", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No7", typeof(Sprite)) as Sprite;
			//fireProjectile(.7f);
			levelNumberOnScreen = 7;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No7")){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No7", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No8", typeof(Sprite)) as Sprite;
			//fireProjectile(.8f);
			levelNumberOnScreen = 8;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No8")){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No8", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No9", typeof(Sprite)) as Sprite;
			//fireProjectile(.9f);
			levelNumberOnScreen = 9;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No9")){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No9", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No10", typeof(Sprite)) as Sprite;
			rightArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
			//fireProjectile(1f);
			levelNumberOnScreen = 10;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No10")){

		}

		determinePlayButtonStatus();
		determineLineHumSound();
		//AudioSource.PlayClipAtPoint(buttonTap, transform.position);
		buttonTap2.Play();
	}

	public void toggleLevelToTheLeft(){

		//AudioSource.PlayClipAtPoint(buttonTap, transform.position);
		flashLeftArrow();

		if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No10")){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No8", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No9", typeof(Sprite)) as Sprite;
			rightArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			//fireProjectile(.9f);
			levelNumberOnScreen = 9;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No9")){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No7", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No8", typeof(Sprite)) as Sprite;
			//fireProjectile(.8f);
			levelNumberOnScreen = 8;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No8")){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No6", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No7", typeof(Sprite)) as Sprite;
			//fireProjectile(.7f);
			levelNumberOnScreen = 7;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No7")){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No5", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No6", typeof(Sprite)) as Sprite;
			//fireProjectile(.6f);
			levelNumberOnScreen = 6;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No6")){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No4", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No5", typeof(Sprite)) as Sprite;
			//fireProjectile(.5f);
			levelNumberOnScreen = 5;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No5")){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No3", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No4", typeof(Sprite)) as Sprite;
			//fireProjectile(.4f);
			levelNumberOnScreen = 4;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No4")){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No2", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No3", typeof(Sprite)) as Sprite;
			//fireProjectile(.3f);
			levelNumberOnScreen = 3;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No3")){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No1", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No2", typeof(Sprite)) as Sprite;
			//fireProjectile(.2f);
			levelNumberOnScreen = 2;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No2")){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No1", typeof(Sprite)) as Sprite;
			leftArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
			//fireProjectile(.1f);
			levelNumberOnScreen = 1;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No1")){

		}

		determinePlayButtonStatus();
		determineLineHumSound();

		buttonTap2.Play();
	}

	private void determineArrowStatus(){
		if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No1")){
			leftArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
		}

		if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No10")){
			rightArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
		}
	}

	public void setUpMainMenuTextRows(){
		row1Text.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("OptionsText", typeof(Sprite)) as Sprite;
		row2Text.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("HowToPlayText", typeof(Sprite)) as Sprite;
		row3Text.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LeaderboardsText", typeof(Sprite)) as Sprite;
		row4Text.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("PlayText", typeof(Sprite)) as Sprite;
	}

	public void displayLeaderboards(){
		StartCoroutine(displayLeaderboardsCo()); 
	}

	private IEnumerator displayLeaderboardsCo(){ 
		//KTGameCenter.SharedCenter().SubmitScore(PlayerPrefs.GetInt("PlayerLevel"),"pipspin.01"); //TODO 
        //Social.ReportScore(PlayerPrefs.GetInt("PlayerLevel"), "CgkIga39zNoTEAIQBQ", (bool success) => {});
		buttonTap2.Play();
		statsButton.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LeaderboardsTextInv", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (.125f);
		statsButton.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LeaderboardsText", typeof(Sprite)) as Sprite;
//        	if(Social.localUser.authenticated){
//				Social.ShowLeaderboardUI();  
//			}else{
//			    Social.localUser.Authenticate((bool success) =>{
//                    if(success){
//						Social.ShowLeaderboardUI(); 
//					}else{
//
//                    }
//                });
//            }
		//KTGameCenter.SharedCenter().ShowLeaderboard();
	}

	public void openOptions(){
		StartCoroutine(openOptionsCo()); 
	}

	private IEnumerator openOptionsCo(){ 
		PlayerPrefs.SetInt("hasSeenColors",1);
		chooseColorsText.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		buttonTap2.Play();
		upperLeftButton.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("SettingsGearInv", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (.125f);
        wannaGetHackerEditionText.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
        thankYouText.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		//optionsMenu.SetActive(true); 
		lineBGsound.volume = lineBGsound.volume/4;
		isOnOptionsMenu = true;
		OptionsMenu.transform.position = new Vector3(OptionsMenu.transform.position.x, OptionsMenu.transform.position.y + 10, 1);
		upperLeftButton.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ExitButton", typeof(Sprite)) as Sprite;
		if(AudioListener.volume == 1){
			row2Text.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("SoundOnText", typeof(Sprite)) as Sprite;
		}else if(AudioListener.volume == 0){
			row2Text.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("SoundOffText", typeof(Sprite)) as Sprite;
		}
	}

	public void closeOptions(){
		StartCoroutine(closeOptionsCo()); 
		//optionsMenu.SetActive(false); 
	}
	
	private IEnumerator closeOptionsCo(){ 
		buttonTap2.Play();
		upperLeftButton.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ExitButtonInv", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (.125f);
		lineBGsound.volume = lineBGsound.volume*4;
		upperLeftButton.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("SettingsGear", typeof(Sprite)) as Sprite;
		//optionsMenu.SetActive(false); 
		isOnOptionsMenu = false;
		OptionsMenu.transform.position = new Vector3(OptionsMenu.transform.position.x, OptionsMenu.transform.position.y - 10, 1);
	}

	public void displayHowToPlayMenu(){
		StartCoroutine(displayHowToPlayMenuCo()); 
	}	

	private IEnumerator displayHowToPlayMenuCo(){ 
		buttonTap2.Play();
		upperRightButton.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("QuestionMarkInv", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (.125f);
        wannaGetHackerEditionText.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		lineBGsound.volume = lineBGsound.volume/4;
		//howToPlayMenu.SetActive(true);
		isOnHowToPlayMenu = true;
		HowToPlayMenu.transform.position = new Vector3(OptionsMenu.transform.position.x, OptionsMenu.transform.position.y + 10, 1);
		upperRightButton.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ExitButton", typeof(Sprite)) as Sprite;

	}

	public void closeHowToPlayMenu(){
		StartCoroutine(closeHowToPlayMenuCo()); 
		 
	}
	
	private IEnumerator closeHowToPlayMenuCo(){ 
		buttonTap2.Play();
		upperRightButton.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ExitButtonInv", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (.125f);
		lineBGsound.volume = lineBGsound.volume*4;
		isOnHowToPlayMenu = false;
		HowToPlayMenu.transform.position = new Vector3(OptionsMenu.transform.position.x, OptionsMenu.transform.position.y - 10, 1);
		upperRightButton.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("QuestionMark", typeof(Sprite)) as Sprite;
		//howToPlayMenu.SetActive(false);
	}

	public void toggleSound(){
		StartCoroutine(toggleSoundCo()); 
	}	
	
	private IEnumerator toggleSoundCo(){ 
		if(row2Text.GetComponent<SpriteRenderer>().sprite.name.Equals("SoundOnText")){
			AudioListener.volume = 0;
			row2Text.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("SoundOnTextInv", typeof(Sprite)) as Sprite;
			yield return new WaitForSeconds (.125f);
			row2Text.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("SoundOffText", typeof(Sprite)) as Sprite;

		}else if(row2Text.GetComponent<SpriteRenderer>().sprite.name.Equals("SoundOffText")){
			AudioListener.volume = 1;
			row2Text.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("SoundOffTextInv", typeof(Sprite)) as Sprite;
			buttonTap2.Play();
			yield return new WaitForSeconds (.125f);
			row2Text.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("SoundOnText", typeof(Sprite)) as Sprite;
		}
	}

	public void openPipSpinPage(){
		StartCoroutine(openPipSpinPageCo()); 
	}

	private IEnumerator openPipSpinPageCo(){ 
		buttonTap2.Play();
		row3Text.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("RateTextInv", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (.125f);
		row3Text.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("RateText", typeof(Sprite)) as Sprite;
		Application.OpenURL("itms-apps://itunes.apple.com/app/id1071705747");
        //Application.OpenURL("market://details?id=com.MatthewBurton.PipSpin");
	}

    public void openNinjevadePage() {
        buttonTap2.Play();
		Application.OpenURL("itms-apps://itunes.apple.com/app/id953832109");
        //Application.OpenURL("market://details?id=com.MatthewBurton.NITM2");
    }

    public void openPinPongPage() {
        buttonTap2.Play();
		Application.OpenURL("itms-apps://itunes.apple.com/app/id1015819050");
        //Application.OpenURL("market://details?id=com.MatthewBurton.TwoPlayersOnly");
    }

	public void displayMoreGamesMenu(){
		StartCoroutine(displayMoreGamesMenuCo()); 
	}
	
	private IEnumerator displayMoreGamesMenuCo(){ 
		buttonTap2.Play();
		row4Text.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MoreGamesTextInv", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (.125f);
		row4Text.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MoreGamesText", typeof(Sprite)) as Sprite;
		//Application.OpenURL("market://dev?id=5177073549815025883");
        OptionsMenu.transform.position = new Vector3(OptionsMenu.transform.position.x, OptionsMenu.transform.position.y - 10, 1);
        isOnOptionsMenu = false;

        MoreGamesMenu.transform.position = new Vector3(MoreGamesMenu.transform.position.x, MoreGamesMenu.transform.position.y + 10, 1);
        isOnMoreGamesMenu = true;

	}

    public void closeMoreGamesMenu(){
		StartCoroutine(closeMoreGamesMenuCo()); 
		 
	}
	
	private IEnumerator closeMoreGamesMenuCo(){ 
		buttonTap2.Play();
		upperLeftButton.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ExitButtonInv", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (.125f);
		lineBGsound.volume = lineBGsound.volume*4;
		upperLeftButton.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("SettingsGear", typeof(Sprite)) as Sprite;
		//optionsMenu.SetActive(false); 
		isOnMoreGamesMenu = false;
		MoreGamesMenu.transform.position = new Vector3(MoreGamesMenu.transform.position.x, MoreGamesMenu.transform.position.y - 10, 1);
	}

	public void goToMainMenu(){
		StartCoroutine(goToMainMenuCo()); 
	}
	
	private IEnumerator goToMainMenuCo(){ 
		row1Text.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MainMenuTextInv", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (.125f);
		setUpMainMenuTextRows();
	}

	public void determineLineSpinningSpeed(){
		if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No1")){
			lineSpinningSpeed = 130;
			projectileSpeed = .2f;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No2")){
			lineSpinningSpeed = 155;
			projectileSpeed = .4f;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No3")){
			lineSpinningSpeed = 181;
			projectileSpeed = .6f;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No4")){
			lineSpinningSpeed = 214;
			projectileSpeed = .8f;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No5")){
			lineSpinningSpeed = 241;
			projectileSpeed = 1f;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No6")){
			lineSpinningSpeed = 276;
			projectileSpeed = 1.2f;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No7")){
			lineSpinningSpeed = 302;
			projectileSpeed = 1.4f;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No8")){
			lineSpinningSpeed = 336;
			projectileSpeed = 1.6f;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No9")){
			lineSpinningSpeed = 356;
			projectileSpeed = 1.8f;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No10")){
			lineSpinningSpeed = 390;
			projectileSpeed = 2f;
		}
	}

	public void fireProjectile(float speed){

		Projectile[] projectiles = FindObjectsOfType(typeof(Projectile)) as Projectile[];
		foreach (Projectile projectile in projectiles){
			//projectile.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
			projectile.enabled = false;
		}

		if(canFireProjectile){
			Vector3 Left1ProjectileSpawnLocation = new Vector3 (-4.5f, -1.25f, 0);
			Vector2 downRight = new Vector2 (1, 0);
			//AudioSource.PlayClipAtPoint(Woosh1, transform.position);
			var liveProjectile = (Projectile)Instantiate (projectile, Left1ProjectileSpawnLocation, transform.rotation); 
			liveProjectile.Initialize (gameObject, downRight, new Vector2(speed, 0), -1); 
			liveProjectile.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
			liveProjectile.transform.localScale = new Vector3(transform.localScale.x/3,transform.localScale.y/3,0);			
			
			float sequenceNumber = random.Next (1, 250);
			if(sequenceNumber == 2){ 
				liveProjectile.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("NathalieBG", typeof(Sprite)) as Sprite; 
				liveProjectile.transform.GetChild(0).GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
			}
		}
	}

	public void changeColor(){
		StartCoroutine(changeColorCo()); 
	}

	
	private IEnumerator changeColorCo(){ 
		if(PlayerPrefs.GetInt("hasHackerEdition") == 1){
			buttonTap2.Play();
			row5Text.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("HackerEditionTextInv", typeof(Sprite)) as Sprite;
			yield return new WaitForSeconds (.125f);
			row5Text.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("HackerEditionText", typeof(Sprite)) as Sprite;
			colorChanger.turnColor();
		}

		else{
			requiresHackerEditionText.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
		}
	}

	public void showHackerEditionScreen(){
        if(PlayerPrefs.GetInt("hasHackerEdition") != 1){
            StartCoroutine(showHackerEditionScreenCo()); 
        }
	}


	private IEnumerator showHackerEditionScreenCo(){ 
		buttonTap2.Play();
		hackerEditionButton.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("HackerEditionText2Inv", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (.125f);
		hackerEditionButton.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("HackerEditionText2", typeof(Sprite)) as Sprite;
		goToHackerEditionMenu();
	}

	public void goToHackerEditionMenu(){
		//Application.LoadLevel(4);
        SceneManager.LoadScene(4);
    }

	public void flicker(){
		StartCoroutine(flickerCo()); 
	}
	
	private IEnumerator flickerCo(){ 
		GreenImages.SetActive(true);
		yield return new WaitForSeconds (.025f);
		GreenImages.SetActive(false);
		yield return new WaitForSeconds (.025f);
		GreenImages.SetActive(true);
		yield return new WaitForSeconds (.025f);
		GreenImages.SetActive(false);
		yield return new WaitForSeconds (.025f);
		GreenImages.SetActive(true);
		yield return new WaitForSeconds (.025f);
		GreenImages.SetActive(false);
		yield return new WaitForSeconds (.025f);
		GreenImages.SetActive(true);
		yield return new WaitForSeconds (.1f);
		GreenImages.SetActive(false);
		yield return new WaitForSeconds (.025f);
		GreenImages.SetActive(true);
	}

	public void determinePlayButtonStatus(){
		if(PlayerPrefs.GetInt("PlayerLevel") >= levelNumberOnScreen){
			playButton.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("playText", typeof(Sprite)) as Sprite;
			unlockLvlNumber.GetComponent<SpriteRenderer> ().enabled = false;
			unlockLvlText.GetComponent<SpriteRenderer> ().enabled = false;
		}else{
			playButton.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("playTextInv", typeof(Sprite)) as Sprite;
			unlockLvlNumber.GetComponent<SpriteRenderer> ().enabled = true;
			unlockLvlText.GetComponent<SpriteRenderer> ().enabled = true;
		}
	}

	public void setUpMenu(){
		if(PlayerPrefs.GetInt("PlayerLevel") == 1){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No1", typeof(Sprite)) as Sprite;
			leftArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
			rightArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			levelNumberOnScreen = 1;
		}else if(PlayerPrefs.GetInt("PlayerLevel") == 2){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No1", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No2", typeof(Sprite)) as Sprite;
			leftArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			rightArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			levelNumberOnScreen = 2;
		}else if(PlayerPrefs.GetInt("PlayerLevel") == 3){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No2", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No3", typeof(Sprite)) as Sprite;
			leftArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			rightArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			levelNumberOnScreen = 3;
		}else if(PlayerPrefs.GetInt("PlayerLevel") == 4){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No3", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No4", typeof(Sprite)) as Sprite;
			leftArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			rightArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			levelNumberOnScreen = 4;
		}else if(PlayerPrefs.GetInt("PlayerLevel") == 5){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No4", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No5", typeof(Sprite)) as Sprite;
			leftArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			rightArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			levelNumberOnScreen = 5;
		}else if(PlayerPrefs.GetInt("PlayerLevel") == 6){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No5", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No6", typeof(Sprite)) as Sprite;
			leftArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			rightArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			levelNumberOnScreen = 6;
		}else if(PlayerPrefs.GetInt("PlayerLevel") == 7){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No6", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No7", typeof(Sprite)) as Sprite;
			leftArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			rightArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			levelNumberOnScreen = 7;
		}else if(PlayerPrefs.GetInt("PlayerLevel") == 8){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No7", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No8", typeof(Sprite)) as Sprite;
			leftArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			rightArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			levelNumberOnScreen = 8;
		}else if(PlayerPrefs.GetInt("PlayerLevel") == 9){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No8", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No9", typeof(Sprite)) as Sprite;
			leftArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			rightArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			levelNumberOnScreen = 9;
		}else if(PlayerPrefs.GetInt("PlayerLevel") >= 10){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No9", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No10", typeof(Sprite)) as Sprite;
			leftArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			rightArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
			levelNumberOnScreen = 10;
		}

		determinePlayButtonStatus();

		PlayerPrefs.SetInt("hasSetUpInitialMenu",1);
	}

	public void setUpMenu2(){
		if(GameManager.Instance.menuSpeedNumber == 1){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No1", typeof(Sprite)) as Sprite;
			leftArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
			rightArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			levelNumberOnScreen = 1;
		}else if(GameManager.Instance.menuSpeedNumber == 2){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No1", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No2", typeof(Sprite)) as Sprite;
			leftArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			rightArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			levelNumberOnScreen = 2;
		}else if(GameManager.Instance.menuSpeedNumber == 3){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No2", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No3", typeof(Sprite)) as Sprite;
			leftArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			rightArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			levelNumberOnScreen = 3;
		}else if(GameManager.Instance.menuSpeedNumber == 4){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No3", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No4", typeof(Sprite)) as Sprite;
			leftArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			rightArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			levelNumberOnScreen = 4;
		}else if(GameManager.Instance.menuSpeedNumber == 5){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No4", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No5", typeof(Sprite)) as Sprite;
			leftArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			rightArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			levelNumberOnScreen = 5;
		}else if(GameManager.Instance.menuSpeedNumber == 6){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No5", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No6", typeof(Sprite)) as Sprite;
			leftArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			rightArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			levelNumberOnScreen = 6;
		}else if(GameManager.Instance.menuSpeedNumber == 7){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No6", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No7", typeof(Sprite)) as Sprite;
			leftArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			rightArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			levelNumberOnScreen = 7;
		}else if(GameManager.Instance.menuSpeedNumber == 8){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No7", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No8", typeof(Sprite)) as Sprite;
			leftArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			rightArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			levelNumberOnScreen = 8;
		}else if(GameManager.Instance.menuSpeedNumber == 9){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No8", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No9", typeof(Sprite)) as Sprite;
			leftArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			rightArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			levelNumberOnScreen = 9;
		}else if(GameManager.Instance.menuSpeedNumber == 10){
			unlockLvlNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No9", typeof(Sprite)) as Sprite;
			levelNumber.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("No10", typeof(Sprite)) as Sprite;
			leftArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
			rightArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
			levelNumberOnScreen = 10;
		}
		
		determinePlayButtonStatus();
	}

	public void flashRightArrow(){
		if(levelNumberOnScreen < 9){
			StartCoroutine(flashImageCo()); 
		}
	}

	private IEnumerator flashImageCo(){ 
		rightArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ArrowInv", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (.1f);
		rightArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
	}

	public void flashLeftArrow(){
		if(levelNumberOnScreen > 2){
			StartCoroutine(flashLeftImageCo()); 
		}
	}
	
	private IEnumerator flashLeftImageCo(){ 
		leftArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ArrowInv", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (.1f);
		leftArrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Arrow", typeof(Sprite)) as Sprite;
	}

	public void initiateMenuProjectileFiringSequence(){  
		if (Time.time > nextActionTime ) {
			nextActionTime = Time.time + period;  
			fireProjectile(projectileSpeed);
		}
	}

	public void displayChooseColorsText(){
		chooseColorsText.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
	}

    public void determineBuyHackerEditionTextStatus() {
        if (PlayerPrefs.GetInt("hasHackerEdition") != 1) {
            if (PlayerPrefs.GetInt("PlayerLevel") > 1 && PlayerPrefs.GetInt("adCounter") == 0 && PlayerPrefs.GetInt("timesSeenHackerText") < 3) {
                PlayerPrefs.SetInt("timesSeenHackerText",PlayerPrefs.GetInt("timesSeenHackerText") + 1);
                wannaGetHackerEditionText.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
            }
        }
    }

    public void determineThankYouStatus(){
         if (PlayerPrefs.GetInt("displayThankYou") == 1) {
            thankYouText.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
            PlayerPrefs.SetInt("displayThankYou",0);
         }
    }

	public void determineLineHumSound(){
		if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No1")){
//			lineBGsound.GetComponent<AudioSource>().enabled = false;
//			lineBGsound.GetComponent<AudioSource>().clip = musicManager.LineBuzzC1;
//			lineBGsound.GetComponent<AudioSource>().enabled = true;
			lineBGsound.GetComponent<AudioSource>().pitch = .68f;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No2")){
//			lineBGsound.GetComponent<AudioSource>().enabled = false;
//			lineBGsound.GetComponent<AudioSource>().clip = musicManager.LineBuzzD1;
//			lineBGsound.GetComponent<AudioSource>().enabled = true;
			lineBGsound.GetComponent<AudioSource>().pitch = .7f;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No3")){
//			lineBGsound.GetComponent<AudioSource>().enabled = false;
//			lineBGsound.GetComponent<AudioSource>().clip = musicManager.LineBuzzE1;
//			lineBGsound.GetComponent<AudioSource>().enabled = true;
			lineBGsound.GetComponent<AudioSource>().pitch = .72f;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No4")){
//			lineBGsound.GetComponent<AudioSource>().enabled = false;
//			lineBGsound.GetComponent<AudioSource>().clip = musicManager.LineBuzzF1;
//			lineBGsound.GetComponent<AudioSource>().enabled = true;
			lineBGsound.GetComponent<AudioSource>().pitch = .74f;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No5")){
//			lineBGsound.GetComponent<AudioSource>().enabled = false;
//			lineBGsound.GetComponent<AudioSource>().clip = musicManager.LineBuzzG1;
//			lineBGsound.GetComponent<AudioSource>().enabled = true;
			lineBGsound.GetComponent<AudioSource>().pitch = .76f;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No6")){
//			lineBGsound.GetComponent<AudioSource>().enabled = false;
//			lineBGsound.GetComponent<AudioSource>().clip = musicManager.LineBuzzA1;
//			lineBGsound.GetComponent<AudioSource>().enabled = true;
			lineBGsound.GetComponent<AudioSource>().pitch = .78f;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No7")){
//			lineBGsound.GetComponent<AudioSource>().enabled = false;
//			lineBGsound.GetComponent<AudioSource>().clip = musicManager.LineBuzzB1;
//			lineBGsound.GetComponent<AudioSource>().enabled = true;
			lineBGsound.GetComponent<AudioSource>().pitch = .8f;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No8")){
//			lineBGsound.GetComponent<AudioSource>().enabled = false;
//			lineBGsound.GetComponent<AudioSource>().clip = musicManager.LineBuzzC2;
//			lineBGsound.GetComponent<AudioSource>().enabled = true;
			lineBGsound.GetComponent<AudioSource>().pitch = .82f;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No9")){
//			lineBGsound.GetComponent<AudioSource>().enabled = false;
//			lineBGsound.GetComponent<AudioSource>().clip = musicManager.LineBuzzD2;
//			lineBGsound.GetComponent<AudioSource>().enabled = true;
			lineBGsound.GetComponent<AudioSource>().pitch = .84f;
		}else if(levelNumber.GetComponent<SpriteRenderer>().sprite.name.Equals("No10")){
//			lineBGsound.GetComponent<AudioSource>().enabled = false;
//			lineBGsound.GetComponent<AudioSource>().clip = musicManager.LineBuzzE2;
//			lineBGsound.GetComponent<AudioSource>().enabled = true;
			lineBGsound.GetComponent<AudioSource>().pitch = .86f;
		}
	}
}
