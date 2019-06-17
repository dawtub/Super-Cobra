using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour, IMenu
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuCanvas;

    Button pauseButton;

    // Start is called before the first frame update
    void Start()
    {
        pauseButton = GetComponent<Button>();
        if (pauseButton)
        {
            pauseButton.onClick.AddListener(Pause);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsPaused)
        {
            Pause();
        } else
        {
            Resume();
        }
    }

    public void Resume()
    { 
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Menu()
    {
        GameIsPaused = false;
        FindObjectOfType<GameManager>().Quit();
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        FindObjectOfType<GameManager>().CollectInformation();
        Application.Quit();
    }
}
