using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMovement : MonoBehaviour
{
    public CreatureController creatureController;
    GameObject theTarget;

    private void Awake()
    {
        if (GetComponent<CreatureController>() != null)
        {
            creatureController = GetComponent<CreatureController>();
        }
    }
    public void StartMovingToTheTarget(GameObject target)
    {
        theTarget = target;
        TurnManager.TurnTick += Moving;
       
    }

    public void StopMoving()
    {
        TurnManager.TurnTick -= Moving;
    }
    void Moving()
    {
       
        
        
            gameObject.transform.LookAt(theTarget.transform.position);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, theTarget.transform.position, .001f);
        
        if (Vector3.Distance(theTarget.transform.position, gameObject.transform.position) < .1f)
        {
            StopMoving();
            if(creatureController.dataForTheCreature.currentHealth>0)
            creatureController.FightTheTarget();
        }
    }
}
