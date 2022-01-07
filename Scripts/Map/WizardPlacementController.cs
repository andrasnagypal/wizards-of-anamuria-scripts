using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardPlacementController : MonoBehaviour
{
    [SerializeField] Transform[] places;

    List<Transform> placesToSpawnWizards = new List<Transform>();

    private void Awake()
    {
        MakePlacesAvailable();
    }
    public void PutDownWizard(GameObject placeableobject)
    {
        int rnd = Random.Range(0, placesToSpawnWizards.Count);
                placeableobject.transform.position = placesToSpawnWizards[rnd].position;
        placesToSpawnWizards.RemoveAt(rnd);





        if (placesToSpawnWizards.Count==0)
        {
            MakePlacesAvailable();
        }
    }

    void MakePlacesAvailable()
    {
        placesToSpawnWizards= new List<Transform>();
        for (int i = 0; i < places.Length; i++)
        {
            placesToSpawnWizards.Add(places[i]);
        }
    }


    
}
