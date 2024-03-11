using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesFlow_and_Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float lineOfsite;
    public float shootOfsite;
    public float fireRate =1f;
    private float nextFireTime;
    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfsite && distanceFromPlayer>shootOfsite) {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);

        }else if (distanceFromPlayer <= shootOfsite && nextFireTime<Time.time)
        {
            Instantiate(bullet,bulletParent.transform.position,Quaternion.identity);
            nextFireTime = Time.time+ fireRate;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfsite);
        Gizmos.DrawWireSphere(transform.position, shootOfsite);
    }
}
