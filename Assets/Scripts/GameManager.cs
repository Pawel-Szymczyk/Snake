using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private int score = 0;
    private bool gameHasEnded = false;
    private static bool gameIsPaused = false;

    public float restartDelay = 1f;

    // Failed level screen (panel)...
    public GameObject failedLevelUi;
    //public GameObject completeLevelUI;

    public GameObject pauseMenuUI;


    public Text textComment;

    // New Level
    // when snake scores ex. 100 points level up... 

    public void AddPointToScore()
    {
        score = score + 1;
    }

    public string GetScore()
    {
        return score.ToString();
    }
    
    public void CompleteLevel()
    {
      //  completeLevelUI.SetActive(true);
    }

    public void FailedLevel(string failedReason)
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            failedLevelUi.SetActive(true);

            this.textComment.text = failedReason;

            Debug.Log("GAME OVER");
        }
    }

    public void EndGame()
    {
        //if (gameHasEnded == false)
        //{
        //    gameHasEnded = true;
        //    Debug.Log("GAME OVER");


        //    // show failed level message...
        //    //Invoke("Restart", restartDelay);
        //}
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  // This code will load next level (change this to the last scence index number);

        
    }


    public void PauseGame()
    {
        // bring up pause menu 
        // freeze time in the game
        // change pausegame variable from false to true

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;    // freeze the game
        gameIsPaused = true;    // not needed?

    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;    // unfreeze the game
        gameIsPaused = false;   // not needed?
    }


    // restart when press btn 
    public void RestartGameEvent()
    {
        Invoke("RestartGame", restartDelay);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void MainMenu()
    {
        SceneManager.LoadScene(0); // Load Menu 
    }
}
