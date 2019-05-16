using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateFood : MonoBehaviour
{

    public GameObject food = null;
    public float foodPosX = 9.0f;
    public float foodPosZ = 19.0f;

    // Start is called before the first frame update
    void Start()
    {
        // First food should appear randomly as well...
        Vector3 position = new Vector3(Random.Range(-foodPosX, foodPosX), 1, Random.Range(1f, foodPosZ));
        Instantiate(food, position, Quaternion.identity);
    }

    // Generate food ...
    public void GenerateFood()
    {
        Vector3 position = new Vector3(Random.Range(-foodPosX, foodPosX), 1, Random.Range(1f, foodPosZ));
        Instantiate(food, position, Quaternion.identity);
    }
}
