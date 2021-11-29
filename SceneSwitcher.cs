using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour //Local scene switching script. 
    //The LoadSceneAsync function permits the unity engine to continue running whilst loading a scene. This allows the use of a loading screen
{
    public GameObject terrain;
    public void level1() { //load the first level
        SceneManager.LoadSceneAsync("Level 1(AKA Demo) 1");
    }

    public void level2() // load the level 2 scene
    {
        SceneManager.LoadSceneAsync("Level 2");
    }
    public void level3() // load the level 2 scene
    {
        SceneManager.LoadSceneAsync("Level 3");
    }

    public void Stadium() //load the stadium project scene
    {
        SceneManager.LoadSceneAsync("Stadium");
    }

    public void tutorial()
    { //go to the tutorial scene
        SceneManager.LoadSceneAsync("Tutorial");
    }

    public void back() { //go back to the main menu scene
        
        SceneManager.LoadSceneAsync("Menu");
    }
    public void Quit() //quot the application
    {
        Application.Quit();
    }
}
