using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMovementController : MonoBehaviour
{
    [SerializeField] WizardController mainController;
    bool isOnTargetTile=false;

    public async void StartMoving()
    {
        if(mainController.dataForWizard.dataForMovement.currentNodeIndex >= mainController.dataForWizard.dataForMovement.pathToObjective.Count)
        {
            //next destination
            int rndX = UnityEngine.Random.Range(0, GenerateMap.mapSizeX);
            int rndY = UnityEngine.Random.Range(0, GenerateMap.mapSizeY);
            AStarManager temp = FindObjectOfType<AStarManager>();
            while (temp.IsDestinationAMountain(MapType.MainMap,new int[] { rndX,rndY}))
            {
                 rndX = UnityEngine.Random.Range(0, GenerateMap.mapSizeX);
                 rndY = UnityEngine.Random.Range(0, GenerateMap.mapSizeY);
            }
            int[] destination = new int[] { rndX, rndY };
            mainController.dataForWizard.dataForMovement.pathToObjective = await temp.RecursevlyGetPathIndexesFromAStar(MapType.MainMap, mainController.dataForWizard.dataForMovement.currentPlace, destination);
            mainController.dataForWizard.dataForMovement.currentNodeIndex = 0;
            MoveToNextNode();

        }
        if (mainController.dataForWizard.dataForMovement.currentNodeIndex < mainController.dataForWizard.dataForMovement.pathToObjective.Count)
            //SetupNextNodeToMove();
            MoveToNextNode();
        TurnManager.TurnTick += MoveTowardsTarget;

    }

    public void StartWandering()
    {

        StopMoving();
        if(mainController.dataForWizard.dataForMovement.currentPlace != mainController.dataForWizard.dataForMovement.targetPlace)
        NextWanderingPoint();
        TurnManager.TurnTick += MoveTowardsTarget;


    }
    public void NextWanderingPoint()
    {
        mainController.dataForWizard.dataForMovement.directionToMoveOn = mainController.theMap.GetListForAvailableDirectionsToMove(mainController.dataForWizard.dataForMovement.currentPlace);
        mainController.dataForWizard.dataForMovement.targetPlace = mainController.theMap.GetTileInThatDirection(mainController.dataForWizard.dataForMovement.currentPlace, mainController.dataForWizard.dataForMovement.directionToMoveOn[UnityEngine.Random.Range(0, mainController.dataForWizard.dataForMovement.directionToMoveOn.Count)]);
        mainController.targetToInteractWith = mainController.theMap.GetTerrainForCharacter(mainController.dataForWizard.dataForMovement.targetPlace).gameObject.transform;
        mainController.dataForWizard.dataForMovement.currentPlace = mainController.dataForWizard.dataForMovement.targetPlace;
        transform.LookAt(mainController.targetToInteractWith.position + new Vector3(0, .015f, 0));
        isOnTargetTile = false;
    }
    private void MoveToNextNode()
    {
        if(mainController.dataForWizard.dataForMovement.currentNodeIndex>= mainController.dataForWizard.dataForMovement.pathToObjective.Count)
        {
            return;
        }

        mainController.dataForWizard.dataForMovement.targetPlace = mainController.dataForWizard.dataForMovement.pathToObjective[mainController.dataForWizard.dataForMovement.currentNodeIndex++];
        mainController.targetToInteractWith = mainController.theMap.GetTerrainForCharacter(mainController.dataForWizard.dataForMovement.targetPlace).gameObject.transform;
        transform.LookAt(mainController.targetToInteractWith.position + new Vector3(0, .015f, 0));
        isOnTargetTile = false;
    }

    void MoveTowardsTarget()
    {
        if(mainController.dataForWizard.currentAction==WizardAction.Fighting)
        {
            StopMoving();
            return;
        }
        if (mainController.actionsTakenByCharacter[mainController.actionsTakenByCharacter.Count - 1] == WizardAction.Wandering)
        {
            transform.position = Vector3.MoveTowards(transform.position, mainController.targetToInteractWith.position, .01f);
            if (!isOnTargetTile && Vector3.Distance(transform.position, mainController.targetToInteractWith.position) < .51f)
            {


                mainController.targetToInteractWith.gameObject.GetComponent<TerrainTypeContainer>().TerritoryDiscovered();
              bool isFightNecessary=  mainController.targetToInteractWith.gameObject.GetComponent<TerrainTypeContainer>().IsThereAProblem(gameObject);
                mainController.dataForWizard.tileWizardIsOn = mainController.targetToInteractWith.gameObject.GetComponent<TerrainTypeContainer>().tileIndexes;
                if(isFightNecessary)
                {
                    StopMoving();
                    EnterCombat();
                    //remove movementtick

                    return;
                }
                //if (FindObjectOfType<CombatArenaManager>().IsThereACreatureInThisTile(mainController.dataForWizard.tileWizardIsOn))
                //{
                //    EnterCombat();
                 
                //    return;
                //}
                isOnTargetTile = true;
            }
            if (Vector3.Distance(transform.position, mainController.targetToInteractWith.position) < .1f)
            {
                mainController.dataForWizard.dataForMovement.currentPlace = mainController.dataForWizard.dataForMovement.targetPlace;

                if (mainController.dataForWizard.howLongActionWillTake <= 0)
                {
                    Debug.Log("Make decision");
                    TurnManager.TurnTick -= MoveTowardsTarget;
                    WizardAction nextAction = FindObjectOfType<DecisionManager>().GetActionFromChances(mainController.dataForWizard.chancesForAction);
                    mainController.SetupAction(nextAction);

                }
                else
                {
                    if (mainController.dataForWizard.currentAction != WizardAction.Wandering)
                        MoveToNextNode();
                    else
                    {

                        mainController.dataForWizard.dataForMovement.currentPlace = mainController.dataForWizard.dataForMovement.targetPlace;
                        NextWanderingPoint();
                    }
                }

            }
        }
        if (mainController.actionsTakenByCharacter[mainController.actionsTakenByCharacter.Count - 1] == WizardAction.InTransitToTask)
        {
            transform.position = Vector3.MoveTowards(transform.position, mainController.targetToInteractWith.position, .01f);
            if (!isOnTargetTile && Vector3.Distance(transform.position, mainController.targetToInteractWith.position) < .51f)
            {


                mainController.targetToInteractWith.gameObject.GetComponent<TerrainTypeContainer>().TerritoryDiscovered();
                mainController.dataForWizard.tileWizardIsOn = mainController.targetToInteractWith.gameObject.GetComponent<TerrainTypeContainer>().tileIndexes;
                if(FindObjectOfType<CombatArenaManager>().CheckForFightOnThatTile(mainController.dataForWizard.tileWizardIsOn))
                    {
                    StopMoving();
                    EnterCombat();
                    //remove movementtick

                    return;
                }
                isOnTargetTile = true;
            }
            if (Vector3.Distance(transform.position, mainController.targetToInteractWith.position) < .1f)
            {
                mainController.dataForWizard.dataForMovement.currentPlace = mainController.dataForWizard.dataForMovement.targetPlace;
                if (mainController.dataForWizard.dataForMovement.pathToObjective.Count > mainController.dataForWizard.dataForMovement.currentNodeIndex)
                    SetUpNextNodeToJourneyToForATask();
                else
                    StopMoving();

               

            }
        }
    }

    public void StopMoving()
    {
        TurnManager.TurnTick -= MoveTowardsTarget;
    }

    
    public async void StartJourneyingToTheTaskPlace()
    {
        mainController.dataForWizard.dataForMovement = new WizardMovementData
        {
            currentNodeIndex = 0,
            currentPlace = mainController.dataForWizard.tileWizardIsOn,
            targetPlace = mainController.dataForWizard.currentTaskInfoForTheWizard.tileIndexForTheGO,
            pathToObjective = await FindObjectOfType<AStarManager>().RecursevlyGetPathIndexesFromAStar(MapType.MainMap, mainController.dataForWizard.tileWizardIsOn, mainController.dataForWizard.currentTaskInfoForTheWizard.tileIndexForTheGO),
            directionToMoveOn=null
        };
        Debug.Log("Astar distance:" + mainController.dataForWizard.dataForMovement.pathToObjective.Count);
        SetUpNextNodeToJourneyToForATask();
        TurnManager.TurnTick += MoveTowardsTarget;

    }
    public void EnterCombat()
    {
        FindObjectOfType<CombatArenaManager>().AddParticipantToCombatArea(mainController.dataForWizard.tileWizardIsOn, gameObject);
        //FindObjectOfType<CombatArenaManager>().SearchForEnemyWithThisIndexes(mainController.dataForWizard.tileWizardIsOn);
    }
    public void SetUpNextNodeToJourneyToForATask()
    {
        mainController.dataForWizard.dataForMovement.targetPlace = mainController.dataForWizard.dataForMovement.pathToObjective[mainController.dataForWizard.dataForMovement.currentNodeIndex++];
        mainController.targetToInteractWith = mainController.theMap.GetTerrainForCharacter(mainController.dataForWizard.dataForMovement.targetPlace).gameObject.transform;
        transform.LookAt(mainController.targetToInteractWith.position + new Vector3(0, .015f, 0));
        isOnTargetTile = false;
    }

}
