using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCircleController : MonoBehaviour
{
    public WizardSetupData dataForWizard;



    private void OnMouseDown()
    {
        Debug.Log(dataForWizard.wizardName);
    }
}
