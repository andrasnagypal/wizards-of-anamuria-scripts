using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollPageController : MonoBehaviour
{
    public ScrollPageButtonController[] spellButtons;
    public Image[] noteButtons;
    public Sprite artForTheUnknown,selectedNoteButton,unSelectedNoteButton;
    public TextMeshProUGUI descriptionText;

    public ScrollType[] arcaneScrolls, destScrolls, protectionScrolls, mysticismScrolls, conjuringScrolls, alchemyScrolls, darkmagicScrolls;
    int lastPageVisited = 1;
    ScrollbookManager bookManager;
    private void OnEnable()
    {
        if(bookManager==null)
        {
            bookManager = FindObjectOfType<ScrollbookManager>();
        }
        descriptionText.text = "";
        ChangePage(lastPageVisited);
        
    }
   
    public void SetupButtons(ScrollDataSO[] scrolldatas,int[] scrollNumbers)
    {
        for (int i = 0; i < scrollNumbers.Length; i++)
        {
            if(scrollNumbers[i]>0)
            {
               
                spellButtons[i].amount = scrollNumbers[i];
                spellButtons[i].artFromScroll = scrolldatas[i].artForScroll;
                spellButtons[i].cost = scrolldatas[i].scrollCostForThePlayer;
                spellButtons[i].description = scrolldatas[i].scroll.ToString();
                spellButtons[i].RefreshArt();
            }
            else
            {
                spellButtons[i].amount = 0;
                spellButtons[i].artFromScroll = artForTheUnknown;
                spellButtons[i].cost = 0;
                spellButtons[i].description = "";
                spellButtons[i].RefreshArt();

            }
        }
    }

    public void ColorNoteButtons(int index)
    {
        for (int i =0; i < noteButtons.Length; i++)
        {
            if (index != i)
                noteButtons[i].sprite = unSelectedNoteButton;
            else
                noteButtons[i].sprite = selectedNoteButton;
        }
        lastPageVisited = index;
    }

    public void ShowDescription(int indexOfButton)
    {
       
        if (spellButtons[indexOfButton].amount >0  )
            descriptionText.text = "Description of this spell: " + spellButtons[indexOfButton].description + "\nCost of spell: " + spellButtons[indexOfButton].cost + "\nScroll amount inside your base: " + spellButtons[indexOfButton].amount;
        else
            descriptionText.text = "This spell is hidden still. Sorry...";
    }

    public void ChangePage(int page)
    {
        ColorNoteButtons(page);
        
        switch (page)
        {
          
            case 0:
                {
                    List<ScrollDataSO> temp = new List<ScrollDataSO>();
                    int[] arraycount = new int[6];
                    for (int i = 0; i < arcaneScrolls.Length; i++)
                    {
                        temp.Add(bookManager.GetDataForScroll(arcaneScrolls[i]));
                        arraycount[i] = FindObjectOfType< ScrollbookManager >() .scrollbookKnowledge[arcaneScrolls[i]];
                    }
                    SetupButtons(temp.ToArray(), arraycount);

                }
                break;
            case 1:
                {
                    List<ScrollDataSO> temp = new List<ScrollDataSO>();
                    int[] arraycount = new int[6];
                    for (int i = 0; i < destScrolls.Length; i++)
                    {
                        temp.Add(bookManager.GetDataForScroll(destScrolls[i]));
                        arraycount[i] = FindObjectOfType<ScrollbookManager>().scrollbookKnowledge[destScrolls[i]];
                    }
                    SetupButtons(temp.ToArray(), arraycount);
                }
                break;
            case 2:
                {
                    List<ScrollDataSO> temp = new List<ScrollDataSO>();
                    int[] arraycount = new int[6];
                    for (int i = 0; i < protectionScrolls.Length; i++)
                    {
                        temp.Add(bookManager.GetDataForScroll(protectionScrolls[i]));
                        arraycount[i] = FindObjectOfType<ScrollbookManager>().scrollbookKnowledge[protectionScrolls[i]];
                    }
                    SetupButtons(temp.ToArray(), arraycount);
                }
                break;
            case 3:
                {
                    List<ScrollDataSO> temp = new List<ScrollDataSO>();
                    int[] arraycount = new int[6];
                    for (int i = 0; i < mysticismScrolls.Length; i++)
                    {
                        temp.Add(bookManager.GetDataForScroll(mysticismScrolls[i]));
                        arraycount[i] = FindObjectOfType<ScrollbookManager>().scrollbookKnowledge[mysticismScrolls[i]];
                    }
                    SetupButtons(temp.ToArray(), arraycount);
                }
                break;
            case 4:
                {
                    List<ScrollDataSO> temp = new List<ScrollDataSO>();
                    int[] arraycount = new int[6];
                    for (int i = 0; i < conjuringScrolls.Length; i++)
                    {
                        temp.Add(bookManager.GetDataForScroll(conjuringScrolls[i]));
                        arraycount[i] = FindObjectOfType<ScrollbookManager>().scrollbookKnowledge[conjuringScrolls[i]];
                    }
                    SetupButtons(temp.ToArray(), arraycount);
                }
                break;
            case 5:
                {
                    List<ScrollDataSO> temp = new List<ScrollDataSO>();
                    int[] arraycount = new int[6];
                    for (int i = 0; i < alchemyScrolls.Length; i++)
                    {
                        temp.Add(bookManager.GetDataForScroll(alchemyScrolls[i]));
                        arraycount[i] = FindObjectOfType<ScrollbookManager>().scrollbookKnowledge[alchemyScrolls[i]];
                    }
                    SetupButtons(temp.ToArray(), arraycount);
                }
                break;
            case 6:
                {
                    List<ScrollDataSO> temp = new List<ScrollDataSO>();
                    int[] arraycount = new int[6];
                    for (int i = 0; i < darkmagicScrolls.Length; i++)
                    {
                        temp.Add(bookManager.GetDataForScroll(darkmagicScrolls[i]));
                        arraycount[i] = FindObjectOfType<ScrollbookManager>().scrollbookKnowledge[darkmagicScrolls[i]];
                    }
                    SetupButtons(temp.ToArray(), arraycount);
                }
                break;
        }
    }
}
