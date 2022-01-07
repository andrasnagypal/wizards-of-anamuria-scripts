using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarNode 
{
   public float fCost,gCost,hCost;
    public int[] indexes;
    public AStarNode()
    {
        fCost = -1;
        gCost = 1;
        hCost = -1;
    }
}
