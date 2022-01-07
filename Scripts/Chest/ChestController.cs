using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{

    public Sprite chestImage;


    private void OnMouseDown()
    {
        Debug.Log("Chest opened");
        ClosePopUpInfo();
        Destroy(gameObject);
    }
    private void OnMouseEnter()
        {
        if(UIManager.currentlyOpenPanel==LayoutType.Closed)
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
                character = chestImage,
                characterName = "Treasure chest",
               abilitydescription="Click on the chest to open"

            };

            FindObjectOfType<InfoPopupController>().SetInfoPopUpUI(temp);
        }
        public void ClosePopUpInfo()
        {
            FindObjectOfType<UIManager>().ClosePanel(LayoutType.InfoPopUpForPlayer);
        }
    
}
