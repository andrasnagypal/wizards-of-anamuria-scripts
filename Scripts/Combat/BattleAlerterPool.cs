using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAlerterPool : MonoBehaviour
{
    public GameObject battleAlerter;
    Queue<GameObject> battleAlerters = new Queue<GameObject>();

    public GameObject GetBattleAlerter()
    {
        if(battleAlerters.Count<5)
        {
            FillUpPool();
        }
        GameObject temp = battleAlerters.Dequeue();
        temp.SetActive(true);
        return temp;

    }


    public void AddBattleAlerterBackToPool(GameObject alerter)
    {
        alerter.transform.position = Vector3.zero;
        battleAlerters.Enqueue(alerter);
        alerter.SetActive(false);
    }
    public void FillUpPool()
    {
        for (int i = 0; i < 15; i++)
        {
            GameObject temp = Instantiate(battleAlerter, gameObject.transform);
            battleAlerters.Enqueue(temp);
            temp.SetActive(false);
        }
    }
}
