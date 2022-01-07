using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public struct InfoPopUpData
{
    public Sprite character, ability;
    public string characterName, hpStatus, focusStatus, abilitydescription;
}
public class InfoPopupController : MonoBehaviour
{
    public Image character, ability;
    public TextMeshProUGUI characterName, hpStatus, focusStatus, abilitydescription;


    private void OnEnable()
    {
        character.gameObject.SetActive(false);
        ability.gameObject.SetActive(false);
        characterName.gameObject.SetActive(false);
        hpStatus.gameObject.SetActive(false);
        focusStatus.gameObject.SetActive(false);
        abilitydescription.gameObject.SetActive(false);
    }

    public void SetInfoPopUpUI(InfoPopUpData data)
    {
        if(data.character != null)
        {
            character.gameObject.SetActive(true);
            character.sprite = data.character;
        }
        if (data.ability != null)
        {
            ability.gameObject.SetActive(true);
            ability.sprite = data.ability;
        }
        if (data.characterName != null)
        {
            characterName.gameObject.SetActive(true);
            characterName.text = data.characterName;
        }
        if (data.hpStatus != null)
        {
            hpStatus.gameObject.SetActive(true);
            hpStatus.text = data.hpStatus;
        }
        if (data.focusStatus != null)
        {
            focusStatus.gameObject.SetActive(true);
            focusStatus.text = data.focusStatus;
        }
        if (data.abilitydescription != null)
        {
            abilitydescription.gameObject.SetActive(true);
            abilitydescription.text = data.abilitydescription;
        }
    }
}
