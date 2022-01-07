using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TimeSpeedType:byte
{
    Paused,
    Normal,
    Fast2x,
    Fast4x,
    Fast8x
}
public class TurnManager : MonoBehaviour
{
    public delegate void DoTurnPart();
    public static event DoTurnPart NextTurn,TurnTick,UITick,CharacterInfoUpdater;
    public static TimeSpeedType timeSpeed;
    public static bool isPaused=false;
    public float normalTime, fastTime, veryFastTime;
    
   public float timeCounter;

    int timeMultiplier = 1;
    UI_SourceMeterController uisourceMeterController;
    private void Awake()
    {
        StartCoroutine(PassTime());
    }
    
    public static void UpdateCharacterInfo()
    {
        
        if (CharacterInfoUpdater != null)
        {
           
            CharacterInfoUpdater();
        }
    }

    public void TimeSpeedChange(int amount)
    {
        if(amount>0)
        {
            if(timeSpeed<TimeSpeedType.Fast8x)
            {
                timeSpeed++;
            }
        }
        else
        {
            if (timeSpeed > TimeSpeedType.Paused)
            {
                timeSpeed--;
            }
        }
        SwitchToSpeed(timeSpeed);
    }

    public void SwitchToSpeed(TimeSpeedType speedIndex)
    {
        switch (speedIndex)
        {
            case TimeSpeedType.Paused:
                {
                    isPaused = true;
                    uisourceMeterController.PauseUI();
                    
                }
                break;
            case TimeSpeedType.Normal:
                {
                    isPaused = false;
                    uisourceMeterController.ContinueUI("x1");
                    timeMultiplier = 1;
                }
                break;
            case TimeSpeedType.Fast2x:
                {
                    isPaused = false;
                    uisourceMeterController.ContinueUI("x2");
                    timeMultiplier = 2;
                }
                break;
            case TimeSpeedType.Fast4x:
                {
                    isPaused = false;
                    uisourceMeterController.ContinueUI("x4");
                    timeMultiplier = 4;
                }
                break;
            case TimeSpeedType.Fast8x:
                {
                    isPaused = false;
                    uisourceMeterController.ContinueUI("x8");
                    timeMultiplier = 8;
                }
                break;
        }
    }
        IEnumerator PassTime()
    {
        timeCounter = 0;
        timeSpeed = TimeSpeedType.Normal;
        yield return new WaitForSeconds(1);
        while (true)
        {
            //if (Input.GetKeyDown(KeyCode.Alpha1))
            //    FindObjectOfType<GenerateMap>().PutDownWizards();
            yield return new WaitForSeconds(Time.smoothDeltaTime);
            timeCounter += Time.smoothDeltaTime*timeMultiplier;
            if (UITick != null)
                UITick();
            
            if (!isPaused)
            {
                if (uisourceMeterController == null)
                {
                    uisourceMeterController = FindObjectOfType<UI_SourceMeterController>();
                }
                else
                    uisourceMeterController.ChangesourceTimeScaler(timeCounter / 16f);
                for (int i = 0; i < timeMultiplier; i++)
                    if (TurnTick != null)
                {
                    
                    TurnTick();
                }
                
                if (timeCounter > 16)
                {

                    timeCounter = 0;
                               
                    if (NextTurn != null)
                   
                        NextTurn();
                   
                }
            }
        }
    }


    public static void PauseControllerForUI()
    {
        isPaused = !isPaused;
    }

    }
