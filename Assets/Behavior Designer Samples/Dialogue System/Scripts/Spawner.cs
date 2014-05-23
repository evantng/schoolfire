using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public float spawnTime = 5f;		// The amount of time between each spawn.
    public float spawnDelay = 3f;		// The amount of time before spawning starts.
    public GameObject[] enemies;		// Array of enemy prefabs.

    private GameObject enemyInstantiated; // instantiated enemy


    void Start()
    {
        // Start calling the Spawn function repeatedly after a delay .
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }


    void Spawn()
    {
        if (enemyInstantiated == null) {
            // Instantiate a random enemy if there are no enemies instantiated already
            int enemyIndex = Random.Range(0, enemies.Length);
            enemyInstantiated = Instantiate(enemies[enemyIndex], transform.position, transform.rotation) as GameObject;
            Vector3 scale = enemyInstantiated.transform.localScale;
            scale.x *= -1;
            enemyInstantiated.transform.localScale = scale;
        }
    }
}
