using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PropType:ushort
{
    Nothing=0,
    ManaSource,
    WizardPlacement,
    
    Tree1=100,
    Tree2,
    Tree3,
    Tree4,
    Tree5,
    Rock1=150,
    Rock2,
    Rock3,
    Rock4,
    Rock5,
    Bush1=200,
    Bush2,
    Bush3,
    Grass1=250,
    Grass2,
    Grass3,
    Grass4,
    Grass5,
    MountainCenter=300,
    MountainSummit,
    MountainNorth1side,
    MountainEast1side,
    MountainNorthEast2side,
    MountainSouth1side,
    MountainNorthSouth2side,
    MountainSouthEast2side,
    MountainNorthEastSouth3side,
    MountainWest1side,
    MountainNorthWest2side,     
    MountainWestEast2side,
    MountainWestNorthEast3side,    
    MountainSouthWest2side,
    MountainSouthWestNorth3side,
    MountainEastSouthWest3side,
    Mountain4side,
    
    Ruins1 =400,
    Ruins2,
    Ruins3,
    DungeonRoomCenter=500,
    DungeonRoomNorth,
    DungeonRoomEast,
    DungeonRoomNorthEast,
    DungeonRoomSouth,
    DungeonRoomNorthSouth,
    DungeonRoomSouthEast,
    DungeonRoomNorthEastSouth,
    DungeonRoomWest,
    DungeonRoomNorthWest,
    DungeonRoomWestEast,
    DungeonRoomWestNorthEast,
    DungeonRoomSouthWest,
    DungeonRoomSouthWestNorth,
    DungeonRoomEastSouthWest,
    DungeonRoomMiddle,

   Chest1=600,
    

    Mushrooms1=700,

    Creature1=800,

    DungeonEntrance1=900,

    Portal1=1000,

    House1=1100,
    House2,
    House3,

    LandType=1200,
    FarmLand,
    StartFloor1,
    StartFloor2,
    Pavement1,
    
    MythicCreature1=1300,

    Buildings=1400,
    Tower1,
    Cauldron1,
    StoneGarden1,
    Orb1,
    Statue1,
    Library1,
    CrystalRoom1,
    StorageRoom1,

    QuestGiver1=1500
}

public class TilePropContainer : MonoBehaviour
{
   
    public GameObject[] propList;

    Dictionary<PropType, GameObject> PropDicitionary = new Dictionary<PropType, GameObject>();
    private void Awake()
    {
        CreateDictionary();
    }

