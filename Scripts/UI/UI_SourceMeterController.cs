using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_SourceMeterController : MonoBehaviour
{
    [SerializeField] Image  timeScaler,pauseImage,playImage,timeControllerImage;
    [SerializeField] TextMeshProUGUI turnMeter,scoreMeter,speedTimerCounter;
    public GameObject timePanel;
    int cycle = 1;

    private void Awake()
    {
        ChangeTurnMeter();
        TurnManager.NextTurn += ChangeTurnMeter;
            }
   
    public void ChangesourceTimeScaler(float score)
    {
        timeScaler.fillAmount = score;
    }

    public void ChangeTurnMeter()
    {
        turnMeter.text = cycle++.ToString()+". cycle";
    }
    public void ChangeScore(string score)
    {
        scoreMeter.text = score;
    }

    public void PauseAndPlay()
    {
        TurnManager.isPaused = !TurnManager.isPaused;
        if (TurnManager.isPaused)
            PauseUI();
        else
            FindObjectOfType<TurnManager>().SwitchToSpeed(TurnManager.timeSpeed);
    }

    public void PauseUI()
    {
        timeControllerImage.sprite = pauseImage.sprite;
        if(!TurnManager.isPaused)
        FindObjectOfType<TurnManager>().SwitchToSpeed(TimeSpeedType.Paused);
    }
    public void ContinueUI(string speedText)
    {
        timeControllerImage.sprite = playImage.sprite;
        
        speedTimerCounter.text = speedText;
    }

    public void IncreaseTimeSpeed()
    {
        FindObjectOfType<TurnManager>().TimeSpeedChange(1);
    }
    public void DecreaseTimeSpeed()
    {
        FindObjectOfType<TurnManager>().TimeSpeedChange(-1);
    }
    public void MainMenu()
    {
        FindObjectOfType<UIManager>().SwitchPanel(LayoutType.Menu);
    }

    public void SwitchTimePanel(bool state)
    {
        timePanel.SetActive(state);
    }

}
