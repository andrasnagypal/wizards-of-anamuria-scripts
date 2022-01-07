using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterSelectionManager : MonoBehaviour
{
    
    public void AddPortraitToPanel(GameObject portrait)
    {
        portrait.transform.SetParent(gameObject.transform);
    }
}
