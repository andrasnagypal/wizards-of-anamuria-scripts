using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCirclePool : MonoBehaviour
{
    public GameObject deathCircle;
    Queue<GameObject> deathCircleAlerters = new Queue<GameObject>();

    public GameObject GetDeathCircle()
    {
        if (deathCircleAlerters.Count < 5)
        {
            FillUpPool();
        }
        GameObject temp = deathCircleAlerters.Dequeue();
        temp.SetActive(true);
        return temp;

    }


    public void AddBattleDeathCircleBackToPool(GameObject alerter)
    {
        alerter.transform.position = Vector3.zero;
        deathCircleAlerters.Enqueue(alerter);
        alerter.SetActive(false);
    }
    public void FillUpPool()
    {
        for (int i = 0; i < 15; i++)
        {
            GameObject temp = Instantiate(deathCircle, gameObject.transform);
            deathCircleAlerters.Enqueue(temp);
            temp.SetActive(false);
        }
    }
}
