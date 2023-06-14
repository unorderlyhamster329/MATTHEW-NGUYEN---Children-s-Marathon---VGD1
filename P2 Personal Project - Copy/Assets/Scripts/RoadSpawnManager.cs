using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects = new GameObject[0];
    [SerializeField] private Vector3 spawnLocation = new Vector3();
    [SerializeField] private Vector3 spawnRange = new Vector3();

    [SerializeField] private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        //Repeatedly spawn roads at set interval
        InvokeRepeating("SpawnRandomRoad", 0, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) {
            SpawnRandomRoad();
        }
    }

    void SpawnRandomRoad() {
        //spawn road
        int idx = Random.Range(0, gameObjects.Length);

        if (gameObjects[idx] != null) {
            Vector3 spawnPos = spawnLocation + new Vector3(
                Random.Range(-Mathf.Abs(spawnRange.x), Mathf.Abs(spawnRange.x)),
                Random.Range(-Mathf.Abs(spawnRange.y), Mathf.Abs(spawnRange.y)),
                Random.Range(-Mathf.Abs(spawnRange.z), Mathf.Abs(spawnRange.z))
            );
            Instantiate(gameObjects[idx], spawnPos, gameObjects[idx].transform.rotation);
        }
    }
}