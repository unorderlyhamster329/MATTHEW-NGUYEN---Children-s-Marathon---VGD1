using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Vector3 spawnPosition = new Vector3(0, 0, 0);
    [SerializeField] private float spawnDelayMin = 0;
    [SerializeField] private float spawnDelayMax = 0;

    private PlayerController playerController;

    void Start()
    {
        //Keep spawning buildings when game starts
        SpawnObstacle();
    }

    void SpawnObstacle() {
            //Spawn buildings
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
            Invoke("SpawnObstacle", Random.Range(spawnDelayMin, spawnDelayMax));
        
    }
}