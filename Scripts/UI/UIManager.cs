using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LayoutType : byte
{
   
    CharacterSelection,
    ScoreMeter,
   ScoreReward,
   CharacterInfo,
   EnemyCharacterInfo,
   PlayerObjectives,
   BuildingSelection,
   ScrollSelection,
   WizardCouncil,
   BuildingInfo,
   TileInfo,
   RuinInfo,
   AltarInfo,
   PortalInfo,
   PortalReward,
   WizardQuests,
   BottomButtons,
   EndOfVideo,
   NotificationPanel,
   LoadingPanel,
   Inventory,
   ChooseAHouse,
   Menu,
   Closed,
   InfoPopUpForPlayer,
   CombatPanel
}
public class UIManager : MonoBehaviour
{
    public bool isEndOfAVideo = false;
    public List<Sprite> wizardPortraits = new List<Sprite>();
    [SerializeField] GameObject wizardPortrait;
   public static LayoutType currentlyOpenPanel=LayoutType.Closed;
    Dictionary<LayoutType, GameObject> LayoutsForUI = new Dictionary<LayoutType, GameObject>();

    UICharacterSelectionManager selectionManager;



    private void Start()
    {
        currentlyOpenPanel = LayoutType.Closed;
    }
    public void TurnOnStandardUI()
    {
        TurnManager.TurnTick += EndImage;
        TurnOffEveryThing();
        LayoutsForUI[LayoutType.BottomButtons].SetActive(true);
        LayoutsForUI[LayoutType.CharacterSelection].SetActive(true);
        LayoutsForUI[LayoutType.ScoreMeter].SetActive(true);
        LayoutsForUI[LayoutType.NotificationPanel].SetActive(true);
    }

    public void EndImage()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            isEndOfAVideo = true;
        if (isEndOfAVideo)
        {
            TurnManager.isPaused = true;
            TurnOffEveryThing();
            LayoutsForUI[LayoutType.EndOfVideo].SetActive(true);
        }
    }
    public void AddUILayoutToDictionary(LayoutType layout,GameObject go)
    {
       
            SetUIScriptsToManagers(layout);
            LayoutsForUI.Add(layout, go);
            LayoutsForUI[layout].SetActive(false);
        
    }

    public void TurnOffEveryThing()
    {
        foreach (var item in LayoutsForUI)
        {
            item.Value.SetActive(false);
        }
    }

    void SetUIScriptsToManagers(LayoutType layout)
    {
        if (LayoutType.BuildingSelection == layout)
        {
            BuildingManager.buildingPanelUI = FindObjectOfType<UI_SelectBuildingToBuild>();
        }
    }

    //public void ActivateReward(bool act)
    //{
    //    LayoutsForUI[LayoutType.ScoreReward].SetActive(act);
    //}

    public UI_WizardPortrait GetWizardPortrait(WizardModelVariant variant)
    {
        if (selectionManager == null)
        {
            selectionManager = FindObjectOfType<UICharacterSelectionManager>();
        }
        GameObject temp = Instantiate(wizardPortrait);
        temp.GetComponent<UI_WizardPortrait>().ChangePortrait(wizardPortraits[(int)variant]);
        selectionManager.AddPortraitToPanel(temp);
        return temp.GetComponent<UI_WizardPortrait>(); 
    }

    public LoadingSceneController TurnOnLoadingScreen()
    {
        LayoutsForUI[LayoutType.LoadingPanel].SetActive(true);
        return LayoutsForUI[LayoutType.LoadingPanel].GetComponent<LoadingSceneController>();
    }
    public void SwitchPanel(LayoutType panel)
    {
        if (currentlyOpenPanel == panel&& LayoutsForUI[currentlyOpenPanel].activeInHierarchy)
        {
            if (LayoutsForUI[panel].activeInHierarchy)
            {
                LayoutsForUI[panel].SetActive(false);
                currentlyOpenPanel = LayoutType.Closed;
            }
            else
            {
                if (panel != LayoutType.ScoreReward)
                {
                    LayoutsForUI[panel].SetActive(true);
                    if (panel == LayoutType.BuildingSelection)
                        FindObjectOfType<UI_SelectBuildingToBuild>().CheckDataForButtons();
                }
            }
        }
        else
        {

            //if (!TurnManager.isPaused)
            {
                if(LayoutType.Closed!=currentlyOpenPanel)
                LayoutsForUI[currentlyOpenPanel].SetActive(false);
                currentlyOpenPanel = panel;
                LayoutsForUI[panel].SetActive(true);
            }


        }
    }

   public int SetWizardPortraitVariantForWizardManagerFromReward(Sprite thePortrait)
    {
        int temp = -1;
        for (int i = 0; i < wizardPortraits.Count; i++)
        {
            if(thePortrait==wizardPortraits[i])
            {
                temp = i;
                break;
            }
        }
        return temp;
    }
    public void ClosePanel(LayoutType panelToClose)
    {
        if(currentlyOpenPanel==panelToClose)
        {
            LayoutsForUI[currentlyOpenPanel].SetActive(false);
            currentlyOpenPanel = LayoutType.Closed;
        }
        FindObjectOfType<UI_SourceMeterController>().SwitchTimePanel(true);
    }

    

}
