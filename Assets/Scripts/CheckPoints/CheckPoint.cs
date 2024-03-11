using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
	private PlayPrewn player_Respawm;

	void Start()
	{
		player_Respawm = GameObject.Find("Player").GetComponent<PlayPrewn>();
	}

	// Update is called once per frame
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Player")
		{
			player_Respawm.respawnPoint = transform.position;
		}
	}
}
