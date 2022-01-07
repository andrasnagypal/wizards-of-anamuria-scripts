using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UI_RewardButtonController : MonoBehaviour
{
    public GameObject rewardButton;
    public Image manaFillImage;
    public TextMeshProUGUI rewardTextMultiplier;
    RewardManager rewardManager;

    private void Start()
    {
        rewardManager = FindObjectOfType<RewardManager>();
        rewardButton.SetActive(false);
        SourceScoreManager.uimanaFillController = this;
    }

    public void SwitchRewardButton()
    {
        rewardButton.SetActive(!rewardButton.activeInHierarchy);
    }

    public void SetManaFillUI(float value)
    {
        manaFillImage.fillAmount = value;
    }

    public void SetUpRewardButton(string message)
    {
        if (!rewardButton.activeInHierarchy)
            SwitchRewardButton();
        rewardTextMultiplier.text = message;
    }

    public void ShowRewards()
    {
        if(rewardManager.IsThereMoreRewardsToChooseFrom())
            rewardManager.StartGivingRewardsToPlayer();
        
    }
}
