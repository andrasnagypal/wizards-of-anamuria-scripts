using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WizardEffects:byte
{
    StaffMissile,
    TeleportingIn,
    TeleportinOut,
    DyingFX,
    Fireball
}

public class EffectsManager : MonoBehaviour
{
    public GameObject[] fxPrefabs;
    public Dictionary<WizardEffects, GameObject> wizardEffectsDictionary = new Dictionary<WizardEffects, GameObject>();


    private void Awake()
    {
        for (int i = 0; i < fxPrefabs.Length; i++)
        {
            AddFXToDictionary(fxPrefabs[i]);
        }

        GetComponent<FXPoolSystem>().GetStaffMissiles();
    }

    void AddFXToDictionary(GameObject fx)
    {
        switch(fx.name)
        {
            case "WizardStaffMissile":
                {
                    wizardEffectsDictionary.Add(WizardEffects.StaffMissile, fx);
                }
                break;
        }
    }

}
