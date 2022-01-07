using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public enum TerrainTypes:byte
{
    Forest,
    Desert,
    Frozen,
    Wasteland,
    Mountain,
    Settlement,
    Start,    
    Dungeon
   

}
public enum Direction:byte
{
    North,
    East,
    South,
    West
}

public struct TerrainTypeSeed
{
    public int seedX, seedY, numberOfTilesToGenerate;
    public TerrainTypes typeOfSeed;

}
public class GenerateMap : MonoBehaviour
{
    public List<TerrainTypes> terraintest = new List<TerrainTypes>();
    public static int mapSizeX, mapSizeY;
    public LoadingSceneController loadingScenePanel;
    [SerializeField] GameObject terrainPrefab, terrainParent,parentPrefab;
    [SerializeField] int X, Y, desertNumber, frozenNumber, wastelandNumber, mountainNumber, settlementNumber,treeNumber,chestNumber,mushroomNumber,ruinsNumber,creatureNumber,questgiverNumber,rockNumber;
    [SerializeField] Color[] terrainColors;
    [SerializeField] MountainGenerator mountainCreator;
    [SerializeField] TilePropContainer tileEnvContainer;
    [SerializeField] ContinentManager continentManager;
    [SerializeField] WizardManager wizardManager;
    [SerializeField] SettlementsDecorator decoratorManagerForSettlements;
    [SerializeField] UIManager uiManager;
    [SerializeField] PlayerTilesManager playerTilesManager;
    [SerializeField] AStarManager aStarManager;
    [SerializeField] EnvironmentManager envManager;
    List<PropType>[,] spawnedObjectsOnTiles;

    List<TerrainTypeSeed> seedsForGeneration = new List<TerrainTypeSeed>();
    int rndX, rndY, rndNumber;
    TerrainTypes[,] terrainMap;
  public  TerrainTypeContainer[,] terrainTiles;
    Dictionary<TerrainTypes, Color> terrainColoringDictionary = new Dictionary<TerrainTypes, Color>();
     List<List<int[]>> indexesOfTilesOfGeneratedTiles = new List<List<int[]>>();
    Dictionary<int[], List<MountainTopType>> tempMountain = new Dictionary<int[], List<MountainTopType>>();
    GameObject wizardPlacement;

