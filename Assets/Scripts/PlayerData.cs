using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public int score;
    public string name;

    public PlayerData (GameManager gameManager)
    {
        score = gameManager.score;
        name = gameManager.username;
    }

}
