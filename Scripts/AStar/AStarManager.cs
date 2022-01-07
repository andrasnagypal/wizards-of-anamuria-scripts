using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public enum MapType:byte
{
    MainMap
}
public enum NodeType:byte
{
    NotInList,
    Block,
    Open,
    PossibleForPath,
    Closed
}


public class AStarRecursiveData
{
    public AStarNode[,] map;
    public NodeType[,] mapForNodeTypes;
    public int[] startIndexes;
    public int[] finishIndexes;
    public int numberOfTry;
    public List<AStarNode> closedNodesList = new List<AStarNode>();
    public List<AStarNode> openNodesList = new List<AStarNode>();
    public List<int[]> finishedPathIndexes = new List<int[]>();
}

public class AStarManager : MonoBehaviour
{
    public  AStarNode[,] mainMapBasic;

    public void SetBasicMap(TerrainTypes[,] terrainMap)
    {
        mainMapBasic = new AStarNode[terrainMap.GetLength(0), terrainMap.GetLength(1)];
        for (int i = 0; i < terrainMap.GetLength(0); i++)
        {
            for (int j = 0; j < terrainMap.GetLength(1); j++)
            {
                mainMapBasic[i, j]=new AStarNode();
                if (terrainMap[i,j]==TerrainTypes.Mountain)
                mainMapBasic[i, j].gCost = 10000;
                mainMapBasic[i, j].indexes = new int[] { i, j };
            }
        }
    }

    public bool IsDestinationAMountain(MapType typeOfMap,int[] destination)
    {
        bool result = false;
       
        if (mainMapBasic[destination[0], destination[1]].gCost > 1000)
            result = true;
        return result;
    }