    private void Awake()
    {
        SceneManager.LoadSceneAsync(2,LoadSceneMode.Additive);
       
       
        Application.targetFrameRate = 120;
        OnDemandRendering.renderFrameInterval = 2;
       

    }
    private async void Start()
    {
        loadingScenePanel= uiManager.TurnOnLoadingScreen();
       
        await Task.Delay(1000);
        float totalAmountToLoad = X * Y + desertNumber + frozenNumber + wastelandNumber + mountainNumber + settlementNumber + treeNumber + chestNumber + mushroomNumber + ruinsNumber + creatureNumber + questgiverNumber + rockNumber+1/*UILOADING*/;
       
        await InitializeStart();
       
        {
            
            loadingScenePanel.amountToFillPerTick = X * Y / totalAmountToLoad;
           
            loadingScenePanel.IncreaseLoadingBar();
            PutTilesOnMap(desertNumber, TerrainTypes.Desert);
            
            PutTilesOnMap(frozenNumber, TerrainTypes.Frozen);
            PutTilesOnMap(wastelandNumber, TerrainTypes.Wasteland);
            PutTilesOnMap(mountainNumber, TerrainTypes.Mountain);
            PutTilesOnMap(settlementNumber, TerrainTypes.Settlement);
            await Task.Delay(1000);
            MakeSeeds();
            loadingScenePanel.amountToFillPerTick = (desertNumber + frozenNumber + wastelandNumber + mountainNumber + settlementNumber) / totalAmountToLoad;
            foreach (TerrainTypeSeed item in seedsForGeneration)
            {
                if (item.numberOfTilesToGenerate > 0)
                {
                   await PopulateSeeds(item);
                   
                    loadingScenePanel.IncreaseLoadingBar();
                }
            }
        }
        await FindObjectOfType<UILoader>().StartLoading();
        await Task.Delay(1000);
        DeleteSmallTerrains();
        AddContinentsToManager();
        PutDownOneStartTile();
        TurnOnTheMapColors();
        MountainVisualization();
        envManager.StartAddingGrassToTiles();
        AddEnvOnTiles(new PropType[] { PropType.Tree1, PropType.Tree2, PropType.Tree3, PropType.Tree4, PropType.Tree5 }, treeNumber);        
        AddEnvOnTiles(new PropType[] { PropType.Chest1 }, chestNumber);
        AddEnvOnTiles(new PropType[] { PropType.Ruins1 }, ruinsNumber);
        AddEnvOnTiles(new PropType[] { PropType.Mushrooms1 }, mushroomNumber);
        AddEnvOnTiles(new PropType[] { PropType.Creature1 }, creatureNumber);
        AddEnvOnTiles(new PropType[] { PropType.QuestGiver1 }, questgiverNumber);
        AddEnvOnTiles(new PropType[] { PropType.Rock1, PropType.Rock2, PropType.Rock3, PropType.Rock4, PropType.Rock5 }, rockNumber);
        AddInteractablesOnMap(new PropType[] { PropType.DungeonEntrance1 }, 20);
        AddInteractablesOnMap(new PropType[] { PropType.Portal1 }, 30);
        aStarManager.SetBasicMap(terrainMap);

        FindObjectOfType<SourceScoreManager>().InititateScoreMeterController();
        //uiManager.TurnOnStandardUI();

        //PutDownWizards();
        DecorateSettlements();
        PutDownWizards();

    }
    void StartGenerating()
    {
        InitializeStart();
        PutTilesOnMap(desertNumber, TerrainTypes.Desert);
        PutTilesOnMap(frozenNumber, TerrainTypes.Frozen);
        PutTilesOnMap(wastelandNumber, TerrainTypes.Wasteland);
        PutTilesOnMap(mountainNumber, TerrainTypes.Mountain);
        PutTilesOnMap(settlementNumber, TerrainTypes.Settlement);



        MakeSeeds();
        foreach (TerrainTypeSeed item in seedsForGeneration)
        {
            if (item.numberOfTilesToGenerate > 0)
            {
                PopulateSeeds(item);
            }
        }
        DeleteSmallTerrains();
        AddContinentsToManager();
        PutDownOneStartTile();
        TurnOnTheMapColors();
        MountainVisualization();
        envManager.StartAddingGrassToTiles();
        AddEnvOnTiles(new PropType[] { PropType.Tree1, PropType.Tree2, PropType.Tree3, PropType.Tree4, PropType.Tree5 }, treeNumber);
        //AddEnvOnTiles(new PropType[] { PropType.Tree2 }, treeNumber);
        //AddEnvOnTiles(new PropType[] { PropType.Tree3 }, treeNumber);
        //AddEnvOnTiles(new PropType[] { PropType.Tree4 }, treeNumber);
        //AddEnvOnTiles(new PropType[] { PropType.Tree5 }, treeNumber);
        AddEnvOnTiles(new PropType[] { PropType.Chest1 }, chestNumber);
        AddEnvOnTiles(new PropType[] { PropType.Ruins1 }, ruinsNumber);
        AddEnvOnTiles(new PropType[] { PropType.Mushrooms1 }, mushroomNumber);
        AddEnvOnTiles(new PropType[] { PropType.Creature1 }, creatureNumber);
        AddEnvOnTiles(new PropType[] { PropType.QuestGiver1 }, questgiverNumber);
        AddEnvOnTiles(new PropType[] { PropType.Rock1, PropType.Rock2, PropType.Rock3, PropType.Rock4, PropType.Rock5 }, rockNumber);
        AddInteractablesOnMap(new PropType[] { PropType.DungeonEntrance1 }, 20);
        AddInteractablesOnMap(new PropType[] { PropType.Portal1 }, 30);
        aStarManager.SetBasicMap(terrainMap);
        uiManager.TurnOnStandardUI();

        PutDownWizards();
        DecorateSettlements();
        //GetDescriptionOfATile(indexesOfTilesOfGeneratedTiles[3][0]);
        //   AddNatureToTiles();
    }

