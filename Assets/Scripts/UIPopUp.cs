using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopUp : MonoBehaviour
{
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.instance;
    }
    public void TweenIn(float time)
    {
        LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), time).setEase(LeanTweenType.easeOutElastic);
        Invoke(nameof(DelayTime), time);
    }

    public void TweenOut(float time)
    {
        Time.timeScale = gameManager.timeScaleSaved;
        LeanTween.scale(gameObject, new Vector3(0f, 0f, 0f), time).setDelay(.5f).setEase(LeanTweenType.easeOutElastic);
        Debug.Log("TweenOut" + gameObject.transform.localScale);
        Time.timeScale = gameManager.timeScaleSaved;
        Debug.Log(Time.timeScale);
    }

    private void DelayTime()
    {
        Time.timeScale = 0f;
    }
}
