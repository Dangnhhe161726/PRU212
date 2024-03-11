using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int numberToSpam;
    [SerializeField] private List<GameObject> spamPool;
    [SerializeField] private GameObject quad;

    // Start is called before the first frame update
    void Start()
    {
        spawnObjects();
    }

    public void spawnObjects()
    {
        int randomItem = 0;
        GameObject toSpawn;
        MeshCollider meshCollider = quad.GetComponent<MeshCollider>();

        float screenX, screenY;
        Vector2 pos;

        for (int i = 0; i < numberToSpam; i++)
        {
            randomItem = Random.RandomRange(0, spamPool.Count);
            toSpawn = spamPool[randomItem];

            screenX = Random.RandomRange(meshCollider.bounds.min.x, meshCollider.bounds.max.x);
            screenY = Random.RandomRange(meshCollider.bounds.min.y, meshCollider.bounds.max.y);
            Debug.Log(meshCollider.bounds.min.x + "," + meshCollider.bounds.max.x + "," + meshCollider.bounds.min.y + "," + meshCollider.bounds.max.y);
            Debug.Log(screenX + "," + screenY);
            pos = new Vector2(screenX, screenY);

            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        }
    }

    private void destroyObjects()
    {
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag(""))
        {
            Destroy(obj);
        }
    }

}
