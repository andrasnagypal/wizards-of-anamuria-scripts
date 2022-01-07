using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TerrainTypeContainer :MonoBehaviour
{
    public TerrainTypes typeOfTerrain;
    public int[] tileIndexes;
    [SerializeField] MeshRenderer rendererTile;
    [SerializeField] MeshFilter meshFilter;
    [SerializeField] Transform[] positionsForEnvironment;
    [SerializeField] GameObject fog;
    [SerializeField] List<GameObject> naturePlaces = new List<GameObject>();
    List<GameObject> wizardsOnTile = new List<GameObject>();
    List<GameObject> buildingSelectors = new List<GameObject>();
    public void SetTerrain(TerrainTypes terrain)
    {
        typeOfTerrain = terrain;
        meshFilter.mesh = TerrainMeshAndMatManager.GetMeshForTile(terrain);
        rendererTile.material = TerrainMeshAndMatManager.GetMaterialForTile(terrain);

        //rendererTile.material.color = terrainColor;
        if (!(typeOfTerrain == TerrainTypes.Start) && !(typeOfTerrain == TerrainTypes.Mountain))
        {
            fog.SetActive(true);
            ActivateCorners(false);
        }
        else
        {

            Destroy(fog);
           
            ActivateCorners(true);
        }
       
    }
    public void SetGameObjectToCorner(GameObject cornerobject)
    {
        int rnd = UnityEngine.Random.Range(1, 5);
        if (positionsForEnvironment[rnd].childCount == 0)
        {
           
            cornerobject.transform.position = positionsForEnvironment[rnd].position;
            cornerobject.transform.SetParent(positionsForEnvironment[rnd]);
            cornerobject.transform.LookAt(positionsForEnvironment[0]);
            if(cornerobject.GetComponent<CreatureSpawner>()!=null)
            {
                cornerobject.GetComponent<CreatureSpawner>().indexes = tileIndexes;
            }
        }
        else
        {
           
            Destroy(cornerobject);
        }
    }
    
    public void SetLand(GameObject land)
    {
        land.transform.position = positionsForEnvironment[0].position;
        land.transform.SetParent(positionsForEnvironment[0]);
        
    }
    public void TurnPlayerBuildingChoise(bool mode)
    {
        foreach (var item in buildingSelectors)
        {
            item.SetActive(mode);
        }
    }

    public void SetUpBuildingSelectors(GameObject cornerSelectorForBuildings)
    {
        if(typeOfTerrain!=TerrainTypes.Start&& typeOfTerrain != TerrainTypes.Mountain)
        {
            for (int i = 1; i < 5; i++)
            {
                if (positionsForEnvironment[i].childCount == 0)
                {
                   Instantiate(cornerSelectorForBuildings, positionsForEnvironment[i].position, Quaternion.identity).transform.SetParent(positionsForEnvironment[i]);
                    if(positionsForEnvironment[i].GetChild(0).GetComponentInChildren<BuildingPlaceSelector>()!=null)
                    {
                        positionsForEnvironment[i].GetChild(0).GetComponentInChildren<BuildingPlaceSelector>().directionOfTheObject = (BuildingSelectorPlace)(i - 1);
                    }

                }
            }

            typeOfTerrain = TerrainTypes.Start;
        }
        
            
       
    }

    public void RemoveWizardFromTile(string wizardId)
    {
        for (int i = 0; i < wizardsOnTile.Count; i++)
        {
            



                if (wizardsOnTile[i].GetComponent<WizardController>().dataForWizard.wizardName==wizardId)
                {


                    //FindObjectOfType<CombatManager>().RemoveParticipantFromCombat(wizardsOnTile[i]);
                    wizardsOnTile.RemoveAt(i);
                    break;
                }
            
        }
    }

    public bool IsThereAProblem(GameObject wizard)
    {
        bool isItFightTime = false;
        for (int i = 0; i < positionsForEnvironment.Length; i++)
        {
            if (positionsForEnvironment[i].childCount > 0)
            {
                CreatureSpawner temp = positionsForEnvironment[i].GetChild(0).gameObject.GetComponent<CreatureSpawner>();
                if (temp != null)
                {
                    temp.SpawnCreature(tileIndexes);
                    isItFightTime = true;
                }
            }
        }
        return isItFightTime;
    }

    //public void IsThereATroubleHere(GameObject wizard)
    //{
    //    wizardsOnTile.Add(wizard);
    //    CreatureController[] temp2 = gameObject.GetComponentsInChildren<CreatureController>();
    //    if (temp2 != null )
    //    {
    //        for (int i = 0; i < temp2.Length; i++)
    //            FindObjectOfType<CombatArenaManager>().AddParticipantToCombatArea(tileIndexes, temp2[i].gameObject);



    //        FindObjectOfType<CombatArenaManager>().AddParticipantToCombatArea(tileIndexes, wizard);


    //    }
    //    //if (FindObjectOfType<CombatArenaManager>().isThisACombatArea(tileIndexes)) 
    //    //FindObjectOfType<CombatArenaManager>().SearchForEnemyWithThisIndexes(tileIndexes);
    //}
    public void TerritoryDiscovered()
    {
        
        ActivateCorners(true);
        
        if (fog)
        {
            StartCoroutine(DissolveFog(fog));
            SourceScoreManager.RaiseScore(5);
            
            for (int i = 0; i < positionsForEnvironment.Length; i++)
            {
                if(positionsForEnvironment[i].childCount>0)
                {
                    SourceScoreManager.RaiseScore(5);
                   
                   
                    PopUpInfoTrigger temp2 = positionsForEnvironment[i].GetChild(0).gameObject.GetComponentInChildren<PopUpInfoTrigger>();
                    if (temp2 != null && temp2.nameOfGO == "Mushrooms")
                        ActionManager.gatheringManager.AddGatheringSitesToList(new TaskInfoForTheWizard()
                        {
                            typeOfGO = WizardAction.Gathering,
                            theGO = positionsForEnvironment[i].GetChild(0).gameObject,
                            tileIndexForTheGO = tileIndexes

                        });
                }
            }
            
            fog = null;
        }

        for (int i = 0; i < positionsForEnvironment.Length; i++)
        {
            if(positionsForEnvironment[i].childCount>0)
            {
                
            }
        }
        
        TurnManager.TurnTick += FogCheck;
        
        
        
    }
    void ActivateCorners(bool active)
    {
        for (int i = 0; i < positionsForEnvironment.Length; i++)
        {
            positionsForEnvironment[i].gameObject.SetActive(active);
        }
        foreach (GameObject place in naturePlaces)
        {
            place.SetActive(active);
        }
    }

    public void AddNatureToTile(GameObject natureGO)
    {
        int rnd = UnityEngine.Random.Range(0, naturePlaces.Count);
        while(naturePlaces[rnd].transform.childCount!=0)
        {
            rnd = UnityEngine.Random.Range(0, naturePlaces.Count);
        }
        natureGO.transform.SetParent(naturePlaces[rnd].transform);
        natureGO.transform.localPosition = Vector3.zero;
       
    }

    
    public void RemoveUnusedNaturePlaces()
    {
        GameObject temp = null;
        
            for (int i = 0; i < naturePlaces.Count; i++)
            {
                if (naturePlaces[i].transform.childCount == 0)
                {
                    temp = naturePlaces[i];
                    naturePlaces.RemoveAt(i);
                    Destroy(temp);
                }
            }
       
        
       
        
    }
    void FogCheck()
    {
       
        for (int i = 0; i < wizardsOnTile.Count; i++)
        {
           
        
        
            if (Vector3.Distance(wizardsOnTile[i].transform.position,transform.position)>.52f)
            {


                //FindObjectOfType<CombatManager>().RemoveParticipantFromCombat(wizardsOnTile[i]);
                wizardsOnTile.RemoveAt(i);
                break;
            }
        }
        
        if (wizardsOnTile.Count==0)
        {
           
            TurnManager.TurnTick -= FogCheck;
        }
    }
    
    IEnumerator DissolveFog(GameObject theFog)
    {
        float progress = .7f;
        Material fogMaterial = theFog.GetComponent<MeshRenderer>().material;
        while(progress>=0)
        {
            yield return null;
            progress -= .025f;
            fogMaterial.SetFloat("_Progress", progress);
        }
        Destroy(theFog);
    }
    


    public void SetRoadOnTile(GameObject pavement,PlacementOfPavementOnTile pavementDirection)
    {
        switch (pavementDirection)
        {
            case PlacementOfPavementOnTile.Start:
                break;
            case PlacementOfPavementOnTile.West:
                {
                    pavement.transform.position = positionsForEnvironment[7].position;
                }
                break;
            case PlacementOfPavementOnTile.NorthWest:
                {
                    pavement.transform.position = positionsForEnvironment[3].position;
                }
                break;
            case PlacementOfPavementOnTile.North:
                {
                    pavement.transform.position = positionsForEnvironment[5].position;
                }
                break;
            case PlacementOfPavementOnTile.NorthEast:
                {
                    pavement.transform.position = positionsForEnvironment[4].position;
                }
                break;
            case PlacementOfPavementOnTile.East:
                {
                    pavement.transform.position = positionsForEnvironment[8].position;
                }
                break;
            case PlacementOfPavementOnTile.SouthEast:
                {
                    pavement.transform.position = positionsForEnvironment[2].position;
                }
                break;
            case PlacementOfPavementOnTile.South:
                {
                    pavement.transform.position = positionsForEnvironment[6].position;
                }
                break;
            case PlacementOfPavementOnTile.SouthWest:
                {
                    pavement.transform.position = positionsForEnvironment[1].position;
                }
                break;
        }
    }
}