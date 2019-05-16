using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene(0); // Load Menu 
    }

    public void Quit()
    {
        Application.Quit();
    }
}
