using UnityEngine;


// This script is responsible for following snake by camera (is not in use now)
public class FollowSnake : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public Transform snake;

    /// <summary>
    /// 
    /// </summary>
    public Vector3 offset;

    /// <summary>
    /// 
    /// </summary>
    private void Update()
    {
        transform.position = snake.position + offset;
    }
}
