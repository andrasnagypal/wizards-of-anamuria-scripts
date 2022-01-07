using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingSelectorPlace:byte
{
    BottomLeft,
    BottomRight,
    TopLeft,
    TopRight
}
public class BuildingPlaceSelector : MonoBehaviour
{
    public BuildingSelectorPlace directionOfTheObject;

    private void Awake()
    {
        if (!PlayerTilesManager.currentlyActiveForPlayerToChoosePlacesList.Contains(gameObject))
        {
            PlayerTilesManager.currentlyActiveForPlayerToChoosePlacesList.Add(gameObject);
        }
    }
    public void playerCancelledThis()
    {
        
    }

    public void playerChoseThis()
    {
        PlayerTilesManager.currentlyActiveForPlayerToChoosePlacesList.Remove(gameObject);
        Debug.Log("This was chosen");
        TerrainTypeContainer tilecontainer = transform.GetComponentInParent<TerrainTypeContainer>();
        if (!PlayerTilesManager.terrainsThePlayerHasBuildingOn.Contains(tilecontainer))
        {

            //GameObject floor = Instantiate(FindObjectOfType<TilePropContainer>().GetProp(PropType.Pavement1));
            //tilecontainer.SetLand(floor);
            tilecontainer.typeOfTerrain = TerrainTypes.Start;
            PlayerTilesManager.terrainsThePlayerHasBuildingOn.Add(tilecontainer);
        }

            
        PlayerTilesManager.CancelAllSelectionForBuildings();
        FindObjectOfType<PlayerTilesManager>().AddOrIncreasePavement(tilecontainer.tileIndexes);
        GameObject temp =Instantiate( FindObjectOfType<TilePropContainer>().GetProp(SelectedBuilding.buildingToSpawn));
        temp.transform.position = gameObject.transform.parent.position;
        temp.transform.SetParent(gameObject.transform.parent);
        if(SelectedBuilding.buildingToSpawn==PropType.Statue1)
        {
            ActionManager.meditatingManager.AddMeditationSiteToList(new TaskInfoForTheWizard()
            {
                
                theGO = temp,
                tileIndexForTheGO = tilecontainer.tileIndexes,
                typeOfGO=WizardAction.Meditating
               
            }) ;
        }
       
        Destroy(gameObject);
    }


    private void OnMouseDown()
    {
        playerChoseThis();
    }
}
