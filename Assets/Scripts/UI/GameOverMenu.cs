using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour, IMenu
{
    public void Resume()
    {
        // here starts Unity Monetization
    }

    public void Menu()
    {

    }

    public void Quit()
    {
        FindObjectOfType<GameManager>().Quit();
        SceneManager.LoadScene(0);
    }
}
