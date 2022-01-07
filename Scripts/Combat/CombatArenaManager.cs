using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatArenaManager : MonoBehaviour
{
    public List<CombatData> combatareas = new List<CombatData>();
    public BattleAlerterPool poolForAlerter;
    public DeathCirclePool poolForDeathCircle;

    List<FightController> possibleFights = new List<FightController>();

   public bool CheckForFightOnThatTile(int[] indexes)
    {
        bool result = false;
        foreach (FightController item in possibleFights)
        {
            if (item.dataForFight.battlePlace[0] == indexes[0] && item.dataForFight.battlePlace[1] == indexes[1])
            {
                result = true;
                break;
            }
        }
        return result;
    }


    public void AddParticipantToCombatArea(int[] indexes, GameObject character)
    {
        FightController fightPlace = GetFightPlaceFromList(indexes);
        if(fightPlace==null)
        {
            fightPlace = CreateFightPlace(indexes);
        }

        WizardController wizard = character.GetComponent<WizardController>();
        CreatureController creature = character.GetComponent<CreatureController>();
        if(creature!=null)
        {
            fightPlace.CheckAndAddCreatureToFight(creature);
        }
        if (wizard != null)
        {
            fightPlace.CheckAndAddWizardToFight(wizard);
        }
        fightPlace.CheckForAFight();
    }

    private FightController CreateFightPlace(int[] indexes)
    {
       
        GameObject battleAlerter = poolForAlerter.GetBattleAlerter();
        battleAlerter.transform.position = FindObjectOfType<GenerateMap>().GetTerrainForCharacter(indexes).gameObject.transform.position;
        FightController temp = battleAlerter.GetComponent<FightController>();
        temp.dataForFight.battlePlace = indexes;
        temp.battleAlerter = battleAlerter;
        temp.dataForFight.wizardsInCombat = new List<WizardController>();
        temp.dataForFight.creaturesInCombat = new List<CreatureController>();
        possibleFights.Add(temp);
        return temp;
    }

    public FightController GetFightPlaceFromList(int[] indexes)
    {
        FightController temp = null;
       
        foreach (FightController item in possibleFights)
        {
            if (item.dataForFight.battlePlace[0] == indexes[0] && item.dataForFight.battlePlace[1] == indexes[1])
            {
                temp = item;
                break;
            }
        }
        return temp;
    }
    //public void AddParticipantToCombatArea(int[] indexes, GameObject character)
    //{

    //    CombatData combatAreaThatExistAlready = null;
    //    foreach (CombatData item in combatareas)
    //    {
    //        if(item.battlePlace[0]==indexes[0]&& item.battlePlace[1] == indexes[1])
    //        {
    //            combatAreaThatExistAlready = item;
    //            break;
    //        }
    //    }
    //    if (combatAreaThatExistAlready != null)
    //    {
    //        WizardController wizard = character.GetComponent<WizardController>();
    //        CreatureController creature = character.GetComponent<CreatureController>();
    //        if (wizard != null&&!combatAreaThatExistAlready.wizardsInCombat.Contains(wizard))
    //        {
    //            bool isIsInArea = false;
    //            foreach (WizardController item in combatAreaThatExistAlready.wizardsInCombat)
    //            {
    //                if (item.dataForWizard.dataOfWizardAttributes.wizardId == wizard.dataForWizard.dataOfWizardAttributes.wizardId)
    //                {
    //                    isIsInArea = true;
    //                    break;
    //                }
    //            }
    //            if (!isIsInArea)
    //            {
    //                combatAreaThatExistAlready.wizardsInCombat.Add(wizard);
    //            }
    //        }
    //        if (creature != null&& !combatAreaThatExistAlready.creaturesInCombat.Contains(creature))
    //        {
    //            bool isIsInArea = false;
    //            foreach (CreatureController item in combatAreaThatExistAlready.creaturesInCombat)
    //            {
    //                if (item.dataForTheCreature.createId == creature.dataForTheCreature.createId)
    //                {
    //                    isIsInArea = true;
    //                    break;
    //                }
    //            }
    //            if (!isIsInArea)
    //            {
    //                combatAreaThatExistAlready.creaturesInCombat.Add(creature);
    //            }
    //        }
    //    }
    //    else
    //    {
    //        CombatData temp = new CombatData();
    //        temp.battlePlace = indexes;

    //        temp.wizardsInCombat = new List<WizardController>();
    //        temp.creaturesInCombat = new List<CreatureController>();

    //        combatareas.Add(temp);
    //        WizardController wizard = character.GetComponent<WizardController>();
    //        CreatureController creature = character.GetComponent<CreatureController>();
    //        if (wizard != null)
    //        {

    //            temp.wizardsInCombat.Add(wizard);

    //        }
    //        if (creature != null)
    //        {
    //            temp.creaturesInCombat.Add(creature);
    //            GameObject battleAlerter= poolForAlerter.GetBattleAlerter();

    //            //if (temp.battleAlerter == null)
    //            //{
    //            //    temp.battleAlerter = poolForAlerter.GetBattleAlerter();
    //            //    temp.battleAlerter.transform.position = FindObjectOfType<GenerateMap>().GetTerrainForCharacter(indexes).gameObject.transform.position;
    //            //    temp.battleAlerter.GetComponent<BattleAlerterController>().indexes = indexes;
    //            //    temp.battleAlerter.SetActive(false);
    //            //}
    //        }
    //    }

    //}
    //public void SearchForEnemyWithThisIndexes(int[] indexes)
    //{
    //    CombatData combatAreaThatExistAlready = null;

    //    foreach (CombatData item in combatareas)
    //    {
    //        if (item.battlePlace[0] == indexes[0] && item.battlePlace[1] == indexes[1])
    //        {
    //            combatAreaThatExistAlready = item;

    //            break;
    //        }
    //    }
    //    if (combatAreaThatExistAlready != null)
    //    { 
    //        CheckForEnemyToAttack(combatAreaThatExistAlready); 
    //        if(!combatAreaThatExistAlready.battleAlerter.activeInHierarchy&&(PlayerInteractionData.battleAlerterIndexesThePlayerClickedOn==null|| (PlayerInteractionData.battleAlerterIndexesThePlayerClickedOn[0]!= combatAreaThatExistAlready.battlePlace[0]&& PlayerInteractionData.battleAlerterIndexesThePlayerClickedOn[1] != combatAreaThatExistAlready.battlePlace[1])))
    //        {
    //            SwitchBattleAlerter(combatAreaThatExistAlready.battlePlace);
    //        }
    //    }

    //}

    //private void CloseUIAtTheOfCombat(CombatData combatAreaThatExistAlready)
    //{
    //    PlayerInteractionData.battleAlerterIndexesThePlayerClickedOn = null;
    //    if (combatAreaThatExistAlready.battleAlerter.activeInHierarchy)
    //    {
    //        SwitchBattleAlerter(combatAreaThatExistAlready.battlePlace);
    //    }
    //    if (UIManager.currentlyOpenPanel == LayoutType.CombatPanel)
    //    {
    //        FindObjectOfType<UIManager>().ClosePanel(LayoutType.CombatPanel);
    //    }
    //}

    private void CheckForEnemyToAttack(CombatData data)
    {
        if(data.creaturesInCombat.Count>0)
        {
            foreach (CreatureController item in data.creaturesInCombat)
            {
                if(data.wizardsInCombat.Count > 0&&item.dataForTheCreature.targetToAttack==null)
                {

                    int rnd = UnityEngine.Random.Range(0, data.wizardsInCombat.Count);
                    while(data.wizardsInCombat[rnd].dataForWizard.dataOfWizardAttributes.currentHealth<=0)
                    {
                        rnd = UnityEngine.Random.Range(0, data.wizardsInCombat.Count);
                    }
                    item.dataForTheCreature.targetToAttack = data.wizardsInCombat[rnd].gameObject;
                    Debug.Log(data.wizardsInCombat[rnd].gameObject);
                    Debug.Log("RND "+rnd);
                    item.AttackTarget(data.wizardsInCombat[rnd].gameObject);
                }
                if( data.wizardsInCombat.Count == 0)
                {
                    //item.FightOver();
                    //idle
                }
            }
        }
        if(data.wizardsInCombat.Count > 0)
        {
            foreach (WizardController item in data.wizardsInCombat)
            {
                bool isThereATarget = false;
                if ( data.creaturesInCombat.Count > 0&& item.dataForWizard.combatTarget==null)
                {
                   
                    for (int i = 0; i < data.creaturesInCombat.Count; i++)
                    {
                        if(data.creaturesInCombat[i].dataForTheCreature.currentHealth>0)
                        {
                            item.dataForWizard.combatTarget=data.creaturesInCombat[0].gameObject;
                            isThereATarget = true;
                            item.SetupAction(WizardAction.Fighting);
                            break;
                        }
                    }

                    
                }
                //if (data.creaturesInCombat.Count == 0)
                //{
                //    item.SetupAction(item.GetLastNonFightAction());
                //    //continue previous task
                //}
            }
        }
    }
    //public void RemoveWizardFromCombatArea(WizardController wizard)
    //{

    //    foreach (CombatData item in combatareas)
    //    {
    //        foreach (WizardController item2 in item.wizardsInCombat)
    //        {
    //            if(item2.dataForWizard.dataOfWizardAttributes.wizardId==wizard.dataForWizard.dataOfWizardAttributes.wizardId)
    //            {
    //                item.wizardsInCombat.Remove(wizard);
    //                FindObjectOfType<GenerateMap>().GetTerrainForCharacter(wizard.dataForWizard.tileWizardIsOn).RemoveWizardFromTile(wizard.dataForWizard.wizardName);
    //                if(wizard.dataForWizard.dataOfWizardAttributes.currentHealth<=0)
    //                {
    //                    GameObject deathCircle = poolForDeathCircle.GetDeathCircle();
    //                    deathCircle.transform.position = wizard.gameObject.transform.position;
    //                    deathCircle.GetComponent<DeathCircleController>().dataForWizard = wizard.dataForWizard;
    //                }
    //                //if (item.wizardsInCombat.Count == 0)
    //                //    CloseUIAtTheOfCombat(item);
    //                break;
    //            }
    //        }
            
    //    }
    //}
    //public void RemoveCreatureFromCombatArea(CreatureController creature)
    //{

    //    foreach (CombatData item in combatareas)
    //    {
    //        foreach (CreatureController item2 in item.creaturesInCombat)
    //        {
    //            if (item2.dataForTheCreature.createId == creature.dataForTheCreature.createId)
    //            {
    //                item.creaturesInCombat.Remove(item2);
    //                //if (item.creaturesInCombat.Count == 0)
    //                //    CloseUIAtTheOfCombat(item);
    //                break;
    //            }
    //        }

    //    }
    //}

    public CombatData GetCombatData(int[] tileIndex)
    {
        CombatData result = null;
        foreach (CombatData item in combatareas)
        {
            if (item.battlePlace[0] == tileIndex[0] && item.battlePlace[1] == tileIndex[1])
            {
                result = item;
                break;
            }
        }

        return result;
    }
    //public bool IsThereACreatureInThisTile(int[] indexes)
    //{
    //    bool result = false;

    //    foreach (CombatData item in combatareas)
    //    {
    //        if (item.battlePlace[0] == indexes[0] && item.battlePlace[1] == indexes[1])
    //        {
    //            if (item.creaturesInCombat.Count > 0 )
    //                result = true;
    //            break;
    //        }
    //    }
    //    return result;
    //}

    public void SwitchBattleAlerter(int[] indexes)
    {
        foreach (FightController item in possibleFights)
        {
            if (item.dataForFight.battlePlace[0] == indexes[0] && item.dataForFight.battlePlace[1] == indexes[1])
            {
                item.battleAlerter.SetActive(!item.battleAlerter.activeInHierarchy);
                break;
            }
        }
    }
}
