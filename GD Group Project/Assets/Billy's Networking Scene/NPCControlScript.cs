using System;
using System.Collections;
using UnityEngine;
using Unity.Netcode;

[RequireComponent(typeof(CharacterController))]
public class NPCControlScript : NetworkBehaviour,Health
{
	public float speed = 2;
	public float directionChangeInterval = 1;
	public float maxHeadingChange = 90;

	CharacterController controller;
	float heading;
	Vector3 targetRotation;

	void Awake()
	{
		controller = GetComponent<CharacterController>();

		// Set random initial rotation
		heading = UnityEngine.Random.Range(0, 360);
		transform.eulerAngles = new Vector3(0, heading, 0);

		StartCoroutine(NewHeading());
	}

	void Update()
	{
		transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
		var forward = transform.TransformDirection(Vector3.forward);
		controller.SimpleMove(forward * speed);
	}

	// Repeatedly calculates a new direction to move towards.
	// Use this instead of MonoBehaviour.InvokeRepeating so that the interval can be changed at runtime.
	IEnumerator NewHeading()
	{
		while (true)
		{
			NewHeadingRoutine();
			yield return new WaitForSeconds(directionChangeInterval);
		}
	}
	
	// Calculates a new direction to move towards.
	void NewHeadingRoutine()
	{
		var min = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
		var max = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
		heading = UnityEngine.Random.Range(min, max);
		targetRotation = new Vector3(0, heading, 0);
	}

    public void Take_Damage(float damage)
    {
        throw new NotImplementedException();
    }
}