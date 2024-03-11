using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPrewn : MonoBehaviour
{
	public Vector3 respawnPoint;
	private PlayerLife healthScript;

	// Start is called before the first frame update
	private void Start()
	{
		healthScript = GetComponent<PlayerLife>();
	}

	public void RespawnNow()
	{
		transform.position = respawnPoint;
		healthScript.ResetHealth();
	}
}
