using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField] private Object sceneToLoad;
    public void CloseSettings()
    {
        SceneManager.LoadScene(sceneToLoad.name);
    }
}
