using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpBarController : MonoBehaviour
{
    public GameObject parentForPopUps;


    public void AddPopUpToParent(GameObject popUp)
    {
        popUp.transform.SetParent(parentForPopUps.transform);
    }
}