    private Task InitializeStart()
    {
        
        mapSizeX = X;
        mapSizeY = Y;
        for (int i = 0; i < terrainColors.Length; i++)
        {
            terrainColoringDictionary.Add((TerrainTypes)((int)TerrainTypes.Forest + i), terrainColors[i]);
        }
        terrainTiles = new TerrainTypeContainer[X, Y];
        terrainMap = new TerrainTypes[X, Y];

        GameObject temp;
        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                temp = Instantiate(terrainPrefab, new Vector3(i, 0, j), terrainPrefab.transform.rotation);
                temp.transform.SetParent(terrainParent.transform);
                temp.name = i.ToString() + "X" + j.ToString() + "Y";
                terrainTiles[i, j] = temp.GetComponent<TerrainTypeContainer>();
                terrainTiles[i, j].tileIndexes = new int[] { i, j };

            }
        }

        terrainMap[X / 2, Y / 2] = TerrainTypes.Start;
        seedsForGeneration.Add(new TerrainTypeSeed()
        {
            numberOfTilesToGenerate = 300,
            seedX = X / 2,
            seedY = Y / 2,
            typeOfSeed = TerrainTypes.Start
        });
        Debug.Log("Finished");
        return Task.CompletedTask;
    }



    //private void AddNatureToTiles()
    //{
    //    int rndX = UnityEngine.Random.Range(0, X);
    //    int rndY = UnityEngine.Random.Range(0, Y);
    //    for (int i = 0; i < 10000; i++)
    //    {
    //        if(terrainTiles[rndX,rndY].typeOfTerrain==TerrainTypes.Forest)
    //        {
    //            terrainTiles[rndX, rndY].AddNatureToTile(envManager.GetForestGrass());
    //        }
    //        rndX = UnityEngine.Random.Range(0, X);
    //        rndY = UnityEngine.Random.Range(0, Y);
    //    }
    //    for (int i = 0; i < X; i++)
    //    {
    //        for (int j = 0; j < Y; j++)
    //        {
    //            terrainTiles[i, j].RemoveUnusedNaturePlaces();
    //        }
    //    }
    //}

    private void DecorateSettlements()
    {
        foreach (List<int[]> item in indexesOfTilesOfGeneratedTiles)
        {
            if (terrainMap[item[0][0], item[0][1]] == TerrainTypes.Settlement)
            {
                for (int i = 0; i < item.Count; i++)
                {
                    decoratorManagerForSettlements.GenerateEnvironmentForTile(terrainTiles[item[i][0], item[i][1]]);
                }
            }
        }
    }

    public void PutDownWizards()
    {
        foreach (List<int[]> item in indexesOfTilesOfGeneratedTiles)
        {
            if (terrainMap[item[0][0], item[0][1]] == TerrainTypes.Start)
            {                 
                wizardPlacement = Instantiate(tileEnvContainer.GetProp(PropType.WizardPlacement), terrainTiles[item[0][0], item[0][1]].gameObject.transform.position, Quaternion.identity);
                wizardManager.SetPlaceToSpawnWizards(wizardPlacement.GetComponent<WizardPlacementController>());
                PlayerTilesManager.terrainsThePlayerHasBuildingOn.Add(terrainTiles[item[0][0], item[0][1]]); /*WizardManager.sourceCenter = terrainTiles[item[0][0], item[0][1]];*/
                terrainTiles[item[0][0], item[0][1]].SetLand(Instantiate(tileEnvContainer.GetProp(PropType.StartFloor1)));
                terrainTiles[item[0][0], item[0][1]].gameObject.transform.SetParent(FindObjectOfType<PlayerTilesManager>().gameObject.transform);
                wizardManager.StartSpawning(SpawnWizardType.AtStart);
                FindObjectOfType<CameraController>().StartGame();
            }
        }
    }
    void PutDownOneStartTile()
    {
        foreach (List<int[]> item in indexesOfTilesOfGeneratedTiles)
        {
            if (terrainMap[item[0][0], item[0][1]]==TerrainTypes.Start)
            {
                int[] temparray;
                rndNumber = UnityEngine.Random.Range(0, item.Count);
                for (int i = 0; i < item.Count; i++)
                {
                    terrainMap[item[i][0], item[i][1]] = TerrainTypes.Forest;
                }
                terrainMap[item[rndNumber][0], item[rndNumber][1]] = TerrainTypes.Start;
                WizardManager.sourceCenter = terrainTiles[item[rndNumber][0], item[rndNumber][1]];
                FindObjectOfType<PavementController>().pavementsOnTilesData.Add(new TileInfoAboutPavements() { pavementsOnTile = new List<PlacementOfPavementOnTile>() { PlacementOfPavementOnTile.Start }, tileIndexes = new int[] { item[rndNumber][0], item[rndNumber][1] } });
                temparray = item[rndNumber];
                if(temparray==null)
                {
                    int rndX = UnityEngine.Random.Range(0, mapSizeX);
                    int rndY = UnityEngine.Random.Range(0, mapSizeY);
                    while(terrainMap[rndX,rndY]!=TerrainTypes.Forest)
                    {
                        rndX = UnityEngine.Random.Range(0, mapSizeX);
                        rndY = UnityEngine.Random.Range(0, mapSizeY);
                    }
                    temparray = new int[] { rndX, rndY };
                    terrainMap[rndX, rndY] = TerrainTypes.Start;
                    WizardManager.sourceCenter = terrainTiles[rndX, rndY];
                }
                item.Clear();
                item.Add(temparray);
                break;
            }
        }
    }

    void AddInteractablesOnMap(PropType[] typeOfProps, int maxNumberOfThem)
    {
        GameObject tempGO;
        int rndIndex,counter=0;
        if (typeOfProps.Length > 0)
            while (counter< maxNumberOfThem)
            {
                rndIndex = UnityEngine.Random.Range(0, typeOfProps.Length);
                rndX = UnityEngine.Random.Range(0, X);
                rndY = UnityEngine.Random.Range(0, Y);
                if (terrainMap[rndX, rndY] == TerrainTypes.Forest)
                {
                    tempGO = Instantiate(tileEnvContainer.GetProp(typeOfProps[rndIndex]));
                    terrainTiles[rndX, rndY].SetGameObjectToCorner(tempGO);
                    counter++;
                }
                if (typeOfProps[rndIndex] >= PropType.Chest1 && typeOfProps[rndIndex] <= PropType.Chest1)
                    if (terrainMap[rndX, rndY] == TerrainTypes.Desert || terrainMap[rndX, rndY] == TerrainTypes.Wasteland || terrainMap[rndX, rndY] == TerrainTypes.Frozen)
                    {
                        tempGO = Instantiate(tileEnvContainer.GetProp(typeOfProps[rndIndex]));
                        terrainTiles[rndX, rndY].SetGameObjectToCorner(tempGO);
                        counter++;
                    }
                if (typeOfProps[rndIndex] == PropType.Ruins1)
                    if (terrainMap[rndX, rndY] == TerrainTypes.Desert || terrainMap[rndX, rndY] == TerrainTypes.Wasteland || terrainMap[rndX, rndY] == TerrainTypes.Frozen)
                    {
                        tempGO = Instantiate(tileEnvContainer.GetProp(typeOfProps[rndIndex]));
                        terrainTiles[rndX, rndY].SetGameObjectToCorner(tempGO);
                        counter++;
                    }
                if (typeOfProps[rndIndex] == PropType.Mushrooms1)
                    if (terrainMap[rndX, rndY] == TerrainTypes.Desert || terrainMap[rndX, rndY] == TerrainTypes.Wasteland || terrainMap[rndX, rndY] == TerrainTypes.Frozen)
                    {
                        tempGO = Instantiate(tileEnvContainer.GetProp(typeOfProps[rndIndex]));
                        terrainTiles[rndX, rndY].SetGameObjectToCorner(tempGO);
                        counter++;
                    }
                if (typeOfProps[rndIndex] == PropType.Creature1)
                    if (terrainMap[rndX, rndY] == TerrainTypes.Desert || terrainMap[rndX, rndY] == TerrainTypes.Wasteland || terrainMap[rndX, rndY] == TerrainTypes.Frozen )
                    {
                        tempGO = Instantiate(tileEnvContainer.GetProp(typeOfProps[rndIndex]));
                        terrainTiles[rndX, rndY].SetGameObjectToCorner(tempGO);
                        counter++;
                    }
                if (typeOfProps[rndIndex] == PropType.DungeonEntrance1)
                    if (terrainMap[rndX, rndY] == TerrainTypes.Desert || terrainMap[rndX, rndY] == TerrainTypes.Wasteland || terrainMap[rndX, rndY] == TerrainTypes.Frozen )
                    {
                        tempGO = Instantiate(tileEnvContainer.GetProp(typeOfProps[rndIndex]));
                        terrainTiles[rndX, rndY].SetGameObjectToCorner(tempGO);
                        counter++;
                    }
                if (typeOfProps[rndIndex] == PropType.Portal1)
                    if (terrainMap[rndX, rndY] == TerrainTypes.Desert || terrainMap[rndX, rndY] == TerrainTypes.Wasteland || terrainMap[rndX, rndY] == TerrainTypes.Frozen)
                    {
                        tempGO = Instantiate(tileEnvContainer.GetProp(typeOfProps[rndIndex]));
                        terrainTiles[rndX, rndY].SetGameObjectToCorner(tempGO);
                        counter++;
                    }
            }
    }
    void AddEnvOnTiles(PropType[] typeOfProps,int maxNumberOfThem)
    {
        GameObject tempGO;
        int rndIndex;
        if (typeOfProps.Length>0)
        for (int i = 0; i < maxNumberOfThem; i++)
        {
            rndIndex= UnityEngine.Random.Range(0, typeOfProps.Length);
                rndX = UnityEngine.Random.Range(0, X);
            rndY = UnityEngine.Random.Range(0, Y);
            if (terrainMap[rndX, rndY] == TerrainTypes.Forest)
            {
                    tempGO = Instantiate(tileEnvContainer.GetProp(typeOfProps[rndIndex]));
                terrainTiles[rndX, rndY].SetGameObjectToCorner(tempGO);
            }
           if (typeOfProps[rndIndex]>=PropType.Chest1&& typeOfProps[rndIndex] <= PropType.Chest1)
                    if (terrainMap[rndX, rndY] == TerrainTypes.Desert|| terrainMap[rndX, rndY] == TerrainTypes.Wasteland || terrainMap[rndX, rndY] == TerrainTypes.Frozen )
                    {
                        tempGO = Instantiate(tileEnvContainer.GetProp(typeOfProps[rndIndex]));
                        terrainTiles[rndX, rndY].SetGameObjectToCorner(tempGO);
                    }
           if (typeOfProps[rndIndex] == PropType.Ruins1)
                    if (terrainMap[rndX, rndY] == TerrainTypes.Desert || terrainMap[rndX, rndY] == TerrainTypes.Wasteland || terrainMap[rndX, rndY] == TerrainTypes.Frozen)
                    {
                        tempGO = Instantiate(tileEnvContainer.GetProp(typeOfProps[rndIndex]));
                        terrainTiles[rndX, rndY].SetGameObjectToCorner(tempGO);
                    }
           if (typeOfProps[rndIndex] ==PropType.Mushrooms1)
                    if (terrainMap[rndX, rndY] == TerrainTypes.Desert || terrainMap[rndX, rndY] == TerrainTypes.Wasteland || terrainMap[rndX, rndY] == TerrainTypes.Frozen)
                    {
                        tempGO = Instantiate(tileEnvContainer.GetProp(typeOfProps[rndIndex]));
                        terrainTiles[rndX, rndY].SetGameObjectToCorner(tempGO);
                    }
           if (typeOfProps[rndIndex] == PropType.Creature1)
                    if (terrainMap[rndX, rndY] == TerrainTypes.Desert || terrainMap[rndX, rndY] == TerrainTypes.Wasteland || terrainMap[rndX, rndY] == TerrainTypes.Frozen || terrainMap[rndX, rndY] == TerrainTypes.Settlement)
                    {
                        tempGO = Instantiate(tileEnvContainer.GetProp(typeOfProps[rndIndex]));
                        terrainTiles[rndX, rndY].SetGameObjectToCorner(tempGO);
                    }
                if (typeOfProps[rndIndex] == PropType.QuestGiver1)
                    if (terrainMap[rndX, rndY] == TerrainTypes.Desert || terrainMap[rndX, rndY] == TerrainTypes.Wasteland || terrainMap[rndX, rndY] == TerrainTypes.Frozen || terrainMap[rndX, rndY] == TerrainTypes.Settlement)
                    {
                        tempGO = Instantiate(tileEnvContainer.GetProp(typeOfProps[rndIndex]));
                        terrainTiles[rndX, rndY].SetGameObjectToCorner(tempGO);
                    }
                if (typeOfProps[rndIndex] == PropType.Rock1)
                    if (terrainMap[rndX, rndY] == TerrainTypes.Desert || terrainMap[rndX, rndY] == TerrainTypes.Wasteland || terrainMap[rndX, rndY] == TerrainTypes.Frozen )
                    {
                        tempGO = Instantiate(tileEnvContainer.GetProp(typeOfProps[rndIndex]));
                        terrainTiles[rndX, rndY].SetGameObjectToCorner(tempGO);
                    }
            }

        
    }
    

    void MakeSeeds()
    {
        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                
                if (terrainMap[i, j] != TerrainTypes.Forest && terrainMap[i, j] != TerrainTypes.Start)
                {
                    seedsForGeneration.Add(new TerrainTypeSeed
                    {
                        numberOfTilesToGenerate = NumberToGenerateForASeed(terrainMap[i, j]),
                        seedX = i,
                        seedY = j,
                        typeOfSeed = terrainMap[i, j]
                    });
                    //Debug.Log("Making: Seed X: " + i + " Seed Y: " + j);
                }
            }
        }
    }

    private void MountainVisualization()
    {
        foreach (List<int[]> item in indexesOfTilesOfGeneratedTiles)
        {
            if (item.Count>0&&terrainMap[item[0][0], item[0][1]] == TerrainTypes.Mountain)
            {
                GameObject parent = Instantiate(parentPrefab, Vector3.zero, Quaternion.identity);
                parent.name = "Mountain of Seed " + terrainTiles[item[0][0], item[0][1]].name;
                tempMountain = mountainCreator.GetTypeOfMountainTops(item);
                foreach (int[] mntIndex in item)
                {
                    for (int i = 0; i < tempMountain[mntIndex].Count; i++)
                    {
                        if (tempMountain[mntIndex][i] == MountainTopType.MountainCenter && tempMountain[mntIndex][i + 1] == MountainTopType.MountainCenter)
                        {
                           GameObject mnt= Instantiate(tileEnvContainer.GetProp(PropType.MountainCenter), terrainTiles[mntIndex[0], mntIndex[1]].gameObject.transform.position + (new Vector3(0, .5f, 0) * i), Quaternion.identity);
                            if (i > 8)
                                mnt.GetComponentInChildren<MeshRenderer>().material.color = Color.white;
                            mnt.transform.SetParent(parent.transform);
                        }
                        if (tempMountain[mntIndex][i] == MountainTopType.MountainCenter && tempMountain[mntIndex][i + 1] == MountainTopType.Nothing)
                        {
                            
                            bool[] directions = new bool[4]; 
                            int[] tempResult;
                            if (mntIndex[1] < Y)
                            {
                               
                                tempResult = GetMountainTypeNeighborByArrayIndex(new int[2] { mntIndex[0], mntIndex[1] + 1 }, item);
                                if (tempResult!=null&&tempMountain[tempResult][i] == MountainTopType.MountainCenter)
                                {
                                    
                                    directions[0] = true;
                                }
                            }
                            if (mntIndex[0] < X)
                            {
                                tempResult = GetMountainTypeNeighborByArrayIndex(new int[2] { mntIndex[0] + 1, mntIndex[1] }, item);
                                if (tempResult != null && tempMountain[tempResult][i] == MountainTopType.MountainCenter)
                            {
                                
                                    directions[1] = true;
                            }
                        }
                            if (mntIndex[1] > 0)
                            {
                                tempResult = GetMountainTypeNeighborByArrayIndex(new int[2] { mntIndex[0], mntIndex[1] - 1 }, item);
                                if (tempResult != null && tempMountain[tempResult][i] == MountainTopType.MountainCenter)
                                {
                                   
                                    directions[2] = true;
                                }
                            }
                            if (mntIndex[0] > 0)
                            {
                                tempResult = GetMountainTypeNeighborByArrayIndex(new int[2] { mntIndex[0] - 1, mntIndex[1] }, item);
                                if (tempResult != null && tempMountain[tempResult][i] == MountainTopType.MountainCenter)
                                {
                                    
                                    directions[3] = true;
                                }
                            }
                            int directionOfTileProp = GetDirectionForATileProp(directions);
                            PropType spawnThisGO = (PropType)((int)PropType.MountainSummit + directionOfTileProp);
                            GameObject mnt = Instantiate(tileEnvContainer.GetProp(spawnThisGO), terrainTiles[mntIndex[0], mntIndex[1]].gameObject.transform.position + (new Vector3(0, .5f, 0) * i), Quaternion.identity);
                            if (i > 8)
                                mnt.GetComponentInChildren<MeshRenderer>().material.color = Color.white;
                            mnt.transform.SetParent(parent.transform);
                        }
                    }
                }
                parent.transform.SetParent(terrainParent.transform);
            }
        }
    }


    void AddContinentsToManager()
    {
        foreach (List<int[]> item in indexesOfTilesOfGeneratedTiles)
        {
            if (terrainMap[item[0][0], item[0][1]] != TerrainTypes.Forest)
                continentManager.AddContinentToItsManager(terrainMap[item[0][0], item[0][1]], item);

        }
        List<int[]> templist = new List<int[]>();
        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {

                if (terrainMap[i, j] == TerrainTypes.Forest )
                {
                    templist.Add(new int[] { i,j});
                }
                    }
        }
        continentManager.AddContinentToItsManager(TerrainTypes.Forest, templist);
    }

    int GetDirectionForATileProp(bool[] directions)
    {
        int result = 0;
        for (int i = 0; i < directions.Length; i++)
        {
            if (directions[i])
            {
                result += (int)Math.Pow(2, i);
            }
        }
        return result;
    }

   

    private int[] GetMountainTypeNeighborByArrayIndex(int[] mntIndex, List<int[]> neighbours)
    {
        int[] result=null;
        foreach (int[] item in neighbours)
        {
            if (item[0]==mntIndex[0]&&item[1]==mntIndex[1])
            {
                result = item;
                break;
            }

        }
       
        return result;
        }

    void DeleteSmallTerrains()
    {
        foreach (List<int[]> item in indexesOfTilesOfGeneratedTiles)
        {
            if (terrainMap[item[0][0], item[0][1]] != TerrainTypes.Start && item.Count < 5)
            {
                for (int i = 0; i < item.Count; i++)
                {
                    terrainMap[item[i][0], item[i][1]] = TerrainTypes.Forest;
                    //Debug.Log("Deleted: Seed X: " + item[i][0] + " Seed Y: " + item[i][1]);
                }
                //Debug.Log("Small Spawn");
                item.Clear();
                //Debug.Log("Spawn number after clear: " + item.Count);

            }
            else
                terraintest.Add(terrainMap[item[0][0], item[0][1]]);
            
        }
        int j = 0;
        while(j<indexesOfTilesOfGeneratedTiles.Count)
        {
            if (indexesOfTilesOfGeneratedTiles[j].Count == 0)
            {
                indexesOfTilesOfGeneratedTiles.RemoveAt(j);
                j = 0;
                //Debug.Log("Small Spawn Deleted");
            }
            else j++;
        }
    }
    void TurnOnTheMapColors()
    {
        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                 terrainTiles[i, j].SetTerrain(terrainMap[i, j]/*, terrainColoringDictionary[terrainMap[i, j]]*/);
               
            }
        }
    }
    void PutTilesOnMap(int amount,TerrainTypes theType)
    {
        int h = 0;
        while (h < amount)
        {
            rndX = UnityEngine.Random.Range(0, X);
            rndY = UnityEngine.Random.Range(0, Y);
            
            
            terrainMap[rndX, rndY] = theType;
            
            h++;
        }
    }

  

    int NumberToGenerateForASeed(TerrainTypes theType)
    {
        int amount = 0;
        switch (theType)
        {
            case TerrainTypes.Start:
                break;
            case TerrainTypes.Desert:
                {
                    amount = UnityEngine.Random.Range(50, 300);
                }
                break;
            case TerrainTypes.Frozen:
                {
                    amount = UnityEngine.Random.Range(50, 300);
                }
                break;
            case TerrainTypes.Wasteland:
                {
                    amount = UnityEngine.Random.Range(50, 300);
                }
                break;
            case TerrainTypes.Mountain:
                {
                    amount = UnityEngine.Random.Range(30, 100);
                }
                break;
            case TerrainTypes.Settlement:
                {
                    amount = UnityEngine.Random.Range(3, 25);
                }
                break;
            case TerrainTypes.Forest:
                break;
           
            case TerrainTypes.Dungeon:
                break;
           
            default:
                break;
        }
       
        return amount;
    }

    async Task<int> PopulateSeeds(TerrainTypeSeed seed)
    {
        int seedTry = 0, seededTile = 0;
        List<int[]> tilesForTheSeed = new List<int[]>();
        tilesForTheSeed.Add(new int[] { seed.seedX,seed.seedY});
        //Debug.Log("Seed X: " + seed.seedX + " Seed Y: " + seed.seedY);
        int rndTile;
        byte rndDirection;
        int[] temp;
        while (seededTile<seed.numberOfTilesToGenerate&&seedTry<500)
        {
            rndTile = UnityEngine.Random.Range(0, tilesForTheSeed.Count);
            rndDirection= (byte)UnityEngine.Random.Range(0, 4);
            temp = GetTileInThatDirection(tilesForTheSeed[rndTile], (Direction)rndDirection);
            if (temp!=null)
            {
                if (terrainMap[temp[0], temp[1]]!=TerrainTypes.Start&& terrainMap[temp[0], temp[1]] ==TerrainTypes.Forest)
                {
                    terrainMap[temp[0], temp[1]] = seed.typeOfSeed;
                  
                    tilesForTheSeed.Add(new int[] { temp[0], temp[1] });
                    seededTile++;
                }
                else
                {
                    seedTry++;
                }
            }
            else
            {
                seedTry++;
            }
        }
        indexesOfTilesOfGeneratedTiles.Add(tilesForTheSeed);
        return 0;
    }

    public int[] GetTileInThatDirection(int[] seed, Direction direction)
    {
        int[] temp = null;
        switch (direction)
        {
            case Direction.North:
                {
                    if (seed[1]<Y-1)
                    {
                       if(terrainMap[seed[0], seed[1] + 1]!=TerrainTypes.Mountain)
                        temp = new int[] { seed[0], seed[1] + 1 };
                    }
                }
                break;
            case Direction.East:
                if (seed[0] < X-1)
                {
                    if (terrainMap[seed[0] + 1, seed[1]] != TerrainTypes.Mountain)
                        temp = new int[] { seed[0]+1, seed[1] };                    
                }
                break;
            case Direction.South:
                if (seed[1] > 0 )
                {
                    if (terrainMap[seed[0], seed[1] - 1] != TerrainTypes.Mountain)
                        temp = new int[] { seed[0] , seed[1] - 1 };
                   
                }
                break;
            case Direction.West:
                if (seed[0] > 0)
                {
                    if (terrainMap[seed[0] - 1, seed[1]] != TerrainTypes.Mountain)
                        temp = new int[] { seed[0]-1, seed[1]  };
                   
                }
                break;

             
        }
        return temp;
    }
        public Vector3 GetStartPosition()
    {
        Vector3 result=Vector3.zero;
        foreach (List<int[]> item in indexesOfTilesOfGeneratedTiles)
        {
            if (terrainMap[item[0][0], item[0][1]] == TerrainTypes.Start)
            {
                result= terrainTiles[item[0][0], item[0][1]].gameObject.transform.position;
                break;
            }
        }
        return result;
    }

    public  List<Direction> GetListForAvailableDirectionsToMove(int[] positionOnMap)
    {
        List<Direction> theList = new List<Direction>();
        for (int i = 0; i < 4; i++)
        {
           int[] temp= GetTileInThatDirection(positionOnMap, (Direction)((int)Direction.North + i));
            if (temp!=null)
            {
                if (terrainMap[temp[0],temp[1]]!=TerrainTypes.Mountain)
                theList.Add((Direction)((int)Direction.North + i));
            }
        }
        return theList;
    }
    public int[] GetStartIndexes()
    {
        int[] temp=null;
        foreach (List<int[]> item in indexesOfTilesOfGeneratedTiles)
        {
            if (terrainMap[item[0][0], item[0][1]] == TerrainTypes.Start)
            {
                temp = new int[] { item[0][0], item[0][1] };
                break;
            }
        }
        return temp;
    }
    public TerrainTypeContainer GetTerrainForCharacter(int[] placeIndex)
    {
        
        return terrainTiles[placeIndex[0], placeIndex[1]];
    }

    public void SetupBuildingSelectorsForUse(TerrainTypeContainer terrain)
    {
        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                if (terrainTiles[i, j] == terrain)
                {
                    if (i + 1 < X)
                        if (terrainTiles[i + 1, j].typeOfTerrain != TerrainTypes.Start && terrainTiles[i + 1, j].typeOfTerrain != TerrainTypes.Mountain)
                        {
                            terrainTiles[i + 1, j].SetUpBuildingSelectors(playerTilesManager.cornerBuildingSelector);


                        }
                    if (i - 1 >= 0)
                        if (terrainTiles[i - 1, j].typeOfTerrain != TerrainTypes.Start && terrainTiles[i - 1, j].typeOfTerrain != TerrainTypes.Mountain)
                        {
                            terrainTiles[i - 1, j].SetUpBuildingSelectors(playerTilesManager.cornerBuildingSelector);

                        }
                    if (j + 1 < Y)
                        if (terrainTiles[i, j + 1].typeOfTerrain != TerrainTypes.Start && terrainTiles[i, j + 1].typeOfTerrain != TerrainTypes.Mountain)
                        {
                            terrainTiles[i, j + 1].SetUpBuildingSelectors(playerTilesManager.cornerBuildingSelector);

                        }
                    if (j - 1 >= 0)
                        if (terrainTiles[i, j - 1].typeOfTerrain != TerrainTypes.Start && terrainTiles[i, j - 1].typeOfTerrain != TerrainTypes.Mountain)
                        {
                            terrainTiles[i, j - 1].SetUpBuildingSelectors(playerTilesManager.cornerBuildingSelector);

                        }
                    i = X;
                    break;

                }
            }
        }
        PlayerTilesManager.TurnOnAvailableChoicesForPlayer();
    }

    
    public void GetDescriptionOfATile(int[] indexes)
    {
        string temp = continentManager.GetDescriptionForATile(indexes);
        Debug.Log(temp);
        Debug.Log(indexes[0].ToString()+" "+ indexes[1].ToString());
        
    }

}
