using UnityEngine;
using System.Collections.Generic;

public class SnakeMovement : MonoBehaviour
{
   
    public Joystick joystick;
    public GameObject bodyPrefab;
    public Transform curBodyPart;
    public Transform prevBodyPart;
    public List<Transform> BodyParts = new List<Transform>();

    public int beginSize;

    public float dis;
    public float mindistance = 0.25f;
    public float moveSpeed = 1f;
    public float rotationSpeed = 50f;


    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        float moveXAxis = (joystick.Horizontal * moveSpeed) * Time.smoothDeltaTime;
        float moveZAxis = (joystick.Vertical * moveSpeed) * Time.smoothDeltaTime;

        // head movement
        BodyParts[0].Translate(moveXAxis, 0f, moveZAxis, Space.World);
        
        if(Input.GetAxis("Horizontal") != 0)
        {
            BodyParts[0].Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
        }

        // Responsible for positition and rotation actualtization.
        for (int i = 1; i < BodyParts.Count; i++ )
        {
            curBodyPart = BodyParts[i];
            prevBodyPart = BodyParts[i - 1];

            dis = Vector3.Distance(prevBodyPart.position, curBodyPart.position);

            Vector3 newPos = prevBodyPart.position;
            newPos.y = BodyParts[0].position.y;

            float T = Time.deltaTime * dis / mindistance * moveSpeed;

            if(T > 0.5f)
            {
                T = 0.5f;
            }

            curBodyPart.position = Vector3.Slerp(curBodyPart.position, newPos, T);
            curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, prevBodyPart.rotation, T);
        }

        // If snake go off the platform - die
        if (BodyParts[0].position.y < -1f)
        {
            FindObjectOfType<GameManager>().FailedLevel("Stop jumping off the cliff!");
        }

    }

    public void AddBodyPart()
    {
        Transform newPart = (Instantiate(bodyPrefab, BodyParts[BodyParts.Count - 1].position, BodyParts[BodyParts.Count - 1].rotation) as GameObject).transform;

        newPart.SetParent(transform);
        

        // First element will always touch the snake head that is why it should not be check for collision and the tag should not be attached
        if (BodyParts.Count > 1)
        {
            newPart.tag = "SnakeBody";
        }

        BodyParts.Add(newPart);
    }

}
