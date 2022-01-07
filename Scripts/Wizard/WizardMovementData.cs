using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public struct WizardMovementData 
{
    public int[] currentPlace, targetPlace;
    public List<int[]> pathToObjective;
    public int currentNodeIndex;
    public List<Direction> directionToMoveOn;
}