    public async Task<List<int[]>> GetPathFromAStar(MapType typeOfMap,int[] startIndexes,int[] finishIndexes)
    {
        AStarNode[,] tempMap=new AStarNode[10,10];
        List<int[]> pathIndexes = new List<int[]>();
        float[,] hCostArray=new float[1,1], fCostArray = new float[1, 1];
        List<AStarNode> toCheckNodes = new List<AStarNode>();
        List<AStarNode> pathToWalkOn = new List<AStarNode>();
        Debug.Log("S X" + startIndexes[0] + "S Y" + startIndexes[1] + "F X" + finishIndexes[0] + "F Y" + finishIndexes[1]);
        switch (typeOfMap)
        {
            case MapType.MainMap:
                {
                    //deep copy this!
                    tempMap = mainMapBasic.Clone() as AStarNode[,];
                    hCostArray = new float[mainMapBasic.GetLength(0), mainMapBasic.GetLength(1)];
                    fCostArray = new float[mainMapBasic.GetLength(0), mainMapBasic.GetLength(1)];
                    //tempMap = new AStarNode[mainMapBasic.GetLength(0), mainMapBasic.GetLength(1)];
                    //for (int i = 0; i < tempMap.GetLength(0); i++)
                    //{
                    //    for (int j = 0; j < tempMap.GetLength(1); j++)
                    //    {
                    //        tempMap[i, j] = new AStarNode();
                    //        if (mainMapBasic[i,j].gCost>1000)
                    //            tempMap[i, j].gCost = 10000;
                    //        //else
                    //        //{
                    //        //    tempMap[i, j].hCost = Vector3.Distance(new Vector3(i, 0, j), new Vector3(finishIndexes[0], 0, finishIndexes[1]));
                    //        //}
                    //        tempMap[i, j].indexes = new int[] { i, j };
                    //    }
                    //}
                }
                break;
        }
        hCostArray[startIndexes[0], startIndexes[1]] = 0;
        //for (int i = 0; i < tempMap.GetLength(0); i++)
        //{
        //    for (int j = 0; j < tempMap.GetLength(1); j++)
        //    {
        //        if (i == startIndexes[0] && j == startIndexes[1])
        //            tempMap[i, j].hCost = 0;
        //        //else
        //        //{
        //        //    tempMap[i, j].hCost = Vector3.Distance(new Vector3(i, 0, j), new Vector3(finishIndexes[0], 0, finishIndexes[1]));
        //        //}
        //        tempMap[i, j].indexes = new int[] { i, j };
        //    }
        //}
        pathIndexes.Add(startIndexes);
        pathToWalkOn.Add(tempMap[startIndexes[0], startIndexes[1]]);

        AStarNode temp = null,lowestfCostNode=null;
        //fcost comes!!!
        await Task.Run(() =>
        {
            while (!pathToWalkOn.Contains(tempMap[finishIndexes[0], finishIndexes[1]]))
            {
                toCheckNodes.Clear();
                toCheckNodes = new List<AStarNode>();
                foreach (AStarNode item in pathToWalkOn)
                {

                    for (int i = 0; i < 4; i++)
                    {
                        temp = null;// GetNeighbour(item.indexes[0], item.indexes[1], (Direction)((int)(Direction.North) + i), tempMap);
                        if (temp != null)
                        {
                            if (fCostArray[temp.indexes[0], temp.indexes[1]] <= 0 && temp.gCost < 1000)
                            {
                                hCostArray[temp.indexes[0], temp.indexes[1]] = Vector3.Distance(new Vector3(item.indexes[0], 0, item.indexes[1]), new Vector3(finishIndexes[0], 0, finishIndexes[1]));
                                fCostArray[temp.indexes[0], temp.indexes[1]] = temp.gCost + hCostArray[temp.indexes[0], temp.indexes[1]];
                            }
                            if (!toCheckNodes.Contains(temp) && !pathToWalkOn.Contains(temp) && temp.gCost < 1000)
                            {
                                toCheckNodes.Add(temp);
                            }
                            if (temp.indexes[0] == finishIndexes[0] && temp.indexes[1] == finishIndexes[1])
                            {
                                break;
                            }
                        }
                    }
                    if (temp.indexes[0] == finishIndexes[0] && temp.indexes[1] == finishIndexes[1])
                        break;
                }
                if (temp.indexes[0] == finishIndexes[0] && temp.indexes[1] == finishIndexes[1])
                {
                    pathIndexes.Add(temp.indexes.Clone() as int[]);
                    pathToWalkOn.Add(temp);
                }
                if (!pathToWalkOn.Contains(tempMap[finishIndexes[0], finishIndexes[1]]))

                {
                    lowestfCostNode = toCheckNodes[0];
                    foreach (AStarNode item in toCheckNodes)
                    {
                        if (fCostArray[lowestfCostNode.indexes[0], lowestfCostNode.indexes[1]] > fCostArray[item.indexes[0], item.indexes[1]])
                        {
                            lowestfCostNode = item;
                        }
                    }
                    pathToWalkOn.Add(lowestfCostNode);
                    pathIndexes.Add(lowestfCostNode.indexes.Clone() as int[]);
                }
            }
        });
        return new List<int[]>( pathIndexes.ToArray());
    }

