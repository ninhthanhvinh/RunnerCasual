using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UpdateUI : MonoBehaviour
{

    private GameManager gameManager;
    public TMPro.TextMeshProUGUI scoreText;

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        gameManager.OnPointChange.AddListener(UpdateScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioMixer musicMixer;
    public AudioMixer sfxMixer;
    public void MusicVolumnChange(float value)
    {
        musicMixer.SetFloat("MusicVolumn", Mathf.Log10(value) * 20 + 20);
    }

    public void SFXVolumnChange(float value)
    {
        sfxMixer.SetFloat("SFXVolumn", Mathf.Log10(value) * 20 + 20);
    }

    public void OnButtonClick()
    {
        AudioManager.instance.PlaySound("ButtonClick");
    }

    public void Reset()
    {
        gameManager.Reset();
    }

    public void MainMenu()
    {
        gameManager.LoadScene(0);
    }

    public void StartGame()
    {
        gameManager.StartGame();
    }
}
