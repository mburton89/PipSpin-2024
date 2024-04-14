using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Soomla;
using Soomla.Store;

public class HackerEditionPurchaseMenu : MonoBehaviour {

	public GameObject buyButton;
    public GameObject exitButton;
    public AudioSource buttonTap2;
	public GameObject restoreButton;
	public GameObject transactionInProgressText;

    void Start () {
	
	}

	void Update () {
        HandleKeyboard();
        HandleUserTouches();
        determineHackerEditionStatus();
		determineTransactionStatus();
    }

    public void HandleKeyboard(){
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            returnToMainMenu();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            initiateHackerEdtionPurchase();
        }
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			restorePurchases();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			PlayerPrefs.SetInt("purchaseHasStarted",1);
			startTIPHideCountdown();
		}
    }

    public void HandleUserTouches(){
        for (int i = 0; i < Input.touchCount; i++){
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began) {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                if (touchPosition.x > -3.4 && touchPosition.x < -2.5 && touchPosition.y > -1.3){
                    returnToMainMenu();
                }
                else if (touchPosition.x > -2.8 && touchPosition.x < 1.4 && touchPosition.y > -4.45 && touchPosition.y < -3.62) {
                    initiateHackerEdtionPurchase();
                }
				else if (touchPosition.x > -1.5 && touchPosition.x < 0.05 && touchPosition.y < -4.85) {
					restorePurchases();
				}
			}
		}
	}
	
	
	public void initiateHackerEdtionPurchase(){
        StartCoroutine(initiateHackerEdtionPurchaseCo());
    }

    private IEnumerator initiateHackerEdtionPurchaseCo()
    {
        buttonTap2.Play();
        buyButton.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("BuyButtonInv", typeof(Sprite)) as Sprite;
        yield return new WaitForSeconds(.125f);
        buyButton.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("BuyButton", typeof(Sprite)) as Sprite;
        initiateGooglePurchase();
    }

    public void returnToMainMenu(){
        exitButton.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("ex", typeof(Sprite)) as Sprite;
        StartCoroutine(returnToMainMenuCo());
    }

    private IEnumerator returnToMainMenuCo()
    {
        buttonTap2.Play();
        exitButton.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("ExitButtonInv", typeof(Sprite)) as Sprite;
        yield return new WaitForSeconds(.1f);
        //Application.LoadLevel(1);
        SceneManager.LoadScene(1);
    }

    public void initiateGooglePurchase() {
        //PlayerPrefs.SetInt("hasHackerEdition",1);
        SoomlaStore.BuyMarketItem(PipSpinAssets.HACKER_EDITION_ID, "Hacker Edition"); 
    }

    public void determineHackerEditionStatus() {
        if(PlayerPrefs.GetInt("hasHackerEdition") == 1){
            SceneManager.LoadScene(1);
        }
    }

	public void restorePurchases(){
		SoomlaStore.RestoreTransactions();
		//Debug.Log("RESTORE");
	}

	public void determineTransactionStatus(){
		if(PlayerPrefs.GetInt("purchaseHasStarted")==1){
			transactionInProgressText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("transactionInProgressText", typeof(Sprite)) as Sprite;
			startTIPHideCountdown();
		}else{
			transactionInProgressText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("BLANK", typeof(Sprite)) as Sprite;
		}
	}

	public void startTIPHideCountdown(){
		StartCoroutine(startTIPHideCountdownCo()); 
	}

	private IEnumerator startTIPHideCountdownCo(){ 
		yield return new WaitForSeconds (6);
		PlayerPrefs.SetInt("purchaseHasStarted",0);
	}
}
