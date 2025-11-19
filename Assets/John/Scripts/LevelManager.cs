using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

    public void LoadJohnBeta()
    {
        SceneManager.LoadScene("John Beta");
    }
}
