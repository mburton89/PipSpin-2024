using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdSceneManager : MonoBehaviour {

    public GameObject wannaBuyHackerEditionImages;
    public GameObject broadcastText;
    public bool adHasShown;

	// Use this for initialization
	void Start () {
	    recieveBroadcast();
        //initateBackupLoad();
	}
	
	// Update is called once per frame
	void Update () {
        if (adHasShown) {
            handleKeyboard();
            handleUserTouches();
        }
	}

    public void handleKeyboard(){
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
             SceneManager.LoadScene(1);
		} 
	}

	public void handleUserTouches(){
		for (int i = 0; i < Input.touchCount; i++){  
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began){
                 SceneManager.LoadScene(1);
			}
		}
	}

    public void recieveBroadcast(){
		StartCoroutine(recieveBroadcastCo()); 
	}

	private IEnumerator recieveBroadcastCo(){
        /*        PlayerPrefs.SetInt("adCounter",0);
                yield return new WaitForSeconds (1.2f);
                adHasShown = true;
                    if(Advertisement.IsReady()){
                        Advertisement.Show();    
                    }
                yield return new WaitForSeconds (.25f);
                broadcastText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BroadcastTerminated", typeof(Sprite)) as Sprite;
                yield return new WaitForSeconds (.25f);
                SceneManager.LoadScene(1);*/
        yield return new WaitForSeconds(1.2f);
    }

    public void initateBackupLoad(){
		StartCoroutine(initateBackupLoadCo()); 
	}

	private IEnumerator initateBackupLoadCo(){ 
	    yield return new WaitForSeconds (10f);
        SceneManager.LoadScene(1);
    }

}
