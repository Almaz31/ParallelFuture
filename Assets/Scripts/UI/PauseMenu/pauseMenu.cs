
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuPanel;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenuActive();
        }
 
    }


    public void PauseMenuActive()
    {
        pauseMenuPanel.SetActive(true);

        Time.timeScale = 0.0f;
    }
    public void PauseMenuFalse()
    {
        Time.timeScale = 1.0f;
        pauseMenuPanel.SetActive(false);
    }
    public void MainMenu()
    {
        int sceneIndex = 0;
        SceneManager.LoadScene(sceneIndex);
    }


}
