using UnityEngine;

public class SnakeCollision : MonoBehaviour
{

    public SnakeMovement snakeMovement;
    
    private void OnCollisionEnter(Collision collision)
    {
        
        // Eat food, when snake ate food it grows, 
        // new food is appearing in the random place (on the board) 
        if (collision.collider.tag == "Food")
        {

            Destroy(collision.collider.gameObject, 0.0f);


            // Add point...
            FindObjectOfType<GameManager>().AddPointToScore();

            // Call GenerateFood method that will add food to the scene...
            // Find empty object "FoodObject" that contains function that will add a food to the scene... ?
            FindObjectOfType<InstantiateFood>().GenerateFood();

            // Attach new segment to the snake 
            FindObjectOfType<SnakeMovement>().AddBodyPart();

        }

        if (collision.collider.tag == "SnakeBody")
        {
            FindObjectOfType<GameManager>().FailedLevel("Stop eating yourself!");
        }


    }






}
