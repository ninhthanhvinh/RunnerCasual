using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    public UpdateUI updateUI;
    public void Countdown()
    {
        updateUI.StartGame();
        gameObject.SetActive(false);
    }

}
