using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateFood : MonoBehaviour
{

    public GameObject food = null;

    // Start is called before the first frame update
    void Start()
    {
        // First food should appear randomly as well...
        Vector3 position = new Vector3(Random.Range(-9.0f, 9.0f), 1, Random.Range(1f, 19.0f));
        Instantiate(food, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Generate food ...
    public void GenerateFood()
    {
        Vector3 position = new Vector3(Random.Range(-9.0f, 9.0f), 1, Random.Range(1f, 19.0f));
        Instantiate(food, position, Quaternion.identity);
    }
}
