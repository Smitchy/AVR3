using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturablesSpawn : MonoBehaviour
{
    
    public float spawningInterval;
    public float spawningRadius;

    private int numberSpawned;
    private Vector3 spawnPosition;
    private Vector3 cameraPos;

    public GameObject[] capturables;

    void Start ()
    {
        numberSpawned = 0;
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
       
        StartCoroutine(SpawningRoutine());
    }
	

    void ChooseSpawnPosition()
    {
        spawnPosition = cameraPos + new Vector3(Random.Range(-spawningRadius, spawningRadius), Random.Range(-spawningRadius, spawningRadius), Random.Range(-spawningRadius, spawningRadius));
    }

    IEnumerator SpawningRoutine()
    {
        while (true)
        {
            ChooseSpawnPosition();
            Instantiate(capturables[Random.Range(0, 5)], spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawningInterval - numberSpawned/5.0f);
        }
    }
}