    public async Task<List<int[]>> RecursevlyGetPathIndexesFromAStar(MapType typeOfMap, int[] startIndexes, int[] finishIndexes)
    {
        AStarNode[,] tempMap = new AStarNode[1, 1];
        List<int[]> pathIndexes = new List<int[]>();
        NodeType[,] tempNodeMap=new NodeType[1,1];
        switch (typeOfMap)
        {
            case MapType.MainMap:
                {
                    //deep copy this!
                    //tempMap = mainMapBasic.Clone() as AStarNode[,];
                    tempNodeMap = new NodeType[mainMapBasic.GetLength(0), mainMapBasic.GetLength(1)];
                    for (int i = 0; i < mainMapBasic.GetLength(0); i++)
                    {
                        for (int j = 0; j < mainMapBasic.GetLength(1); j++)
                        {
                            
                            if (mainMapBasic[i, j].gCost > 1000)
                                tempNodeMap[i, j] = NodeType.Block;
                            
                        }
                    }
                }
                break;
        }

        AStarRecursiveData theData = new AStarRecursiveData()
        {
            startIndexes = startIndexes,
            finishIndexes = finishIndexes,
            map = tempMap,
            mapForNodeTypes = tempNodeMap,
            openNodesList = new List<AStarNode>(),
            closedNodesList = new List<AStarNode>(),
            numberOfTry = 0
            //pathToWalkOn = new List<AStarNode>(),
            //toCheckNodes = new List<AStarNode>()
        };
        AStarNode nodeTemp = new AStarNode()
        {

            indexes = startIndexes,
            hCost = Vector3.Distance(new Vector3(startIndexes[0], 0, startIndexes[1]), new Vector3(finishIndexes[0], 0, finishIndexes[1])),
            gCost = 0,
            fCost = 0 + Vector3.Distance(new Vector3(startIndexes[0], 0, startIndexes[1]), new Vector3(finishIndexes[0], 0, finishIndexes[1]))
        };
        theData.closedNodesList.Add(nodeTemp);
        theData.mapForNodeTypes[startIndexes[0], startIndexes[1]] = NodeType.Closed;
        Debug.Log("FinishedIndexes before the while loop_ X " + finishIndexes[0] + " Y " + finishIndexes[1]);
        while(theData.mapForNodeTypes[finishIndexes[0], finishIndexes[1]]<NodeType.Closed&& theData.numberOfTry < 10000)
        {
            await Task.Run(() =>
            {
                RecursivePathFinding(nodeTemp,theData);
            });
        }
        Debug.Log("FinishedIndexes after the while loop_ X " + finishIndexes[0] + " Y " + finishIndexes[1]);
        //Debug.Log("S X" + startIndexes[0] + "S Y" + startIndexes[1] + "F X" + finishIndexes[0] + "F Y" + finishIndexes[1]);
        //theData.pathToWalkOn.Add(new AStarNode()
        //{
        //    indexes=startIndexes,
        //    gCost = tempMap[startIndexes[0], startIndexes[1]].gCost,
        //    hCost = Vector3.Distance(new Vector3(startIndexes[0], 0, startIndexes[1]), new Vector3(finishIndexes[0], 0, finishIndexes[1])),
        //fCost = tempMap[startIndexes[0], startIndexes[1]].gCost + Vector3.Distance(new Vector3(startIndexes[0], 0, startIndexes[1]), new Vector3(finishIndexes[0], 0, finishIndexes[1]))
        //});
        //int counterForCurrentPath = 0;
        //while(!(theData.pathToWalkOn[theData.pathToWalkOn.Count-1].indexes[0]==finishIndexes[0]&& theData.pathToWalkOn[theData.pathToWalkOn.Count - 1].indexes[1] == finishIndexes[1]))
        //{
        //    Debug.Log("New Node");

        //        RecursivePathFinding(theData, counterForCurrentPath++);

        //}

        //List<AStarNode> toCheckNodes = new List<AStarNode>();

        //List<AStarNode> pathToWalkOn = new List<AStarNode>();

        //switch (typeOfMap)
        //{
        //    case MapType.MainMap:
        //        {
        //            //deep copy this!
        //            tempMap = mainMapBasic.Clone() as AStarNode[,];

        //        }
        //        break;
        //}



        //AStarNode nodeTemp = new AStarNode()
        //{

        //    indexes = startIndexes,
        //    hCost = Vector3.Distance(new Vector3(startIndexes[0], 0, startIndexes[1]), new Vector3(finishIndexes[0], 0, finishIndexes[1])),
        //    gCost = tempMap[startIndexes[0], startIndexes[1]].gCost,
        //fCost= tempMap[startIndexes[0], startIndexes[1]].gCost + Vector3.Distance(new Vector3(startIndexes[0], 0, startIndexes[1]), new Vector3(finishIndexes[0], 0, finishIndexes[1]))
        //};
        //pathToWalkOn.Add(nodeTemp);

        //AStarRecursiveData theData = new AStarRecursiveData()
        //{
        //    startIndexes=startIndexes,
        //    finishIndexes=finishIndexes,
        //    map=tempMap,
        //    pathToWalkOn= pathToWalkOn,
        //    toCheckNodes= toCheckNodes,
        //    pathToCheckForWalkOnIndexes=new List<int[]>()
        //};
        //theData.pathToCheckForWalkOnIndexes.Add(startIndexes);
        //Debug.Log("S X" + startIndexes[0] + "S Y" + startIndexes[1] + "F X" + finishIndexes[0] + "F Y" + finishIndexes[1]);
        ////fcost comes!!!
        //await Task.Run(() =>
        //{
        //    RecursivePathFinding(theData);
        //});

        //if (theData.numberOfTry < 10000)
        //{
        //    await Task.Run(() =>
        //  {
        //      List<int[]> temp = new List<int[]>();
        //      temp.Add(theData.closedNodesList[theData.closedNodesList.Count - 1].indexes);
        //      int tempIndexOfLastConnectedNode = theData.closedNodesList.Count - 1;
        //      for (int i = theData.closedNodesList.Count - 2; i >= 1; i--)
        //      {
        //          if (IsNeighBours(theData.closedNodesList[i], theData.closedNodesList[tempIndexOfLastConnectedNode]))
        //          {
        //              tempIndexOfLastConnectedNode = i;
        //              temp.Add(theData.closedNodesList[i].indexes);
        //          }
        //      }
        //      temp.Add(theData.closedNodesList[0].indexes);
        //      temp.Reverse();
        //      theData.finishedPathIndexes = temp;

        //  });
        //}
        //else
        {
            theData.finishedPathIndexes = new List<int[]>() { new int[] { startIndexes[0], startIndexes[1] } };
        }

        return theData.finishedPathIndexes;
    }

