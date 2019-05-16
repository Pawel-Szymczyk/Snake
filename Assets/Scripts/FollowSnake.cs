using UnityEngine;


// This script is responsible for following snake by camera (is not in use now)
public class FollowSnake : MonoBehaviour
{
    public Transform snake;
    public Vector3 offset;

    private void Update()
    {
        transform.position = snake.position + offset;
    }
}
