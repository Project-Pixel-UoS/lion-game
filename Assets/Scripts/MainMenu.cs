using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OpenCharacterIndex()
    {
        SceneManager.LoadScene("CharacterIndex");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
