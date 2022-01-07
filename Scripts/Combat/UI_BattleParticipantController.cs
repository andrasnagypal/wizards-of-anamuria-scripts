using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_BattleParticipantController : MonoBehaviour
{
    public string characterId;
    public TextMeshProUGUI hp,percentageText;
    public Image characterPortrait, spellPortrait,hpScrollBar;
    public GameObject focusMeter,healButton,focusButton;
    

    public void SetEnemyParticipant()
    {
        healButton.SetActive(false);
        focusButton.SetActive(false);
    }

    public void ChangeCharacterPortrait(Sprite character)
    {
        characterPortrait.sprite = character;
    }
    public void ChangeSpellPortrait(Sprite spell)
    {
        spellPortrait.sprite = spell;
    }
    public void ChangeId(string id)
    {
        characterId = id;
    }
    public void ChangeHP(string hpamount)
    {
        hp.text = hpamount;
    }
    public void ChangeHPScrollbar(float amount)
    {
        hpScrollBar.fillAmount = amount;
    }
    public void ChangeFocusPercentage(string percentage)
    {
        percentageText.text = percentage;
    }
    public void IncreaseFocus(int focusNumber)
    {
        for (int i = 0; i < focusMeter.transform.childCount; i++)
        {
            if(i<focusNumber)
            {
                focusMeter.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                focusMeter.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

}
