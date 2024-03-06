using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private AudioSource dieSourceEffect;

    private int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Debug.Log(lives);
            LoseLife();
        }
    }

    private void LoseLife()
    {
        lives--;
        dieSourceEffect.Play();
        if (lives <= 0)
        {
            Die();
        }
        if (lives > 0)
        {
            StartCoroutine(BlinkEffect());
        }
    }
    private void Die()
    {
        rb2D.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
        Invoke("RestartLevel", 4f);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator BlinkEffect()
    {

        for (int i = 0; i < 5; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            Debug.Log("đã chạm");
            Debug.Log(spriteRenderer.enabled);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
            Debug.Log("đã chạm 1");
            Debug.Log(spriteRenderer.enabled);
        }
    }
}
