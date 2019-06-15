using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject controllsCanvas;
    public GameObject score;

    bool gameHasEnded = false;

    void Start()
    {
        hideFinished();
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            showFinished();
        }
    }

    public void Resume()
    {
        Fuel.ResetFuelLevel();
        gameObject.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Fuel.ResetFuelLevel();
        Score.ScoreValue = 0;
        Destroy(gameObject);
    }

    private void hideFinished()
    {
        gameOverCanvas.SetActive(false);
    }

    private void showFinished()
    {
        controllsCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
    }
}
