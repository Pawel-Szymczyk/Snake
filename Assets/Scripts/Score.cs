using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public Transform player;

    /// <summary>
    /// 
    /// </summary>
    public Text scoreText;

    /// <summary>
    /// 
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        // get actual score (string)
        string score = FindObjectOfType<GameManager>().GetScore();

        scoreText.text = score;
    }


    // when snake scores ex. 100 points level up... 
}
