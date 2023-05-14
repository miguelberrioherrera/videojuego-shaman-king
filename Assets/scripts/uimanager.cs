using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uimanager : MonoBehaviour
{

    public GameObject panelOption;
    

    public void PanelOption()
    {

        Time.timeScale = 0;
        panelOption.SetActive(true);

    }

    public void Return()
    {

        Time.timeScale = 1;
        panelOption.SetActive(false);

    }

    public void AnotherOptions()
    {
        //sound
        //graphics
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("nivel5");
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
