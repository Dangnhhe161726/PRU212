using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Respawm : MonoBehaviour
{
    public Vector3 respawnPoint;
    private Player_Life healthScript;

    // Start is called before the first frame update
    private void Start()
    {
        healthScript = GetComponent<Player_Life>();
    }

    public void RespawnNow()
    {
        // ??t v? tr� respawn
        transform.position = respawnPoint;

        // Reset gi� tr? health
        healthScript.ResetHealth();
    }
}
