using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : StateMachineBehaviour
{
    [SerializeField] private string sceneName;
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SceneManager.LoadScene(sceneName);
    }
}
