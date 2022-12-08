using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PickUP : NetworkBehaviour
{

    internal enum PickUpItemStates { Waiting, Held, Thrown, Landed, DoYourThing }
    internal PickUpItemStates currentState = PickUpItemStates.Waiting;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    internal void latestOwner(JoeControlScript joe)
    {
        currentState = PickUpItemStates.Held;

        if (this.GetComponent<NetworkObject>().TrySetParent(joe.myRightHand, false))
        {

            //  transform.parent = joe.myRightHand;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
        else
            print("Could not set parent");
    }
}
