using UnityEngine;

public class EnemySwa : MonoBehaviour
{

    public GameObject enemyPrefab; // Reference to the enemy prefab
    public Transform spawnPoint1; // First spawn point
    public Transform spawnPoint2; // Second spawn point
    public Transform playerPosition;
    public float moveSpeed = 5f; // Speed at which the enemy moves
    public float spawnDistanceThreshold = 10f; // Distance threshold for spawning enemy

    private GameObject currentEnemy = null; // Reference to the spawned enemy
    float distanceToSpawnPoint1;
    float distanceToSpawnPoint2;
    float distanceBetweenSpawnPoints;

    void Start()
    {
        // Check if the player is positioned between the two spawn points
        CheckPlayerPosition();
    }

    void CheckPlayerPosition()
    {
        // Calculate the distance between the player and the two spawn points
        distanceToSpawnPoint1 = Vector2.Distance(playerPosition.transform.position, spawnPoint1.position);
        distanceToSpawnPoint2 = Vector2.Distance(playerPosition.transform.position, spawnPoint2.position);

        // Calculate the distance between the two spawn points
        distanceBetweenSpawnPoints = Vector2.Distance(spawnPoint1.position, spawnPoint2.position);

        // Check if the player is positioned closer to one of the spawn points than the distance between them
        if (distanceToSpawnPoint1 < distanceBetweenSpawnPoints && distanceToSpawnPoint2 < distanceBetweenSpawnPoints)
        {
            // Player is between the two spawn points, spawn the enemy
            if (currentEnemy == null)
            {
                SpawnEnemy();
            }
        }
        else
        {
            currentEnemy.GetComponent<TriggerMonster>().Destroy();
            currentEnemy = null;
        }

    }

    void SpawnEnemy()
    {
        // Calculate a random position between the two spawn points
        float randomX = Random.Range(spawnPoint1.position.x, spawnPoint2.position.x);
        Vector2 spawnPosition = new Vector2(randomX, transform.position.y); // Assuming enemies spawn at the same Y-coordinate as the spawner

        // Instantiate an enemy at the random position
        currentEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    void Update()
    {
        // If the enemy exists, move it back and forth between the two points, else check player position
        if (currentEnemy != null)
        {

            currentEnemy.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

            // Check if the enemy reaches the boundaries and change direction
            if (currentEnemy.transform.position.x >= spawnPoint2.position.x)
            {
                moveSpeed = -Mathf.Abs(moveSpeed); // Move left
            }
            else if (currentEnemy.transform.position.x <= spawnPoint1.position.x)
            {
                moveSpeed = Mathf.Abs(moveSpeed); // Move right
            }
        }

        CheckPlayerPosition();

    }


}
