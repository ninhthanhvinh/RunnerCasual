using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public int points = 0;
    public static GameManager instance;
    private AudioManager audioManager;
    public UnityEvent<int> OnPointChange;
    public UnityEvent OnGameOver;

    LevelGenerator levelGenerator;

    [HideInInspector]
    public float timeScaleSaved;

    private float timer;

    public float timeBetweenSpeedUp;
    public float speedUpAmount;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        levelGenerator = GetComponent<LevelGenerator>();
        points = 0; 
        audioManager = AudioManager.instance;
        audioManager.PlaySound("BackgroundMusic");
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 0f)
        {
            timer = timeBetweenSpeedUp;
            Time.timeScale *= speedUpAmount;
            timeScaleSaved = Time.timeScale;
        }
    }

    public void Reset()
    {
        levelGenerator.Reset();
        points = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }

    internal void StartGame()
    {
        Time.timeScale = 1f;
    }
}
