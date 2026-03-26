using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SoundSystem.Instance.PlaySfx(SfxType.Test);
        SceneManager.LoadScene("LevelSelect");
    }

    public void OpenCharacterIndex()
    {
        SceneManager.LoadScene("CharacterIndex");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void OpenShop()
    {
        SceneManager.LoadScene("LionShop");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
