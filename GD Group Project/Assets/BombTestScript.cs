using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class BombTestScript : MonoBehaviour
{
    BombScript myBomb;
    public Transform BombTemplate;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
          Transform newBomb =  Instantiate(BombTemplate);
          myBomb =  newBomb.GetComponent<BombScript>();
            NetworkObject nn = newBomb.GetComponent<NetworkObject>();

            nn.Spawn();
        
            myBomb.transform.position =
                new Vector3(Random.Range(-10f, 10f), 1f, Random.Range(-10f, 10f));


        }

 


    }
}
