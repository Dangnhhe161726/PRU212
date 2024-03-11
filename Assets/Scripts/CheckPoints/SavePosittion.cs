using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePosittion : MonoBehaviour
{
	private void Start()
	{
		transform.position = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));
	}

	// Update is called once per frame
	void Update()
	{
		PlayerPrefs.SetFloat("x", transform.position.x);
		PlayerPrefs.SetFloat("y", transform.position.y);
		PlayerPrefs.SetFloat("z", transform.position.z);
	}
}
