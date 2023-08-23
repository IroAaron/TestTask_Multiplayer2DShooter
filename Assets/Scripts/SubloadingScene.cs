using UnityEngine;
using UnityEngine.SceneManagement;

public class SubloadingScene : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene("UIScene", LoadSceneMode.Additive);
    }
}
