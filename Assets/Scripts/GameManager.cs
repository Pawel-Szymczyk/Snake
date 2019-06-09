using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.ObjectModel;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Initial player score.
    /// </summary>
    public int score = 0;

    /// <summary>
    /// Player name set in the options panel.
    /// </summary>
    public InputField playerName;

    public string username;

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

    public Collection<PlayerData> list = new Collection<PlayerData>();

    /// <summary>
    /// 
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;    // unfreeze the game
    }

    /// <summary>
    /// 
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }


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


    public void StorePlayerUsername()
    {
        PlayerPrefs.SetString("username", this.playerName.text);
        //string finalScore = GetScore();
        //string playerName = this.playerName.text;
    }


    /// <summary>
    /// 
    /// </summary>
    public void FailedLevel(string failedReason)
    {

        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            
            GameObject.Find("PauseButton").SetActive(false);


            failedLevelUi.SetActive(true);

            //this.failureComment.GetComponent<Text>().text = failedReason;
            //this.failureComment = GameObject.Find("Comment");


            // Get username from local memory and  Save username and score to file
            this.username = PlayerPrefs.GetString("username");
            SaveSystem.SavePlayer(this);

            

            Debug.Log("GAME OVER");

            
        }
    }

    /// <summary>
    /// Get the list of score and return it to collection used in ui table.
    /// </summary>
    public void LoadScoreTable()
    {
        Collection<PlayerData> data = SaveSystem.LoadPlayer();

        list = data;

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
        //var btn = GameObject.FindGameObjectsWithTag("PauseButton");

        //btn.SetActive(true);
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
