using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.Burst.Intrinsics.X86.Avx;

public class PlayerLife : MonoBehaviour
{
	private Animator animator;
	private Rigidbody2D rb2D;
	private PlayPrewn respawnScript;
	[SerializeField] private AudioSource dieSourceEffect;
	[SerializeField] private int health = 3;
	private PlayPrewn player_Respawm;

	// Start is called before the first frame update
	void Start()
	{
		animator = GetComponent<Animator>();
		rb2D = GetComponent<Rigidbody2D>();
		respawnScript = GetComponent<PlayPrewn>();

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
				player_Respawm = GameObject.Find("Player").GetComponent<PlayPrewn>();
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
