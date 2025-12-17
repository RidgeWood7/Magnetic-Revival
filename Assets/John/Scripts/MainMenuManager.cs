using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
  
    public void OnClickPlay()
    {
        SceneManager.LoadScene("Main Level");

    }




    public void OnClickQuit()
    {
        SceneManager.LoadScene("Title Screen");
    }

  

}
