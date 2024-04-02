using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScripts : MonoBehaviour
{

    [SerializeField] GameObject panelAboutUs;




    public void ButtonStartGame()
    {
        int mainScene = 1;
        Time.timeScale = 1;
        SceneManager.LoadScene(mainScene);
    }
    public void AboutUsClick()
    {
        panelAboutUs.SetActive(true);

        
    }
    public void AboutUsBackButton()
    {
        panelAboutUs.SetActive(false);
    }

}
