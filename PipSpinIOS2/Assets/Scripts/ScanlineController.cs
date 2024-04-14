using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ScanlineController : MonoBehaviour 
{
	public static ScanlineController Instance;

	[SerializeField] private Image _scanline;

	void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		StartCoroutine(Fade());
	}

	public void SetUpScanlines(float amount)
	{
		Color updatedColor = _scanline.color;
		_scanline.color = new Color (updatedColor.r, updatedColor.g, updatedColor.b, amount);
	}

    private IEnumerator Fade()
    {
        float duration = 1;

        duration = Random.Range(0.75f, 1.5f);
        float min = Random.Range(0.2f, .5f);
        float max = Random.Range(0.5f, 1f);

        _scanline.DOFade(min, duration + Random.Range(-0.2f, 0.2f));
        yield return new WaitForSeconds(duration);
        _scanline.DOFade(max, duration + Random.Range(-0.2f, 0.2f));
        yield return new WaitForSeconds(duration);
        StartCoroutine(Fade());
    }
}
