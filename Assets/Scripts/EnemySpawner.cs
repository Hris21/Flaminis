using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    private GameObject[] spawnPoints;
    public GameObject enemy;
    // Use this for initialization
    void Start () {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        InvokeRepeating("Spawn", 5, 5);

    }
    private void Spawn()
    {
        Debug.Log("Spawned enemy");
        int spawnPointIndex = UnityEngine.Random.Range(0, spawnPoints.Length);

        var newEnemy = Enemy.CreateInstance(typeof(Enemy));
        Enemy.Instantiate(enemy, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.rotation);
    }
}
