using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UI_WizardPortrait : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI name, actionname;
    [SerializeField] Image thePortrait; 
    GameObject wizard;
    
    

    public void AddReferenceWizard(GameObject wiz)
    {
        wizard = wiz;
    }
    public void ChangePortrait(Sprite portrait)
    {
        thePortrait.sprite = portrait;
    }

   

    public void Click(BaseEventData bed)
    {
        PointerEventData ped = (PointerEventData)bed;
        if(ped.pointerId==-1)
            FindObjectOfType<CameraController>().SetCameraToThisWizard(wizard);
        if (ped.pointerId == -2)
        {
            if(UIManager.currentlyOpenPanel!= LayoutType.CharacterInfo)
            FindObjectOfType<UIManager>().SwitchPanel(LayoutType.CharacterInfo);
            FindObjectOfType<CharacterInfoController>().SetCurrentUIFromThisData(wizard.GetComponent<WizardController>().dataForWizard);
        }
        
    }
}
