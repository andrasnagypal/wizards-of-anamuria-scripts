using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RewardType:byte
{
    CrystalRoomPlan,
    StoneGardenPlan,
    LibraryPlan,
    TowerPlan,
    CauldronPlan,
    StoragePlan,
    StatuePlan,
    OrbRoomPlan,
    Arcane1,
    Arcane2,
    Arcane3,
    Arcane4,
    Arcane5,
    Arcane6,
    Destruction1,
    Destruction2,
    Destruction3,
    Destruction4,
    Destruction5,
    Destruction6,
    Protection1,
    Protection2,
    Protection3,
    Protection4,
    Protection5,
    Protection6,
    Myscticism1,
    Myscticism2,
    Myscticism3,
    Myscticism4,
    Myscticism5,
    Myscticism6,
    Conjuring1,
    Conjuring2,
    Conjuring3,
    Conjuring4,
    Conjuring5,
    Conjuring6,
    Alchemy1,
    Alchemy2,
    Alchemy3,
    Alchemy4,
    Alchemy5,
    Alchemy6,
    DarkMagic1,
    DarkMagic2,
    DarkMagic3,
    DarkMagic4,
    DarkMagic5,
    DarkMagic6,
    Creature1Lvl1Scroll,
    Creature2Lvl1Scroll,
    Creature3Lvl1Scroll,
    Creature4Lvl1Scroll,
    Creature5Lvl1Scroll,
    Creature6Lvl1Scroll,
    Creature7Lvl1Scroll,
    Creature8Lvl1Scroll,
    Creature9Lvl1Scroll,
    Creature10Lvl1Scroll,
    Creature11Lvl1Scroll,
    Creature12Lvl1Scroll,
    Smallstone1,
    Smallstone2,
    Smallstone3,
    Smallstone4,
    Smallstone5,
    Smallstone6,
    Smallstone7,
    NoobWizard,
    ApprenticeWizard,
    AdvanceWizard,
    CompetentWizard,
    ProWizard,
    VeteranWizard,
    LegendaryWizard
    
}

public enum RewardPackageType:byte
{
    LvlUp,
    AllWizardsDead
}

public class RewardManager : MonoBehaviour
{
    public List<RewardSO> rewardsToChoose = new List<RewardSO>();
    public List<RewardSO> currentChoices = new List<RewardSO>();
    public WizardManager wizardManager;
    UI_RewardsUI rewardView;
    Queue<RewardPackageType> rewardPackagesThePlayerHasToChooseFrom = new Queue<RewardPackageType>();


    public bool IsThereMoreRewardsToChooseFrom()
    {
        return rewardPackagesThePlayerHasToChooseFrom.Count > 0;
    }
    public void CloseRewardPanelByCloseButton()
    {
        FindObjectOfType<UIManager>().ClosePanel(LayoutType.ScoreReward);
       
    }
    public void AddRewardPackageToList(RewardPackageType package)
    {
        rewardPackagesThePlayerHasToChooseFrom.Enqueue(package);
        RewardButtonStringSetup();


    }
    public void RewardButtonStringSetup()
    {
        string msg ="x"+ rewardPackagesThePlayerHasToChooseFrom.Count.ToString() ;

        FindObjectOfType<UI_RewardButtonController>().SetUpRewardButton(msg);
    }
    public void StartGivingRewardsToPlayer()
    {
        if(rewardPackagesThePlayerHasToChooseFrom.Count==0)
        {
           
            TurnManager.isPaused = false;
            FindObjectOfType<UIManager>().ClosePanel(LayoutType.ScoreReward);
            FindObjectOfType<UI_RewardButtonController>().SwitchRewardButton();
            return;
        }
        if(UIManager.currentlyOpenPanel!=LayoutType.ScoreReward)
            FindObjectOfType<UIManager>().SwitchPanel(LayoutType.ScoreReward);

        RewardButtonStringSetup();

        if(currentChoices.Count==0)
        {
          
            MakeRewardsForPlayersToChose();
        }
       
        TurnManager.isPaused = true;
    }
    public void MakeRewardsForPlayersToChose()
    {
        currentChoices = new List<RewardSO>();
        for (int i = 0; i < 5; i++)
        {
            currentChoices.Add(rewardsToChoose[Random.Range(0, rewardsToChoose.Count)]);
        }
       
        rewardView.SetUpPortraits(currentChoices);
        
    }
    public void CreateThisReward(RewardSO data)
    {
       
        currentChoices = new List<RewardSO>();
        if(data.reward<RewardType.Arcane1)
        {
            rewardsToChoose.Remove(data);
            FindObjectOfType<BuildingManager>().MakeBuildingAvailableForThePlayer(data.reward);
            
        }
        if (data.reward >=RewardType.Arcane1 && data.reward < RewardType.Creature12Lvl1Scroll)
        {
            ScrollType scroll = (ScrollType)(data.reward- RewardType.Arcane1);            
            FindObjectOfType<ScrollbookManager>().PlayerChoseThisScroll(scroll);
        }
        if (data.reward >= RewardType.Smallstone1 && data.reward <= RewardType.Smallstone7)
        {
            Debug.Log("SmallstoneReward");
        }
        if (data.reward == RewardType.NoobWizard )
        {
            

            wizardManager.StartSpawning(SpawnWizardType.NoobWizard);
        }
        if (rewardPackagesThePlayerHasToChooseFrom.Count > 0)
        {
            rewardPackagesThePlayerHasToChooseFrom.Dequeue();
            StartGivingRewardsToPlayer();
        }
        else
        {
            FindObjectOfType<UIManager>().SwitchPanel(LayoutType.ScoreReward);
            FindObjectOfType<UI_RewardButtonController>().SwitchRewardButton();
            TurnManager.isPaused = false;
        }
    }

    public void SetRewardView(UI_RewardsUI view)
    {
        rewardView = view;
    }
}
