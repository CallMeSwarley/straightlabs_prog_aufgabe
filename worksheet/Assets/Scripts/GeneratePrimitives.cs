using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePrimitives : MonoBehaviour
{
    public List<GameObject> landscapeObjects;
    public int numOfElements = 0;

    // TODO retreive min and max depending on min and max of the terrains in scene
    float minX = 0f;
    float minY = 0f;
    float minZ = 0f;
    float maxX = 500f;
    float maxZ = 500f;
    float maxY = 20f;
    // Start is called before the first frame update
    // get the min and max coordinates of our terrain
    void Start()
    {
        if (numOfElements < 100 || numOfElements > int.MaxValue / 2)
        {
            numOfElements = 100;
        }

        for (int i = 0; i <= numOfElements; i++)
        {
            GameObject selectedObject = landscapeObjects[Random.Range(0, landscapeObjects.Count)];
            float randomX = Random.Range(minX, maxX);
            float randomZ = Random.Range(minZ, maxZ);
            float randomY = Random.Range(minY, maxY);
            Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);

            GameObject go = Instantiate(selectedObject, randomPosition, Quaternion.identity);
            go.transform.parent = transform;
        }
        foreach (GameObject go in landscapeObjects)
        {
            Destroy(go);
        }
    }

}
