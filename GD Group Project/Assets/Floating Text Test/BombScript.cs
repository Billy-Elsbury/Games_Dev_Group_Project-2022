using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    Vector3 Velocity, Acceleration;
    // Start is called before the first frame update
    void Start()
    {
        Acceleration = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Velocity += Acceleration * Time.deltaTime;
        transform.position += Velocity * Time.deltaTime;
    }

    public void BombThrow(Vector3 Dir, float Speed)
    {
        Velocity = (Dir + Vector3.up) * Speed;
        Acceleration = new Vector3(0, -9.8f, 0);

    }
}
