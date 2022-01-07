using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BottompanelController : MonoBehaviour
{
    UIManager uiManager;

    private void Awake()
    {
        if (uiManager == null)
            uiManager = FindObjectOfType<UIManager>();
    }
    public void MainMenu()
    {
        uiManager.SwitchPanel(LayoutType.Menu);
    }
    public void Scrollbook()
    {
        uiManager.SwitchPanel(LayoutType.ScrollSelection);
    }
    public void Quests()
    {
        uiManager.SwitchPanel(LayoutType.PlayerObjectives);
    }
    public void Council()
    {
        uiManager.SwitchPanel(LayoutType.WizardCouncil);
    }
    public void Inventory()
    {
        uiManager.SwitchPanel(LayoutType.Inventory);
    }
    public void Buildings()
    {
        uiManager.SwitchPanel(LayoutType.BuildingSelection);
        FindObjectOfType<UI_SourceMeterController>().SwitchTimePanel(false);
    }
}
