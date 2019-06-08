using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private int score = 0;

    /// <summary>
    /// 
    /// </summary>
    private bool gameHasEnded = false;

    /// <summary>
    /// 
    /// </summary>
    private static bool gameIsPaused = false;

    /// <summary>
    /// 
    /// </summary>
    public float restartDelay = 1f;

    /// <summary>
    /// 
    /// </summary>
    // Failed level screen (panel)...
    public GameObject failedLevelUi;
    //public GameObject completeLevelUI;

    /// <summary>
    /// 
    /// </summary>
    public GameObject pauseMenuUI;

    /// <summary>
    /// 
    /// </summary>
    public Text textComment;

    // New Level
    // when snake scores ex. 100 points level up... 
    /// <summary>
    /// 
    /// </summary>
    public void AddPointToScore()
    {
        score = score + 1;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string GetScore()
    {
        return score.ToString();
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void CompleteLevel()
    {
      //  completeLevelUI.SetActive(true);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="failedReason"></param>
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

    /// <summary>
    /// 
    /// </summary>
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

    /// <summary>
    /// 
    /// </summary>
    public void PauseGame()
    {
        // bring up pause menu 
        // freeze time in the game
        // change pausegame variable from false to true

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;    // freeze the game
        gameIsPaused = true;    // not needed?

    }

    /// <summary>
    /// 
    /// </summary>
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;    // unfreeze the game
        gameIsPaused = false;   // not needed?
    }

    /// <summary>
    /// 
    /// </summary>
    // restart when press btn 
    public void RestartGameEvent()
    {
        Invoke("RestartGame", restartDelay);
    }

    /// <summary>
    /// 
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// 
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene(0); // Load Menu 
    }
}
