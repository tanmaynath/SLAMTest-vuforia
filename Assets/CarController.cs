using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

	private bool soundFlag = false;
	
	// Update is called once per frame
	void Update () {

		print("Flag: " + !soundFlag + " local Position: " + transform.localPosition.y);
		if(!soundFlag && transform.localPosition.y < 0.05f)
		{
			soundFlag = true;
			StartCoroutine(DelayedSoundPlay ());
			Debug.Log("Started Coroutine");

		}
	}

	public void MoveCar()
	{
		Debug.Log("move car called");
		transform.localPosition += new Vector3 (0, 10.0f, 0);
		transform.eulerAngles = new Vector3 (5, 20, 5);
		soundFlag = false;
	}

	IEnumerator DelayedSoundPlay ()
	{
		Debug.Log("in coroutine");
		yield return new WaitForSeconds(0.2f);
		GetComponent <AudioSource>().Play();
		Debug.Log("sound played!");
	}
}
