using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CharacterInfoController : MonoBehaviour
{
    public TextMeshProUGUI nameLabel,currentActionLabel;
    public Image portrait;
    public List<BarInfoController> barInfos = new List<BarInfoController>();
   
    WizardSetupData dataOfWizard;

    public void SetCurrentUIFromThisData(WizardSetupData data)
    {
        
        dataOfWizard = data;
        portrait.sprite = FindObjectOfType<UIManager>().wizardPortraits[data.wizardPortraitVariant];
        RefreshUI();
        TurnManager.CharacterInfoUpdater += RefreshUI;
    }

    void RefreshUI()
    {
        string temp = dataOfWizard.wizardName.Replace("\r", "").Replace("\n", "");
        
        nameLabel.text = temp ;
        currentActionLabel.text = "";
        temp =dataOfWizard.currentAction.ToString()+" "+ StringManager.stringsListForTheGame[(int)StringTypes.For].ToString() + " " + dataOfWizard.howLongActionWillTake.ToString() + " " + StringManager.stringsListForTheGame[(int)StringTypes.Turns].ToString();
        string[] removeeof = temp.Split('\r');
        for (int i = 0; i < removeeof.Length; i++)
        {
            currentActionLabel.text += removeeof[i];

        }
       
        RefreshBars();
    }

    void RefreshBars()
    {
       
        foreach (BarInfoController item in barInfos)
        {
            switch (item.typeOfBar)
            {
                case BarInfoType.Wandering:
                    {
                        item.description.text = StringManager.stringsListForTheGame[(int)StringTypes.Wandering];
                        item.buttonInfo.text = SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Wandering].ToString();
                        item.info.text = dataOfWizard.barInfoLvlsForUI.Wandering.ToString() + " " + StringManager.stringsListForTheGame[(int)StringTypes.Lvl]; 
                        
                    }
                    break;
                case BarInfoType.Questing:
                    {
                        item.description.text = StringManager.stringsListForTheGame[(int)StringTypes.Questing];
                        item.buttonInfo.text = SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Questing].ToString();
                        item.info.text = dataOfWizard.barInfoLvlsForUI.Questing.ToString() + " " + StringManager.stringsListForTheGame[(int)StringTypes.Lvl];

                    }
                    break;
                case BarInfoType.GatherMushrooms:
                    {
                        item.description.text = StringManager.stringsListForTheGame[(int)StringTypes.Gathering];
                        item.buttonInfo.text = SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Gathering].ToString();
                        item.info.text = dataOfWizard.barInfoLvlsForUI.Gathering.ToString() + " " + StringManager.stringsListForTheGame[(int)StringTypes.Lvl];

                    }
                    break;
                case BarInfoType.Examining:
                    {
                        item.description.text = StringManager.stringsListForTheGame[(int)StringTypes.Examining];
                        item.buttonInfo.text = SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Examining].ToString();
                        item.info.text = dataOfWizard.barInfoLvlsForUI.Examining.ToString() + " " + StringManager.stringsListForTheGame[(int)StringTypes.Lvl];

                    }
                    break;
                case BarInfoType.Visiting:
                    {
                        item.description.text = StringManager.stringsListForTheGame[(int)StringTypes.Visiting];
                        item.buttonInfo.text = SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Visiting].ToString();
                        item.info.text = dataOfWizard.barInfoLvlsForUI.Visiting.ToString() + " " + StringManager.stringsListForTheGame[(int)StringTypes.Lvl];

                    }
                    break;
                case BarInfoType.Meditating:
                    {
                        item.description.text = StringManager.stringsListForTheGame[(int)StringTypes.Meditating];
                        item.buttonInfo.text = SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Meditating].ToString();
                        item.info.text = dataOfWizard.barInfoLvlsForUI.Meditating.ToString() + " " + StringManager.stringsListForTheGame[(int)StringTypes.Lvl];

                    }
                    break;
                case BarInfoType.Experimenting:
                    {
                        item.description.text = StringManager.stringsListForTheGame[(int)StringTypes.Experimenting];
                        item.buttonInfo.text = SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Experimenting].ToString();
                        item.info.text = dataOfWizard.barInfoLvlsForUI.Experimenting.ToString() + " " + StringManager.stringsListForTheGame[(int)StringTypes.Lvl];

                    }
                    break;
                case BarInfoType.Gardening:
                    {
                        item.description.text = StringManager.stringsListForTheGame[(int)StringTypes.Gardening];
                        item.buttonInfo.text = SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Gardening].ToString();
                        item.info.text = dataOfWizard.barInfoLvlsForUI.Gardening.ToString() + " " + StringManager.stringsListForTheGame[(int)StringTypes.Lvl];

                    }
                    break;
                case BarInfoType.Research:
                    {
                        item.description.text = StringManager.stringsListForTheGame[(int)StringTypes.Research];
                        item.buttonInfo.text = SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Research].ToString();
                        item.info.text = dataOfWizard.barInfoLvlsForUI.Research.ToString() + " " + StringManager.stringsListForTheGame[(int)StringTypes.Lvl];

                    }
                    break;
                case BarInfoType.Invoking:
                    {
                        item.description.text = StringManager.stringsListForTheGame[(int)StringTypes.Invoking];
                        item.buttonInfo.text = SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Invoking].ToString();
                        item.info.text = dataOfWizard.barInfoLvlsForUI.Invoking.ToString() + " " + StringManager.stringsListForTheGame[(int)StringTypes.Lvl];

                    }
                    break;
                case BarInfoType.Arcane:
                    {
                        item.description.text = StringManager.stringsListForTheGame[(int)StringTypes.Arcane];
                        item.buttonInfo.text = SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Arcane].ToString();
                        item.info.text = dataOfWizard.barInfoLvlsForUI.Arcane.ToString() + " " + StringManager.stringsListForTheGame[(int)StringTypes.Lvl];

                    }
                    break;
                case BarInfoType.Destruction:
                    {
                        item.description.text = StringManager.stringsListForTheGame[(int)StringTypes.Destruction];
                        item.buttonInfo.text = SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Destruction].ToString();
                        item.info.text = dataOfWizard.barInfoLvlsForUI.Destruction.ToString() + " " + StringManager.stringsListForTheGame[(int)StringTypes.Lvl];

                    }
                    break;
                case BarInfoType.Protection:
                    {
                        item.description.text = StringManager.stringsListForTheGame[(int)StringTypes.Protection];
                        item.buttonInfo.text = SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Protection].ToString();
                        item.info.text = dataOfWizard.barInfoLvlsForUI.Protection.ToString() + " " + StringManager.stringsListForTheGame[(int)StringTypes.Lvl];

                    }
                    break;
                case BarInfoType.Mysticism:
                    {
                        item.description.text = StringManager.stringsListForTheGame[(int)StringTypes.Mysticism];
                        item.buttonInfo.text = SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Mysticism].ToString();
                        item.info.text = dataOfWizard.barInfoLvlsForUI.Mysticism.ToString() + " " + StringManager.stringsListForTheGame[(int)StringTypes.Lvl];

                    }
                    break;
                case BarInfoType.Conjuring:
                    {
                        item.description.text = StringManager.stringsListForTheGame[(int)StringTypes.Conjuring];
                        item.buttonInfo.text = SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Conjuring].ToString();
                        item.info.text = dataOfWizard.barInfoLvlsForUI.Conjuring.ToString() + " " + StringManager.stringsListForTheGame[(int)StringTypes.Lvl];

                    }
                    break;
                case BarInfoType.Alchemy:
                    {
                        item.description.text = StringManager.stringsListForTheGame[(int)StringTypes.Alchemy];
                        item.buttonInfo.text = SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Alchemy].ToString();
                        item.info.text = dataOfWizard.barInfoLvlsForUI.Alchemy.ToString() + " " + StringManager.stringsListForTheGame[(int)StringTypes.Lvl];

                    }
                    break;
                case BarInfoType.DarkMagic:
                    {
                        item.description.text = StringManager.stringsListForTheGame[(int)StringTypes.DarkMagic];
                        item.buttonInfo.text = SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.DarkMagic].ToString();
                        item.info.text = dataOfWizard.barInfoLvlsForUI.DarkMagic.ToString() + " " + StringManager.stringsListForTheGame[(int)StringTypes.Lvl];

                    }
                    break;
                case BarInfoType.HP:
                    {
                        item.description.text = StringManager.stringsListForTheGame[(int)StringTypes.HealthPoints];
                        item.buttonInfo.text = SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.HP].ToString();
                        item.info.text = dataOfWizard.barInfoLvlsForUI.HP.ToString()+ " " + StringManager.stringsListForTheGame[(int)StringTypes.Lvl];

                    }
                    break;
                case BarInfoType.Concentration:
                    {
                        item.description.text = StringManager.stringsListForTheGame[(int)StringTypes.Concentration];
                        item.buttonInfo.text = SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Concetration].ToString();
                        item.info.text = dataOfWizard.barInfoLvlsForUI.Concetration.ToString()+ " " + StringManager.stringsListForTheGame[(int)StringTypes.Lvl];

                    }
                    break;
                case BarInfoType.Intellect:
                    {
                        item.description.text = StringManager.stringsListForTheGame[(int)StringTypes.Intellect];
                        item.buttonInfo.text = SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Intellect].ToString();
                        item.info.text = dataOfWizard.dataOfWizardAttributes.intellect.ToString() + " " + StringManager.stringsListForTheGame[(int)StringTypes.Lvl];

                    }
                    break;
                case BarInfoType.Knowledge:
                    {
                        item.description.text = StringManager.stringsListForTheGame[(int)StringTypes.Knowledge];
                        item.buttonInfo.text = SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Knowledge].ToString();
                        item.info.text = dataOfWizard.dataOfWizardAttributes.knowledge.ToString()+ " " + StringManager.stringsListForTheGame[(int)StringTypes.Lvl];

                    }
                    break;
                case BarInfoType.Energy:
                    {
                        item.description.text = StringManager.stringsListForTheGame[(int)StringTypes.Energy];
                        item.buttonInfo.text = SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Energy].ToString();
                        item.info.text = dataOfWizard.dataOfWizardAttributes.spellEnergy.ToString()+ " " + StringManager.stringsListForTheGame[(int)StringTypes.Lvl];

                    }
                    break;
            }
        }
    }

    public void PlayerChoseThis(BarInfoType bar)
    {
        switch (bar)
        {
            case BarInfoType.Wandering:
                {
                    if (SourceScoreManager.IsScoreEnoughToBuy((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Wandering]))
                    {
                        SourceScoreManager.DecreaseScore((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Wandering]);
                        dataOfWizard.barInfoLvlsForUI.Wandering++;
                        RefreshUI();
                    }
                }
                break;
            case BarInfoType.Questing:
                {
                    if (SourceScoreManager.IsScoreEnoughToBuy((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Questing]))
                    {
                        SourceScoreManager.DecreaseScore((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Questing]);
                        dataOfWizard.barInfoLvlsForUI.Questing++;
                        RefreshUI();
                    }
                }
                break;
            case BarInfoType.GatherMushrooms:
                {
                    if (SourceScoreManager.IsScoreEnoughToBuy((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Gathering]))
                    {
                        SourceScoreManager.DecreaseScore((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Gathering]);
                        dataOfWizard.barInfoLvlsForUI.Gathering++;
                        RefreshUI();
                    }
                }
                break;
            case BarInfoType.Examining:
                {
                    if (SourceScoreManager.IsScoreEnoughToBuy((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Examining]))
                    {
                        SourceScoreManager.DecreaseScore((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Examining]);
                        dataOfWizard.barInfoLvlsForUI.Examining++;
                        RefreshUI();
                    }
                }
                break;
            case BarInfoType.Visiting:
                {
                    if (SourceScoreManager.IsScoreEnoughToBuy((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Visiting]))
                    {
                        SourceScoreManager.DecreaseScore((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Visiting]);
                        dataOfWizard.barInfoLvlsForUI.Visiting++;
                        RefreshUI();
                    }
                }
                break;
            case BarInfoType.Meditating:
                {
                    if (SourceScoreManager.IsScoreEnoughToBuy((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Meditating]))
                    {
                        SourceScoreManager.DecreaseScore((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Meditating]);
                        dataOfWizard.barInfoLvlsForUI.Meditating++;
                        RefreshUI();
                    }
                }
                break;
            case BarInfoType.Experimenting:
                {
                    if (SourceScoreManager.IsScoreEnoughToBuy((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Experimenting]))
                    {
                        SourceScoreManager.DecreaseScore((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Experimenting]);
                        dataOfWizard.barInfoLvlsForUI.Experimenting++;
                        RefreshUI();
                    }
                }
                break;
            case BarInfoType.Gardening:
                {
                    if (SourceScoreManager.IsScoreEnoughToBuy((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Gardening]))
                    {
                        SourceScoreManager.DecreaseScore((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Gardening]);
                        dataOfWizard.barInfoLvlsForUI.Gardening++;
                        RefreshUI();
                    }
                }
                break;
            case BarInfoType.Research:
                {
                    if (SourceScoreManager.IsScoreEnoughToBuy((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Research]))
                    {
                        SourceScoreManager.DecreaseScore((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Research]);
                        dataOfWizard.barInfoLvlsForUI.Research++;
                        RefreshUI();
                    }
                }
                break;
            case BarInfoType.Invoking:
                {
                    if (SourceScoreManager.IsScoreEnoughToBuy((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Invoking]))
                    {
                        SourceScoreManager.DecreaseScore((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Invoking]);
                        dataOfWizard.barInfoLvlsForUI.Invoking++;
                        RefreshUI();
                    }
                }
                break;
            case BarInfoType.Arcane:
                {
                    if (SourceScoreManager.IsScoreEnoughToBuy((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Arcane]))
                    {
                        SourceScoreManager.DecreaseScore((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Arcane]);
                        dataOfWizard.barInfoLvlsForUI.Arcane++;
                        RefreshUI();
                    }
                }
                break;
            case BarInfoType.Destruction:
                {
                    if (SourceScoreManager.IsScoreEnoughToBuy((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Destruction]))
                    {
                        SourceScoreManager.DecreaseScore((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Destruction]);
                        dataOfWizard.barInfoLvlsForUI.Destruction++;
                        RefreshUI();
                    }
                }
                break;
            case BarInfoType.Protection:
                {
                    if (SourceScoreManager.IsScoreEnoughToBuy((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Protection]))
                    {
                        SourceScoreManager.DecreaseScore((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Protection]);
                        dataOfWizard.barInfoLvlsForUI.Protection++;
                        RefreshUI();
                    }
                }
                break;
            case BarInfoType.Mysticism:
                {
                    if (SourceScoreManager.IsScoreEnoughToBuy((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Mysticism]))
                    {
                        SourceScoreManager.DecreaseScore((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Mysticism]);
                        dataOfWizard.barInfoLvlsForUI.Mysticism++;
                        RefreshUI();
                    }
                }
                break;
            case BarInfoType.Conjuring:
                {
                    if (SourceScoreManager.IsScoreEnoughToBuy((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Conjuring]))
                    {
                        SourceScoreManager.DecreaseScore((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Conjuring]);
                        dataOfWizard.barInfoLvlsForUI.Conjuring++;
                        RefreshUI();
                    }
                }
                break;
            case BarInfoType.Alchemy:
                {
                    if (SourceScoreManager.IsScoreEnoughToBuy((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Alchemy]))
                    {
                        SourceScoreManager.DecreaseScore((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Alchemy]);
                        dataOfWizard.barInfoLvlsForUI.Alchemy++;
                        RefreshUI();
                    }
                }
                break;
            case BarInfoType.DarkMagic:
                {
                    if (SourceScoreManager.IsScoreEnoughToBuy((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.DarkMagic]))
                    {
                        SourceScoreManager.DecreaseScore((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.DarkMagic]);
                        dataOfWizard.barInfoLvlsForUI.DarkMagic++;
                        RefreshUI();
                    }
                }
                break;
            case BarInfoType.HP:
                {
                    if (SourceScoreManager.IsScoreEnoughToBuy((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.HP]))
                    {
                        SourceScoreManager.DecreaseScore((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.HP]);
                        dataOfWizard.barInfoLvlsForUI.HP++;
                        dataOfWizard.dataOfWizardAttributes.maxHealth += 100;
                        RefreshUI();
                    }
                }
                break;
            case BarInfoType.Concentration:
                {
                    if (SourceScoreManager.IsScoreEnoughToBuy((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Concetration]))
                    {
                        SourceScoreManager.DecreaseScore((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Concetration]);
                        dataOfWizard.barInfoLvlsForUI.Concetration++;
                        
                        RefreshUI();
                    }
                }
                break;
            case BarInfoType.Intellect:
                {
                    if (SourceScoreManager.IsScoreEnoughToBuy((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Intellect]))
                    {
                        SourceScoreManager.DecreaseScore((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Intellect]);
                        dataOfWizard.barInfoLvlsForUI.Intellect++;
                        RefreshUI();
                    }
                }
                break;
            case BarInfoType.Knowledge:
                {
                    if (SourceScoreManager.IsScoreEnoughToBuy((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Knowledge]))
                    {
                        SourceScoreManager.DecreaseScore((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Knowledge]);
                        dataOfWizard.barInfoLvlsForUI.Knowledge++;
                        RefreshUI();
                    }
                }
                break;
            case BarInfoType.Energy:
                {
                    if (SourceScoreManager.IsScoreEnoughToBuy((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Energy]))
                    {
                        SourceScoreManager.DecreaseScore((int)SourceScoreManager.lvlBoundariesForSkill[dataOfWizard.barInfoLvlsForUI.Energy]);
                        dataOfWizard.barInfoLvlsForUI.Energy++;
                        RefreshUI();
                    }
                }
                break;
        }
    }

        private void OnDisable()
    {
        TurnManager.CharacterInfoUpdater -= RefreshUI;
    }
    }
