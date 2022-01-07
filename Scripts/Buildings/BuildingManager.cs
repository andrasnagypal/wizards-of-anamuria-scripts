using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingType:byte
{
   
    CrystalRoom,
    StoneGarden,
    Library,
    Tower,
    Cauldron,
    Storage,
    Statue,
    OrbRoom
}

public class BuildingManager : MonoBehaviour
{
    public static List<BuildingType> whatIsAvailableToBuild = new List<BuildingType>();
    public static UI_SelectBuildingToBuild buildingPanelUI;

    public void MakeBuildingAvailableForThePlayer(RewardType rewardToAddAvailableBuildingToBuild)
    {
       
            
        switch (rewardToAddAvailableBuildingToBuild)
        {
            case RewardType.CrystalRoomPlan:
                {
                    whatIsAvailableToBuild.Add(BuildingType.CrystalRoom);
                }
                break;
            case RewardType.StoneGardenPlan:
                {
                    whatIsAvailableToBuild.Add(BuildingType.StoneGarden);
                }
                break;
            case RewardType.LibraryPlan:
                {
                    whatIsAvailableToBuild.Add(BuildingType.Library);
                }
                break;
            case RewardType.TowerPlan:
                {
                    whatIsAvailableToBuild.Add(BuildingType.Tower);
                }
                break;
            case RewardType.CauldronPlan:
                {
                    whatIsAvailableToBuild.Add(BuildingType.Cauldron);
                }
                break;
            case RewardType.StoragePlan:
                {
                    whatIsAvailableToBuild.Add(BuildingType.Storage);
                }
                break;
            case RewardType.StatuePlan:
                {
                    whatIsAvailableToBuild.Add(BuildingType.Statue);
                }
                break;
            case RewardType.OrbRoomPlan:
                {
                    whatIsAvailableToBuild.Add(BuildingType.OrbRoom);
                }
                break;
            
            
        }
        if (buildingPanelUI.isActiveAndEnabled)
        {
            
                buildingPanelUI.CheckDataForButtons();
            
        }
        
    }
}