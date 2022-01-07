using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_RewardsUI : MonoBehaviour
{
    public List<UI_RewardPortrait> portraitsControllers = new List<UI_RewardPortrait>();

    public TextMeshProUGUI descriptionText;
    private void Awake()
    {
        FindObjectOfType<RewardManager>().SetRewardView(this);
    }

    public void OpenDescription(int indexOfPortrait)
    {
        descriptionText.transform.parent.gameObject.SetActive(true);
        descriptionText.text = portraitsControllers[indexOfPortrait].GetDescription();
    }

    public void CloseDescription()
    {
        descriptionText.transform.parent.gameObject.SetActive(false);
       
    }
    public void SetUpPortraits(List<RewardSO> rewards)
    {
        for (int i = 0; i < rewards.Count; i++)
        {
            portraitsControllers[i].SetReward(rewards[i]);
        }
    }

    public void CloseTheRewardWindowWithoutThePlayerChoosing()
    {
        FindObjectOfType<RewardManager>().CloseRewardPanelByCloseButton();
    }

    private void OnEnable()
    {
        FindObjectOfType<UI_SourceMeterController>().SwitchTimePanel(false);
    }
    private void OnDisable()
    {
        CloseDescription();
    }
}