    private bool IsNeighBours(AStarNode aStarNode1, AStarNode aStarNode2)
    {
        bool result=false;
        //astarnode1 western neighbour of astarnode2
        if (aStarNode1.indexes[0] == aStarNode2.indexes[0] - 1 && aStarNode1.indexes[1] == aStarNode2.indexes[1])
            result = true;
        //astarnode1 northern neighbour of astarnode2
        if (aStarNode1.indexes[0] == aStarNode2.indexes[0]  && aStarNode1.indexes[1] == aStarNode2.indexes[1]+1)
            result = true;
        //astarnode1 eastern neighbour of astarnode2
        if (aStarNode1.indexes[0] == aStarNode2.indexes[0] + 1 && aStarNode1.indexes[1] == aStarNode2.indexes[1])
            result = true;
        //astarnode1 southern neighbour of astarnode2
        if (aStarNode1.indexes[0] == aStarNode2.indexes[0]  && aStarNode1.indexes[1] == aStarNode2.indexes[1]-1)
            result = true;

        return result;
    }

    public AStarNode GetNeighbour(int x,int y, Direction dir, NodeType[,] theMap)
    {
        AStarNode result =null;
        switch (dir)
        {
            case Direction.North:
                {
                    if (y < GenerateMap.mapSizeY - 2)
                    {
                        result = new AStarNode() { 
                        indexes=new int[] {x,y+1},
                        gCost= 0,
                        fCost= 0,
                        hCost=0
                        };//theMap[x,y+1];
                    }
                }
                break;
            case Direction.East:
                {
                    if (x < GenerateMap.mapSizeX - 2)
                    {
                        result = new AStarNode()
                        {
                            indexes = new int[] { x + 1, y },
                            gCost = 0,
                            fCost = 0,
                            hCost = 0
                        };//theMap[x+1, y ];
                        }
                }
                break;
            case Direction.South:
                {
                    if (y > 0)
                    {
                        result = new AStarNode()
                        {
                            indexes = new int[] { x, y - 1 },
                            gCost = 0,
                            fCost = 0,
                            hCost =0
                        };  //theMap[x, y - 1];
                    }
                }
                break;
            case Direction.West:
                {
                    if (x >0)
                    {
                        result = new AStarNode()
                        {
                            indexes = new int[] { x - 1, y },
                            gCost = 0,
                            fCost = 0,
                            hCost = 0
                        }; //theMap[x-1, y ];
                    }
                }
                break;
        }
      
        return result;
    }



