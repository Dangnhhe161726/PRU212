using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Player_Respawm player_Respawm;
    public GameObject greenFlag;
    public GameObject redFlag;

    void Start()
    {
        player_Respawm = GameObject.Find("Player").GetComponent<Player_Respawm>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player_Respawm.respawnPoint= transform.position;
            redFlag.SetActive(false);
            greenFlag.SetActive(true);
        }
    }
}
