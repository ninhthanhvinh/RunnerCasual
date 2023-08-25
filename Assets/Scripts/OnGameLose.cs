using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnGameLose : MonoBehaviour
{
    GameManager gameManager;
    public TextMeshProUGUI scoreBoard;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        gameManager.OnGameOver.AddListener(GameEnd);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GameEnd()
    {
        scoreBoard.text = gameManager.points.ToString();
        TweenIn(2f);
    }

    public void TweenIn(float time)
    {
        LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), time).setDelay(1f).setEase(LeanTweenType.easeOutElastic);
        Invoke(nameof(DelayTime), time);
    }

    public void TweenOut(float time)
    {
        Time.timeScale = 1f;
        LeanTween.scale(gameObject, new Vector3(0f, 0f, 0f), time).setDelay(.5f).setEase(LeanTweenType.easeOutElastic);
        Debug.Log("TweenOut" + gameObject.transform.localScale);
        Time.timeScale = 1f;
        Debug.Log(Time.timeScale);
    }

    private void DelayTime()
    {
        Time.timeScale = 0f;
    }
}
