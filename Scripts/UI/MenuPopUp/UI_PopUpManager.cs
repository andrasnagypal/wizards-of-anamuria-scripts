using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PopUpType:byte
{
    Combat,
    Stasis,
    Research,
    Treasure,

}

public class UI_PopUpManager : MonoBehaviour
{
    public GameObject popUpPrefab;


    public void AddNewPopUp(PopUpType type,GameObject theWizard)
    {
        PopUpData temp = new PopUpData();
        temp.popUptype = type;
        temp.theWizard = theWizard;
        GameObject popUp = Instantiate(popUpPrefab);
        popUp.GetComponent<PopUpController>().SetPopUpData(temp);
        FindObjectOfType<PopUpBarController>().AddPopUpToParent(popUp);
    }

}
