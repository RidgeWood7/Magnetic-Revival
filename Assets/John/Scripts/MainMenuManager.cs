using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject OptionsMenu;

    public GameObject PauseMenu;

    public void OnClickPlay()
    {
        SceneManager.LoadScene("MainLevel");

    }




    public void OnClickQuit()
    {
        SceneManager.LoadScene("John Testing");
    }

    public void OnClickPause()
    {
        PauseMenu.SetActive(true);
    }


}
