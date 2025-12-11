using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseScreen;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))

            if (isPaused)
            {
                ResumeGame();
                
            }
            else
            {
                PauseGame();
                EventSystem.current.SetSelectedGameObject(null);
            }
    }

    void PauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    void ResumeGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void LoadMenu()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene("John Testing");
    }

    public void Resume()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
