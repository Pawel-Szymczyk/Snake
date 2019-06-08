using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Reference: https://www.youtube.com/watch?v=zc8ac_qUXQY

    /// <summary>
    /// 
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// 
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
