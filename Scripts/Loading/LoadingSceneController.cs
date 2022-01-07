using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneController : MonoBehaviour
{
    public GameObject loadingPanel,loadingBar;
    public Image fillArea;
    public float amountToFillPerTick=.1f;
    float fillAmount = 0;
    
    


    public async void StartLoading()
    {
        for (int i = 0; i < 10; i++)
        {
            await Task.Delay(1000);
            IncreaseLoadingBar();
        }
        await Task.Delay(1000);
        loadingBar.SetActive(false);
        DeletePanel();
    }
    public void IncreaseLoadingBar()
    {
        fillAmount += amountToFillPerTick;
        
        fillArea.fillAmount = fillAmount;
    }
    

   public void DeletePanel()
    {
        Image temp = loadingPanel.GetComponent<Image>();
        for (int i = 1000; i >0; i--)
        {
            temp.material.color= new Color(0, 0, 0, i / 1000);

        }
        Destroy(loadingPanel);
        Destroy(gameObject);
    }


    
}
