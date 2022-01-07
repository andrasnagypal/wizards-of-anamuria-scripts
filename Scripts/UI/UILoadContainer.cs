using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILoadContainer : MonoBehaviour
{
    public LayoutType typeOfUI;
    private void Awake()
    {
        FindObjectOfType<UIManager>().AddUILayoutToDictionary(typeOfUI, gameObject);
        if(typeOfUI==LayoutType.NotificationPanel)
        {
            FindObjectOfType<UIManager>().TurnOnStandardUI();
            
        }
    }

    public void ClosePanel()
    {
        FindObjectOfType<UIManager>().ClosePanel(typeOfUI);
    }

    public void GoBackToMainMenu()
    {
        FindObjectOfType<UILoader>().BackToMainMenu();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
