using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
            //lam thay doi chieu 
            Vector2 direction = waypoints[currentWaypointIndex].transform.position - transform.position;
            Vector3 direction1 = waypoints[currentWaypointIndex].transform.position - transform.position;

            // Update the flipX property based on the direction
            if (direction.x > 0f)
            {
                spriteRenderer.flipX = true;
            }
            else if (direction.x < 0f)
            {
                spriteRenderer.flipX = false;
            }
        }


        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
