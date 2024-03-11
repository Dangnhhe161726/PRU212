//using JetBrains.Annotations;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class HealthTest : MonoBehaviour
//{
//    public int health = 3;
//    private Player_Respawm player_Respawm;
//    private Animator animator;
//    private Rigidbody2D rb2D;
//    [SerializeField] private AudioSource dieSourceEffect;
//    // Start is called before the first frame update
//    private void Start()
//    {
        
//        animator = GetComponent<Animator>();
//    }
//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.tag == ("Trap"))
//        {
            
//            health -= 1;
//            animator.SetTrigger("hurt");
//            if (health <= 0)
//            {
//                dieSourceEffect.Play();
//                player_Respawm = GameObject.Find("Player").GetComponent<Player_Respawm>();
//                player_Respawm.RespawnNow();

//            }
//        }
//    }
//    public void ResetHealth()
//    {
//        health = 3;
//    }

//}
