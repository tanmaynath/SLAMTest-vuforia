using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour {


	private float currAngle = 0.0f;
	private float desiredAngle = 0.0f;
	
	// Update is called once per frame
	void Update () {
		currAngle = Mathf.LerpAngle(currAngle, desiredAngle, Time.deltaTime * 3.0f);
		transform.localEulerAngles = new Vector3(0, 0, currAngle);
	}

	void OpenDoors()
	{
		if(gameObject.CompareTag("RightDoor"))
		{
			desiredAngle = 60.0f;
		}
		else 
		{
			desiredAngle = -60.0f;
		}
		GetComponent <AudioSource>().Play();

	}

	void CloseDoors()
	{
		desiredAngle = 0.0f;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("MainCamera"))
		{
			OpenDoors();

		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("MainCamera"))
		{
			CloseDoors();
		}
	}
}
