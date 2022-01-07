using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnWizardType:byte
{
    AtStart,   
    NoobWizard,
    FamiliarWizard,
    ApprenticeWizard,
    CompetentWizard,
    ProWizard,
    VeteranWizard,
    LegendaryWizard,

}
public class WizardManager : MonoBehaviour
{
    public static int modelVariantSetByRewardManager = -1;
    public WizardDataChanceSO startWizardDataChance;
    [SerializeField] int howManyToSpawnAtStart;
    [SerializeField] WizardObjectPool objectPoolForWizards;
    [SerializeField] GenerateMap theMap;
    [SerializeField] UIManager uiManager;
    [SerializeField] TextAsset textOfNamesForWizards;
    WizardPlacementController placeToSpawnWizards;
    List<GameObject> wizardsInGame = new List<GameObject>();
   
    string[] namesForWizardsArray ;
    public List<string> namesForWizardsList = new List<string>();
    public static TerrainTypeContainer sourceCenter;

    
    private void Awake()
    {
        MakeNamesList();
    }

    public void StartSpawning(SpawnWizardType typeOfWizard)
    {
        switch (typeOfWizard)
        {
            case SpawnWizardType.AtStart:
                {
                   StartCoroutine( SpawnWizardsAtSpawn());
                }
                break;
            
            case SpawnWizardType.NoobWizard:
                {
                    SpawnOneSkillWizard();
                }
                break;
            case SpawnWizardType.FamiliarWizard:
                break;
            case SpawnWizardType.ApprenticeWizard:
                break;
            case SpawnWizardType.CompetentWizard:
                break;
            case SpawnWizardType.ProWizard:
                break;
            case SpawnWizardType.VeteranWizard:
                break;
            case SpawnWizardType.LegendaryWizard:
                break;
        }


        
    }

    private void SpawnOneSkillWizard()
    {
       GameObject  temp = objectPoolForWizards.GetWizard();
        placeToSpawnWizards.PutDownWizard(temp);
        temp.SetActive(true);
        wizardsInGame.Add(temp);
        WizardSetupData newData = new WizardSetupData();
        newData.chancesForAction = new WizardActionChances(startWizardDataChance);
        newData.hiddenChancesForActionModifiers = new WizardActionChances();
        newData.currentAction = WizardAction.Wandering;
        newData.howLongActionWillTake = 10;
        newData.dataOfWizardAttributes = new WizardAttributesData();
        newData.dataOfWizardAttributes.wizardId = temp.GetInstanceID().ToString();
        newData.scrollsTheWizardKnow = new List<ScrollKnowledge>();
        newData.barInfoLvlsForUI = new WizardCharacterInfoLvls();
       
        int rnIndex = UnityEngine.Random.Range(0, namesForWizardsList.Count);
        newData.wizardName = namesForWizardsList[rnIndex];
        newData.combatTarget = null;
        newData.combatData = new WizardCombatData();
        newData.combatData.meeleeDMG = 10;
        newData.combatData.meeleeSpeed = 1;
        newData.currentTaskInfoForTheWizard = new TaskInfoForTheWizard
        {
            theGO=null,
            tileIndexForTheGO=null,
            typeOfGO=WizardAction.InTransitToTask
        };
        namesForWizardsList.RemoveAt(rnIndex);
       
        int[] startIndexes = theMap.GetStartIndexes();
        WizardController controller = temp.GetComponent<WizardController>();
        if(modelVariantSetByRewardManager<0)
        controller.portrait = uiManager.GetWizardPortrait(controller.modelForTheWizard);
        else
        {
            controller.modelForTheWizard = (WizardModelVariant)modelVariantSetByRewardManager;
            controller.portrait = uiManager.GetWizardPortrait(controller.modelForTheWizard);
            modelVariantSetByRewardManager = -1;
        }
        newData.wizardPortraitVariant = (int)controller.modelForTheWizard;

        
       
        controller.portrait.AddReferenceWizard(temp);

        
        newData.dataForMovement = new WizardMovementData()
        {
            currentPlace = new int[] { sourceCenter.tileIndexes[0], sourceCenter.tileIndexes[1] },
            targetPlace = null,
            pathToObjective = new List<int[]>() { sourceCenter.tileIndexes },
            currentNodeIndex=0,
            directionToMoveOn = null
        };

        
        temp.name = newData.wizardName;
        temp.transform.SetParent(transform);

        controller.SetupTheWizard(newData);
    }

    public void SetPlaceToSpawnWizards(WizardPlacementController controller)
    {
        placeToSpawnWizards = controller;
    }

    void MakeNamesList()
    {
        namesForWizardsArray= textOfNamesForWizards.text.Split('\n');
        namesForWizardsList = new List<string>(namesForWizardsArray);
    }
    IEnumerator SpawnWizardsAtSpawn()
    {
        for (int i = 0; i < howManyToSpawnAtStart; i++)
        {
            SpawnOneSkillWizard();
            yield return new WaitForSeconds(.1f);
            


        }
    }

}
