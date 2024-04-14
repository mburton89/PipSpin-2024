using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	//Lagatto
	public AudioClip C1;
	public AudioClip D1;
	public AudioClip E1;
	public AudioClip F1;
		public AudioClip Fs1;
	public AudioClip G1;
		public AudioClip Gs1;
	public AudioClip A1;
	public AudioClip B1;
	public AudioClip C2;
		public AudioClip Cs2;
	public AudioClip D2;
		public AudioClip Ds2;
	public AudioClip E2;
	public AudioClip F2;
		public AudioClip Fs2;
	public AudioClip G2;
		public AudioClip Gs2;
	public AudioClip A2;
	public AudioClip B2;
	public AudioClip C3;
	public AudioClip D3;
	public AudioClip E3;

	//Stagatto
	public AudioClip C1Short;
	public AudioClip D1Short;
	public AudioClip E1Short;
	public AudioClip F1Short;
	public AudioClip Fs1Short;
	public AudioClip G1Short;
	public AudioClip Gs1Short;
	public AudioClip A1Short;
	public AudioClip B1Short;
	public AudioClip C2Short;
	public AudioClip Cs2Short;
	public AudioClip D2Short;
	public AudioClip Ds2Short;
	public AudioClip E2Short;
	public AudioClip F2Short;
	public AudioClip Fs2Short;
	public AudioClip G2Short;
	public AudioClip Gs2Short;
	public AudioClip A2Short;
	public AudioClip B2Short;
	public AudioClip C3Short;
	public AudioClip D3Short;
	public AudioClip E3Short;

	public AudioClip Snare1;
	public AudioClip Bass1;

	private AudioClip L1;
	private AudioClip L2;
	private AudioClip R1;
	private AudioClip R2;

	private AudioClip L1Short;
	private AudioClip L2Short;
	private AudioClip R1Short;
	private AudioClip R2Short;

	public AudioClip LineBuzzC1;
	public AudioClip LineBuzzD1;
	public AudioClip LineBuzzE1;
	public AudioClip LineBuzzF1;
	public AudioClip LineBuzzG1;
	public AudioClip LineBuzzA1;
	public AudioClip LineBuzzB1;
	public AudioClip LineBuzzC2;
	public AudioClip LineBuzzD2;
	public AudioClip LineBuzzE2;

	public AudioClip CurrentLineBuzz;

	private bool playedSnare = true;

	public AudioSource aL1;
	public AudioSource aL2;
	public AudioSource aR1;
	public AudioSource aR2;
	public AudioSource aL1Short;
	public AudioSource aL2Short;
	public AudioSource aR1Short;
	public AudioSource aR2Short;
	public AudioSource aSnare;
	public AudioSource aBass;

	void Awake (){
		determineSoundsForLevel();
	}

	void Start () {

	}

	void Update () {
	
	}

	public void play1a2Sound(float time){
		StartCoroutine(play1a2SoundCo(time));
	}

	public void play1a3Sound(float time){
		//AudioSource.PlayClipAtPoint(L2, transform.position);
		StartCoroutine(play1a3SoundCo(time));
	}

	public void play2a4Sound(float time){
		//AudioSource.PlayClipAtPoint(R1, transform.position);
		StartCoroutine(play2a4SoundCo(time));
	}

	public void play3a4Sound(float time){
		StartCoroutine(play3a4SoundCo(time));
	}

	private IEnumerator play1a2SoundCo(float time){ 
		aL1.Play();
		aL2.Play();
		yield return new WaitForSeconds (time/2);
		//AudioSource.PlayClipAtPoint(Snare1, transform.position);
		playDrum();
	}

	private IEnumerator play1a3SoundCo(float time){ 
		aL1Short.Play();
		yield return new WaitForSeconds (time/2);
		aR1Short.Play();
		//AudioSource.PlayClipAtPoint(Snare1, transform.position);
		playDrum();
	}

	private IEnumerator play2a4SoundCo(float time){ 
		aL2Short.Play();
		yield return new WaitForSeconds (time/2);
		aR2Short.Play();
		playDrum();
	}

	private IEnumerator play3a4SoundCo(float time){ 
		aR1.Play();
		aR2.Play();
		yield return new WaitForSeconds (time/2);
		//AudioSource.PlayClipAtPoint(Snare1, transform.position);
		playDrum();
	}