    void CreateDictionary()
    {
        for (int i = 0; i < propList.Length; i++)
        {
            switch(propList[i].name)
            {
                case "MountainCenter":
                    {
                        PropDicitionary.Add(PropType.MountainCenter, propList[i]);
                        
                    }
                    break;
                case "MountainNorth1side":
                    {
                        PropDicitionary.Add(PropType.MountainNorth1side, propList[i]);

                    }
                    break;
                case "MountainEast1side":
                    {
                        PropDicitionary.Add(PropType.MountainEast1side, propList[i]);

                    }
                    break;
                case "MountainSouth1side":
                    {
                        PropDicitionary.Add(PropType.MountainSouth1side, propList[i]);

                    }
                    break;
                case "MountainWest1side":
                    {
                        PropDicitionary.Add(PropType.MountainWest1side, propList[i]);

                    }
                    break;
                case "MountainNorthEast2side":
                    {
                        PropDicitionary.Add(PropType.MountainNorthEast2side, propList[i]);

                    }
                    break;
                case "MountainSouthEast2side":
                    {
                        PropDicitionary.Add(PropType.MountainSouthEast2side, propList[i]);

                    }
                    break;
                case "MountainSouthWest2side":
                    {
                        PropDicitionary.Add(PropType.MountainSouthWest2side, propList[i]);

                    }
                    break;
                case "MountainNorthWest2side":
                    {
                        PropDicitionary.Add(PropType.MountainNorthWest2side, propList[i]);

                    }
                    break;
                case "MountainNorthSouth2side":
                    {
                        PropDicitionary.Add(PropType.MountainNorthSouth2side, propList[i]);

                    }
                    break;
                case "MountainWestEast2side":
                    {
                        PropDicitionary.Add(PropType.MountainWestEast2side, propList[i]);

                    }
                    break;
                case "MountainNorthEastSouth3side":
                    {
                        PropDicitionary.Add(PropType.MountainNorthEastSouth3side, propList[i]);

                    }
                    break;
                case "MountainEastSouthWest3side":
                    {
                        PropDicitionary.Add(PropType.MountainEastSouthWest3side, propList[i]);

                    }
                    break;
                case "MountainSouthWestNorth3side":
                    {
                        PropDicitionary.Add(PropType.MountainSouthWestNorth3side, propList[i]);

                    }
                    break;
                case "MountainWestNorthEast3side":
                    {
                        PropDicitionary.Add(PropType.MountainWestNorthEast3side, propList[i]);

                    }
                    break;
                case "Mountain4side":
                    {
                        PropDicitionary.Add(PropType.Mountain4side, propList[i]);

                    }
                    break;
                case "MountainSummit":
                    {
                        PropDicitionary.Add(PropType.MountainSummit, propList[i]);

                    }
                    break;
                case "Tree1":
                    {
                        PropDicitionary.Add(PropType.Tree1, propList[i]);
                    }
                    break;
                case "Tree2":
                    {
                        PropDicitionary.Add(PropType.Tree2, propList[i]);
                    }
                    break;
                case "Tree3":
                    {
                        PropDicitionary.Add(PropType.Tree3, propList[i]);
                    }
                    break;
                case "Tree4":
                    {
                        PropDicitionary.Add(PropType.Tree4, propList[i]);
                    }
                    break;
                case "Tree5":
                    {
                        PropDicitionary.Add(PropType.Tree5, propList[i]);
                    }
                    break;
                case "DungeonRoomNorth":
                    {
                        PropDicitionary.Add(PropType.DungeonRoomNorth, propList[i]);
                    }
                    break;
                case "DungeonRoomEast":
                    {
                        PropDicitionary.Add(PropType.DungeonRoomEast, propList[i]);
                    }
                    break;
                case "DungeonRoomNorthEast":
                    {
                        PropDicitionary.Add(PropType.DungeonRoomNorthEast, propList[i]);
                    }
                    break;
                case "DungeonRoomSouth":
                    {
                        PropDicitionary.Add(PropType.DungeonRoomSouth, propList[i]);
                    }
                    break;
                case "DungeonRoomNorthSouth":
                    {
                        PropDicitionary.Add(PropType.DungeonRoomNorthSouth, propList[i]);
                    }
                    break;
                case "DungeonRoomSouthEast":
                    {
                        PropDicitionary.Add(PropType.DungeonRoomSouthEast, propList[i]);
                    }
                    break;
                case "DungeonRoomNorthEastSouth":
                    {
                        PropDicitionary.Add(PropType.DungeonRoomNorthEastSouth, propList[i]);
                    }
                    break;
                case "DungeonRoomWest":
                    {
                        PropDicitionary.Add(PropType.DungeonRoomWest, propList[i]);
                    }
                    break;
                case "DungeonRoomNorthWest":
                    {
                        PropDicitionary.Add(PropType.DungeonRoomNorthWest, propList[i]);
                    }
                    break;
                case "DungeonRoomWestEast":
                    {
                        PropDicitionary.Add(PropType.DungeonRoomWestEast, propList[i]);
                    }
                    break;
                case "DungeonRoomWestNorthEast":
                    {
                        PropDicitionary.Add(PropType.DungeonRoomWestNorthEast, propList[i]);
                    }
                    break;
                case "DungeonRoomSouthWest":
                    {
                        PropDicitionary.Add(PropType.DungeonRoomSouthWest, propList[i]);
                    }
                    break;
                case "DungeonRoomSouthWestNorth":
                    {
                        PropDicitionary.Add(PropType.DungeonRoomSouthWestNorth, propList[i]);
                    }
                    break;
                case "DungeonRoomEastSouthWest":
                    {
                        PropDicitionary.Add(PropType.DungeonRoomEastSouthWest, propList[i]);
                    }
                    break;
                case "DungeonRoomMiddle":
                    {
                        PropDicitionary.Add(PropType.DungeonRoomMiddle, propList[i]);
                    }
                    break;
                case "Chest1":
                    {
                        PropDicitionary.Add(PropType.Chest1, propList[i]);
                    }
                    break;
                
                case "Ruins1":
                    {
                        PropDicitionary.Add(PropType.Ruins1, propList[i]);
                    }
                    break;
                case "Mushrooms1":
                    {
                        PropDicitionary.Add(PropType.Mushrooms1, propList[i]);
                    }
                    break;
                case "Creature1":
                    {
                        PropDicitionary.Add(PropType.Creature1, propList[i]);
                    }
                    break;
                case "DungeonEntrance1":
                    {
                        PropDicitionary.Add(PropType.DungeonEntrance1, propList[i]);
                    }
                    break;
                case "Portal1":
                    {
                        PropDicitionary.Add(PropType.Portal1, propList[i]);
                    }
                    break;
                case "WizardPlacement":
                    {
                        PropDicitionary.Add(PropType.WizardPlacement, propList[i]);
                    }
                    break;
                case "House1":
                    {
                        PropDicitionary.Add(PropType.House1, propList[i]);
                    }
                    break;
                case "House2":
                    {
                        PropDicitionary.Add(PropType.House2, propList[i]);
                    }
                    break;
                case "House3":
                    {
                        PropDicitionary.Add(PropType.House3, propList[i]);
                    }
                    break;  
                case "FarmLand":
                    {
                        PropDicitionary.Add(PropType.FarmLand, propList[i]);
                    }
                    break;
                case "StartFloor1":
                    {
                        PropDicitionary.Add(PropType.StartFloor1, propList[i]);
                    }
                    break; 
                case "MythicCreature1":
                    {
                        PropDicitionary.Add(PropType.MythicCreature1, propList[i]);
                    }
                    break;
                case "Tower1":
                    {
                        PropDicitionary.Add(PropType.Tower1, propList[i]);
                    }
                    break;
                case "StoneGarden1":
                    {
                        PropDicitionary.Add(PropType.StoneGarden1, propList[i]);
                    }
                    break; 
                case "Orb1":
                    {
                        PropDicitionary.Add(PropType.Orb1, propList[i]);
                    }
                    break;
                case "Statue1":
                    {
                        PropDicitionary.Add(PropType.Statue1, propList[i]);
                    }
                    break;
                case "Cauldron1":
                    {
                        PropDicitionary.Add(PropType.Cauldron1, propList[i]);
                    }
                    break;
                case "StartFloor2":
                    {
                        PropDicitionary.Add(PropType.StartFloor2, propList[i]);
                    }
                    break;
                case "QuestGiver1":
                    {
                        PropDicitionary.Add(PropType.QuestGiver1, propList[i]);
                    }
                    break;
                case "Rock1":
                    {
                        PropDicitionary.Add(PropType.Rock1, propList[i]);
                    }
                    break;
                case "Rock2":
                    {
                        PropDicitionary.Add(PropType.Rock2, propList[i]);
                    }
                    break;
                case "Rock3":
                    {
                        PropDicitionary.Add(PropType.Rock3, propList[i]);
                    }
                    break;
                case "Rock4":
                    {
                        PropDicitionary.Add(PropType.Rock4, propList[i]);
                    }
                    break;
                case "Rock5":
                    {
                        PropDicitionary.Add(PropType.Rock5, propList[i]);
                    }
                    break; 
                         case "Pavement1":
                    {
                        PropDicitionary.Add(PropType.Pavement1, propList[i]);
                    }
                    break;
                case "Grass1":
                    {
                        PropDicitionary.Add(PropType.Grass1, propList[i]);
                    }
                    break;
                case "Grass2":
                    {
                        PropDicitionary.Add(PropType.Grass2, propList[i]);
                    }
                    break;
                case "Grass3":
                    {
                        PropDicitionary.Add(PropType.Grass3, propList[i]);
                    }
                    break;
                case "Grass4":
                    {
                        PropDicitionary.Add(PropType.Grass4, propList[i]);
                    }
                    break;
                case "Grass5":
                    {
                        PropDicitionary.Add(PropType.Grass5, propList[i]);
                    }
                    break;
                case "Library1":
                    {
                        PropDicitionary.Add(PropType.Library1, propList[i]);
                    }
                    break;
                case "CrystalRoom1":
                    {
                        PropDicitionary.Add(PropType.CrystalRoom1, propList[i]);
                    }
                    break;
                case "StorageRoom1":
                    {
                        PropDicitionary.Add(PropType.StorageRoom1, propList[i]);
                    }
                    break;
            }
        }
       
    }

  
    public GameObject GetProp(PropType prop)
    {
        return PropDicitionary[prop];
    }
}
