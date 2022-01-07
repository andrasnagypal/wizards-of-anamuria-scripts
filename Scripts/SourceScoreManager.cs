using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceScoreManager : MonoBehaviour
{
    public static long[] lvlBoundariesForSkill = new long[]
    {
        100,
        200,
        300,
        500,
        1000,
        2000,
        3000,
        5000,
        10000,
        20000,
        30000,
        50000,
        100000,
        200000,
        300000,
        500000,
        1000000,
        2000000,
        3000000,
        5000000,
        10000000,
        20000000,
        30000000,
        50000000,
        100000000,
        200000000
    };

    public static long[] lvlUpBoundaries = new long[]
    {
        100,
        200,
        350,
        600,
        750,
        900,
        1050,
        1300,
        1500,
        1700,
        1900,
        2100,
        2300,
        2500,
        3000,
        3500,
        4000,
        4500,
        5000,
        5500,
        6000,
        7000,
        8000,
        9000,
        10000,
        11000,
        12000,
        14000,
        16000,
        18000,
        20000,
        25000,
        30000,
        35000,
        40000,
        45000,
        50000,
        60000,
        70000,
        80000,
        90000,
        100000,
        120000,
        140000,
        160000,
        180000,
        200000,
        250000,
        300000,
        350000,
        400000,
        450000,
        500000,
        600000,
        700000,
        800000,
        900000,
        1000000,
        2000000,
        3000000,
        4000000,
        5000000,
        6000000,
        7000000,
        8000000,
        9000000,
        10000000,
        12000000,
        14000000,
        16000000,
        18000000,
        20000000,
        30000000,
        40000000,
        50000000,
        60000000,
        70000000,
        80000000,
        90000000,
        100000000,
        120000000,
        140000000,
        160000000,
        180000000,
        200000000,
        300000000,
        400000000,
        500000000,
        600000000,
        700000000,
        800000000,
        900000000,
        1000000000,
        2000000000,
        3000000000,
        4000000000,
        5000000000,
        10000000000,
        100000000000
    };
    
    static int currentScore = 0, lvlUpAmount = 0;
    static UI_SourceMeterController uiScoreController;
   public static UI_RewardButtonController uimanaFillController;

    static RewardManager rewardManager;
    static UIManager uiManager;

    //has to be called after loading
    public void InititateScoreMeterController()
    {
        uiScoreController=FindObjectOfType<UI_SourceMeterController>();
        rewardManager = FindObjectOfType<RewardManager>();
        uiManager = FindObjectOfType<UIManager>();
       
    }
    public static void RaiseScore(int amount)
    {
       
        currentScore += amount;
        ChangeManaFillUI(amount);
        CheckScore();
        UpdateUI();
       

    }
    public static bool IsScoreEnoughToBuy(int amount)
    {
        return currentScore - amount > 0;
    }
    public static void DecreaseScore(int amount)
    {
        currentScore -= amount;
        ChangeManaFillUI(-amount);
        CheckScore();
        UpdateUI();
    }

    static void ChangeManaFillUI(int amount)
    {
        if(amount>=0)
        if(currentScore+amount>0&&lvlUpAmount>0&& lvlUpBoundaries[lvlUpAmount-1]<currentScore)
        {
            float value = (float)currentScore / lvlUpBoundaries[lvlUpAmount];
            uimanaFillController.SetManaFillUI(value);
        }
        else
            {
                float value = (float)currentScore / lvlUpBoundaries[lvlUpAmount];
                uimanaFillController.SetManaFillUI(value);
            }
        else
            {
                float value = (float)currentScore / lvlUpBoundaries[lvlUpAmount];
                uimanaFillController.SetManaFillUI(value);
            }
        if(lvlUpAmount==0)
        {
            float value = (float)currentScore / lvlUpBoundaries[lvlUpAmount];
            uimanaFillController.SetManaFillUI(value);
        }
    }

    private static void UpdateUI()
    {
        if(uiScoreController==null)
            uiScoreController = FindObjectOfType<UI_SourceMeterController>();
     
        uiScoreController.ChangeScore(currentScore.ToString()+" / "+ lvlUpBoundaries[lvlUpAmount].ToString());
      
    }

    static void CheckScore()
    {
       
        
        if (currentScore>= lvlUpBoundaries[lvlUpAmount])
        {
            rewardManager.AddRewardPackageToList(RewardPackageType.LvlUp);

            
            lvlUpAmount++;
            uimanaFillController.SetManaFillUI(0);
        }
        
       
    }
}
