using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BuildingButtonController : MonoBehaviour
{
    public Button button;
    public Image imageOfButtonArt;
    public UI_SelectBuildingToBuild buildingUIManager;
    public BuildingType buildingInfo;
  
    public void SetButtonAvailable(Sprite image)
    {
        button.interactable = true;
        imageOfButtonArt.sprite = image;
    }

    public void ShowCostAndDescription()
    {
        if(button.interactable)
        buildingUIManager.GetInfoForThisBuilding(buildingInfo);
    }

    public void PlayerChoseThis()
    {
        if (button.interactable)
        {
            buildingUIManager.IncreaseCost(buildingInfo);
            PlayerTilesManager.BuildingUISelected();
            FindObjectOfType<UIManager>().SwitchPanel(LayoutType.BuildingSelection);
            SetBuildingToBuild();
        }
    }

    void SetBuildingToBuild()
    {
        switch (buildingInfo)
        {
            case BuildingType.CrystalRoom:
                {
                    SelectedBuilding.buildingToSpawn = PropType.CrystalRoom1;
                }
                break;
            case BuildingType.StoneGarden:
                {
                    SelectedBuilding.buildingToSpawn = PropType.StoneGarden1;
                }
                break;
            case BuildingType.Library:
                {
                    SelectedBuilding.buildingToSpawn = PropType.Library1;
                }
                break;
            case BuildingType.Tower:
                {
                    SelectedBuilding.buildingToSpawn = PropType.Tower1;
                }
                break;
            case BuildingType.Cauldron:
                {
                    SelectedBuilding.buildingToSpawn = PropType.Cauldron1;
                }
                break;
            case BuildingType.Storage:
                {
                    SelectedBuilding.buildingToSpawn = PropType.StorageRoom1;
                }
                break;
            case BuildingType.Statue:
                {
                    SelectedBuilding.buildingToSpawn = PropType.Statue1;
                }
                break;
            case BuildingType.OrbRoom:
                {
                    SelectedBuilding.buildingToSpawn = PropType.Orb1;
                }
                break;
        }

    }
}