using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_RewardPortrait : MonoBehaviour
{
    public Image portrait;
    public TextMeshProUGUI classOfPortrait, nameOfPortrait;

    RewardSO rewardData;

    public void SetReward(RewardSO data)
    {
        rewardData = data;
       if(rewardData.reward==RewardType.NoobWizard)
        {
            portrait.sprite=FindObjectOfType<UIManager>().wizardPortraits[Random.Range(0,(int)WizardModelVariant.WizardLady15+1)];
        }
        else       
        portrait.sprite = data.imageOfReward;
        classOfPortrait.text = data.rewardClass;
        nameOfPortrait.text = data.rewardRank;
    }


    public void PlayerChoseThisReward()
    {
        if (rewardData.reward == RewardType.NoobWizard)
        {
            WizardManager.modelVariantSetByRewardManager = FindObjectOfType<UIManager>().SetWizardPortraitVariantForWizardManagerFromReward(portrait.sprite);
        }
        FindObjectOfType<RewardManager>().CreateThisReward(rewardData);
    }


    public string GetDescription()
    {
        return rewardData.rewardClass + " "+rewardData.rewardRank;
    }

}
