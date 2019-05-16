using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        // get actual score (string)
        string score = FindObjectOfType<GameManager>().GetScore();

        scoreText.text = score;
    }


    // when snake scores ex. 100 points level up... 
}
