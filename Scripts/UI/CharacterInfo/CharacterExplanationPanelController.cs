using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterExplanationPanelController : MonoBehaviour
{
    public GameObject explanationPanel;
    public TextMeshProUGUI text;


    public void SetupPanel(int explanation)
    {
        explanationPanel.SetActive(true);
        text.text = FindObjectOfType<ExplanationManager>().GetExplanation((ExplanationType)explanation);
    }

    public void ClosePanel()
    {
        explanationPanel.SetActive(false);
    }
}
