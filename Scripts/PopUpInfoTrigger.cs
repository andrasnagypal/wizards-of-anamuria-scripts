using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpInfoTrigger : MonoBehaviour
{
    
    public Sprite imageOfGO;
    public string nameOfGO, description;

    private void OnMouseDown()
    {
       
        ClosePopUpInfo();
        if (nameOfGO == "Treasure Chest")
        {
            FindObjectOfType<RewardManager>().AddRewardPackageToList(RewardPackageType.LvlUp);
            FindObjectOfType<UI_PopUpManager>().AddNewPopUp(PopUpType.Treasure, null);
            gameObject.transform.parent.transform.parent = null;
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
    private void OnMouseEnter()
    {
        if (UIManager.currentlyOpenPanel == LayoutType.Closed)
            ShowChestPopUpInfo();
    }

    private void OnMouseExit()
    {
        ClosePopUpInfo();
    }
    public void ShowChestPopUpInfo()
    {
        FindObjectOfType<UIManager>().SwitchPanel(LayoutType.InfoPopUpForPlayer);
        InfoPopUpData temp = new InfoPopUpData
        {
            character = imageOfGO,
            characterName = nameOfGO,
            abilitydescription = description

        };

        FindObjectOfType<InfoPopupController>().SetInfoPopUpUI(temp);
    }
    public void ClosePopUpInfo()
    {
        FindObjectOfType<UIManager>().ClosePanel(LayoutType.InfoPopUpForPlayer);
    }
}
