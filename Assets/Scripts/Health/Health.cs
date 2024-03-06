using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    private Animator anim;

    private bool dead;
    private void Awake()
    {
        currentHealth = startingHealth;
        anim= GetComponent<Animator>();
    }


    public void TakeDamge(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth >0) 
        {
            anim.SetTrigger("hurt");
        }
        else
        {   if(!dead) 
            {
                anim.SetTrigger("death");
                GetComponent<Player>().enabled = false;
                dead = true;
            }
            
        }
    }
}
// Start is called before the first frame update


    