    async void RecursivePathFinding(AStarNode nodeOfPossiblePath, AStarRecursiveData theData)
    {
        AStarNode[] neighbours = new AStarNode[4];
        theData.numberOfTry++;
       
        if (theData.numberOfTry >= 10000)
        {
           return;
        }

        for (int i = 0; i < 4; i++)
        {
            neighbours[i] = GetNeighbour(nodeOfPossiblePath.indexes[0], nodeOfPossiblePath.indexes[1], (Direction)((int)(Direction.North) + i), theData.mapForNodeTypes);
        }
        for (int i = 0; i < 4; i++)
        {
            if (neighbours[i]!=null&& theData.mapForNodeTypes[ neighbours[i].indexes[0],neighbours[i].indexes[1]] == NodeType.NotInList)
            {
                theData.mapForNodeTypes[neighbours[i].indexes[0], neighbours[i].indexes[1]] = NodeType.Open;
                theData.openNodesList.Add(neighbours[i]);
            }
        }
        AStarNode lowestFCostNode = null;
        for (int i = 0; i < 4; i++)
        {
            if (neighbours[i] != null && theData.mapForNodeTypes[neighbours[i].indexes[0], neighbours[i].indexes[1]] == NodeType.Open)
            {
                foreach (AStarNode item in theData.openNodesList)
                {
                    if(item.indexes[0]== neighbours[i].indexes[0]&& item.indexes[1] == neighbours[i].indexes[1]&& neighbours[i].fCost<=.1f)
                    {
                        item.gCost = 1 + Vector3.Distance(new Vector3(item.indexes[0], 0, item.indexes[1]), new Vector3(nodeOfPossiblePath.indexes[0], 0, nodeOfPossiblePath.indexes[1]));
                        item.hCost =  Vector3.Distance(new Vector3(item.indexes[0], 0, item.indexes[1]), new Vector3(theData.finishIndexes[0], 0, theData.finishIndexes[1]));
                        item.fCost = item.gCost + item.hCost;
                        if(lowestFCostNode==null)
                        {
                            lowestFCostNode = item;
                        }
                        else
                        {
                            if(lowestFCostNode.fCost>item.fCost)
                            {
                                lowestFCostNode = item;
                            }
                        }
                        break;
                    }
                }
            }
        }
        if(lowestFCostNode==null)
        {
            theData.mapForNodeTypes[nodeOfPossiblePath.indexes[0], nodeOfPossiblePath.indexes[1]] = NodeType.Closed;
            foreach (AStarNode item in theData.closedNodesList)
            {
                if(theData.mapForNodeTypes[item.indexes[0], item.indexes[1]]==NodeType.PossibleForPath)
                {
                    await Task.Run(() =>
                    {
                        RecursivePathFinding(item, theData);
                    });
                    break;
                }
            }
        }
        else

        if(lowestFCostNode.indexes[0]== theData.finishIndexes[0]&& lowestFCostNode.indexes[1] == theData.finishIndexes[1])
        {
            theData.closedNodesList.Add(lowestFCostNode);
            theData.mapForNodeTypes[lowestFCostNode.indexes[0], lowestFCostNode.indexes[1]] = NodeType.Closed;

        }
        else
        {
            theData.closedNodesList.Add(lowestFCostNode);
            theData.mapForNodeTypes[lowestFCostNode.indexes[0], lowestFCostNode.indexes[1]] = NodeType.PossibleForPath;
            await Task.Run(() =>
            {
                RecursivePathFinding(lowestFCostNode, theData);
            });
        }

            }


  
}
