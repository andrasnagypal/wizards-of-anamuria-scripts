using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CreatureType:byte
{
    Druid,
    Knight,
    Elf,
    Wolf,
    Bandit,
    Cobra,
    Golem,
    AncientWarrior,
    Spider,
    Orc,
    Undead,
    DarkElf,
    Assassin,
    Viking,
    Dragon,
    King,
    OrcChief,
    VikingLeader,
    Witch,
    BarbarianChief,
    AncientQueen

}

public class CreatureController : MonoBehaviour
{
    public CreatureType TheCreature;
    public bool isMythical = false;
    public CreatureData dataForTheCreature;
    public CreatureMovement moveController;
    public CreatureCombatController combatController;
   
    public CreatureAnimationController animationController;
    public SkinnedMeshRenderer meshOfCreature;
    //private void Awake()
    //{
    //    dataForTheCreature = new CreatureData();
    //    dataForTheCreature.targetToAttack = null;
    //    dataForTheCreature.createId = gameObject.GetInstanceID().ToString();
    //    dataForTheCreature.lvlOfCreature = UnityEngine.Random.Range(0,40);
    //    int lvlBoundary = dataForTheCreature.lvlOfCreature / 10;       
    //    dataForTheCreature.dmgPerHit = CreatureStats.dmgForLvl[lvlBoundary];
    //    Debug.Log("Dmg: " + dataForTheCreature.dmgPerHit);
    //    dataForTheCreature.maxHealth = CreatureStats.healthForLvl[lvlBoundary];
    //    dataForTheCreature.currentHealth = CreatureStats.healthForLvl[lvlBoundary];
    //    Debug.Log("Health: " + dataForTheCreature.maxHealth);
    //    dataForTheCreature.manaForCreature = 10;
    //    dataForTheCreature.attackSpeed = CreatureStats.attackSpeed[lvlBoundary];
    //    animationController = GetComponent<CreatureAnimationController>();
    //    combatController= GetComponent<CreatureCombatController>();
    //    dataForTheCreature.typeOfCreature = TheCreature;
    //    if (GetComponent<CreatureMovement>() != null)
    //    {
    //        moveController = GetComponent<CreatureMovement>();
    //    }
            
    //}


    public void TakeDamage(int dmgAmount)
    {
      if(PlayerInteractionData.battleAlerterIndexesThePlayerClickedOn!=null&&UIManager.currentlyOpenPanel==LayoutType.CombatPanel)
        {
            FindObjectOfType<UI_CombatPanelController>().RefreshUI();
        }
        if (dataForTheCreature.currentHealth > 0)
        {
            
            dataForTheCreature.currentHealth -= dmgAmount;
           //GameObject popup= UI_DMG_Info_Popup_PoolSystem.GetPopupInfo();
            //popup.SetActive(true);
            //popup.transform.position = hpBarController.gameObject.transform.position;
            //popup.GetComponent<UI_DMG_Info_PopupController>().StartPopup(dmgAmount);
            
           
           
        }
        //if (dataForTheCreature.currentHealth <= 0)
        //    FightOver();
    }

    

    public void AttackTarget(GameObject target)
    {
      
        dataForTheCreature.targetToAttack = target;
        if (dataForTheCreature.currentHealth > 0 && target!=null&&dataForTheCreature.targetToAttack.GetComponent<WizardController>().dataForWizard.dataOfWizardAttributes.currentHealth>0)
        {
           
           
            moveController.StartMovingToTheTarget(target);
            
        }
    }
    //public void FightOver()
    //{
    //    if(dataForTheCreature.currentHealth<=0)
    //    {
           
            
    //        SetDying();
    //    }
    //    else
    //    {
    //       if(dataForTheCreature.targetToAttack.GetComponent<WizardController>().dataForWizard.dataOfWizardAttributes.currentHealth <= 0)
    //        {
    //            dataForTheCreature.targetToAttack = null;
    //            animationController.SetIdlingAnimationForCreature(TheCreature);
    //            //if (FindObjectOfType<CombatArenaManager>().isThisACombatArea(dataForTheCreature.theTileIndexesTheCreatureIsOn))
    //            //    FindObjectOfType<CombatArenaManager>().SearchForEnemyWithThisIndexes(dataForTheCreature.theTileIndexesTheCreatureIsOn);

               
                
    //        }
    //    }
        
    //}
    public void FightTheTarget()
    {
        if (combatController == null)
            combatController = GetComponent<CreatureCombatController>();
        combatController.StartAttacking();
    }

   

    
   
  

  

    public void SetDying()
    {
        transform.SetParent(null);
      //  FindObjectOfType<CombatArenaManager>().RemoveCreatureFromCombatArea(this);
        dataForTheCreature.currentHealth = 0;
        
       
        SourceScoreManager.RaiseScore(50);
        animationController.SetDyingAnimationForCreature(TheCreature);
        moveController.StopMoving();
        
        
    }


    private void OnMouseEnter()
    {
        if(UIManager.currentlyOpenPanel==LayoutType.Closed)
        ShowCreaturePopUpInfo();
    }

    private void OnMouseExit()
    {
        ClosePopUpInfo();
    }
    public void ShowCreaturePopUpInfo()
    {
        FindObjectOfType<UIManager>().SwitchPanel(LayoutType.InfoPopUpForPlayer);
        InfoPopUpData temp = new InfoPopUpData
        {
            character = FindObjectOfType<CreatureManager>().GetCreaturePortraitForUI(dataForTheCreature.typeOfCreature),
            characterName = dataForTheCreature.typeOfCreature.ToString(),
            hpStatus = dataForTheCreature.currentHealth+"/"+dataForTheCreature.maxHealth,
            focusStatus = "0"

        };

        FindObjectOfType<InfoPopupController>().SetInfoPopUpUI(temp);
    }
    public void ClosePopUpInfo()
    {
        FindObjectOfType<UIManager>().ClosePanel(LayoutType.InfoPopUpForPlayer);
    }
}