using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_SelectBuildingToBuild : MonoBehaviour
{
    public TextMeshProUGUI descriptionText, costText;
    public UI_BuildingButtonController[] buildingButtons;
    public BuildingInfoSO[] buildingInfos;
    


    private void OnEnable()
    {
        CheckDataForButtons();
    }
    public void GetInfoForThisBuilding(BuildingType building)
    {
        for (int i = 0; i < buildingInfos.Length; i++)
        {
            if (buildingInfos[i].building==building)
            {
                descriptionText.text = buildingInfos[i].description;
                //costText.text = costLvls[buildingInfos[i].cost].ToString();
                break;
            }
        }
    }


    public void CheckDataForButtons()
    {
        foreach (BuildingType item in BuildingManager.whatIsAvailableToBuild)
        {
            for (int i = 0; i < buildingInfos.Length; i++)
            {
                if (buildingInfos[i].building == item)
                {
                    ActivateBuildingButton(item, buildingInfos[i].artForButton);

                    break;
                        }
            }
          
        }
        
    }

    public void IncreaseCost(BuildingType building)
    {
        for (int i = 0; i < buildingInfos.Length; i++)
        {
            if (buildingInfos[i].building == building)
            {

                if(SourceScoreManager.IsScoreEnoughToBuy((int)SourceScoreManager.lvlBoundariesForSkill[buildingInfos[i].cost]))
               {
                    SourceScoreManager.DecreaseScore((int)SourceScoreManager.lvlBoundariesForSkill[buildingInfos[i].cost]);

                    buildingInfos[i].cost++;

                }
                else
                {
                    descriptionText.text = "Not enough score for purchase";
                }
                break;
            }
        }
    }

    public void ActivateBuildingButton(BuildingType building,Sprite image)
    {
        for (int i = 0; i < buildingButtons.Length; i++)
        {
            if(buildingButtons[i].buildingInfo==building)
            {
                buildingButtons[i].SetButtonAvailable(image);
                break;
            }
        }
    }
    public void ClosePanel()
    {
        FindObjectOfType<UIManager>().ClosePanel(LayoutType.BuildingSelection);
    }
}