//	private IEnumerator play1a2SoundCo(float time){ 
//		AudioSource.PlayClipAtPoint(L1, transform.position);
//		AudioSource.PlayClipAtPoint(L2, transform.position);
//		yield return new WaitForSeconds (time/2);
//		//AudioSource.PlayClipAtPoint(Snare1, transform.position);
//		playDrum();
//	}
//
//	private IEnumerator play1a3SoundCo(float time){ 
//		AudioSource.PlayClipAtPoint(L1Short, transform.position);
//		yield return new WaitForSeconds (time/2);
//		AudioSource.PlayClipAtPoint(R1Short, transform.position);
//		//AudioSource.PlayClipAtPoint(Snare1, transform.position);
//		playDrum();
//	}
//
//	private IEnumerator play2a4SoundCo(float time){ 
//		AudioSource.PlayClipAtPoint(L2Short, transform.position);
//		yield return new WaitForSeconds (time/2);
//		AudioSource.PlayClipAtPoint(R2Short, transform.position);
//		//AudioSource.PlayClipAtPoint(Snare1, transform.position);
//		playDrum();
//	}
//
//	private IEnumerator play3a4SoundCo(float time){ 
//		AudioSource.PlayClipAtPoint(R1, transform.position);
//		AudioSource.PlayClipAtPoint(R2, transform.position);
//		yield return new WaitForSeconds (time/2);
//		//AudioSource.PlayClipAtPoint(Snare1, transform.position);
//		playDrum();
//	}

	public void setUpLevel1(){
//		L1 = C1;
//		L2 = E1;
//		R1 = G1;
//		R2 = C2;
//		L1Short = C1Short;
//		L2Short = E1Short;
//		R1Short = G1Short;
//		R2Short = C2Short;
		CurrentLineBuzz = LineBuzzC1;

		aL1.clip = C1;
		aL2.clip = E1;
		aR1.clip = G1;
		aR2.clip = C2;
		aL1Short.clip = C1Short;
		aL2Short.clip = E1Short;
		aR1Short.clip = G1Short;
		aR2Short.clip = C2Short;
		aSnare.clip = Snare1;
		aBass.clip = Bass1;

	}

	public void setUpLevel2(){
		L1 = D1;
		L2 = Fs1;
		R1 = A1;
		R2 = D2;
		L1Short = D1Short;
		L2Short = Fs1Short;
		R1Short = A1Short;
		R2Short = D2Short;
		CurrentLineBuzz = LineBuzzD1;


	}

	public void setUpLevel3(){
		L1 = E1;
		L2 = Gs1;
		R1 = B1;
		R2 = E2;
		L1Short = E1Short;
		L2Short = Gs1Short;
		R1Short = B1Short;
		R2Short = E2Short;
		CurrentLineBuzz = LineBuzzE1;
	}

	public void setUpLevel4(){
		L1 = F1;
		L2 = A1;
		R1 = C2;
		R2 = F2;
		L1Short = F1Short;
		L2Short = A1Short;
		R1Short = C2Short;
		R2Short = F2Short;
		CurrentLineBuzz = LineBuzzF1;
	}

	public void setUpLevel5(){
		L1 = G1;
		L2 = B1;
		R1 = D2;
		R2 = G2;
		L1Short = G1Short;
		L2Short = B1Short;
		R1Short = D2Short;
		R2Short = G2Short;
		CurrentLineBuzz = LineBuzzG1;
	}

	public void setUpLevel6(){
		L1 = A1;
		L2 = Cs2;
		R1 = E2;
		R2 = A2;
		L1Short = A1Short;
		L2Short = Cs2Short;
		R1Short = E2Short;
		R2Short = A2Short;
		CurrentLineBuzz = LineBuzzA1;
	}

	public void setUpLevel7(){
//		L1 = B1;
//		L2 = Ds2;
//		R1 = Fs2;
//		R2 = B2;
//		L1Short = B1Short;
//		L2Short = Ds2Short;
//		R1Short = Fs2Short;
//		R2Short = B2Short;
		CurrentLineBuzz = LineBuzzB1;

		aL1.clip = B1;
		aL2.clip = Ds2;
		aR1.clip = Fs2;
		aR2.clip = B2;
		aL1Short.clip = B1Short;
		aL2Short.clip = Ds2Short;
		aR1Short.clip = Fs2Short;
		aR2Short.clip = B2Short;
		aSnare.clip = Snare1;
		aBass.clip = Bass1;
	}

	public void setUpLevel8(){
		L1 = C2;
		L2 = E2;
		R1 = G2;
		R2 = C3;
		L1Short = C2Short;
		L2Short = E2Short;
		R1Short = G2Short;
		R2Short = C3Short;
		CurrentLineBuzz = LineBuzzC2;
	}

	public void setUpLevel9(){
		L1 = D2;
		L2 = Fs2;
		R1 = A2;
		R2 = D3;
		L1Short = D2Short;
		L2Short = Fs2Short;
		R1Short = A2Short;
		R2Short = D3Short;
		CurrentLineBuzz = LineBuzzD2;
	}

	public void setUpLevel10(){
//		L1 = E2;
//		L2 = Gs2;
//		R1 = B2;
//		R2 = E3;
//		L1Short = E2Short;
//		L2Short = Gs2Short;
//		R1Short = B2Short;
//		R2Short = E3Short;
		CurrentLineBuzz = LineBuzzE2;

		aL1.clip = E2;
		aL2.clip = Gs2;
		aR1.clip = B2;
		aR2.clip = E3;
		aL1Short.clip = E2Short;
		aL2Short.clip = Gs2Short;
		aR1Short.clip = B2Short;
		aR2Short.clip = E3Short;
		aSnare.clip = Snare1;
		aBass.clip = Bass1;
	}

	public void determineSoundsForLevel(){
		if(GameManager.Instance.menuSpeedNumber == 1){
			setUpLevel1();
		}else if(GameManager.Instance.menuSpeedNumber == 2){
			setUpLevel2();
		}else if(GameManager.Instance.menuSpeedNumber == 3){
			setUpLevel3();
		}else if(GameManager.Instance.menuSpeedNumber == 4){
			setUpLevel4();
		}else if(GameManager.Instance.menuSpeedNumber == 5){
			setUpLevel5();
		}else if(GameManager.Instance.menuSpeedNumber == 6){
			setUpLevel6();
		}else if(GameManager.Instance.menuSpeedNumber == 7){
			setUpLevel7();
		}else if(GameManager.Instance.menuSpeedNumber == 8){
			setUpLevel8();
		}else if(GameManager.Instance.menuSpeedNumber == 9){
			setUpLevel9();
		}else if(GameManager.Instance.menuSpeedNumber == 10){
			setUpLevel10();
		}
	}

	public void playDrum(){
		if(playedSnare){
			aSnare.Play();
			playedSnare = false;
		}else{
			aBass.Play();
			playedSnare = true;
		}
	}

