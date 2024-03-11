using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb2D;
    private Player_Respawm respawnScript;
    [SerializeField] private AudioSource dieSourceEffect;
    public int health = 3;
    private Player_Respawm player_Respawm;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        respawnScript = GetComponent<Player_Respawm>();

    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Trap"))
    //    {
    //        dieSourceEffect.Play();

    //        //Die();

    //        respawnScript.RespawnNow();

    //    }
    //}
    //private void Die()
    //{
    //    rb2D.bodyType = RigidbodyType2D.Static;
    //    animator.SetTrigger("death");

    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Trap"))
        {

            health -= 1;
            animator.SetTrigger("hurt");
            if (health <= 0)
            {
                
                player_Respawm = GameObject.Find("Player").GetComponent<Player_Respawm>();
                player_Respawm.RespawnNow();
                dieSourceEffect.Play();
            }
        }

    }
    public void ResetHealth()
    {
        health = 3;
    }
    private void RestartLevel()
    {   
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
        
    }

}
