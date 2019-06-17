using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject controllsCanvas;
    public GameObject score;
    public static string KilledBy = "No information";

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
        CollectInformation();
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

    public void CollectInformation()
    {
        Analytics.CustomEvent("GameOver", new Dictionary<string, object>
        {
            { "score", Score.ScoreValue },
            { "fuel_level", Fuel.FuelLevel },
            { "bonuses_taken", Bonus.BonusCounter },
            { "killed_by", KilledBy }
        });
    }
}
