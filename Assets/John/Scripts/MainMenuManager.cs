using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
  
    public void OnClickPlay()
    {
        SceneManager.LoadScene("Main Scene");

    }




    public void OnClickCredit()
    {
        SceneManager.LoadScene("Credit Scene");
    }

  

}
