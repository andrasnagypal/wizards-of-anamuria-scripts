using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffMissileController : MonoBehaviour
{
    GameObject theTarget;
    CreatureController creature;
    public void SetTarget(GameObject target)
    {
        theTarget = target;
        if (target)
        {
            creature = theTarget.GetComponent<CreatureController>();
            TurnManager.TurnTick += MoveTowardTarget;
        }
        else
        {
            RemoveMissileFromScene();
        }
    }

    public void MoveTowardTarget()
    {
        float distance = Vector3.Distance(gameObject.transform.position, theTarget.transform.position);
        if(distance<.02f||creature.dataForTheCreature.currentHealth<=0)
        {
            TurnManager.TurnTick -= MoveTowardTarget;
           
            creature.TakeDamage(2);
            theTarget = null;
            RemoveMissileFromScene();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, theTarget.transform.position, .01f);
            transform.LookAt(theTarget.transform.position);
        }
    }


    void RemoveMissileFromScene()
    {
        FXPoolSystem.staffMissiles.Enqueue(gameObject);
        gameObject.transform.position = new Vector3(0, -1000f, 0);
        gameObject.SetActive(false);
    }

}