//	public void playDrum(){
//		if(playedSnare){
//			AudioSource.PlayClipAtPoint(Bass1, transform.position);
//			playedSnare = false;
//		}else{
//			AudioSource.PlayClipAtPoint(Snare1, transform.position);
//			playedSnare = true;
//		}
//	}

	public void playLevelUpSound(){
		StartCoroutine(playLevelUpSoundCo());
	}

	private IEnumerator playLevelUpSoundCo(){ 
		AudioSource.PlayClipAtPoint(L1Short, transform.position);
		yield return new WaitForSeconds (.0625f);
		AudioSource.PlayClipAtPoint(L2Short, transform.position);
		yield return new WaitForSeconds (.0625f);
		AudioSource.PlayClipAtPoint(R1Short, transform.position);
		yield return new WaitForSeconds (.0625f);
		AudioSource.PlayClipAtPoint(R2Short, transform.position);
		yield return new WaitForSeconds (.125f);

		AudioSource.PlayClipAtPoint(L1Short, transform.position);
		yield return new WaitForSeconds (.0625f);
		AudioSource.PlayClipAtPoint(L2Short, transform.position);
		yield return new WaitForSeconds (.0625f);
		AudioSource.PlayClipAtPoint(R1Short, transform.position);
		yield return new WaitForSeconds (.0625f);
		AudioSource.PlayClipAtPoint(R2Short, transform.position);
		yield return new WaitForSeconds (.125f);

		AudioSource.PlayClipAtPoint(L1Short, transform.position);
		yield return new WaitForSeconds (.0625f);
		AudioSource.PlayClipAtPoint(L2Short, transform.position);
		yield return new WaitForSeconds (.0625f);
		AudioSource.PlayClipAtPoint(R1Short, transform.position);
		yield return new WaitForSeconds (.0625f);
		AudioSource.PlayClipAtPoint(R2Short, transform.position);
		yield return new WaitForSeconds (.125f);
	}
}
