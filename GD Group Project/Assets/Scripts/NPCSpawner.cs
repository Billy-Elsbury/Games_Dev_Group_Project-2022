using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public Transform spawnPoint;

    public GameObject prefabToSpawn;

    GameObject newObject;

    // Start is called before the first frame update
    void Start()
    {   for (int i = 0; i < 5; i++)
        {
            newObject = Instantiate<GameObject>(prefabToSpawn, spawnPoint.position, Quaternion.identity);
        
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
