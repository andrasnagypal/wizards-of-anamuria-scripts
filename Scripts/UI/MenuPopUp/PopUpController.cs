using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpController : MonoBehaviour
{
    public TextMeshProUGUI textOfPopUp;

    PopUpData dataForPopUp;
    


    public void GoToWizard()
    {
        FindObjectOfType<CameraController>().SetCameraToThisWizard(dataForPopUp.theWizard);
    }

    public void SetPopUpData(PopUpData theData)
    {
        dataForPopUp = theData;
        SetTextForPopUp();
    }

    public void CloseNotification()
    {
        Destroy(gameObject);
    }

    void SetTextForPopUp()
    {
        switch (dataForPopUp.popUptype)
        {
            case PopUpType.Combat:
                {                    
                    dataForPopUp.theMessage = dataForPopUp.theWizard.name + " is in combat!";                    
                    textOfPopUp.text = dataForPopUp.theMessage.Replace("\r", "").Replace("\n", "");
                }
                break;
            case PopUpType.Stasis:
                {
                    dataForPopUp.theMessage = dataForPopUp.theWizard.name + " has died!";
                    textOfPopUp.text = dataForPopUp.theMessage.Replace("\r", "").Replace("\n", "");
                }
                break;
            case PopUpType.Research:
                break;
            case PopUpType.Treasure:
                {
                    textOfPopUp.text = "You opened the treasure chest and it contained a set of reward you can choose from clicking on the bag!";
                    
                }
                break;
        }

    }
}