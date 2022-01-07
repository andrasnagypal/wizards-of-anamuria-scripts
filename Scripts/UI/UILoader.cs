using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;



public class UILoader : MonoBehaviour
{
    [SerializeField] GameObject UICanvas;
    [SerializeField] int sceneIndexStart, sceneIndexLast;
    [SerializeField] UIManager uimanager;


   
    

    public async Task<Task> StartLoading()
    {
        for (int index = sceneIndexStart; index < sceneIndexLast + 1; index++)
        {
            LoadUILayoutByIndex(index);
            await Task.Delay(10);
        }
        return Task.CompletedTask;
    }



    void LoadUILayoutByIndex(int index)
    {
        if (SceneManager.GetSceneByBuildIndex(index).isLoaded == false)
        {
            SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
        }
        else
            SceneManager.UnloadSceneAsync(index);

        
    }

    void LoadUILayout(string layoutname)
    {
        if (SceneManager.GetSceneByName(layoutname).isLoaded == false)
        {
            SceneManager.LoadSceneAsync(layoutname, LoadSceneMode.Additive);
        }
        else
            SceneManager.UnloadSceneAsync(layoutname);
    }
    public void BackToMainMenu()
    {
        for (int index = sceneIndexStart; index < sceneIndexLast + 1; index++)
        {
            SceneManager.UnloadSceneAsync(index);
           
        }
        
        SceneManager.LoadScene(0);
    }






}
